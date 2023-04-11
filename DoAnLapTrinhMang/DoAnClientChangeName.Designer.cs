
namespace DoAnLapTrinhMang
{
    partial class DoAnClientChangeName
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
            this.tbNewAccountName = new System.Windows.Forms.TextBox();
            this.lbNewName = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.btApply = new System.Windows.Forms.Button();
            this.lbConfirmPassword = new System.Windows.Forms.Label();
            this.lbNofication = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbNewAccountName
            // 
            this.tbNewAccountName.Location = new System.Drawing.Point(118, 29);
            this.tbNewAccountName.Name = "tbNewAccountName";
            this.tbNewAccountName.Size = new System.Drawing.Size(200, 20);
            this.tbNewAccountName.TabIndex = 0;
            this.tbNewAccountName.TextChanged += new System.EventHandler(this.tbNewAccountName_TextChanged);
            // 
            // lbNewName
            // 
            this.lbNewName.AutoSize = true;
            this.lbNewName.Location = new System.Drawing.Point(12, 32);
            this.lbNewName.Name = "lbNewName";
            this.lbNewName.Size = new System.Drawing.Size(92, 13);
            this.lbNewName.TabIndex = 1;
            this.lbNewName.Text = "Tên tài khoản mới";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(118, 67);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(200, 20);
            this.tbConfirmPassword.TabIndex = 2;
            this.tbConfirmPassword.TextChanged += new System.EventHandler(this.tbConfirmPassword_TextChanged);
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(249, 111);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(69, 23);
            this.btApply.TabIndex = 3;
            this.btApply.Text = "Đổi tên";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.AutoSize = true;
            this.lbConfirmPassword.Location = new System.Drawing.Point(12, 70);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(100, 13);
            this.lbConfirmPassword.TabIndex = 4;
            this.lbConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // lbNofication
            // 
            this.lbNofication.AutoSize = true;
            this.lbNofication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNofication.ForeColor = System.Drawing.Color.Red;
            this.lbNofication.Location = new System.Drawing.Point(12, 116);
            this.lbNofication.Name = "lbNofication";
            this.lbNofication.Size = new System.Drawing.Size(68, 13);
            this.lbNofication.TabIndex = 5;
            this.lbNofication.Text = "Thông báo";
            this.lbNofication.Visible = false;
            // 
            // DoAnClientChangeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 146);
            this.Controls.Add(this.lbNofication);
            this.Controls.Add(this.lbConfirmPassword);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lbNewName);
            this.Controls.Add(this.tbNewAccountName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DoAnClientChangeName";
            this.Text = "Đổi tên tài khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoAnClientChangeName_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNewAccountName;
        private System.Windows.Forms.Label lbNewName;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Label lbConfirmPassword;
        private System.Windows.Forms.Label lbNofication;
    }
}