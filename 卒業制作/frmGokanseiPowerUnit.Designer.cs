namespace 卒業制作
{
    partial class frmGokanseiPowerUnit
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstSpec = new System.Windows.Forms.ListBox();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.btnSadd = new System.Windows.Forms.Button();
            this.btnSchange = new System.Windows.Forms.Button();
            this.btnSdelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "大きさの規格";
            // 
            // lstSpec
            // 
            this.lstSpec.FormattingEnabled = true;
            this.lstSpec.ItemHeight = 21;
            this.lstSpec.Location = new System.Drawing.Point(28, 56);
            this.lstSpec.Name = "lstSpec";
            this.lstSpec.Size = new System.Drawing.Size(120, 88);
            this.lstSpec.TabIndex = 1;
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(212, 56);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.ReadOnly = true;
            this.txtSpec.Size = new System.Drawing.Size(249, 28);
            this.txtSpec.TabIndex = 2;
            // 
            // btnSadd
            // 
            this.btnSadd.Location = new System.Drawing.Point(212, 90);
            this.btnSadd.Name = "btnSadd";
            this.btnSadd.Size = new System.Drawing.Size(75, 32);
            this.btnSadd.TabIndex = 3;
            this.btnSadd.Text = "追加";
            this.btnSadd.UseVisualStyleBackColor = true;
            // 
            // btnSchange
            // 
            this.btnSchange.Location = new System.Drawing.Point(302, 90);
            this.btnSchange.Name = "btnSchange";
            this.btnSchange.Size = new System.Drawing.Size(75, 32);
            this.btnSchange.TabIndex = 4;
            this.btnSchange.Text = "変更";
            this.btnSchange.UseVisualStyleBackColor = true;
            // 
            // btnSdelete
            // 
            this.btnSdelete.Location = new System.Drawing.Point(402, 90);
            this.btnSdelete.Name = "btnSdelete";
            this.btnSdelete.Size = new System.Drawing.Size(75, 32);
            this.btnSdelete.TabIndex = 5;
            this.btnSdelete.Text = "削除";
            this.btnSdelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(402, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "戻る";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmGokanseiPowerUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 383);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSdelete);
            this.Controls.Add(this.btnSchange);
            this.Controls.Add(this.btnSadd);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.lstSpec);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGokanseiPowerUnit";
            this.Text = "互換性管理電源ユニット";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSpec;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Button btnSadd;
        private System.Windows.Forms.Button btnSchange;
        private System.Windows.Forms.Button btnSdelete;
        private System.Windows.Forms.Button btnClose;
    }
}