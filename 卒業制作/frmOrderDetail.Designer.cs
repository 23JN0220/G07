namespace 卒業制作
{
    partial class frmOrderDetail
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
            this.txtSearchNumber = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.goods_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ouder_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "注文番号検索";
            // 
            // txtSearchNumber
            // 
            this.txtSearchNumber.Location = new System.Drawing.Point(16, 46);
            this.txtSearchNumber.Name = "txtSearchNumber";
            this.txtSearchNumber.Size = new System.Drawing.Size(293, 28);
            this.txtSearchNumber.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(355, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goods_code,
            this.num,
            this.ouder_id});
            this.dgvOrder.Location = new System.Drawing.Point(12, 108);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowTemplate.Height = 21;
            this.dgvOrder.Size = new System.Drawing.Size(569, 243);
            this.dgvOrder.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(461, 363);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 32);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // goods_code
            // 
            this.goods_code.DataPropertyName = "goods_code";
            this.goods_code.HeaderText = "商品番号";
            this.goods_code.Name = "goods_code";
            this.goods_code.Width = 119;
            // 
            // num
            // 
            this.num.DataPropertyName = "num";
            this.num.HeaderText = "個数";
            this.num.Name = "num";
            this.num.Width = 77;
            // 
            // ouder_id
            // 
            this.ouder_id.DataPropertyName = "ouder_id";
            this.ouder_id.HeaderText = "注文番号";
            this.ouder_id.Name = "ouder_id";
            this.ouder_id.Width = 119;
            // 
            // frmOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 407);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmOrderDetail";
            this.Text = "注文管理画面";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn ouder_id;
    }
}