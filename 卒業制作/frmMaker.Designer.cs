namespace 卒業制作
{
    partial class frmMaker
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
            this.txtMaker_Name = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvMaker = new System.Windows.Forms.DataGridView();
            this.maker_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maker_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMakerChange = new System.Windows.Forms.Button();
            this.btnAddMaker = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaker)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "メーカー名";
            // 
            // txtMaker_Name
            // 
            this.txtMaker_Name.Location = new System.Drawing.Point(185, 32);
            this.txtMaker_Name.Name = "txtMaker_Name";
            this.txtMaker_Name.Size = new System.Drawing.Size(186, 28);
            this.txtMaker_Name.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(389, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(519, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 34);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvMaker
            // 
            this.dgvMaker.AllowUserToAddRows = false;
            this.dgvMaker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMaker.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMaker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maker_id,
            this.maker_Name});
            this.dgvMaker.Location = new System.Drawing.Point(54, 72);
            this.dgvMaker.Name = "dgvMaker";
            this.dgvMaker.RowTemplate.Height = 21;
            this.dgvMaker.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaker.Size = new System.Drawing.Size(420, 205);
            this.dgvMaker.TabIndex = 4;
            // 
            // maker_id
            // 
            this.maker_id.DataPropertyName = "maker_id";
            this.maker_id.HeaderText = "メーカー番号";
            this.maker_id.Name = "maker_id";
            this.maker_id.ReadOnly = true;
            this.maker_id.Width = 141;
            // 
            // maker_name
            // 
            this.maker_Name.DataPropertyName = "maker_name";
            this.maker_Name.HeaderText = "メーカー名";
            this.maker_Name.Name = "maker_name";
            this.maker_Name.ReadOnly = true;
            this.maker_Name.Width = 120;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(500, 351);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMakerChange
            // 
            this.btnMakerChange.Location = new System.Drawing.Point(385, 295);
            this.btnMakerChange.Name = "btnMakerChange";
            this.btnMakerChange.Size = new System.Drawing.Size(89, 38);
            this.btnMakerChange.TabIndex = 6;
            this.btnMakerChange.Text = "編集";
            this.btnMakerChange.UseVisualStyleBackColor = true;
            // 
            // btnAddMaker
            // 
            this.btnAddMaker.Location = new System.Drawing.Point(54, 295);
            this.btnAddMaker.Name = "btnAddMaker";
            this.btnAddMaker.Size = new System.Drawing.Size(92, 34);
            this.btnAddMaker.TabIndex = 7;
            this.btnAddMaker.Text = "追加";
            this.btnAddMaker.UseVisualStyleBackColor = true;
            this.btnAddMaker.Click += new System.EventHandler(this.btnAddMaker_Click);
            // 
            // frmMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 401);
            this.Controls.Add(this.btnAddMaker);
            this.Controls.Add(this.btnMakerChange);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvMaker);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMaker_Name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmMaker";
            this.Text = "メーカー管理";
            this.Load += new System.EventHandler(this.frmMeker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaker_Name;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvMaker;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMakerChange;
        private System.Windows.Forms.Button btnAddMaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn maker_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn maker_Name;
    }
}