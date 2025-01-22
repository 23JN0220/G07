namespace 卒業制作
{
    partial class frmGokanseiCpu
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
            this.lstSeries = new System.Windows.Forms.ListBox();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.btnSeAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstGen = new System.Windows.Forms.ListBox();
            this.txtGen = new System.Windows.Forms.TextBox();
            this.btnSeChange = new System.Windows.Forms.Button();
            this.btnSeDelete = new System.Windows.Forms.Button();
            this.btnGadd = new System.Windows.Forms.Button();
            this.btnGchange = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGdelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstSocket = new System.Windows.Forms.ListBox();
            this.txtSocket = new System.Windows.Forms.TextBox();
            this.btnSoAdd = new System.Windows.Forms.Button();
            this.btnSoChange = new System.Windows.Forms.Button();
            this.btnSoDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstChipset = new System.Windows.Forms.ListBox();
            this.txtChipset = new System.Windows.Forms.TextBox();
            this.btnCadd = new System.Windows.Forms.Button();
            this.btnCchange = new System.Windows.Forms.Button();
            this.btnCdelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "シリーズ名";
            // 
            // lstSeries
            // 
            this.lstSeries.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstSeries.FormattingEnabled = true;
            this.lstSeries.ItemHeight = 21;
            this.lstSeries.Location = new System.Drawing.Point(28, 62);
            this.lstSeries.Margin = new System.Windows.Forms.Padding(2);
            this.lstSeries.Name = "lstSeries";
            this.lstSeries.Size = new System.Drawing.Size(186, 88);
            this.lstSeries.TabIndex = 1;
            this.lstSeries.SelectedIndexChanged += new System.EventHandler(this.lstSeries_SelectedIndexChanged);
            // 
            // txtSeries
            // 
            this.txtSeries.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSeries.Location = new System.Drawing.Point(258, 62);
            this.txtSeries.Margin = new System.Windows.Forms.Padding(2);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.Size = new System.Drawing.Size(198, 28);
            this.txtSeries.TabIndex = 2;
            // 
            // btnSeAdd
            // 
            this.btnSeAdd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSeAdd.Location = new System.Drawing.Point(254, 104);
            this.btnSeAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeAdd.Name = "btnSeAdd";
            this.btnSeAdd.Size = new System.Drawing.Size(65, 35);
            this.btnSeAdd.TabIndex = 3;
            this.btnSeAdd.Text = "追加";
            this.btnSeAdd.UseVisualStyleBackColor = true;
            this.btnSeAdd.Click += new System.EventHandler(this.btnSeAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(24, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "世代";
            // 
            // lstGen
            // 
            this.lstGen.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstGen.FormattingEnabled = true;
            this.lstGen.ItemHeight = 21;
            this.lstGen.Location = new System.Drawing.Point(28, 184);
            this.lstGen.Margin = new System.Windows.Forms.Padding(2);
            this.lstGen.Name = "lstGen";
            this.lstGen.Size = new System.Drawing.Size(186, 88);
            this.lstGen.TabIndex = 6;
            this.lstGen.SelectedIndexChanged += new System.EventHandler(this.lstGen_SelectedIndexChanged);
            // 
            // txtGen
            // 
            this.txtGen.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtGen.Location = new System.Drawing.Point(254, 184);
            this.txtGen.Margin = new System.Windows.Forms.Padding(2);
            this.txtGen.Name = "txtGen";
            this.txtGen.Size = new System.Drawing.Size(198, 28);
            this.txtGen.TabIndex = 7;
            // 
            // btnSeChange
            // 
            this.btnSeChange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSeChange.Location = new System.Drawing.Point(323, 104);
            this.btnSeChange.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeChange.Name = "btnSeChange";
            this.btnSeChange.Size = new System.Drawing.Size(61, 35);
            this.btnSeChange.TabIndex = 4;
            this.btnSeChange.Text = "変更";
            this.btnSeChange.UseVisualStyleBackColor = true;
            this.btnSeChange.Click += new System.EventHandler(this.btnSeChange_Click);
            // 
            // btnSeDelete
            // 
            this.btnSeDelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSeDelete.Location = new System.Drawing.Point(388, 104);
            this.btnSeDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeDelete.Name = "btnSeDelete";
            this.btnSeDelete.Size = new System.Drawing.Size(61, 35);
            this.btnSeDelete.TabIndex = 5;
            this.btnSeDelete.Text = "削除";
            this.btnSeDelete.UseVisualStyleBackColor = true;
            this.btnSeDelete.Click += new System.EventHandler(this.btnSeDelete_Click);
            // 
            // btnGadd
            // 
            this.btnGadd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnGadd.Location = new System.Drawing.Point(254, 225);
            this.btnGadd.Margin = new System.Windows.Forms.Padding(2);
            this.btnGadd.Name = "btnGadd";
            this.btnGadd.Size = new System.Drawing.Size(61, 33);
            this.btnGadd.TabIndex = 8;
            this.btnGadd.Text = "追加";
            this.btnGadd.UseVisualStyleBackColor = true;
            this.btnGadd.Click += new System.EventHandler(this.btnGadd_Click);
            // 
            // btnGchange
            // 
            this.btnGchange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnGchange.Location = new System.Drawing.Point(323, 225);
            this.btnGchange.Margin = new System.Windows.Forms.Padding(2);
            this.btnGchange.Name = "btnGchange";
            this.btnGchange.Size = new System.Drawing.Size(61, 33);
            this.btnGchange.TabIndex = 9;
            this.btnGchange.Text = "変更";
            this.btnGchange.UseVisualStyleBackColor = true;
            this.btnGchange.Click += new System.EventHandler(this.btnGchange_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 194);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(7, 6);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnGdelete
            // 
            this.btnGdelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnGdelete.Location = new System.Drawing.Point(394, 225);
            this.btnGdelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnGdelete.Name = "btnGdelete";
            this.btnGdelete.Size = new System.Drawing.Size(61, 33);
            this.btnGdelete.TabIndex = 10;
            this.btnGdelete.Text = "削除";
            this.btnGdelete.UseVisualStyleBackColor = true;
            this.btnGdelete.Click += new System.EventHandler(this.btnGdelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(24, 285);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "ソケット名";
            // 
            // lstSocket
            // 
            this.lstSocket.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstSocket.FormattingEnabled = true;
            this.lstSocket.ItemHeight = 21;
            this.lstSocket.Location = new System.Drawing.Point(28, 306);
            this.lstSocket.Margin = new System.Windows.Forms.Padding(2);
            this.lstSocket.Name = "lstSocket";
            this.lstSocket.Size = new System.Drawing.Size(186, 88);
            this.lstSocket.TabIndex = 11;
            this.lstSocket.SelectedIndexChanged += new System.EventHandler(this.lstSocket_SelectedIndexChanged);
            // 
            // txtSocket
            // 
            this.txtSocket.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSocket.Location = new System.Drawing.Point(258, 306);
            this.txtSocket.Margin = new System.Windows.Forms.Padding(2);
            this.txtSocket.Name = "txtSocket";
            this.txtSocket.Size = new System.Drawing.Size(198, 28);
            this.txtSocket.TabIndex = 12;
            // 
            // btnSoAdd
            // 
            this.btnSoAdd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSoAdd.Location = new System.Drawing.Point(258, 348);
            this.btnSoAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoAdd.Name = "btnSoAdd";
            this.btnSoAdd.Size = new System.Drawing.Size(61, 33);
            this.btnSoAdd.TabIndex = 13;
            this.btnSoAdd.Text = "追加";
            this.btnSoAdd.UseVisualStyleBackColor = true;
            this.btnSoAdd.Click += new System.EventHandler(this.btnSoAdd_Click);
            // 
            // btnSoChange
            // 
            this.btnSoChange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSoChange.Location = new System.Drawing.Point(323, 348);
            this.btnSoChange.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoChange.Name = "btnSoChange";
            this.btnSoChange.Size = new System.Drawing.Size(61, 33);
            this.btnSoChange.TabIndex = 14;
            this.btnSoChange.Text = "変更";
            this.btnSoChange.UseVisualStyleBackColor = true;
            this.btnSoChange.Click += new System.EventHandler(this.btnSoChange_Click);
            // 
            // btnSoDelete
            // 
            this.btnSoDelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSoDelete.Location = new System.Drawing.Point(395, 348);
            this.btnSoDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoDelete.Name = "btnSoDelete";
            this.btnSoDelete.Size = new System.Drawing.Size(61, 33);
            this.btnSoDelete.TabIndex = 15;
            this.btnSoDelete.Text = "削除";
            this.btnSoDelete.UseVisualStyleBackColor = true;
            this.btnSoDelete.Click += new System.EventHandler(this.btnSoDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(24, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "チップセットシリーズ";
            // 
            // lstChipset
            // 
            this.lstChipset.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstChipset.FormattingEnabled = true;
            this.lstChipset.ItemHeight = 21;
            this.lstChipset.Location = new System.Drawing.Point(28, 432);
            this.lstChipset.Name = "lstChipset";
            this.lstChipset.Size = new System.Drawing.Size(186, 88);
            this.lstChipset.TabIndex = 16;
            this.lstChipset.SelectedIndexChanged += new System.EventHandler(this.lstChipset_SelectedIndexChanged);
            // 
            // txtChipset
            // 
            this.txtChipset.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtChipset.Location = new System.Drawing.Point(257, 432);
            this.txtChipset.Name = "txtChipset";
            this.txtChipset.Size = new System.Drawing.Size(198, 28);
            this.txtChipset.TabIndex = 17;
            // 
            // btnCadd
            // 
            this.btnCadd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCadd.Location = new System.Drawing.Point(254, 466);
            this.btnCadd.Name = "btnCadd";
            this.btnCadd.Size = new System.Drawing.Size(61, 35);
            this.btnCadd.TabIndex = 18;
            this.btnCadd.Text = "追加";
            this.btnCadd.UseVisualStyleBackColor = true;
            this.btnCadd.Click += new System.EventHandler(this.btnCadd_Click);
            // 
            // btnCchange
            // 
            this.btnCchange.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCchange.Location = new System.Drawing.Point(323, 466);
            this.btnCchange.Name = "btnCchange";
            this.btnCchange.Size = new System.Drawing.Size(61, 35);
            this.btnCchange.TabIndex = 19;
            this.btnCchange.Text = "変更";
            this.btnCchange.UseVisualStyleBackColor = true;
            this.btnCchange.Click += new System.EventHandler(this.btnCchange_Click);
            // 
            // btnCdelete
            // 
            this.btnCdelete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCdelete.Location = new System.Drawing.Point(390, 467);
            this.btnCdelete.Name = "btnCdelete";
            this.btnCdelete.Size = new System.Drawing.Size(62, 32);
            this.btnCdelete.TabIndex = 20;
            this.btnCdelete.Text = "削除";
            this.btnCdelete.UseVisualStyleBackColor = true;
            this.btnCdelete.Click += new System.EventHandler(this.btnCdelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.Location = new System.Drawing.Point(373, 525);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(82, 38);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmGokanseiCpu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 575);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCdelete);
            this.Controls.Add(this.btnCchange);
            this.Controls.Add(this.btnCadd);
            this.Controls.Add(this.txtChipset);
            this.Controls.Add(this.lstChipset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSoDelete);
            this.Controls.Add(this.btnSoChange);
            this.Controls.Add(this.btnSoAdd);
            this.Controls.Add(this.txtSocket);
            this.Controls.Add(this.lstSocket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGdelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGchange);
            this.Controls.Add(this.btnGadd);
            this.Controls.Add(this.btnSeDelete);
            this.Controls.Add(this.btnSeChange);
            this.Controls.Add(this.txtGen);
            this.Controls.Add(this.lstGen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSeAdd);
            this.Controls.Add(this.txtSeries);
            this.Controls.Add(this.lstSeries);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmGokanseiCpu";
            this.Text = "互換性管理CPU";
            this.Load += new System.EventHandler(this.frmGokanseiCpu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSeries;
        private System.Windows.Forms.TextBox txtSeries;
        private System.Windows.Forms.Button btnSeAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstGen;
        private System.Windows.Forms.TextBox txtGen;
        private System.Windows.Forms.Button btnSeChange;
        private System.Windows.Forms.Button btnSeDelete;
        private System.Windows.Forms.Button btnGadd;
        private System.Windows.Forms.Button btnGchange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGdelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstSocket;
        private System.Windows.Forms.TextBox txtSocket;
        private System.Windows.Forms.Button btnSoAdd;
        private System.Windows.Forms.Button btnSoChange;
        private System.Windows.Forms.Button btnSoDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstChipset;
        private System.Windows.Forms.TextBox txtChipset;
        private System.Windows.Forms.Button btnCadd;
        private System.Windows.Forms.Button btnCchange;
        private System.Windows.Forms.Button btnCdelete;
        private System.Windows.Forms.Button btnBack;
    }
}