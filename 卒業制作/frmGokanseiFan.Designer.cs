namespace 卒業制作
{
    partial class frmGokanseiFan
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
            this.lstSizeStandards = new System.Windows.Forms.ListBox();
            this.txtSizeStandards = new System.Windows.Forms.TextBox();
            this.btnSadd = new System.Windows.Forms.Button();
            this.btnSchange = new System.Windows.Forms.Button();
            this.btnSdelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "サイズ規格";
            // 
            // lstSizeStandards
            // 
            this.lstSizeStandards.FormattingEnabled = true;
            this.lstSizeStandards.ItemHeight = 21;
            this.lstSizeStandards.Location = new System.Drawing.Point(16, 153);
            this.lstSizeStandards.Name = "lstSizeStandards";
            this.lstSizeStandards.Size = new System.Drawing.Size(165, 88);
            this.lstSizeStandards.TabIndex = 1;
            this.lstSizeStandards.SelectedIndexChanged += new System.EventHandler(this.lstSizeStandards_SelectedIndexChanged);
            // 
            // txtSizeStandards
            // 
            this.txtSizeStandards.Location = new System.Drawing.Point(210, 153);
            this.txtSizeStandards.MaxLength = 240;
            this.txtSizeStandards.Name = "txtSizeStandards";
            this.txtSizeStandards.Size = new System.Drawing.Size(237, 28);
            this.txtSizeStandards.TabIndex = 2;
            // 
            // btnSadd
            // 
            this.btnSadd.Location = new System.Drawing.Point(210, 196);
            this.btnSadd.Name = "btnSadd";
            this.btnSadd.Size = new System.Drawing.Size(75, 30);
            this.btnSadd.TabIndex = 3;
            this.btnSadd.Text = "追加";
            this.btnSadd.UseVisualStyleBackColor = true;
            this.btnSadd.Click += new System.EventHandler(this.btnSadd_Click);
            // 
            // btnSchange
            // 
            this.btnSchange.Location = new System.Drawing.Point(291, 196);
            this.btnSchange.Name = "btnSchange";
            this.btnSchange.Size = new System.Drawing.Size(75, 30);
            this.btnSchange.TabIndex = 4;
            this.btnSchange.Text = "変更";
            this.btnSchange.UseVisualStyleBackColor = true;
            this.btnSchange.Click += new System.EventHandler(this.btnSchange_Click);
            // 
            // btnSdelete
            // 
            this.btnSdelete.Location = new System.Drawing.Point(372, 196);
            this.btnSdelete.Name = "btnSdelete";
            this.btnSdelete.Size = new System.Drawing.Size(75, 30);
            this.btnSdelete.TabIndex = 5;
            this.btnSdelete.Text = "削除";
            this.btnSdelete.UseVisualStyleBackColor = true;
            this.btnSdelete.Click += new System.EventHandler(this.btnSdelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(372, 293);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "戻る";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 63);
            this.label5.TabIndex = 23;
            this.label5.Text = "項目を削除する場合は\r\n左の表から削除したい項目を選択してから\r\n削除ボタンを押してください";
            // 
            // frmGokanseiFan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 343);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSdelete);
            this.Controls.Add(this.btnSchange);
            this.Controls.Add(this.btnSadd);
            this.Controls.Add(this.txtSizeStandards);
            this.Controls.Add(this.lstSizeStandards);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGokanseiFan";
            this.Text = "互換性管理PCケースファン";
            this.Load += new System.EventHandler(this.frmGokanseiFan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSizeStandards;
        private System.Windows.Forms.TextBox txtSizeStandards;
        private System.Windows.Forms.Button btnSadd;
        private System.Windows.Forms.Button btnSchange;
        private System.Windows.Forms.Button btnSdelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
    }
}