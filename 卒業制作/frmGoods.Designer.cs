namespace 卒業制作
{
    partial class frmGoods
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
            this.txtGoods = new System.Windows.Forms.TextBox();
            this.btnSerch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtGoods
            // 
            this.txtGoods.Location = new System.Drawing.Point(107, 12);
            this.txtGoods.Name = "txtGoods";
            this.txtGoods.Size = new System.Drawing.Size(211, 28);
            this.txtGoods.TabIndex = 0;
            // 
            // btnSerch
            // 
            this.btnSerch.Location = new System.Drawing.Point(351, 12);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(94, 36);
            this.btnSerch.TabIndex = 1;
            this.btnSerch.Text = "検索";
            this.btnSerch.UseVisualStyleBackColor = true;
            // 
            // frmGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 370);
            this.Controls.Add(this.btnSerch);
            this.Controls.Add(this.txtGoods);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGoods";
            this.Text = "商品管理画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGoods;
        private System.Windows.Forms.Button btnSerch;
    }
}