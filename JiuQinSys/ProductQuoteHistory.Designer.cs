namespace JiuQinSys
{
    partial class ProductQuoteHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dStart = new System.Windows.Forms.DateTimePicker();
            this.dEnd = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDateRange = new System.Windows.Forms.CheckBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.gvQueryResult = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuoteOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueryResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gvQueryResult, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 721);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dStart, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dEnd, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnQuery, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbDateRange, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbCount, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1000, 37);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dStart
            // 
            this.dStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dStart.Enabled = false;
            this.dStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dStart.Location = new System.Drawing.Point(671, 3);
            this.dStart.Name = "dStart";
            this.dStart.Size = new System.Drawing.Size(107, 31);
            this.dStart.TabIndex = 0;
            // 
            // dEnd
            // 
            this.dEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dEnd.Enabled = false;
            this.dEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dEnd.Location = new System.Drawing.Point(809, 3);
            this.dEnd.Name = "dEnd";
            this.dEnd.Size = new System.Drawing.Size(107, 31);
            this.dEnd.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuery.AutoSize = true;
            this.btnQuery.Location = new System.Drawing.Point(922, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 30);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "~";
            // 
            // cbDateRange
            // 
            this.cbDateRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbDateRange.AutoSize = true;
            this.cbDateRange.Location = new System.Drawing.Point(554, 6);
            this.cbDateRange.Name = "cbDateRange";
            this.cbDateRange.Size = new System.Drawing.Size(111, 24);
            this.cbDateRange.TabIndex = 4;
            this.cbDateRange.Text = "日期區間";
            this.cbDateRange.UseVisualStyleBackColor = true;
            this.cbDateRange.CheckedChanged += new System.EventHandler(this.cbDateRange_CheckedChanged);
            // 
            // lbCount
            // 
            this.lbCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(3, 8);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(0, 20);
            this.lbCount.TabIndex = 5;
            // 
            // gvQueryResult
            // 
            this.gvQueryResult.AllowUserToAddRows = false;
            this.gvQueryResult.AllowUserToDeleteRows = false;
            this.gvQueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQueryResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNo,
            this.colDate,
            this.colCustID,
            this.colCustName,
            this.colContact,
            this.colPhone,
            this.colMobile,
            this.colCount,
            this.colPrice,
            this.colQuoteOrder});
            this.gvQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQueryResult.Location = new System.Drawing.Point(3, 46);
            this.gvQueryResult.Name = "gvQueryResult";
            this.gvQueryResult.ReadOnly = true;
            this.gvQueryResult.RowTemplate.Height = 27;
            this.gvQueryResult.Size = new System.Drawing.Size(1000, 672);
            this.gvQueryResult.TabIndex = 1;
            this.gvQueryResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvQueryResult_CellContentClick);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "出貨單";
            this.dataGridViewButtonColumn1.Width = 5;
            // 
            // colOrderNo
            // 
            this.colOrderNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colOrderNo.DataPropertyName = "no";
            this.colOrderNo.HeaderText = "單號";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            this.colOrderNo.Width = 78;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDate.DataPropertyName = "date";
            this.colDate.HeaderText = "日期";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 78;
            // 
            // colCustID
            // 
            this.colCustID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCustID.DataPropertyName = "custID";
            this.colCustID.HeaderText = "客戶編號";
            this.colCustID.Name = "colCustID";
            this.colCustID.ReadOnly = true;
            this.colCustID.Width = 118;
            // 
            // colCustName
            // 
            this.colCustName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCustName.DataPropertyName = "custName";
            this.colCustName.HeaderText = "客戶名稱";
            this.colCustName.Name = "colCustName";
            this.colCustName.ReadOnly = true;
            this.colCustName.Width = 118;
            // 
            // colContact
            // 
            this.colContact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colContact.DataPropertyName = "contact";
            this.colContact.HeaderText = "聯絡人";
            this.colContact.Name = "colContact";
            this.colContact.ReadOnly = true;
            this.colContact.Width = 98;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPhone.DataPropertyName = "phone";
            this.colPhone.HeaderText = "電話";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 78;
            // 
            // colMobile
            // 
            this.colMobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMobile.DataPropertyName = "mobile";
            this.colMobile.HeaderText = "手機";
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;
            this.colMobile.Width = 78;
            // 
            // colCount
            // 
            this.colCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCount.DataPropertyName = "count";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.colCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCount.HeaderText = "數量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 78;
            // 
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrice.DataPropertyName = "pice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPrice.HeaderText = "金額";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 78;
            // 
            // colQuoteOrder
            // 
            this.colQuoteOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colQuoteOrder.HeaderText = "";
            this.colQuoteOrder.Name = "colQuoteOrder";
            this.colQuoteOrder.ReadOnly = true;
            this.colQuoteOrder.Text = "出貨單";
            this.colQuoteOrder.UseColumnTextForButtonValue = true;
            this.colQuoteOrder.Width = 5;
            // 
            // ProductQuoteHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductQuoteHistory";
            this.Text = "ProductQuoteHistory";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueryResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dStart;
        private System.Windows.Forms.DateTimePicker dEnd;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbDateRange;
        private System.Windows.Forms.DataGridView gvQueryResult;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewButtonColumn colQuoteOrder;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}