namespace 卒業制作
{
    partial class payment
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditcard_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.convenience_store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymented = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "支払い番号";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(211, 18);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(183, 28);
            this.txtNumber.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(400, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(651, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvPayment
            // 
            this.dgvPayment.AllowUserToDeleteRows = false;
            this.dgvPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPayment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_id,
            this.order_date,
            this.member_id,
            this.price,
            this.creditcard_number,
            this.convenience_store,
            this.paymented});
            this.dgvPayment.Location = new System.Drawing.Point(48, 83);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowTemplate.Height = 21;
            this.dgvPayment.Size = new System.Drawing.Size(751, 283);
            this.dgvPayment.TabIndex = 4;
            // 
            // order_id
            // 
            this.order_id.DataPropertyName = "order_id";
            this.order_id.HeaderText = "注文番号";
            this.order_id.Name = "order_id";
            this.order_id.Width = 90;
            // 
            // order_date
            // 
            this.order_date.DataPropertyName = "order_date";
            this.order_date.HeaderText = "注文日時";
            this.order_date.Name = "order_date";
            this.order_date.Width = 90;
            // 
            // member_id
            // 
            this.member_id.DataPropertyName = "member_id";
            this.member_id.HeaderText = "会員番号";
            this.member_id.Name = "member_id";
            this.member_id.Width = 90;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "合計金額";
            this.price.Name = "price";
            this.price.Width = 90;
            // 
            // creditcard_number
            // 
            this.creditcard_number.DataPropertyName = "creditcard_number";
            this.creditcard_number.HeaderText = "カード番号";
            this.creditcard_number.Name = "creditcard_number";
            this.creditcard_number.Width = 95;
            // 
            // convenience_store
            // 
            this.convenience_store.DataPropertyName = "convenience_store";
            this.convenience_store.HeaderText = "コンビニ名";
            this.convenience_store.Name = "convenience_store";
            this.convenience_store.Width = 89;
            // 
            // paymented
            // 
            this.paymented.DataPropertyName = "paymented";
            this.paymented.HeaderText = "支払い済み";
            this.paymented.Name = "paymented";
            this.paymented.Width = 106;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(663, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 37);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 459);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPayment);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "payment";
            this.Text = "支払い管理画面";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn member_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditcard_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn convenience_store;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymented;
        private System.Windows.Forms.Button btnClose;
    }
}