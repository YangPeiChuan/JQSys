using JiuQinSys.Modle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiuQinSys
{
    public partial class ProductEdit : CustForm
    {
        JiuQinEntities db = new JiuQinEntities();
        Modle.Product p = new Modle.Product() { stock = -1 };
        public Modle.Product ProductObject { get { return p; } }
        Modle.Product existProduct = null;
        bool isNewProduct = false;
        bool isEditID { get; set; }
        string productIDFlag { get; set; }
        short productStokeFlag { get; set; }
        public ProductEdit(string PruductID)
        {
            InitializeComponent();
            isNewProduct = string.IsNullOrEmpty(PruductID);

            if (!isNewProduct)
            {
                existProduct = db.Product.First(a => a.id == PruductID);
                p.brand = existProduct.brand;
                p.buyday = existProduct.buyday;
                p.buypoint = existProduct.buypoint;
                p.descript = existProduct.descript;
                p.id = existProduct.id;
                p.inventory = existProduct.inventory;
                p.name = existProduct.name;
                p.price = existProduct.price;
                p.type = existProduct.type;
                p.unit = existProduct.unit;
                p.stock = existProduct.stock;

                productIDFlag = p.id.Trim();
            }
            productStokeFlag = isNewProduct ? (short)-1 : p.stock;

            tbID.DataBindings.Add("Text", p, "id");
            tbName.DataBindings.Add("Text", p, "name");
            tbBrand.DataBindings.Add("Text", p, "brand");
            tbType.DataBindings.Add("Text", p, "type");
            tbUnit.DataBindings.Add("Text", p, "unit");
            tbPrice.DataBindings.Add("Text", p, "price", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            tbDescript.DataBindings.Add("Text", p, "descript");
            tbStock.DataBindings.Add("Text", p, "stock", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            if (p.unit == null || string.IsNullOrEmpty(p.unit.Trim()))
            {
                tbUnit.ForeColor = SystemColors.GrayText;
                p.unit = "單位";
            }
            else
                tbUnit.ForeColor = SystemColors.WindowText;

            checkRequiredAttributes(null, null);
            isEditID = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            p.unit = p.unit.Equals("單位") ? "" : p.unit; //若單位為浮水印的值("單位")則設為空值("")

            if (isNewProduct || !productIDFlag.Equals(p.id.Trim()))
            {
                if (!checkIdConflict())
                    return;
                JiuQinHelper.pidac.Add(p.id);
                JiuQinHelper.pname.Add(p.name + ";" + p.id);
            }

            if (!isNewProduct)
            {
                if (productIDFlag.Equals(p.id.Trim()))
                {
                    existProduct.name = p.name;
                    existProduct.brand = p.brand;
                    existProduct.type = p.type;
                    existProduct.unit = p.unit;
                    existProduct.price = p.price;
                    existProduct.descript = p.descript;
                    existProduct.stock = p.stock;
                }
                else
                {
                    db.Product.Remove(existProduct);
                }
            }

            if (!p.stock.Equals(productStokeFlag))
            {
                string message = string.Format(@"庫存數量已直接修改，確定將庫存自""{0}""更改至""{1}""?", productStokeFlag, p.stock);
                if (MessageBox.Show(message, "修改庫存確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    db.StockChangeLog.Add(new StockChangeLog()
                        {
                            time = DateTime.Now,
                            countAfterEdit = p.stock,
                            countBeforeEdit = productStokeFlag,
                            descript = "",
                            productID = p.id,
                            userID = JiuQinHelper.User.Seq
                        });
                }
                else return;
            }

            db.SaveChanges();
            if (Owner != null)
            {
                Task.Factory.StartNew((Owner as ProductLoad).InitProductList);
                ((Owner as ProductLoad).Controls.Find("dataGridView1", true).First() as DataGridView).Refresh();
            }
            MessageBox.Show(string.Format("編號 {0} ： {1} 已儲存成功", p.id.Trim(), p.name.Trim()));
        }

        /// <summary>
        /// 確認是否和現有產品的ID衝突
        /// </summary>
        bool checkIdConflict()
        {
            var product = db.Product.FirstOrDefault(a => a.id == p.id);
            if (product != null)
            {
                var message = string.Format(@"編號「{0}」已存在，請確認此編號現有產品內容，並決定是否覆蓋
品名：{1}    類別編號：{3}
品牌：{2}    建議售價：{5}
             庫　　存：{7} {4}
備註：{6}"
, product.id, product.name, product.brand, product.type, product.unit, product.price, product.descript, p.stock);
                var resule = MessageBox.Show(message, "確認", MessageBoxButtons.YesNo);
                if (resule == System.Windows.Forms.DialogResult.Yes)
                {
                    product.name = p.name;
                    product.brand = p.brand;
                    product.type = p.type;
                    product.unit = p.unit;
                    product.price = p.price;
                    product.descript = p.descript;
                    product.stock = p.stock;
                }
                else return false;
            }
            else db.Product.Add(p);
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (p.stock == -1)
            {
                DialogResult dr = MessageBox.Show("庫存量未設定，確定關閉？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes) Close();
            }
            else Close();
        }

        private void checkRequiredAttributes(object sender, EventArgs e)
        {
            btnSave.Enabled = !(string.IsNullOrEmpty(tbID.Text) || string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbType.Text));
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            checkRequiredAttributes(null, null);
            Task.Run(() =>
            {
                if (isNewProduct) isEditID = true;
            });
        }

        private void tbUnit_Leave(object sender, EventArgs e)
        {
            if (tbUnit.Text.Length == 0)
            {
                tbUnit.ForeColor = SystemColors.GrayText;
                tbUnit.Text = "單位";
            }
        }

        private void tbUnit_Enter(object sender, EventArgs e)
        {
            if (tbUnit.Text == "單位")
            {
                tbUnit.Text = "";
                tbUnit.ForeColor = SystemColors.WindowText;
            }
        }
    }

}
