using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace DoAnLapTrinhMang
{
    public partial class DoAnClientChangePassword : Form
    {
        TcpClient _server;
        DoAnClient _parent;
        StreamWriter _sw;

        public DoAnClientChangePassword()
        {
            InitializeComponent();
        }

        public DoAnClientChangePassword(TcpClient server, DoAnClient parent) : this()
        {
            _server = server;
            _parent = parent;
            _sw = new StreamWriter(_server.GetStream());
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (tbCurrentPassword.Text.Trim() != "")
            {
                if (tbNewPassword.Text.Trim() != "" && tbNewPassword.Text.Trim().Length <= 50)
                {
                    if (tbConfirmPassword.Text.Trim() != "")
                    {
                        if (tbNewPassword.Text.Trim() == tbConfirmPassword.Text.Trim())
                        {
                            _sw.WriteLine("Command:ChangePassword");
                            _sw.WriteLine(tbCurrentPassword.Text.Trim() + "?" + tbNewPassword.Text.Trim());
                            _sw.Flush();
                            string receiveData = _parent.GetChangePasswordData();
                            if (receiveData == "Password wrong")
                            {
                                lbNofication.Text = "Password hiện tại sai";
                                lbNofication.Visible = true;
                            }
                            else if (receiveData == "Success")
                            {
                                lbNofication.Text = "Thay đổi password thành công";
                                tbCurrentPassword.Text = tbNewPassword.Text = tbConfirmPassword.Text = "";
                                lbNofication.Visible = true;
                            }
                        }
                        else
                        {
                            tbConfirmPassword.Clear();
                            lbNofication.Text = "Password xác nhận sai";
                            lbNofication.Visible = true;
                        }
                    }
                    else
                    {
                        lbNofication.Text = "Vui lòng xác nhận password mới";
                        lbNofication.Visible = true;
                    }
                }
                else
                {
                    lbNofication.Text = "Vui lòng nhập password mới không được quá 50 kí tự";
                    lbNofication.Visible = true;
                }
            }
            else
            {
                lbNofication.Text = "Vui lòng nhập password hiện tại";
                lbNofication.Visible = true;
            }
        }

        private void tbCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbNewPassword_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void DoAnClientChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Show();
        }
    }
}
