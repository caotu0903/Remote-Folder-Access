using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace DoAnLapTrinhMang
{
    public partial class DoAnClientSignUp : Form
    {
        TcpClient _server;
        DoAnClientLogin _frmfather;
        StreamWriter _sw;
        StreamReader _sr;

        public DoAnClientSignUp()
        {
            InitializeComponent();
        }

        public DoAnClientSignUp(TcpClient server, DoAnClientLogin frmfather) : this()
        {
            _server = server;
            _frmfather = frmfather;
            _sw = new StreamWriter(_server.GetStream());
            _sr = new StreamReader(_server.GetStream());
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text != "" && tbAccountName.Text != "" && tbPassword.Text != "" && tbConfirmPassword.Text != "")
            {
                if (tbUsername.Text.Trim().Length <= 50)
                {
                    if (tbPassword.Text.Trim().Length <= 50)
                    {
                        if (tbAccountName.Text.Trim().Length <= 30)
                        {
                            if (tbPassword.Text == tbConfirmPassword.Text)
                            {
                                _sw.WriteLine("Command:NewAccount?" + tbUsername.Text.Trim() + "?" +
                                    tbAccountName.Text.Trim() + "?" + tbPassword.Text.Trim());
                                _sw.Flush();
                                string receive = _sr.ReadLine();
                                if (receive == "Username has been existed")
                                {
                                    lbNofication.Text = "Tên tài khoản đã tồn tại, vui lòng dùng tên tài khoản khác";
                                    lbNofication.Visible = true;
                                }
                                else if (receive == "Success")
                                {
                                    MessageBox.Show("Đăng ký thành công");
                                    this.Close();
                                }
                                else if (receive == "Fail")
                                {
                                    _sw.Dispose();
                                    lbNofication.Text = "Tạo tài khoản thất bại, vui lòng thử lại";
                                    lbNofication.Visible = true;
                                }
                            }
                            else
                            {
                                lbNofication.Text = "Mật khẩu xác nhận sai";
                                lbNofication.Visible = true;
                                tbConfirmPassword.Clear();
                            }
                        }
                        else
                        {
                            lbNofication.Text = "Tên người dùng không được quá 30 kí tự";
                            lbNofication.Visible = true;
                        }
                    }
                    else
                    {
                        lbNofication.Text = "Mật khẩu không được quá 50 kí tự";
                        lbNofication.Visible = true;
                    }
                }
                else
                {
                    lbNofication.Text = "Tên tài khoản không được quá 50 kí tự";
                    lbNofication.Visible = true;
                }
            }
        }

        private void tbTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (lbNofication.Visible == true)
                lbNofication.Visible = false;
        }

        private void tbTenNguoiDung_TextChanged(object sender, EventArgs e)
        {
            if (lbNofication.Visible == true)
                lbNofication.Visible = false;
        }

        private void tbMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (lbNofication.Visible == true)
                lbNofication.Visible = false;
        }

        private void tbNhapLaiMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (lbNofication.Visible == true)
                lbNofication.Visible = false;
        }

        private void DoAnClientSignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmfather.Show();
        }
    }
}
