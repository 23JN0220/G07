namespace 卒業制作
{
    partial class frmGokanseiWarning
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
            this.dgvGoods = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.goods_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGoods
            // 
            this.dgvGoods.AllowUserToAddRows = false;
            this.dgvGoods.AllowUserToDeleteRows = false;
            this.dgvGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGoods.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goods_code,
            this.goods_name});
            this.dgvGoods.Location = new System.Drawing.Point(12, 54);
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.RowTemplate.Height = 21;
            this.dgvGoods.Size = new System.Drawing.Size(584, 371);
            this.dgvGoods.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "削除しようとしている項目は、現在商品に使用されている項目です\r\nこの項目を削除する前に、以下の商品の登録データを変更してください\r\n";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(243, 431);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 33);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // goods_code
            // 
            this.goods_code.DataPropertyName = "goods_code";
            this.goods_code.HeaderText = "商品番号";
            this.goods_code.Name = "goods_code";
            this.goods_code.Width = 90;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "商品名";
            this.goods_name.Name = "goods_name";
            this.goods_name.Width = 90;
            // 
            // FrmGokanseiWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 472);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGoods);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmGokanseiWarning";
            this.Text = "互換性管理";
            this.Load += new System.EventHandler(this.FrmGokanseiWarning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGoods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
    }
}