namespace JiuQinSys
{
    partial class AccountReciableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.dEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dStart = new System.Windows.Forms.DateTimePicker();
            this.tbCustID = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntiBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbBeforeAntiBalance = new System.Windows.Forms.Label();
            this.lbThisTotal = new System.Windows.Forms.Label();
            this.lbTax = new System.Windows.Forms.Label();
            this.lbThisBalance = new System.Windows.Forms.Label();
            this.lbThisAntiBalance = new System.Windows.Forms.Label();
            this.lbTotalAntiBalance = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 721);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 10;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tbCustName, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.dEnd, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.dStart, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbCustID, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPrint, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnQuery, 8, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1000, 37);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tbCustName
            // 
            this.tbCustName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbCustName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCustName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCustName.Enabled = false;
            this.tbCustName.Location = new System.Drawing.Point(634, 3);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(233, 31);
            this.tbCustName.TabIndex = 5;
            // 
            // dEnd
            // 
            this.dEnd.CustomFormat = "";
            this.dEnd.Location = new System.Drawing.Point(241, 3);
            this.dEnd.Name = "dEnd";
            this.dEnd.Size = new System.Drawing.Size(152, 31);
            this.dEnd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "~";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "客戶編號";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "名稱";
            // 
            // dStart
            // 
            this.dStart.CustomFormat = "";
            this.dStart.Location = new System.Drawing.Point(58, 3);
            this.dStart.Name = "dStart";
            this.dStart.Size = new System.Drawing.Size(152, 31);
            this.dStart.TabIndex = 2;
            this.dStart.ValueChanged += new System.EventHandler(this.dStart_ValueChanged);
            // 
            // tbCustID
            // 
            this.tbCustID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbCustID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCustID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbCustID.Location = new System.Drawing.Point(494, 3);
            this.tbCustID.Name = "tbCustID";
            this.tbCustID.Size = new System.Drawing.Size(79, 31);
            this.tbCustID.TabIndex = 4;
            this.tbCustID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.AutoSize = true;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(938, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(59, 30);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuery.AutoSize = true;
            this.btnQuery.Location = new System.Drawing.Point(873, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(59, 30);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colId,
            this.colAmt,
            this.colTax,
            this.colTotalAmt,
            this.colBalance,
            this.colAntiBalance});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 536);
            this.dataGridView1.TabIndex = 8;
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
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colId.DataPropertyName = "no";
            this.colId.HeaderText = "單號";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 78;
            // 
            // colAmt
            // 
            this.colAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAmt.DataPropertyName = "total";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = null;
            this.colAmt.DefaultCellStyle = dataGridViewCellStyle16;
            this.colAmt.HeaderText = "金額";
            this.colAmt.Name = "colAmt";
            this.colAmt.ReadOnly = true;
            this.colAmt.Width = 78;
            // 
            // colTax
            // 
            this.colTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTax.DataPropertyName = "tax";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            this.colTax.DefaultCellStyle = dataGridViewCellStyle17;
            this.colTax.HeaderText = "營業稅";
            this.colTax.Name = "colTax";
            this.colTax.ReadOnly = true;
            this.colTax.Width = 98;
            // 
            // colTotalAmt
            // 
            this.colTotalAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotalAmt.DataPropertyName = "totalAmt";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            this.colTotalAmt.DefaultCellStyle = dataGridViewCellStyle18;
            this.colTotalAmt.HeaderText = "應收金額";
            this.colTotalAmt.Name = "colTotalAmt";
            this.colTotalAmt.ReadOnly = true;
            this.colTotalAmt.Width = 118;
            // 
            // colBalance
            // 
            this.colBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colBalance.DataPropertyName = "balance";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            this.colBalance.DefaultCellStyle = dataGridViewCellStyle19;
            this.colBalance.HeaderText = "已收金額";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            this.colBalance.Width = 118;
            // 
            // colAntiBalance
            // 
            this.colAntiBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAntiBalance.DataPropertyName = "antiBalance";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N0";
            this.colAntiBalance.DefaultCellStyle = dataGridViewCellStyle20;
            this.colAntiBalance.HeaderText = "未收金額";
            this.colAntiBalance.Name = "colAntiBalance";
            this.colAntiBalance.ReadOnly = true;
            this.colAntiBalance.Width = 118;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.label10, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.lbBeforeAntiBalance, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbThisTotal, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbTax, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbThisBalance, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbThisAntiBalance, 4, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbTotalAntiBalance, 4, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 588);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1000, 130);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "前期累計應收帳款：";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(669, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "本期應收合計：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(669, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "(＋) 營業稅額：";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(669, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "(－) 已收金額：";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(669, 81);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "本期應收款金額：";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(669, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "本期應收款總計：";
            // 
            // lbBeforeAntiBalance
            // 
            this.lbBeforeAntiBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbBeforeAntiBalance.AutoSize = true;
            this.lbBeforeAntiBalance.Location = new System.Drawing.Point(198, 81);
            this.lbBeforeAntiBalance.Name = "lbBeforeAntiBalance";
            this.lbBeforeAntiBalance.Size = new System.Drawing.Size(165, 20);
            this.lbBeforeAntiBalance.TabIndex = 2;
            this.lbBeforeAntiBalance.Text = "lbBeforeAntiBalance";
            this.lbBeforeAntiBalance.Visible = false;
            // 
            // lbThisTotal
            // 
            this.lbThisTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbThisTotal.AutoSize = true;
            this.lbThisTotal.Location = new System.Drawing.Point(904, 3);
            this.lbThisTotal.Name = "lbThisTotal";
            this.lbThisTotal.Size = new System.Drawing.Size(93, 20);
            this.lbThisTotal.TabIndex = 2;
            this.lbThisTotal.Text = "lbThisTotal";
            // 
            // lbTax
            // 
            this.lbTax.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTax.AutoSize = true;
            this.lbTax.Location = new System.Drawing.Point(946, 29);
            this.lbTax.Name = "lbTax";
            this.lbTax.Size = new System.Drawing.Size(51, 20);
            this.lbTax.TabIndex = 2;
            this.lbTax.Text = "lbTax";
            // 
            // lbThisBalance
            // 
            this.lbThisBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbThisBalance.AutoSize = true;
            this.lbThisBalance.Location = new System.Drawing.Point(883, 55);
            this.lbThisBalance.Name = "lbThisBalance";
            this.lbThisBalance.Size = new System.Drawing.Size(114, 20);
            this.lbThisBalance.TabIndex = 2;
            this.lbThisBalance.Text = "lbThisBalance";
            // 
            // lbThisAntiBalance
            // 
            this.lbThisAntiBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbThisAntiBalance.AutoSize = true;
            this.lbThisAntiBalance.Location = new System.Drawing.Point(850, 81);
            this.lbThisAntiBalance.Name = "lbThisAntiBalance";
            this.lbThisAntiBalance.Size = new System.Drawing.Size(147, 20);
            this.lbThisAntiBalance.TabIndex = 2;
            this.lbThisAntiBalance.Text = "lbThisAntiBalance";
            // 
            // lbTotalAntiBalance
            // 
            this.lbTotalAntiBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalAntiBalance.AutoSize = true;
            this.lbTotalAntiBalance.Location = new System.Drawing.Point(844, 107);
            this.lbTotalAntiBalance.Name = "lbTotalAntiBalance";
            this.lbTotalAntiBalance.Size = new System.Drawing.Size(153, 20);
            this.lbTotalAntiBalance.TabIndex = 2;
            this.lbTotalAntiBalance.Text = "lbTotalAntiBalance";
            // 
            // AccountReciableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AccountReciableForm";
            this.Text = "應收帳款簡要表";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.DateTimePicker dEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DateTimePicker dStart;
        private System.Windows.Forms.TextBox tbCustID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbBeforeAntiBalance;
        private System.Windows.Forms.Label lbThisTotal;
        private System.Windows.Forms.Label lbTax;
        private System.Windows.Forms.Label lbThisBalance;
        private System.Windows.Forms.Label lbThisAntiBalance;
        private System.Windows.Forms.Label lbTotalAntiBalance;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntiBalance;
    }
}