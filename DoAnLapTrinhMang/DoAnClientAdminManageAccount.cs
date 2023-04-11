using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace DoAnLapTrinhMang
{
    public partial class DoAnClientAdminManageAccount : Form
    {
        TcpClient _server;
        DoAnClient _parent;
        StreamWriter _sw;

        public DoAnClientAdminManageAccount()
        {
            InitializeComponent();
        }

        public DoAnClientAdminManageAccount(TcpClient server, DoAnClient parent) : this()
        {
            _server = server;
            _parent = parent;
            _sw = new StreamWriter(_server.GetStream());
            RefreshPerform();
        }

        //Xử lí SafeCall
        private delegate void SafeCallLvAccountInfo(ref List<ListViewItem> list);
        void LvAccountInfoUpdate(ref List<ListViewItem> itemList)
        {
            if (lvAccountInfo.InvokeRequired)
            {
                SafeCallLvAccountInfo delInfoMessage = new SafeCallLvAccountInfo(LvAccountInfoUpdate);
                lvAccountInfo.Invoke(delInfoMessage, new object[] { itemList });
            }
            else
            {
                ListViewItem[] list = new ListViewItem[itemList.Count];
                for (int i = 0; i < itemList.Count; i++)
                {
                    list[i] = itemList[i];
                }
                lvAccountInfo.Items.AddRange(list);
            }
        }

        //Xử lí Refresh
        void RefreshPerform()
        {
            _sw.WriteLine("Command:AdminManageAccount");
            _sw.Flush();

            int _countAccount = int.Parse(_parent.GetChangeAdminManageAccount());

            if (_countAccount > 0)
            {
                List<ListViewItem> arrListViewItems = new List<ListViewItem>();

                for (int i = 0; i < _countAccount; i++)
                {
                    string AccountInfo = _parent.GetChangeAdminManageAccount();
                    string[] splitInfo = AccountInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] data = new string[6];
                    for (int j = 0; j < 5; j++)
                    {
                        data[j + 1] = splitInfo[j];
                    }
                    ListViewItem lvi;
                    lvi = new ListViewItem(data);

                    arrListViewItems.Add(lvi);
                }
                lvAccountInfo.Items.Clear();
                LvAccountInfoUpdate(ref arrListViewItems);
            }
            else
            {
                lvAccountInfo.Items.Clear();
            }
        }

        //Xử lí sự kiện Click
        private void tsAdd_Click(object sender, EventArgs e)
        {
            DoAnClientAdminCreateAccount doAnClientAdminCreateAccount = new DoAnClientAdminCreateAccount(_server, _parent);
            doAnClientAdminCreateAccount.Show();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            var listCheckAccount = lvAccountInfo.CheckedItems;
            if (listCheckAccount.Count > 0)
            {
                DialogResult dlr = MessageBox.Show("Xác nhận xóa các tài khoản đã đánh dấu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    string sql = "delete from ACCOUNT where USERNAME in (";
                    for (int i = 0; i < listCheckAccount.Count; i++)
                    {
                        if (i == 0)
                        {
                            sql += "'" + listCheckAccount[i].SubItems[1].Text + "'";
                        }
                        else
                        {
                            sql += ", '" + listCheckAccount[i].SubItems[1].Text + "'";
                        }
                    }
                    sql += ")";
                    _sw.WriteLine("Command:AdminDeleteAccount:" + sql);
                    _sw.Flush();
                    string receive = _parent.GetChangeAdminManageAccount();
                    if (receive == "DeleteSuccess")
                    {
                        RefreshPerform();
                        tsNofication.Text = "Xóa thành công";
                        tsNofication.Visible = true;
                    }
                    else if (receive == "DeleteFail")
                    {
                        tsNofication.Text = "Xóa thất bại, vui lòng thử lại";
                        tsNofication.Visible = true;
                    }
                }
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            RefreshPerform();
            tsNofication.Text = "Cập nhật thành công";
            tsNofication.Visible = true;
        }

        //Xử lí sự kiện Close
        private void DoAnClientAdminManageAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Show();
        }
    }
}
