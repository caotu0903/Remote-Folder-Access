
namespace DoAnLapTrinhMang
{
    partial class DoAnClientAdminCreateAccount
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
            this.lbNofication = new System.Windows.Forms.Label();
            this.btCreate = new System.Windows.Forms.Button();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.lbXacNhanMK = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbMK = new System.Windows.Forms.Label();
            this.tbAccountName = new System.Windows.Forms.TextBox();
            this.lbTenNguoiDung = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbTenTaiKhoan = new System.Windows.Forms.Label();
            this.lbDKTK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNofication
            // 
            this.lbNofication.AutoSize = true;
            this.lbNofication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNofication.ForeColor = System.Drawing.Color.Red;
            this.lbNofication.Location = new System.Drawing.Point(22, 241);
            this.lbNofication.Name = "lbNofication";
            this.lbNofication.Size = new System.Drawing.Size(74, 16);
            this.lbNofication.TabIndex = 21;
            this.lbNofication.Text = "Thông báo";
            this.lbNofication.Visible = false;
            // 
            // btCreate
            // 
            this.btCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreate.Location = new System.Drawing.Point(144, 210);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(109, 23);
            this.btCreate.TabIndex = 20;
            this.btCreate.Text = "Tạo tài khoản";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(150, 175);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(222, 20);
            this.tbConfirmPassword.TabIndex = 19;
            this.tbConfirmPassword.TextChanged += new System.EventHandler(this.tbConfirmPassword_TextChanged);
            // 
            // lbXacNhanMK
            // 
            this.lbXacNhanMK.AutoSize = true;
            this.lbXacNhanMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXacNhanMK.Location = new System.Drawing.Point(22, 176);
            this.lbXacNhanMK.Name = "lbXacNhanMK";
            this.lbXacNhanMK.Size = new System.Drawing.Size(123, 16);
            this.lbXacNhanMK.TabIndex = 18;
            this.lbXacNhanMK.Text = "Xác nhận mật khẩu:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(150, 138);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(222, 20);
            this.tbPassword.TabIndex = 17;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // lbMK
            // 
            this.lbMK.AutoSize = true;
            this.lbMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMK.Location = new System.Drawing.Point(22, 139);
            this.lbMK.Name = "lbMK";
            this.lbMK.Size = new System.Drawing.Size(65, 16);
            this.lbMK.TabIndex = 16;
            this.lbMK.Text = "Mật khẩu:";
            // 
            // tbAccountName
            // 
            this.tbAccountName.Location = new System.Drawing.Point(150, 101);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(222, 20);
            this.tbAccountName.TabIndex = 15;
            this.tbAccountName.TextChanged += new System.EventHandler(this.tbAccountName_TextChanged);
            // 
            // lbTenNguoiDung
            // 
            this.lbTenNguoiDung.AutoSize = true;
            this.lbTenNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNguoiDung.Location = new System.Drawing.Point(22, 102);
            this.lbTenNguoiDung.Name = "lbTenNguoiDung";
            this.lbTenNguoiDung.Size = new System.Drawing.Size(104, 16);
            this.lbTenNguoiDung.TabIndex = 14;
            this.lbTenNguoiDung.Text = "Tên người dùng:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(150, 64);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(222, 20);
            this.tbUsername.TabIndex = 13;
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            // 
            // lbTenTaiKhoan
            // 
            this.lbTenTaiKhoan.AutoSize = true;
            this.lbTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenTaiKhoan.Location = new System.Drawing.Point(22, 65);
            this.lbTenTaiKhoan.Name = "lbTenTaiKhoan";
            this.lbTenTaiKhoan.Size = new System.Drawing.Size(92, 16);
            this.lbTenTaiKhoan.TabIndex = 12;
            this.lbTenTaiKhoan.Text = "Tên tài khoản:";
            // 
            // lbDKTK
            // 
            this.lbDKTK.AutoSize = true;
            this.lbDKTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDKTK.ForeColor = System.Drawing.Color.Red;
            this.lbDKTK.Location = new System.Drawing.Point(137, 23);
            this.lbDKTK.Name = "lbDKTK";
            this.lbDKTK.Size = new System.Drawing.Size(123, 24);
            this.lbDKTK.TabIndex = 11;
            this.lbDKTK.Text = "Tạo tài khoản";
            // 
            // DoAnClientAdminCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 266);
            this.Controls.Add(this.lbNofication);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lbXacNhanMK);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbMK);
            this.Controls.Add(this.tbAccountName);
            this.Controls.Add(this.lbTenNguoiDung);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.lbTenTaiKhoan);
            this.Controls.Add(this.lbDKTK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DoAnClientAdminCreateAccount";
            this.Text = "Tạo tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNofication;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lbXacNhanMK;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbMK;
        private System.Windows.Forms.TextBox tbAccountName;
        private System.Windows.Forms.Label lbTenNguoiDung;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lbTenTaiKhoan;
        private System.Windows.Forms.Label lbDKTK;
    }
}