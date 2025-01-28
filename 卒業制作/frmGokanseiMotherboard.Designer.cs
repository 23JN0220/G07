namespace 卒業制作
{
    partial class frmGokanseiMotherboard
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
            this.lstChipset = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChipset = new System.Windows.Forms.TextBox();
            this.btnCadd = new System.Windows.Forms.Button();
            this.btnCchange = new System.Windows.Forms.Button();
            this.btnCdelete = new System.Windows.Forms.Button();
            this.lstSize = new System.Windows.Forms.ListBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnSadd = new System.Windows.Forms.Button();
            this.btnSchange = new System.Windows.Forms.Button();
            this.btnSdelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstWirelessLan = new System.Windows.Forms.ListBox();
            this.txtWirelessLan = new System.Windows.Forms.TextBox();
            this.btnSpAdd = new System.Windows.Forms.Button();
            this.btnSpChange = new System.Windows.Forms.Button();
            this.btnSpDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(13, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "チップセット";
            // 
            // lstChipset
            // 
            this.lstChipset.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstChipset.FormattingEnabled = true;
            this.lstChipset.ItemHeight = 21;
            this.lstChipset.Location = new System.Drawing.Point(16, 122);
            this.lstChipset.Margin = new System.Windows.Forms.Padding(2);
            this.lstChipset.Name = "lstChipset";
            this.lstChipset.Size = new System.Drawing.Size(155, 88);
            this.lstChipset.TabIndex = 1;
            this.lstChipset.SelectedIndexChanged += new System.EventHandler(this.lstChipset_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 221);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "大きさ";
            // 
            // txtChipset
            // 
            this.txtChipset.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtChipset.Location = new System.Drawing.Point(243, 122);
            this.txtChipset.Margin = new System.Windows.Forms.Padding(2);
            this.txtChipset.Name = "txtChipset";
            this.txtChipset.Size = new System.Drawing.Size(225, 28);
            this.txtChipset.TabIndex = 3;
            // 
            // btnCadd
            // 
            this.btnCadd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCadd.Location = new System.Drawing.Point(243, 157);
            this.btnCadd.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadd.Name = "btnCadd";
            this.btnCadd.Size = new System.Drawing.Size(61, 39);
            this.btnCadd.TabIndex = 4;
            this.btnCadd.Text = "追加";
            this.btnCadd.UseVisualStyleBackColor = true;
            this.btnCadd.Click += new System.EventHandler(this.btnCadd_Click);
            // 
            // btnCchange
            // 
            this.btnCchange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCchange.Location = new System.Drawing.Point(320, 157);
            this.btnCchange.Margin = new System.Windows.Forms.Padding(2);
            this.btnCchange.Name = "btnCchange";
            this.btnCchange.Size = new System.Drawing.Size(61, 39);
            this.btnCchange.TabIndex = 5;
            this.btnCchange.Text = "変更";
            this.btnCchange.UseVisualStyleBackColor = true;
            this.btnCchange.Click += new System.EventHandler(this.btnCchange_Click);
            // 
            // btnCdelete
            // 
            this.btnCdelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCdelete.Location = new System.Drawing.Point(406, 157);
            this.btnCdelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnCdelete.Name = "btnCdelete";
            this.btnCdelete.Size = new System.Drawing.Size(61, 39);
            this.btnCdelete.TabIndex = 6;
            this.btnCdelete.Text = "削除";
            this.btnCdelete.UseVisualStyleBackColor = true;
            this.btnCdelete.Click += new System.EventHandler(this.btnCdelete_Click);
            // 
            // lstSize
            // 
            this.lstSize.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstSize.FormattingEnabled = true;
            this.lstSize.ItemHeight = 21;
            this.lstSize.Location = new System.Drawing.Point(16, 244);
            this.lstSize.Margin = new System.Windows.Forms.Padding(2);
            this.lstSize.Name = "lstSize";
            this.lstSize.Size = new System.Drawing.Size(155, 88);
            this.lstSize.TabIndex = 7;
            this.lstSize.SelectedIndexChanged += new System.EventHandler(this.lstSize_SelectedIndexChanged);
            // 
            // txtSize
            // 
            this.txtSize.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSize.Location = new System.Drawing.Point(242, 244);
            this.txtSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(225, 28);
            this.txtSize.TabIndex = 8;
            // 
            // btnSadd
            // 
            this.btnSadd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSadd.Location = new System.Drawing.Point(243, 294);
            this.btnSadd.Margin = new System.Windows.Forms.Padding(2);
            this.btnSadd.Name = "btnSadd";
            this.btnSadd.Size = new System.Drawing.Size(61, 38);
            this.btnSadd.TabIndex = 9;
            this.btnSadd.Text = "追加";
            this.btnSadd.UseVisualStyleBackColor = true;
            this.btnSadd.Click += new System.EventHandler(this.btnSadd_Click);
            // 
            // btnSchange
            // 
            this.btnSchange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSchange.Location = new System.Drawing.Point(320, 294);
            this.btnSchange.Margin = new System.Windows.Forms.Padding(2);
            this.btnSchange.Name = "btnSchange";
            this.btnSchange.Size = new System.Drawing.Size(61, 38);
            this.btnSchange.TabIndex = 10;
            this.btnSchange.Text = "変更";
            this.btnSchange.UseVisualStyleBackColor = true;
            this.btnSchange.Click += new System.EventHandler(this.btnSchange_Click);
            // 
            // btnSdelete
            // 
            this.btnSdelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSdelete.Location = new System.Drawing.Point(407, 294);
            this.btnSdelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnSdelete.Name = "btnSdelete";
            this.btnSdelete.Size = new System.Drawing.Size(61, 38);
            this.btnSdelete.TabIndex = 11;
            this.btnSdelete.Text = "削除";
            this.btnSdelete.UseVisualStyleBackColor = true;
            this.btnSdelete.Click += new System.EventHandler(this.btnSdelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 342);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "無線LANの規格";
            // 
            // lstWirelessLan
            // 
            this.lstWirelessLan.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstWirelessLan.FormattingEnabled = true;
            this.lstWirelessLan.ItemHeight = 21;
            this.lstWirelessLan.Location = new System.Drawing.Point(16, 365);
            this.lstWirelessLan.Margin = new System.Windows.Forms.Padding(2);
            this.lstWirelessLan.Name = "lstWirelessLan";
            this.lstWirelessLan.Size = new System.Drawing.Size(155, 88);
            this.lstWirelessLan.TabIndex = 13;
            this.lstWirelessLan.SelectedIndexChanged += new System.EventHandler(this.lstWirelessLan_SelectedIndexChanged);
            // 
            // txtWirelessLan
            // 
            this.txtWirelessLan.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtWirelessLan.Location = new System.Drawing.Point(242, 365);
            this.txtWirelessLan.Margin = new System.Windows.Forms.Padding(2);
            this.txtWirelessLan.Name = "txtWirelessLan";
            this.txtWirelessLan.Size = new System.Drawing.Size(225, 28);
            this.txtWirelessLan.TabIndex = 14;
            // 
            // btnSpAdd
            // 
            this.btnSpAdd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSpAdd.Location = new System.Drawing.Point(243, 408);
            this.btnSpAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpAdd.Name = "btnSpAdd";
            this.btnSpAdd.Size = new System.Drawing.Size(61, 35);
            this.btnSpAdd.TabIndex = 15;
            this.btnSpAdd.Text = "追加";
            this.btnSpAdd.UseVisualStyleBackColor = true;
            this.btnSpAdd.Click += new System.EventHandler(this.btnSpAdd_Click);
            // 
            // btnSpChange
            // 
            this.btnSpChange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSpChange.Location = new System.Drawing.Point(320, 408);
            this.btnSpChange.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpChange.Name = "btnSpChange";
            this.btnSpChange.Size = new System.Drawing.Size(61, 35);
            this.btnSpChange.TabIndex = 16;
            this.btnSpChange.Text = "変更";
            this.btnSpChange.UseVisualStyleBackColor = true;
            this.btnSpChange.Click += new System.EventHandler(this.btnSpChange_Click);
            // 
            // btnSpDelete
            // 
            this.btnSpDelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSpDelete.Location = new System.Drawing.Point(407, 408);
            this.btnSpDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpDelete.Name = "btnSpDelete";
            this.btnSpDelete.Size = new System.Drawing.Size(61, 35);
            this.btnSpDelete.TabIndex = 17;
            this.btnSpDelete.Text = "削除";
            this.btnSpDelete.UseVisualStyleBackColor = true;
            this.btnSpDelete.Click += new System.EventHandler(this.btnSpDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(15, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "チップセットシリーズ/ソケット";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(14, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(426, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "チップセットシリーズ/ソケットの登録はCPU登録画面で行ってください";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(14, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 20;
            this.label6.Text = "M.2規格";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 568);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(312, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "M.2規格の登録はSSD登録画面で行ってください";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(14, 604);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "メモリ規格";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 638);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(323, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "メモリ規格の登録はメモリ登録画面で行ってください";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(406, 604);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 35);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "戻る";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(354, 63);
            this.label10.TabIndex = 25;
            this.label10.Text = "項目を削除する場合は\r\n左の表から削除したい項目を選択してから\r\n削除ボタンを押してください";
            // 
            // frmGokanseiMotherboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 671);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSpDelete);
            this.Controls.Add(this.btnSpChange);
            this.Controls.Add(this.btnSpAdd);
            this.Controls.Add(this.txtWirelessLan);
            this.Controls.Add(this.lstWirelessLan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSdelete);
            this.Controls.Add(this.btnSchange);
            this.Controls.Add(this.btnSadd);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lstSize);
            this.Controls.Add(this.btnCdelete);
            this.Controls.Add(this.btnCchange);
            this.Controls.Add(this.btnCadd);
            this.Controls.Add(this.txtChipset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstChipset);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmGokanseiMotherboard";
            this.Text = "互換性管理マザーボード";
            this.Load += new System.EventHandler(this.frmGokanseiMotherboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstChipset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChipset;
        private System.Windows.Forms.Button btnCadd;
        private System.Windows.Forms.Button btnCchange;
        private System.Windows.Forms.Button btnCdelete;
        private System.Windows.Forms.ListBox lstSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnSadd;
        private System.Windows.Forms.Button btnSchange;
        private System.Windows.Forms.Button btnSdelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstWirelessLan;
        private System.Windows.Forms.TextBox txtWirelessLan;
        private System.Windows.Forms.Button btnSpAdd;
        private System.Windows.Forms.Button btnSpChange;
        private System.Windows.Forms.Button btnSpDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label10;
    }
}