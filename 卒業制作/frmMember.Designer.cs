namespace 卒業制作
{
    partial class frmMember
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.member_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.brnSerch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(557, 87);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvMember
            // 
            this.dgvMember.AllowUserToAddRows = false;
            this.dgvMember.AllowUserToDeleteRows = false;
            this.dgvMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMember.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.member_id,
            this.tel,
            this.member_name,
            this.email});
            this.dgvMember.Location = new System.Drawing.Point(101, 123);
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.RowTemplate.Height = 21;
            this.dgvMember.Size = new System.Drawing.Size(539, 258);
            this.dgvMember.TabIndex = 2;
            // 
            // member_id
            // 
            this.member_id.DataPropertyName = "member_id";
            this.member_id.HeaderText = "会員番号";
            this.member_id.Name = "member_id";
            this.member_id.Width = 119;
            // 
            // tel
            // 
            this.tel.DataPropertyName = "tel";
            this.tel.HeaderText = "電話番号";
            this.tel.Name = "tel";
            this.tel.Width = 119;
            // 
            // member_name
            // 
            this.member_name.DataPropertyName = "member_name";
            this.member_name.HeaderText = "会員名";
            this.member_name.Name = "member_name";
            this.member_name.Width = 98;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "メールアドレス";
            this.email.Name = "email";
            this.email.Width = 147;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(537, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtMember
            // 
            this.txtMember.Location = new System.Drawing.Point(143, 41);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(235, 28);
            this.txtMember.TabIndex = 5;
            // 
            // brnSerch
            // 
            this.brnSerch.Location = new System.Drawing.Point(417, 42);
            this.brnSerch.Name = "brnSerch";
            this.brnSerch.Size = new System.Drawing.Size(84, 27);
            this.brnSerch.TabIndex = 6;
            this.brnSerch.Text = "検索";
            this.brnSerch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "会員番号";
            // 
            // frmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.brnSerch);
            this.Controls.Add(this.txtMember);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvMember);
            this.Controls.Add(this.btnDelete);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmMember";
            this.Text = "会員管理画面";
            this.Shown += new System.EventHandler(this.frmMember_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn member_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn member_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.Button brnSerch;
        private System.Windows.Forms.Label label1;
    }
}