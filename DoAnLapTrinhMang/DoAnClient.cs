using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace DoAnLapTrinhMang
{
    public partial class DoAnClient : Form
    {
        //Khai báo biến cần thiết
        TcpClient _server;
        bool _connected;
        StreamReader _sr;
        StreamWriter _sw;
        string _username, _accountname, _currentURL = "";
        DoAnClientLogin _frmLogin;
        int _typeSend = 0;
        Stack<string> _history = new Stack<string>();
        Stack<string> _forward = new Stack<string>();
        Thread receiveThread;
        Queue<string> _ChangeName = new Queue<string>();
        Queue<string> _ChangePassword = new Queue<string>();
        Queue<string> _AdminManageAccount = new Queue<string>();

        //Khởi tạo Form
        public DoAnClient()
        {
            InitializeComponent();
            lbNotification.Visible = false;
        }

        public DoAnClient(TcpClient server, string username, string accountname, bool isadmin, DoAnClientLogin frmLogin) : this()
        {
            _server = server;
            _username = username;
            _accountname = accountname;
            if (isadmin == true)
            {
                tsManageAccount.Enabled = true;
                tsManageAccount.Visible = true;
            }
            _frmLogin = frmLogin;
            _connected = true;
            lbAccountName.Text = "Xin chào, " + _accountname + "!";
            _sw = new StreamWriter(_server.GetStream());
            receiveThread = new Thread(ReceiveThread);
            receiveThread.Start();
        }

        //Xử lí Click
        private void SendData(int typeSend)
        {
            if (cbURL.Text != "")
            {
                _typeSend = typeSend;
                if (cbHiddenItems.Checked == false)
                {
                    _sw.WriteLine("Command:GetData:" + cbURL.Text);
                    _sw.Flush();
                }
                else if (cbHiddenItems.Checked == true)
                {
                    _sw.WriteLine("Command:GetHiddenData:" + cbURL.Text);
                    _sw.Flush();
                }
            }
            else
            {
                cbURL.Text = _currentURL;
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            btForward.Enabled = true;
            _forward.Push(_history.Pop());
            cbURL.Text = _history.Pop();
            SendData(2);
        }

        private void btForward_Click(object sender, EventArgs e)
        {
            _history.Push(cbURL.Text);
            cbURL.Text = _forward.Pop();
            SendData(2);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            SendData(4);
        }

        private void tsChangeAccountName_Click(object sender, EventArgs e)
        {
            DoAnClientChangeName doAnClientChangeName = new DoAnClientChangeName(_server, this);
            doAnClientChangeName.Show();
            this.Hide();
        }

        private void tsChangePassword_Click(object sender, EventArgs e)
        {
            DoAnClientChangePassword doAnClientChangePassword = new DoAnClientChangePassword(_server, this);
            doAnClientChangePassword.Show();
            this.Hide();
        }

        private void tsManageAccount_Click(object sender, EventArgs e)
        {
            DoAnClientAdminManageAccount doAnClientAdminManageAccount = new DoAnClientAdminManageAccount(_server, this);
            doAnClientAdminManageAccount.Show();
            this.Hide();
        }

        //Thread nhận dữ liệu
        private void ReceiveThread()
        {
            _sr = new StreamReader(_server.GetStream());
            while (_connected == true)
            {
                try
                {
                    string receiveData = "";

                    receiveData = _sr.ReadLine();

                    if (receiveData == null || receiveData == "")
                        continue;
                    if (receiveData == "ClientMainForm: Thư mục không tồn tại")
                    {
                        MessageBox.Show("Thư mục không tồn tại, vui lòng kiểm tra lại đường dẫn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CbText(_currentURL);
                    }
                    else if (receiveData.Contains("ClientMainForm:"))
                    {
                        receiveData = receiveData.Replace("ClientMainForm:", "");
                        _currentURL = GetCbText();
                        if (_typeSend == 1)
                        {
                            if (cbURL.InvokeRequired)
                            {
                                cbURL.Invoke(new Action(() =>
                                {
                                    InsertHistory(cbURL.Text);
                                }));
                            }
                            _forward.Clear();
                        }
                        else if (_typeSend == 2)
                        {
                            if (cbURL.InvokeRequired)
                            {
                                cbURL.Invoke(new Action(() =>
                                {
                                    InsertHistory(cbURL.Text);
                                }));
                            }
                        }
                        if (_history.Count > 1)
                        {
                            BtBack(true);
                        }
                        else
                        {
                            BtBack(false);
                        }
                        if (_forward.Count > 0)
                        {
                            BtForward(true);
                        }
                        else
                        {
                            BtForward(false);
                        }
                        VisibleLbNofication(false);
                        ClearLvItem();
                        List<ListViewItem> arrListViewItems = new List<ListViewItem>();
                        string[] splitLine = receiveData.Split(new char[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string splitLineData in splitLine)
                        {
                            string[] splitInfo = splitLineData.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] data = new string[3];
                            data[0] = splitInfo[0];
                            if (splitInfo[2] == "Thư mục")
                            {
                                data[1] = "";
                                data[2] = splitInfo[2];
                            }
                            else
                            {
                                if (splitInfo[1] == "null")
                                {
                                    data[1] = "";
                                }
                                else
                                {
                                    data[1] = splitInfo[1];
                                }
                                data[2] = splitInfo[2];
                            }
                            ListViewItem lvi;
                            lvi = new ListViewItem(data);

                            arrListViewItems.Add(lvi);
                        }
                        InfoMessage(ref arrListViewItems);
                        InfoMessage("Có " + lvInfo.Items.Count.ToString() + " mục.");
                    }
                    else if (receiveData.Contains("ClientChangeName:"))
                    {
                        receiveData = receiveData.Replace("ClientChangeName:", "");
                        _ChangeName.Enqueue(receiveData);
                    }
                    else if (receiveData.Contains("ClientChangePassword:"))
                    {
                        receiveData = receiveData.Replace("ClientChangePassword:", "");
                        _ChangePassword.Enqueue(receiveData);
                    }
                    else if (receiveData.Contains("AdminManageAccount:"))
                    {
                        receiveData = receiveData.Replace("AdminManageAccount:", "");
                        _AdminManageAccount.Enqueue(receiveData);
                    }
                }
                catch
                {
                    receiveThread.Abort();
                }
            }
        }

        //Xử lí SafeCall List<ListViewItem>
        private delegate void SafeCallLVI(ref List<ListViewItem> list);
        void InfoMessage(ref List<ListViewItem> itemList)
        {
            if (lvInfo.InvokeRequired)
            {
                SafeCallLVI delInfoMessage = new SafeCallLVI(InfoMessage);
                lvInfo.Invoke(delInfoMessage, new object[] { itemList });
            }
            else
            {
                ListViewItem[] list = new ListViewItem[itemList.Count];
                for (int i = 0; i < itemList.Count; i++) 
                {
                    list[i] = itemList[i];
                }
                lvInfo.Items.AddRange(list);
            }
        }

        //Xử lí SafeCall ListViewItem
        private delegate void SafeCallInfoMessageLVI(ListViewItem message);
        void InfoMessage(ListViewItem mess)
        {
            if (lvInfo.InvokeRequired)
            {
                SafeCallInfoMessageLVI delInfoMessage = new SafeCallInfoMessageLVI(InfoMessage);
                lvInfo.Invoke(delInfoMessage, new object[] { mess });
            }
            else
            {
                lvInfo.Items.Add(mess);
            }
        }

        private delegate void SafeCallListView();

        void ClearLvItem()
        {
            if (lvInfo.InvokeRequired)
            {
                SafeCallListView safeCallListView = new SafeCallListView(ClearLvItem);
                lvInfo.Invoke((MethodInvoker)(() => lvInfo.Items.Clear()));
            }
            else
            {
                lvInfo.Items.Clear();
            }
        }

        //Xử lí SafeCall Label
        private delegate void SafeCallInfoMessageLabel(string message);
        void InfoMessage(string mess)
        {
            if (lbNotification.InvokeRequired)
            {
                SafeCallInfoMessageLabel delInfoMessage = new SafeCallInfoMessageLabel(InfoMessage);
                lbNotification.Invoke(delInfoMessage, new object[] { mess });
                lbNotification.Invoke((MethodInvoker)(() => lbNotification.Visible = true));
            }
            else
            {
                lbNotification.Text = mess; 
            }
        }

        private delegate void SafeCallLabelVisible(bool status);

        void VisibleLbNofication(bool status)
        {
            if (lbNotification.InvokeRequired)
            {
                SafeCallLabelVisible safeCallLabelVisible = new SafeCallLabelVisible(VisibleLbNofication);
                lbNotification.Invoke((MethodInvoker)(() => lbNotification.Visible = status));
            }
            else
            {
                lbNotification.Visible = status;
            }
        }

        //Xử lí SafeCall ComboBox
        private delegate string SafeCallComboBox();

        string GetCbText()
        {
            if (cbURL.InvokeRequired)
            {
                SafeCallComboBox safeCallButton = new SafeCallComboBox(GetCbText);
                string temp = "";
                cbURL.Invoke((MethodInvoker)(() => temp = cbURL.Text));
                return temp;
            }
            else
            {
                return cbURL.Text;
            }
        }

        private delegate void SafeCallComboBoxSetText(string data);

        void CbText(string data)
        {
            if (cbURL.InvokeRequired)
            {
                SafeCallComboBoxSetText safeCallComboBoxSetText = new SafeCallComboBoxSetText(CbText);
                cbURL.Invoke((MethodInvoker)(() => cbURL.Text = data));
            }
            else
            {
                cbURL.Text = data;
            }
        }

        //Xử lí SafeCall Button
        private delegate void SafeCallButton(bool signal);

        void BtBack(bool signal)
        {
            if (btBack.InvokeRequired)
            {
                if (signal == false)
                {
                    SafeCallButton safeCallButton = new SafeCallButton(BtBack);
                    btBack.Invoke((MethodInvoker)(() => btBack.Enabled = false));
                }
                else if (signal == true)
                {
                    SafeCallButton safeCallButton = new SafeCallButton(BtBack);
                    btBack.Invoke((MethodInvoker)(() => btBack.Enabled = true));
                }
            }
            else
            {
                if (signal == false)
                {
                    btBack.Enabled = false;
                }
                else if (signal == true)
                {
                    btBack.Enabled = true;
                }
            }
        }

        void BtForward(bool signal)
        {
            if (btForward.InvokeRequired)
            {
                if (signal == false)
                {
                    SafeCallButton safeCallButton = new SafeCallButton(BtForward);
                    btForward.Invoke((MethodInvoker)(() => btForward.Enabled = false));
                }
                else if (signal == true)
                {
                    SafeCallButton safeCallButton = new SafeCallButton(BtForward);
                    btForward.Invoke((MethodInvoker)(() => btForward.Enabled = true));
                }
            }
            else
            {
                if (signal == false)
                {
                    btForward.Enabled = false;
                }
                else if (signal == true)
                {
                    btForward.Enabled = true;
                }
            }
        }

        //Xử lí thêm vào Stack _history
        public void InsertHistory(string data)
        {
            if (_history.Count() != 0)
            {
                if (_history.Peek() != data)
                {
                    _history.Push(data);
                }
            }
            else
            {
                _history.Push(data);
            }
            if (!cbURL.Items.Contains(data))
            {
                if (cbURL.InvokeRequired)
                {
                    cbURL.Invoke(new Action(() =>
                    {
                        cbURL.Items.Add(data);
                    }));
                }
                else
                {
                    cbURL.Items.Add(data);
                }
            }
        }

        //Xử lí cbHiddenItems
        private void cbHiddenItems_CheckedChanged(object sender, EventArgs e)
        {
            SendData(4);
        }

        //Xử lí KeyPress
        void cbURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendData(1);
            }
        }

        //Xử lí DoubleClick
        public void lvInfo_DoubleClick(object sender, EventArgs e)
        {
            lbNotification.Visible = false;
            ListView.SelectedListViewItemCollection data = lvInfo.SelectedItems;
            ListViewItem listViewItem = data[0];
            string URL;
            if (_currentURL.EndsWith("\\"))
            {
                URL = _currentURL + listViewItem.SubItems[0].Text;
                if (listViewItem.SubItems[2].Text == "Thư mục")
                {
                    cbURL.Text = URL;
                    SendData(1);
                }
            }
            else
            {
                URL = _currentURL + "\\" + listViewItem.SubItems[0].Text;
                if (listViewItem.SubItems[2].Text == "Thư mục")
                {
                    cbURL.Text = URL;
                    SendData(1);
                }
            }    
        }

        //Xử lí CbURL
        private void cbURL_Leave(object sender, EventArgs e)
        {
            cbURL.Text = _currentURL;
        }

        //Truyền dữ liệu đến Form khác
        public string GetChangeNameData()
        {
            while (_ChangeName.Count == 0)
            {
                Wait(100);
            }
            string temp = _ChangeName.Dequeue();
            return temp;
        }

        public string GetChangePasswordData()
        {
            while (_ChangePassword.Count == 0)
            {
                Wait(100);
            }
            string temp = _ChangePassword.Dequeue();
            return temp;
        }

        public string GetChangeAdminManageAccount()
        {
            while (_AdminManageAccount.Count == 0)
            {
                Wait(100);
            }
            string temp = _AdminManageAccount.Dequeue();
            return temp;
        }

        //Set dữ liệu từ Form khác
        public void SetAccountName(string accountname)
        {
            _accountname = accountname;
            lbAccountName.Text = "Xin chào, " + _accountname + "!";
        }

        //Hàm đợi
        public void Wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        //Xử lí sort
        private bool order;
        private void lvInfo_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lvInfo.ListViewItemSorter = new ListViewItemComparer(e.Column, order);
            order = !order;
        }

        // Xử lí đóng
        private void DoAnClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sw.WriteLine("Command:Quit");
            _sw.Flush();
            _connected = false;
            _frmLogin.Show();
            _frmLogin.ClickbtConnect();
            _frmLogin.ClickbtConnect();
            _frmLogin.HidelbNofication();
        }

        private void tsLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        private bool order;

        public ListViewItemComparer()
        {
            col = 0;
        }

        public ListViewItemComparer(int column, bool ord)
        {
            col = column;
            order = ord;
        }

        public int Compare(object x, object y)
        {
            if (order == true)
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            else
                return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
        }
    }  //Class để sắp xếp
}
