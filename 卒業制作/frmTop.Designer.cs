namespace 卒業制作
{
    partial class frmTop
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMember = new System.Windows.Forms.Button();
            this.btnGoods = new System.Windows.Forms.Button();
            this.btnCompatibility = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMember
            // 
            this.btnMember.Location = new System.Drawing.Point(80, 42);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(171, 59);
            this.btnMember.TabIndex = 0;
            this.btnMember.Text = "会員管理";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnGoods
            // 
            this.btnGoods.Location = new System.Drawing.Point(342, 42);
            this.btnGoods.Name = "btnGoods";
            this.btnGoods.Size = new System.Drawing.Size(179, 59);
            this.btnGoods.TabIndex = 1;
            this.btnGoods.Text = "商品管理";
            this.btnGoods.UseVisualStyleBackColor = true;
            this.btnGoods.Click += new System.EventHandler(this.btnGoods_Click);
            // 
            // btnCompatibility
            // 
            this.btnCompatibility.Location = new System.Drawing.Point(80, 134);
            this.btnCompatibility.Name = "btnCompatibility";
            this.btnCompatibility.Size = new System.Drawing.Size(171, 59);
            this.btnCompatibility.TabIndex = 2;
            this.btnCompatibility.Text = "互換性管理";
            this.btnCompatibility.UseVisualStyleBackColor = true;
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(342, 134);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(179, 59);
            this.btnReview.TabIndex = 3;
            this.btnReview.Text = "レビュー管理";
            this.btnReview.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(80, 218);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(171, 59);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "注文管理";
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(342, 218);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(179, 59);
            this.btnPay.TabIndex = 5;
            this.btnPay.Text = "支払管理";
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(435, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 378);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.btnCompatibility);
            this.Controls.Add(this.btnGoods);
            this.Controls.Add(this.btnMember);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmTop";
            this.Text = "管理トップ画面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnGoods;
        private System.Windows.Forms.Button btnCompatibility;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnClose;
    }
}

