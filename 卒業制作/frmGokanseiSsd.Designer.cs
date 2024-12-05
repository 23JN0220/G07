namespace 卒業制作
{
    partial class frmGokanseiSsd
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
            this.label2 = new System.Windows.Forms.Label();
            this.lstPlugs = new System.Windows.Forms.ListBox();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.btnSpAdd = new System.Windows.Forms.Button();
            this.btnSpChange = new System.Windows.Forms.Button();
            this.btnSpDelete = new System.Windows.Forms.Button();
            this.txtPlugs = new System.Windows.Forms.TextBox();
            this.btnPadd = new System.Windows.Forms.Button();
            this.btnPchange = new System.Windows.Forms.Button();
            this.btnPdelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstType = new System.Windows.Forms.ListBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnTadd = new System.Windows.Forms.Button();
            this.btnTchange = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTdelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "規格";
            // 
            // lstSpec
            // 
            this.lstSpec.FormattingEnabled = true;
            this.lstSpec.ItemHeight = 21;
            this.lstSpec.Location = new System.Drawing.Point(29, 58);
            this.lstSpec.Name = "lstSpec";
            this.lstSpec.Size = new System.Drawing.Size(120, 88);
            this.lstSpec.TabIndex = 1;
            this.lstSpec.SelectedIndexChanged += new System.EventHandler(this.lstSpec_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "接続方法";
            // 
            // lstPlugs
            // 
            this.lstPlugs.FormattingEnabled = true;
            this.lstPlugs.ItemHeight = 21;
            this.lstPlugs.Location = new System.Drawing.Point(29, 236);
            this.lstPlugs.Name = "lstPlugs";
            this.lstPlugs.Size = new System.Drawing.Size(120, 88);
            this.lstPlugs.TabIndex = 3;
            this.lstPlugs.SelectedIndexChanged += new System.EventHandler(this.lstPlugs_SelectedIndexChanged);
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(264, 58);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(237, 28);
            this.txtSpec.TabIndex = 4;
            // 
            // btnSpAdd
            // 
            this.btnSpAdd.Location = new System.Drawing.Point(264, 104);
            this.btnSpAdd.Name = "btnSpAdd";
            this.btnSpAdd.Size = new System.Drawing.Size(75, 32);
            this.btnSpAdd.TabIndex = 5;
            this.btnSpAdd.Text = "追加";
            this.btnSpAdd.UseVisualStyleBackColor = true;
            // 
            // btnSpChange
            // 
            this.btnSpChange.Location = new System.Drawing.Point(345, 104);
            this.btnSpChange.Name = "btnSpChange";
            this.btnSpChange.Size = new System.Drawing.Size(75, 32);
            this.btnSpChange.TabIndex = 6;
            this.btnSpChange.Text = "変更";
            this.btnSpChange.UseVisualStyleBackColor = true;
            // 
            // btnSpDelete
            // 
            this.btnSpDelete.Location = new System.Drawing.Point(426, 104);
            this.btnSpDelete.Name = "btnSpDelete";
            this.btnSpDelete.Size = new System.Drawing.Size(75, 32);
            this.btnSpDelete.TabIndex = 7;
            this.btnSpDelete.Text = "削除";
            this.btnSpDelete.UseVisualStyleBackColor = true;
            // 
            // txtPlugs
            // 
            this.txtPlugs.Location = new System.Drawing.Point(264, 208);
            this.txtPlugs.Name = "txtPlugs";
            this.txtPlugs.Size = new System.Drawing.Size(237, 28);
            this.txtPlugs.TabIndex = 8;
            // 
            // btnPadd
            // 
            this.btnPadd.Location = new System.Drawing.Point(264, 256);
            this.btnPadd.Name = "btnPadd";
            this.btnPadd.Size = new System.Drawing.Size(75, 32);
            this.btnPadd.TabIndex = 9;
            this.btnPadd.TabStop = false;
            this.btnPadd.Text = "追加";
            this.btnPadd.UseVisualStyleBackColor = true;
            // 
            // btnPchange
            // 
            this.btnPchange.Location = new System.Drawing.Point(345, 256);
            this.btnPchange.Name = "btnPchange";
            this.btnPchange.Size = new System.Drawing.Size(75, 32);
            this.btnPchange.TabIndex = 10;
            this.btnPchange.Text = "変更";
            this.btnPchange.UseVisualStyleBackColor = true;
            // 
            // btnPdelete
            // 
            this.btnPdelete.Location = new System.Drawing.Point(426, 256);
            this.btnPdelete.Name = "btnPdelete";
            this.btnPdelete.Size = new System.Drawing.Size(75, 32);
            this.btnPdelete.TabIndex = 11;
            this.btnPdelete.Text = "削除";
            this.btnPdelete.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "タイプ";
            // 
            // lstType
            // 
            this.lstType.FormattingEnabled = true;
            this.lstType.ItemHeight = 21;
            this.lstType.Location = new System.Drawing.Point(29, 414);
            this.lstType.Name = "lstType";
            this.lstType.Size = new System.Drawing.Size(120, 88);
            this.lstType.TabIndex = 13;
            this.lstType.SelectedIndexChanged += new System.EventHandler(this.lstType_SelectedIndexChanged);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(264, 414);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(237, 28);
            this.txtType.TabIndex = 14;
            // 
            // btnTadd
            // 
            this.btnTadd.Location = new System.Drawing.Point(264, 459);
            this.btnTadd.Name = "btnTadd";
            this.btnTadd.Size = new System.Drawing.Size(75, 31);
            this.btnTadd.TabIndex = 15;
            this.btnTadd.Text = "追加";
            this.btnTadd.UseVisualStyleBackColor = true;
            this.btnTadd.Click += new System.EventHandler(this.btnTadd_Click);
            // 
            // btnTchange
            // 
            this.btnTchange.Location = new System.Drawing.Point(345, 459);
            this.btnTchange.Name = "btnTchange";
            this.btnTchange.Size = new System.Drawing.Size(75, 31);
            this.btnTchange.TabIndex = 16;
            this.btnTchange.Text = "変更";
            this.btnTchange.UseVisualStyleBackColor = true;
            this.btnTchange.Click += new System.EventHandler(this.btnTchange_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnTdelete
            // 
            this.btnTdelete.Location = new System.Drawing.Point(426, 459);
            this.btnTdelete.Name = "btnTdelete";
            this.btnTdelete.Size = new System.Drawing.Size(75, 31);
            this.btnTdelete.TabIndex = 18;
            this.btnTdelete.Text = "削除";
            this.btnTdelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(426, 535);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "戻る";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGokanseiSsd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 635);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTdelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTchange);
            this.Controls.Add(this.btnTadd);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lstType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPdelete);
            this.Controls.Add(this.btnPchange);
            this.Controls.Add(this.btnPadd);
            this.Controls.Add(this.txtPlugs);
            this.Controls.Add(this.btnSpDelete);
            this.Controls.Add(this.btnSpChange);
            this.Controls.Add(this.btnSpAdd);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.lstPlugs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSpec);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGokanseiSsd";
            this.Text = "互換性SSD";
            this.Load += new System.EventHandler(this.frmGokanseiSsd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSpec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstPlugs;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Button btnSpAdd;
        private System.Windows.Forms.Button btnSpChange;
        private System.Windows.Forms.Button btnSpDelete;
        private System.Windows.Forms.TextBox txtPlugs;
        private System.Windows.Forms.Button btnPadd;
        private System.Windows.Forms.Button btnPchange;
        private System.Windows.Forms.Button btnPdelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnTadd;
        private System.Windows.Forms.Button btnTchange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTdelete;
        private System.Windows.Forms.Button btnClose;
    }
}