namespace JiuQinSys
{
    partial class QuoteOrderForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadOrder = new System.Windows.Forms.Button();
            this.btnOrderRemark = new System.Windows.Forms.Button();
            this.btnPickingState = new System.Windows.Forms.Button();
            this.tbOrderNo = new System.Windows.Forms.TextBox();
            this.gvProducts = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbAmt = new System.Windows.Forms.Label();
            this.lbSubtotal = new System.Windows.Forms.Label();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.btnBalance = new System.Windows.Forms.Button();
            this.rbHasTax = new System.Windows.Forms.RadioButton();
            this.rbNonTax = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInvoiceaddr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadCust = new System.Windows.Forms.Button();
            this.tbCustmorName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCustmorID = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.cbPhone = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFax = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTel = new System.Windows.Forms.ComboBox();
            this.cbContact = new System.Windows.Forms.ComboBox();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gvProducts, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1422, 853);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tOrderDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLoadOrder, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOrderRemark, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPickingState, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbOrderNo, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1412, 39);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tOrderDate
            // 
            this.tOrderDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tOrderDate.Location = new System.Drawing.Point(61, 4);
            this.tOrderDate.Margin = new System.Windows.Forms.Padding(4);
            this.tOrderDate.Name = "tOrderDate";
            this.tOrderDate.Size = new System.Drawing.Size(178, 31);
            this.tOrderDate.TabIndex = 0;
            this.tOrderDate.ValueChanged += new System.EventHandler(this.controlEdited);
            this.tOrderDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tOrderDate_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "單號";
            // 
            // btnLoadOrder
            // 
            this.btnLoadOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadOrder.AutoSize = true;
            this.btnLoadOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadOrder.Location = new System.Drawing.Point(424, 4);
            this.btnLoadOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadOrder.Name = "btnLoadOrder";
            this.btnLoadOrder.Size = new System.Drawing.Size(34, 30);
            this.btnLoadOrder.TabIndex = 4;
            this.btnLoadOrder.Text = "...";
            this.btnLoadOrder.UseVisualStyleBackColor = true;
            this.btnLoadOrder.Click += new System.EventHandler(this.btnLoadOrder_Click);
            // 
            // btnOrderRemark
            // 
            this.btnOrderRemark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrderRemark.AutoSize = true;
            this.btnOrderRemark.Location = new System.Drawing.Point(465, 4);
            this.btnOrderRemark.Name = "btnOrderRemark";
            this.btnOrderRemark.Size = new System.Drawing.Size(70, 30);
            this.btnOrderRemark.TabIndex = 5;
            this.btnOrderRemark.Text = "備註";
            this.btnOrderRemark.UseVisualStyleBackColor = true;
            this.btnOrderRemark.Click += new System.EventHandler(this.btnOrderRemark_Click);
            // 
            // btnPickingState
            // 
            this.btnPickingState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPickingState.AutoSize = true;
            this.btnPickingState.Enabled = false;
            this.btnPickingState.Location = new System.Drawing.Point(541, 4);
            this.btnPickingState.Name = "btnPickingState";
            this.btnPickingState.Size = new System.Drawing.Size(99, 30);
            this.btnPickingState.TabIndex = 6;
            this.btnPickingState.Text = "揀貨狀態";
            this.btnPickingState.UseVisualStyleBackColor = true;
            this.btnPickingState.Visible = false;
            this.btnPickingState.Click += new System.EventHandler(this.btnPickingState_Click);
            // 
            // tbOrderNo
            // 
            this.tbOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOrderNo.Location = new System.Drawing.Point(303, 3);
            this.tbOrderNo.Name = "tbOrderNo";
            this.tbOrderNo.Size = new System.Drawing.Size(114, 31);
            this.tbOrderNo.TabIndex = 7;
            this.tbOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOrderNo_KeyDown);
            // 
            // gvProducts
            // 
            this.gvProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colProductNo,
            this.colProductName,
            this.colCount,
            this.colUnit,
            this.colPrice,
            this.colAmt,
            this.colStock,
            this.colShortRemark,
            this.colRemark,
            this.colDel});
            this.gvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProducts.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.gvProducts.Location = new System.Drawing.Point(4, 225);
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.RowTemplate.Height = 27;
            this.gvProducts.Size = new System.Drawing.Size(1414, 548);
            this.gvProducts.TabIndex = 1;
            this.gvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProducts_CellClick);
            this.gvProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProducts_CellEndEdit);
            this.gvProducts.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.gvProducts_CellStateChanged);
            this.gvProducts.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvProducts_EditingControlShowing);
            this.gvProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvProducts_KeyDown);
            this.gvProducts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvProducts_MouseClick);
            // 
            // colNo
            // 
            this.colNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNo.DataPropertyName = "no";
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 57;
            // 
            // colProductNo
            // 
            this.colProductNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProductNo.DataPropertyName = "id";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colProductNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colProductNo.HeaderText = "產品編號";
            this.colProductNo.Name = "colProductNo";
            this.colProductNo.Width = 114;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductName.DataPropertyName = "name";
            this.colProductName.FillWeight = 30F;
            this.colProductName.HeaderText = "品名";
            this.colProductName.Name = "colProductName";
            // 
            // colCount
            // 
            this.colCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCount.DataPropertyName = "count";
            this.colCount.HeaderText = "數量";
            this.colCount.Name = "colCount";
            this.colCount.Width = 74;
            // 
            // colUnit
            // 
            this.colUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUnit.DataPropertyName = "unit";
            this.colUnit.HeaderText = "單位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.Width = 74;
            // 
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrice.DataPropertyName = "price";
            this.colPrice.HeaderText = "單價";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 74;
            // 
            // colAmt
            // 
            this.colAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAmt.DataPropertyName = "amt";
            this.colAmt.HeaderText = "金額";
            this.colAmt.Name = "colAmt";
            this.colAmt.ReadOnly = true;
            this.colAmt.Width = 74;
            // 
            // colStock
            // 
            this.colStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "庫存";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 74;
            // 
            // colShortRemark
            // 
            this.colShortRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colShortRemark.HeaderText = "";
            this.colShortRemark.Name = "colShortRemark";
            this.colShortRemark.Width = 24;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colRemark.HeaderText = "　　";
            this.colRemark.Name = "colRemark";
            this.colRemark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemark.Text = "備註";
            this.colRemark.UseColumnTextForButtonValue = true;
            this.colRemark.Width = 55;
            // 
            // colDel
            // 
            this.colDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colDel.HeaderText = "　　";
            this.colDel.Name = "colDel";
            this.colDel.Text = "刪除";
            this.colDel.UseColumnTextForButtonValue = true;
            this.colDel.Width = 55;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 12;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.btnSave, 11, 0);
            this.tableLayoutPanel6.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label10, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbAmt, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbSubtotal, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnNewOrder, 10, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnPrint, 9, 0);
            this.tableLayoutPanel6.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbBalance, 7, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnBalance, 8, 0);
            this.tableLayoutPanel6.Controls.Add(this.rbHasTax, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.rbNonTax, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 780);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1414, 36);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(1350, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "合計";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(487, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "總計";
            // 
            // lbAmt
            // 
            this.lbAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAmt.AutoSize = true;
            this.lbAmt.Location = new System.Drawing.Point(542, 8);
            this.lbAmt.Name = "lbAmt";
            this.lbAmt.Size = new System.Drawing.Size(18, 20);
            this.lbAmt.TabIndex = 0;
            this.lbAmt.Text = "0";
            // 
            // lbSubtotal
            // 
            this.lbSubtotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSubtotal.AutoSize = true;
            this.lbSubtotal.Location = new System.Drawing.Point(230, 8);
            this.lbSubtotal.Name = "lbSubtotal";
            this.lbSubtotal.Size = new System.Drawing.Size(18, 20);
            this.lbSubtotal.TabIndex = 4;
            this.lbSubtotal.Text = "0";
            this.lbSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewOrder.AutoSize = true;
            this.btnNewOrder.Location = new System.Drawing.Point(1283, 3);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(60, 30);
            this.btnNewOrder.TabIndex = 1;
            this.btnNewOrder.Text = "新增";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.AutoSize = true;
            this.btnPrint.Location = new System.Drawing.Point(1217, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(799, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "沖款金額";
            // 
            // lbBalance
            // 
            this.lbBalance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbBalance.AutoSize = true;
            this.lbBalance.Location = new System.Drawing.Point(894, 8);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(18, 20);
            this.lbBalance.TabIndex = 0;
            this.lbBalance.Text = "0";
            // 
            // btnBalance
            // 
            this.btnBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBalance.AutoSize = true;
            this.btnBalance.Location = new System.Drawing.Point(1151, 3);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(60, 30);
            this.btnBalance.TabIndex = 6;
            this.btnBalance.Text = "沖款";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // rbHasTax
            // 
            this.rbHasTax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbHasTax.AutoSize = true;
            this.rbHasTax.Checked = true;
            this.rbHasTax.Location = new System.Drawing.Point(3, 6);
            this.rbHasTax.Name = "rbHasTax";
            this.rbHasTax.Size = new System.Drawing.Size(70, 24);
            this.rbHasTax.TabIndex = 7;
            this.rbHasTax.TabStop = true;
            this.rbHasTax.Text = "應稅";
            this.rbHasTax.UseVisualStyleBackColor = true;
            this.rbHasTax.CheckedChanged += new System.EventHandler(this.rbHasTax_CheckedChanged);
            // 
            // rbNonTax
            // 
            this.rbNonTax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbNonTax.AutoSize = true;
            this.rbNonTax.Location = new System.Drawing.Point(79, 6);
            this.rbNonTax.Name = "rbNonTax";
            this.rbNonTax.Size = new System.Drawing.Size(90, 24);
            this.rbNonTax.TabIndex = 7;
            this.rbNonTax.Text = "免稅金";
            this.rbNonTax.UseVisualStyleBackColor = true;
            this.rbNonTax.CheckedChanged += new System.EventHandler(this.rbNonTax_CheckedChanged);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.lbUserName, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(4, 823);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(109, 26);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // lbUserName
            // 
            this.lbUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(3, 3);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(3);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(103, 20);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "lbUserName";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnAddProduct, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(5, 181);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1412, 36);
            this.tableLayoutPanel8.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(609, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "商品清單";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.AutoSize = true;
            this.btnAddProduct.Location = new System.Drawing.Point(1310, 3);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(99, 30);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "新增商品";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.tbInvoiceaddr, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel11, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(4, 52);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1414, 121);
            this.tableLayoutPanel9.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "送貨地址";
            // 
            // tbInvoiceaddr
            // 
            this.tbInvoiceaddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInvoiceaddr.Location = new System.Drawing.Point(103, 87);
            this.tbInvoiceaddr.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.tbInvoiceaddr.Name = "tbInvoiceaddr";
            this.tbInvoiceaddr.Size = new System.Drawing.Size(1305, 31);
            this.tbInvoiceaddr.TabIndex = 4;
            this.tbInvoiceaddr.TextChanged += new System.EventHandler(this.controlEdited);
            this.tbInvoiceaddr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInvoiceaddr_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "客戶編號";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "聯絡人";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 4;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.Controls.Add(this.btnLoadCust, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.tbCustmorName, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.tbCustmorID, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(100, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1311, 38);
            this.tableLayoutPanel10.TabIndex = 5;
            // 
            // btnLoadCust
            // 
            this.btnLoadCust.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadCust.AutoSize = true;
            this.btnLoadCust.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadCust.Location = new System.Drawing.Point(1207, 4);
            this.btnLoadCust.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadCust.Name = "btnLoadCust";
            this.btnLoadCust.Size = new System.Drawing.Size(99, 30);
            this.btnLoadCust.TabIndex = 4;
            this.btnLoadCust.Text = "查詢客戶";
            this.btnLoadCust.UseVisualStyleBackColor = true;
            this.btnLoadCust.Click += new System.EventHandler(this.btnLoadCust_Click);
            // 
            // tbCustmorName
            // 
            this.tbCustmorName.AutoCompleteCustomSource.AddRange(new string[] {
            "123",
            "112",
            "111"});
            this.tbCustmorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbCustmorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCustmorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCustmorName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbCustmorName.Location = new System.Drawing.Point(542, 3);
            this.tbCustmorName.Name = "tbCustmorName";
            this.tbCustmorName.Size = new System.Drawing.Size(658, 31);
            this.tbCustmorName.TabIndex = 3;
            this.tbCustmorName.TextChanged += new System.EventHandler(this.controlEdited);
            this.tbCustmorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCustmorName_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "客戶名稱";
            // 
            // tbCustmorID
            // 
            this.tbCustmorID.AutoCompleteCustomSource.AddRange(new string[] {
            "123",
            "112",
            "111"});
            this.tbCustmorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbCustmorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCustmorID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCustmorID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbCustmorID.Location = new System.Drawing.Point(3, 3);
            this.tbCustmorID.Name = "tbCustmorID";
            this.tbCustmorID.Size = new System.Drawing.Size(436, 31);
            this.tbCustmorID.TabIndex = 6;
            this.tbCustmorID.TextChanged += new System.EventHandler(this.controlEdited);
            this.tbCustmorID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 7;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99999F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.Controls.Add(this.cbPhone, 6, 0);
            this.tableLayoutPanel11.Controls.Add(this.label14, 5, 0);
            this.tableLayoutPanel11.Controls.Add(this.label7, 3, 0);
            this.tableLayoutPanel11.Controls.Add(this.cbFax, 4, 0);
            this.tableLayoutPanel11.Controls.Add(this.label12, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.cbTel, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.cbContact, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(100, 47);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1311, 34);
            this.tableLayoutPanel11.TabIndex = 6;
            // 
            // cbPhone
            // 
            this.cbPhone.DisplayMember = "Number";
            this.cbPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPhone.FormattingEnabled = true;
            this.cbPhone.Location = new System.Drawing.Point(1028, 3);
            this.cbPhone.Name = "cbPhone";
            this.cbPhone.Size = new System.Drawing.Size(280, 28);
            this.cbPhone.TabIndex = 5;
            this.cbPhone.SelectedIndexChanged += new System.EventHandler(this.controlEdited);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(972, 7);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "手機";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "傳真";
            // 
            // cbFax
            // 
            this.cbFax.DisplayMember = "Number";
            this.cbFax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFax.FormattingEnabled = true;
            this.cbFax.Location = new System.Drawing.Point(686, 3);
            this.cbFax.Name = "cbFax";
            this.cbFax.Size = new System.Drawing.Size(279, 28);
            this.cbFax.TabIndex = 5;
            this.cbFax.SelectedIndexChanged += new System.EventHandler(this.controlEdited);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(288, 7);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "電話";
            // 
            // cbTel
            // 
            this.cbTel.DisplayMember = "Number";
            this.cbTel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTel.FormattingEnabled = true;
            this.cbTel.Location = new System.Drawing.Point(344, 3);
            this.cbTel.Name = "cbTel";
            this.cbTel.Size = new System.Drawing.Size(279, 28);
            this.cbTel.TabIndex = 5;
            this.cbTel.SelectedIndexChanged += new System.EventHandler(this.controlEdited);
            // 
            // cbContact
            // 
            this.cbContact.DisplayMember = "Name";
            this.cbContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbContact.FormattingEnabled = true;
            this.cbContact.Location = new System.Drawing.Point(3, 3);
            this.cbContact.Name = "cbContact";
            this.cbContact.Size = new System.Drawing.Size(278, 28);
            this.cbContact.TabIndex = 6;
            this.cbContact.SelectedIndexChanged += new System.EventHandler(this.cbContact_SelectedIndexChanged);
            this.cbContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbContact_KeyDown);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewButtonColumn1.HeaderText = "　　";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.Text = "備註";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewButtonColumn2.HeaderText = "　　";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "刪除";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            // 
            // QuoteOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 853);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuoteOrderForm";
            this.Text = "出貨單";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuoteOrderForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker tOrderDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadOrder;
        private System.Windows.Forms.DataGridView gvProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCustmorName;
        private System.Windows.Forms.TextBox tbInvoiceaddr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbAmt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCustmorID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadCust;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTel;
        private System.Windows.Forms.ComboBox cbFax;
        private System.Windows.Forms.ComboBox cbPhone;
        private System.Windows.Forms.Label lbSubtotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.ComboBox cbContact;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOrderRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Button btnPickingState;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.RadioButton rbHasTax;
        private System.Windows.Forms.RadioButton rbNonTax;
        private System.Windows.Forms.TextBox tbOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortRemark;
        private System.Windows.Forms.DataGridViewButtonColumn colRemark;
        private System.Windows.Forms.DataGridViewButtonColumn colDel;
    }
}

