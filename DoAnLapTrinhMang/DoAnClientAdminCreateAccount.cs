using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace DoAnLapTrinhMang
{
    public partial class DoAnClientAdminCreateAccount : Form
    {
        TcpClient _server;
        DoAnClient _frmDoAnClient;
        StreamWriter _sw;

        public DoAnClientAdminCreateAccount()
        {
            InitializeComponent();
        }

        public DoAnClientAdminCreateAccount(TcpClient server, DoAnClient FrmDoAnClient) : this()
        {
            _server = server;
            _frmDoAnClient = FrmDoAnClient;
            _sw = new StreamWriter(_server.GetStream());
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
                                string username = tbUsername.Text.Trim();
                                _sw.WriteLine("Command:AdminAddAccount?" + tbUsername.Text.Trim() + "?" +
                                    tbAccountName.Text.Trim() + "?" + tbPassword.Text.Trim());
                                _sw.Flush();
                                string receive = _frmDoAnClient.GetChangeAdminManageAccount();
                                if (receive == "Username has been existed")
                                {
                                    lbNofication.Text = "Tên tài khoản đã tồn tại, vui lòng dùng tên tài khoản khác";
                                    lbNofication.Visible = true;
                                }
                                else if (receive == "Success")
                                {
                                    lbNofication.Text = "Đã tạo thành công tài khoản " + username;
                                    lbNofication.Visible = true;
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

        //Xử lý sự kiện TextChanged
        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbAccountName_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }
    }
}
