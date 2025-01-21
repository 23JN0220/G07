namespace 卒業制作
{
    partial class frmGokanseiOs
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
            this.lstVersion = new System.Windows.Forms.ListBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.btnVadd = new System.Windows.Forms.Button();
            this.btnVchange = new System.Windows.Forms.Button();
            this.btnVdelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "バージョン";
            // 
            // lstVersion
            // 
            this.lstVersion.FormattingEnabled = true;
            this.lstVersion.ItemHeight = 21;
            this.lstVersion.Location = new System.Drawing.Point(12, 70);
            this.lstVersion.Name = "lstVersion";
            this.lstVersion.Size = new System.Drawing.Size(196, 151);
            this.lstVersion.TabIndex = 1;
            this.lstVersion.SelectedIndexChanged += new System.EventHandler(this.lstVersion_SelectedIndexChanged);
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(244, 70);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(246, 28);
            this.txtVersion.TabIndex = 2;
            // 
            // btnVadd
            // 
            this.btnVadd.Location = new System.Drawing.Point(244, 114);
            this.btnVadd.Name = "btnVadd";
            this.btnVadd.Size = new System.Drawing.Size(75, 32);
            this.btnVadd.TabIndex = 3;
            this.btnVadd.Text = "追加";
            this.btnVadd.UseVisualStyleBackColor = true;
            // 
            // btnVchange
            // 
            this.btnVchange.Location = new System.Drawing.Point(325, 114);
            this.btnVchange.Name = "btnVchange";
            this.btnVchange.Size = new System.Drawing.Size(75, 32);
            this.btnVchange.TabIndex = 4;
            this.btnVchange.Text = "変更";
            this.btnVchange.UseVisualStyleBackColor = true;
            // 
            // btnVdelete
            // 
            this.btnVdelete.Location = new System.Drawing.Point(415, 114);
            this.btnVdelete.Name = "btnVdelete";
            this.btnVdelete.Size = new System.Drawing.Size(75, 32);
            this.btnVdelete.TabIndex = 5;
            this.btnVdelete.Text = "削除";
            this.btnVdelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(415, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 34);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "戻る";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGokanseiOs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 266);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnVdelete);
            this.Controls.Add(this.btnVchange);
            this.Controls.Add(this.btnVadd);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lstVersion);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGokanseiOs";
            this.Text = "互換性管理OS";
            this.Load += new System.EventHandler(this.frmGokanseiOs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstVersion;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Button btnVadd;
        private System.Windows.Forms.Button btnVchange;
        private System.Windows.Forms.Button btnVdelete;
        private System.Windows.Forms.Button btnClose;
    }
}