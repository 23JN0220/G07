namespace 卒業制作
{
    partial class frmGokanseiMemory
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
            this.lstMemoryStandard = new System.Windows.Forms.ListBox();
            this.btnSadd = new System.Windows.Forms.Button();
            this.txtMemoryStandard = new System.Windows.Forms.TextBox();
            this.btnSchange = new System.Windows.Forms.Button();
            this.btnSdelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstModule = new System.Windows.Forms.ListBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.btnMadd = new System.Windows.Forms.Button();
            this.btnMchange = new System.Windows.Forms.Button();
            this.btnMdelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(34, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "メモリ規格";
            // 
            // lstMemoryStandard
            // 
            this.lstMemoryStandard.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstMemoryStandard.FormattingEnabled = true;
            this.lstMemoryStandard.ItemHeight = 21;
            this.lstMemoryStandard.Location = new System.Drawing.Point(38, 74);
            this.lstMemoryStandard.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lstMemoryStandard.Name = "lstMemoryStandard";
            this.lstMemoryStandard.Size = new System.Drawing.Size(301, 151);
            this.lstMemoryStandard.TabIndex = 1;
            this.lstMemoryStandard.SelectedIndexChanged += new System.EventHandler(this.lstMemoryStandard_SelectedIndexChanged);
            // 
            // btnSadd
            // 
            this.btnSadd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSadd.Location = new System.Drawing.Point(348, 112);
            this.btnSadd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSadd.Name = "btnSadd";
            this.btnSadd.Size = new System.Drawing.Size(82, 36);
            this.btnSadd.TabIndex = 2;
            this.btnSadd.Text = "追加";
            this.btnSadd.UseVisualStyleBackColor = true;
            // 
            // txtMemoryStandard
            // 
            this.txtMemoryStandard.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMemoryStandard.Location = new System.Drawing.Point(348, 74);
            this.txtMemoryStandard.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMemoryStandard.Name = "txtMemoryStandard";
            this.txtMemoryStandard.Size = new System.Drawing.Size(325, 28);
            this.txtMemoryStandard.TabIndex = 3;
            // 
            // btnSchange
            // 
            this.btnSchange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSchange.Location = new System.Drawing.Point(442, 112);
            this.btnSchange.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSchange.Name = "btnSchange";
            this.btnSchange.Size = new System.Drawing.Size(79, 36);
            this.btnSchange.TabIndex = 4;
            this.btnSchange.Text = "変更";
            this.btnSchange.UseVisualStyleBackColor = true;
            // 
            // btnSdelete
            // 
            this.btnSdelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSdelete.Location = new System.Drawing.Point(537, 112);
            this.btnSdelete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSdelete.Name = "btnSdelete";
            this.btnSdelete.Size = new System.Drawing.Size(79, 36);
            this.btnSdelete.TabIndex = 5;
            this.btnSdelete.Text = "削除";
            this.btnSdelete.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(34, 243);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "モジュール";
            // 
            // lstModule
            // 
            this.lstModule.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstModule.FormattingEnabled = true;
            this.lstModule.ItemHeight = 21;
            this.lstModule.Location = new System.Drawing.Point(38, 269);
            this.lstModule.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lstModule.Name = "lstModule";
            this.lstModule.Size = new System.Drawing.Size(301, 151);
            this.lstModule.TabIndex = 7;
            this.lstModule.SelectedIndexChanged += new System.EventHandler(this.lstModule_SelectedIndexChanged);
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(348, 269);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(325, 28);
            this.txtModule.TabIndex = 8;
            // 
            // btnMadd
            // 
            this.btnMadd.Location = new System.Drawing.Point(355, 324);
            this.btnMadd.Name = "btnMadd";
            this.btnMadd.Size = new System.Drawing.Size(75, 30);
            this.btnMadd.TabIndex = 9;
            this.btnMadd.Text = "追加";
            this.btnMadd.UseVisualStyleBackColor = true;
            // 
            // btnMchange
            // 
            this.btnMchange.Location = new System.Drawing.Point(442, 324);
            this.btnMchange.Name = "btnMchange";
            this.btnMchange.Size = new System.Drawing.Size(79, 30);
            this.btnMchange.TabIndex = 10;
            this.btnMchange.Text = "変更";
            this.btnMchange.UseVisualStyleBackColor = true;
            // 
            // btnMdelete
            // 
            this.btnMdelete.Location = new System.Drawing.Point(537, 321);
            this.btnMdelete.Name = "btnMdelete";
            this.btnMdelete.Size = new System.Drawing.Size(79, 36);
            this.btnMdelete.TabIndex = 11;
            this.btnMdelete.Text = "削除";
            this.btnMdelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(593, 428);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "戻る";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGokanseiMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 481);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMdelete);
            this.Controls.Add(this.btnMchange);
            this.Controls.Add(this.btnMadd);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.lstModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSdelete);
            this.Controls.Add(this.btnSchange);
            this.Controls.Add(this.txtMemoryStandard);
            this.Controls.Add(this.btnSadd);
            this.Controls.Add(this.lstMemoryStandard);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGokanseiMemory";
            this.Text = "互換性管理メモリ";
            this.Load += new System.EventHandler(this.frmGokanseiMemory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMemoryStandard;
        private System.Windows.Forms.Button btnSadd;
        private System.Windows.Forms.TextBox txtMemoryStandard;
        private System.Windows.Forms.Button btnSchange;
        private System.Windows.Forms.Button btnSdelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstModule;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Button btnMadd;
        private System.Windows.Forms.Button btnMchange;
        private System.Windows.Forms.Button btnMdelete;
        private System.Windows.Forms.Button btnClose;
    }
}