using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace DoAnLapTrinhMang
{
    public partial class DoAnClientChangeName : Form
    {
        TcpClient _server;
        DoAnClient _parent;
        StreamWriter _sw;
        
        public DoAnClientChangeName()
        {
            InitializeComponent();
        }

        public DoAnClientChangeName(TcpClient server, DoAnClient parent) : this()
        {
            _server = server;
            _parent = parent;
            _sw = new StreamWriter(_server.GetStream());
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (tbNewAccountName.Text.Trim() != "")
            {
                if (tbConfirmPassword.Text.Trim() != "")
                {
                    _sw.WriteLine("Command:ChangeName");
                    _sw.WriteLine(tbNewAccountName.Text.Trim() + "?" + tbConfirmPassword.Text.Trim());
                    _sw.Flush();
                    string receiveData = _parent.GetChangeNameData();
                    if (receiveData == "Password wrong")
                    {
                        lbNofication.Text = "Password sai";
                        lbNofication.Visible = true;
                    }
                    else if (receiveData == "Success")
                    {
                        lbNofication.Text = "Thay đổi tên tài khoản thành công";
                        _parent.SetAccountName(tbNewAccountName.Text.Trim());
                        tbConfirmPassword.Clear();
                        lbNofication.Visible = true;
                    }
                }
                else
                {
                    lbNofication.Text = "Vui lòng nhập password";
                    lbNofication.Visible = true;
                }
            }
            else
            {
                lbNofication.Text = "Vui lòng nhập tên mới";
                lbNofication.Visible = true;
            }
        }

        private void tbNewAccountName_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void DoAnClientChangeName_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Show();
        }
    }
}
