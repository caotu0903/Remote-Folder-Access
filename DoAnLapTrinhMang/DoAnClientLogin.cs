using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace DoAnLapTrinhMang
{
    public partial class DoAnClientLogin : Form
    {
        TcpClient _server;
        StreamWriter _sw;
        StreamReader _sr;
        public DoAnClientLogin()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (btConnect.Text == "Kết nối")
            {
                try
                {
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(tbIP.Text.Trim()), int.Parse(tbPort.Text.Trim()));
                    _server = new TcpClient();
                    _server.Connect(iPEndPoint);
                    _sw = new StreamWriter(_server.GetStream());
                    _sr = new StreamReader(_server.GetStream());
                    tbIP.Enabled = tbPort.Enabled = false;
                    tbUsername.Enabled = tbPassword.Enabled = btSignUp.Enabled = btLogin.Enabled = true;
                    btConnect.Text = "Ngắt kết nối";
                    lbNofication.Text = "Kết nối thành công";
                    lbNofication.Visible = true;
                }
                catch
                {
                    if (tbIP.Text == "")
                    {
                        lbNofication.Text = "Vui lòng nhập địa chỉ IP.";
                        lbNofication.Visible = true;
                    }
                    else if (tbPort.Text == "")
                    {
                        lbNofication.Text = "Vui lòng nhập địa chỉ port.";
                        lbNofication.Visible = true;
                    }
                    else
                        MessageBox.Show("Máy chủ không hoạt động!");
                }
            }
            else if (btConnect.Text == "Ngắt kết nối")
            {
                _server.Close();
                tbIP.Enabled = tbPort.Enabled = true;
                tbUsername.Enabled = tbPassword.Enabled = btSignUp.Enabled = btLogin.Enabled = false;
                btConnect.Text = "Kết nối";
                lbNofication.Text = "Đã ngắt kết nối";
                lbNofication.Visible = true;
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text.Trim() != "" && tbUsername.Text.Trim().Length <= 50)
            {
                if (tbPassword.Text.Trim() != "" && tbPassword.Text.Trim().Length <= 50)
                {
                    string username = tbUsername.Text.Trim();
                    _sw.WriteLine("Command:Login " + username + " " + tbPassword.Text.Trim());
                    _sw.Flush();
                    _sr = new StreamReader(_server.GetStream());
                    string statusReturn = _sr.ReadLine();
                    if (statusReturn == "User is online.")
                    {
                        lbNofication.Text = "Tài khoản đang online.";
                        lbNofication.Visible = true;
                    }
                    else if (statusReturn == "Password is not correct.")
                    {
                        lbNofication.Text = "Mật khẩu không chính xác.";
                        lbNofication.Visible = true;
                    }
                    else if (statusReturn == "Username is not correct.")
                    {
                        lbNofication.Text = "Tên tài khoản không chính xác.";
                        lbNofication.Visible = true;
                    }
                    else
                    {
                        string[] splitData = statusReturn.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                        DoAnClient doAnClient = new DoAnClient(_server, username, splitData[0], bool.Parse(splitData[1]), this);
                        doAnClient.Show();
                        tbUsername.Clear();
                        tbPassword.Clear();
                        this.Hide();
                    }
                }
                else
                {
                    lbNofication.Text = "Mật khẩu không chính xác.";
                    lbNofication.Visible = true;
                }
            }
            else
            {
                lbNofication.Text = "Tên tài khoản không chính xác.";
                lbNofication.Visible = true;
            }
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            DoAnClientSignUp SignUp = new DoAnClientSignUp(_server,this);
            SignUp.Show();
            this.Hide();
        }

        public void ClickbtConnect()
        {
            btConnect.PerformClick();
        }

        public void HidelbNofication()
        {
            lbNofication.Visible = false;
        }


        //Xử lý KeyPress
        public void tbIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btConnect.PerformClick();
            }
        }

        public void tbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btConnect.PerformClick();
            }
        }

        //Xử lí khi thay đổi dữ liệu trong TextBox
        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            lbNofication.Visible = false;
        }
    }
}
