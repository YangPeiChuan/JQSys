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
using System.Windows.Forms.VisualStyles;

namespace JiuQinSys
{
    public partial class LoadOrder : Form
    {
        OrderType OrderType;

        List<LoadQuote> conditionQuery = new List<LoadQuote>();

        Task loadQuote = null;
        public LoadOrder(OrderType OrderType)
        {
            InitializeComponent();
            dStart.Value = DateTime.Now.AddMonths(-6).Date;
            dEnd.Value = DateTime.Now.Date;
            gvResult.AutoGenerateColumns = false;
            this.OrderType = OrderType;
            string query = "";
            switch (OrderType)
            {
                case JiuQinSys.OrderType.Quote:
                    query = string.Format(@"SELECT TOP 20 Q.[no],Q.[date],[custName],[contact],P.[no] prepareOrderNo
FROM [JiuQin].[dbo].[QuoteOrderMain] AS Q
LEFT JOIN [JiuQin].[dbo].[PrepareOrderMain] AS P ON Q.no= P.quoteNo
order by Q.[no] desc");
                    break;
            }

            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    conditionQuery.Add(new LoadQuote(dr));
                }
            }
            //gvResult.DataSource = conditionQuery;
            DisableNonPrepareButtons(conditionQuery);

            loadQuote = Task.Run(() =>
            {
                JiuQinEntities e = new JiuQinEntities();
                byte _connectTime = 0;
                while (true)
                {
                    try
                    {
                        conditionQuery = e.Database.SqlQuery<LoadQuote>(string.Format(@"SELECT Q.[no],Q.[date],[custName],[contact]
FROM [JiuQin].[dbo].[QuoteOrderMain] as Q
LEFT JOIN [JiuQin].[dbo].[PrepareOrderMain] AS P ON Q.no= P.quoteNo
order by date desc")).ToList();
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (_connectTime++ == 10)
                        {
                            MessageBox.Show("嘗試連線資料庫10次失敗，請確認資料庫正常運作或網路正常");
                            return;
                        }
                    }
                }
            });
        }

        private void DisableNonPrepareButtons(IEnumerable<LoadQuote> list)
        {
            gvResult.Rows.Clear();
            foreach (var o in list)
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(gvResult, o.date, o.no, o.custName, o.contact);
                dr.Tag = o;
                var c = dr.Cells[colPartPrepare.Index] as DataGridViewDisableButtonCell;
                c.Enabled = !string.IsNullOrEmpty(o.prepareOrderNo);
                gvResult.Rows.Add(dr);
            }
            //foreach (DataGridViewRow dr in gvResult.Rows)
            //{
            //    var c = dr.Cells[colPartPrepare.Index] as DataGridViewDisableButtonCell;
            //    var i = dr.DataBoundItem as LoadQuote;
            //    c.Enabled = !string.IsNullOrEmpty(i.prepareOrderNo);
            //}
            //gvResult.Refresh();
        }

        private void LoadOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            conditionQuery.Clear();
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (conditionQuery.Count == 0) return;
            if (dStart.Value > dEnd.Value)
            {
                MessageBox.Show("結束日期必須晚於起始日期");
                return;
            }
            var EndDate = dEnd.Value.AddDays(1);

            IEnumerable<LoadQuote> query_byText = null;
            Task.WaitAll(loadQuote);
            if (string.IsNullOrEmpty(tbCustName.Text) && string.IsNullOrEmpty(tbContact.Text))
            {
                query_byText = conditionQuery.Where(a => a.date >= dStart.Value && a.date < EndDate);
            }
            else
            {
                query_byText = conditionQuery.Where(a =>
                                a.date >= dStart.Value &&
                                a.date < EndDate &&
                                a.custName.Contains(tbCustName.Text) &&
                                a.contact.Contains(tbContact.Text))
                                .Select(a => new LoadQuote()
                                {
                                    contact = a.contact,
                                    custName = a.custName,
                                    date = a.date,
                                    no = a.no,
                                    prepareOrderNo = a.prepareOrderNo,
                                });
            }
            //gvResult.DataSource = conditionQuery.Where(a =>
            //                a.custName.Contains(tbCustName.Text) &&
            //                a.contact.Contains(tbContact.Text)
            //                ).ToList();
            DisableNonPrepareButtons(query_byText);
        }

        public string OrderNo { get; set; }

        private void gvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSelect.Index)
            {
                OrderNo = (gvResult.Rows[e.RowIndex].Tag as LoadOrderModel).no;
                Close();
            }
            else if (e.ColumnIndex == colPartPrepare.Index && (gvResult[e.ColumnIndex, e.RowIndex] as DataGridViewDisableButtonCell).Enabled)
            {
                var No = (gvResult.Rows[e.RowIndex].Tag as LoadOrderModel).no;
                using (PartPrepareOrderOrderForm fm = new PartPrepareOrderOrderForm(No))
                {
                    fm.ShowDialog();
                }
            }
        }
    }
    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,  
            // background, and disabled button for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text. 
                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class 
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
