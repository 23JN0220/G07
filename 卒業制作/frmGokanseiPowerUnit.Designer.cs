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
            this.lstSize = new System.Windows.Forms.ListBox();
            this.txtSize = new System.Windows.Forms.TextBox();
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
            // lstSize
            // 
            this.lstSize.FormattingEnabled = true;
            this.lstSize.ItemHeight = 21;
            this.lstSize.Location = new System.Drawing.Point(28, 56);
            this.lstSize.Name = "lstSize";
            this.lstSize.Size = new System.Drawing.Size(149, 88);
            this.lstSize.TabIndex = 1;
            this.lstSize.SelectedIndexChanged += new System.EventHandler(this.lstSize_SelectedIndexChanged);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(212, 56);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(249, 28);
            this.txtSize.TabIndex = 2;
            // 
            // btnSadd
            // 
            this.btnSadd.Location = new System.Drawing.Point(212, 112);
            this.btnSadd.Name = "btnSadd";
            this.btnSadd.Size = new System.Drawing.Size(75, 32);
            this.btnSadd.TabIndex = 3;
            this.btnSadd.Text = "追加";
            this.btnSadd.UseVisualStyleBackColor = true;
            this.btnSadd.Click += new System.EventHandler(this.btnSadd_Click);
            // 
            // btnSchange
            // 
            this.btnSchange.Location = new System.Drawing.Point(302, 112);
            this.btnSchange.Name = "btnSchange";
            this.btnSchange.Size = new System.Drawing.Size(75, 32);
            this.btnSchange.TabIndex = 4;
            this.btnSchange.Text = "変更";
            this.btnSchange.UseVisualStyleBackColor = true;
            this.btnSchange.Click += new System.EventHandler(this.btnSchange_Click);
            // 
            // btnSdelete
            // 
            this.btnSdelete.Location = new System.Drawing.Point(402, 112);
            this.btnSdelete.Name = "btnSdelete";
            this.btnSdelete.Size = new System.Drawing.Size(75, 32);
            this.btnSdelete.TabIndex = 5;
            this.btnSdelete.Text = "削除";
            this.btnSdelete.UseVisualStyleBackColor = true;
            this.btnSdelete.Click += new System.EventHandler(this.btnSdelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(402, 199);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "戻る";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGokanseiPowerUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 244);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSdelete);
            this.Controls.Add(this.btnSchange);
            this.Controls.Add(this.btnSadd);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lstSize);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGokanseiPowerUnit";
            this.Text = "互換性管理電源ユニット";
            this.Load += new System.EventHandler(this.frmGokanseiPowerUnit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnSadd;
        private System.Windows.Forms.Button btnSchange;
        private System.Windows.Forms.Button btnSdelete;
        private System.Windows.Forms.Button btnClose;
    }
}