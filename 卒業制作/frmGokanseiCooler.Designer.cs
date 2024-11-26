namespace 卒業制作
{
    partial class frmGokanseiCooler
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
            this.lstType = new System.Windows.Forms.ListBox();
            this.txtCPUcooler = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCPUcAdd = new System.Windows.Forms.Button();
            this.btnCPUcChange = new System.Windows.Forms.Button();
            this.btnCPUcdelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "種類";
            // 
            // lstType
            // 
            this.lstType.FormattingEnabled = true;
            this.lstType.ItemHeight = 21;
            this.lstType.Location = new System.Drawing.Point(61, 52);
            this.lstType.Name = "lstType";
            this.lstType.Size = new System.Drawing.Size(120, 88);
            this.lstType.TabIndex = 1;
            // 
            // txtCPUcooler
            // 
            this.txtCPUcooler.Location = new System.Drawing.Point(278, 52);
            this.txtCPUcooler.Name = "txtCPUcooler";
            this.txtCPUcooler.ReadOnly = true;
            this.txtCPUcooler.Size = new System.Drawing.Size(244, 28);
            this.txtCPUcooler.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "対応ソケット";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(438, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "対応ソケットの登録はCPU登録画面で行ってください";
            // 
            // btnCPUcAdd
            // 
            this.btnCPUcAdd.Location = new System.Drawing.Point(278, 99);
            this.btnCPUcAdd.Name = "btnCPUcAdd";
            this.btnCPUcAdd.Size = new System.Drawing.Size(75, 27);
            this.btnCPUcAdd.TabIndex = 5;
            this.btnCPUcAdd.Text = "追加";
            this.btnCPUcAdd.UseVisualStyleBackColor = true;
            // 
            // btnCPUcChange
            // 
            this.btnCPUcChange.Location = new System.Drawing.Point(369, 99);
            this.btnCPUcChange.Name = "btnCPUcChange";
            this.btnCPUcChange.Size = new System.Drawing.Size(75, 27);
            this.btnCPUcChange.TabIndex = 6;
            this.btnCPUcChange.Text = "変更";
            this.btnCPUcChange.UseVisualStyleBackColor = true;
            // 
            // btnCPUcdelete
            // 
            this.btnCPUcdelete.Location = new System.Drawing.Point(459, 99);
            this.btnCPUcdelete.Name = "btnCPUcdelete";
            this.btnCPUcdelete.Size = new System.Drawing.Size(75, 27);
            this.btnCPUcdelete.TabIndex = 7;
            this.btnCPUcdelete.Text = "削除";
            this.btnCPUcdelete.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(429, 343);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // frmGokianseiCooler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 429);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCPUcdelete);
            this.Controls.Add(this.btnCPUcChange);
            this.Controls.Add(this.btnCPUcAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCPUcooler);
            this.Controls.Add(this.lstType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmGokianseiCooler";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstType;
        private System.Windows.Forms.TextBox txtCPUcooler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCPUcAdd;
        private System.Windows.Forms.Button btnCPUcChange;
        private System.Windows.Forms.Button btnCPUcdelete;
        private System.Windows.Forms.Button btnBack;
    }
}