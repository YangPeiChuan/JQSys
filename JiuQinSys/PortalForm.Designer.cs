namespace JiuQinSys
{
    partial class PortalForm
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
            this.btnQuote = new System.Windows.Forms.Button();
            this.btnPrepareOrder = new System.Windows.Forms.Button();
            this.btnAssessment = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnAccountReciable = new System.Windows.Forms.Button();
            this.btnPurchaseOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuote
            // 
            this.btnQuote.Location = new System.Drawing.Point(13, 52);
            this.btnQuote.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Size = new System.Drawing.Size(99, 31);
            this.btnQuote.TabIndex = 1;
            this.btnQuote.Text = "出貨單";
            this.btnQuote.UseVisualStyleBackColor = true;
            this.btnQuote.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrepareOrder
            // 
            this.btnPrepareOrder.Location = new System.Drawing.Point(13, 255);
            this.btnPrepareOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrepareOrder.Name = "btnPrepareOrder";
            this.btnPrepareOrder.Size = new System.Drawing.Size(99, 31);
            this.btnPrepareOrder.TabIndex = 2;
            this.btnPrepareOrder.Text = "揀貨單";
            this.btnPrepareOrder.UseVisualStyleBackColor = true;
            this.btnPrepareOrder.Visible = false;
            this.btnPrepareOrder.Click += new System.EventHandler(this.btnPrepareOrder_Click);
            // 
            // btnAssessment
            // 
            this.btnAssessment.Location = new System.Drawing.Point(13, 13);
            this.btnAssessment.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssessment.Name = "btnAssessment";
            this.btnAssessment.Size = new System.Drawing.Size(99, 31);
            this.btnAssessment.TabIndex = 0;
            this.btnAssessment.Text = "估價單";
            this.btnAssessment.UseVisualStyleBackColor = true;
            this.btnAssessment.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.AutoSize = true;
            this.btnCustomer.Location = new System.Drawing.Point(13, 126);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(99, 30);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "顧客資料";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.AutoSize = true;
            this.btnProduct.Location = new System.Drawing.Point(13, 162);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(99, 30);
            this.btnProduct.TabIndex = 5;
            this.btnProduct.Text = "產品資料";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAccountReciable
            // 
            this.btnAccountReciable.AutoSize = true;
            this.btnAccountReciable.Location = new System.Drawing.Point(12, 198);
            this.btnAccountReciable.Name = "btnAccountReciable";
            this.btnAccountReciable.Size = new System.Drawing.Size(99, 50);
            this.btnAccountReciable.TabIndex = 6;
            this.btnAccountReciable.Text = "應收帳款\r\n簡要表";
            this.btnAccountReciable.UseVisualStyleBackColor = true;
            this.btnAccountReciable.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnPurchaseOrder
            // 
            this.btnPurchaseOrder.AutoSize = true;
            this.btnPurchaseOrder.Location = new System.Drawing.Point(13, 90);
            this.btnPurchaseOrder.Name = "btnPurchaseOrder";
            this.btnPurchaseOrder.Size = new System.Drawing.Size(99, 30);
            this.btnPurchaseOrder.TabIndex = 3;
            this.btnPurchaseOrder.Text = "進貨單";
            this.btnPurchaseOrder.UseVisualStyleBackColor = true;
            this.btnPurchaseOrder.Click += new System.EventHandler(this.btnPurchaseOrder_Click);
            // 
            // PortalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 340);
            this.Controls.Add(this.btnPurchaseOrder);
            this.Controls.Add(this.btnAccountReciable);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnAssessment);
            this.Controls.Add(this.btnPrepareOrder);
            this.Controls.Add(this.btnQuote);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PortalForm";
            this.Text = "Portal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PortalForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuote;
        private System.Windows.Forms.Button btnPrepareOrder;
        private System.Windows.Forms.Button btnAssessment;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnAccountReciable;
        private System.Windows.Forms.Button btnPurchaseOrder;
    }
}