using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Linq;


namespace DoAnLapTrinhMangServer
{
    public partial class DoAnServer : Form
    {
        public StreamWriter streamWriter;
        public StreamReader streamReader;
        public ArrayList listClient = new ArrayList(50);
        public ArrayList listUser = new ArrayList(50);
        public TcpClient tcpClient;
        public SqlConnection _sqlConnection;
        Thread thread;

        public DoAnServer()
        {
            InitializeComponent();
            tbIP.Text = "127.0.0.1";
            tbPort.Text = "8000";
        }

        public delegate void SafeCallInfoMessage(string message);
        public void InfoMessage(string mess)
        {
            if (tbList.InvokeRequired)
            {
                SafeCallInfoMessage delInfoMessage = new SafeCallInfoMessage(InfoMessage);
                tbList.Invoke(delInfoMessage, new object[] { mess });
            }
            else
            {
                tbList.AppendText(mess + "\r\n");
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (btStart.Text == "Bắt đầu")
            {
                _sqlConnection = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = DuyetThuMuc; Integrated Security = True");
                _sqlConnection.Open();
                thread = new Thread(new ThreadStart(ListenThread));
                thread.Start();
                tbIP.Enabled = tbPort.Enabled = false;
                btStart.Text = "Kết thúc";
                InfoMessage("Server bắt đầu lắng nghe ở IP " + tbIP.Text.Trim() + ", port " + tbPort.Text.Trim());
            }
        }

        public void ListenThread()
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(tbIP.Text), int.Parse(tbPort.Text));
                TcpListener tcpListener = new TcpListener(ipEndPoint);
                tcpListener.Start();
                while (true)
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    IPAddress ipClient = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
                    int portClient = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port;
                    InfoMessage("Client có địa chỉ IP " + ipClient.ToString() + ", port " + portClient.ToString() + " đã kết nối");
                    if (!listClient.Contains(tcpClient))
                    {
                        listClient.Add(tcpClient);
                        Connection newConnection = new Connection(tcpClient, this);
                    }
                }
            }
            catch
            {
                thread.Abort();
            }

        }

        class Connection
        {
            TcpClient _tcpClient;
            StreamReader _srClient;
            StreamWriter _swClient;
            string _strReceive;
            Thread _threadConnect;
            bool _Connected;
            DoAnServer _frmServer;
            bool _login = false;
            string _username;

            public Connection(TcpClient tcpClient, DoAnServer frmServer)
            {
                _Connected = true;
                _tcpClient = tcpClient;
                _frmServer = frmServer;
                _threadConnect = new Thread(Connect);
                _threadConnect.Start();
            }

            public void AccountLogout(string username)
            {
                _login = false;
                _frmServer.listUser.Remove(username);
                _frmServer.UpdateStatus(username, 0);
                _frmServer.InfoMessage("Tài khoản " + username + " đã đăng xuất");
            }

            public void Connect()
            {
                _srClient = new StreamReader(_tcpClient.GetStream());
                _swClient = new StreamWriter(_tcpClient.GetStream());

                while (_Connected == true)
                {
                    try
                    {
                        if ((_strReceive = _srClient.ReadLine()) != null)
                        {
                            if (_strReceive.Contains("Command:NewAccount"))
                            {
                                CreateAccount(_strReceive);
                            }
                            else if (_strReceive.Contains("Command:Login"))
                            {
                                Login(_strReceive, this);
                            }
                            else if (_strReceive.Contains("Command:Quit"))
                            {
                                AccountLogout(_username);
                            }
                            else if (_strReceive.Contains("Command:ChangeName"))
                            {
                                string temp = _srClient.ReadLine();
                                ChangeName(temp);
                            }
                            else if (_strReceive.Contains("Command:ChangePassword"))
                            {
                                string temp = _srClient.ReadLine();
                                ChangePassword(temp);
                            }
                            else if (_strReceive.Contains("Command:AdminManageAccount"))
                            {
                                GetAccountInfo();
                            }
                            else if (_strReceive.Contains("Command:AdminAddAccount"))
                            {
                                AdminAddAccount(_strReceive);
                            }
                            else if (_strReceive.Contains("Command:AdminDeleteAccount:"))
                            {
                                AdminDeleteAccount(_strReceive);
                            }
                            else if (_strReceive.Contains("Command:Get"))
                            {
                                if (_login == true)
                                {
                                    if (_strReceive.Contains("Command:GetData:"))
                                    {
                                        _strReceive = _strReceive.Replace("Command:GetData:", "");
                                        GetData(_strReceive, false);
                                    }
                                    else if (_strReceive.Contains("Command:GetHiddenData:")) 
                                    {
                                        _strReceive = _strReceive.Replace("Command:GetHiddenData:", "");
                                        GetData(_strReceive, true);
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        _frmServer.InfoMessage("Client có địa chỉ IP " + ((IPEndPoint)_tcpClient.Client.RemoteEndPoint).Address.ToString() + ", port " + ((IPEndPoint)_tcpClient.Client.RemoteEndPoint).Port.ToString() + " đã ngắt kết nối");
                        _tcpClient.Close();
                        _swClient.Close();
                        _srClient.Close();
                        _Connected = false;
                    }
                }
            }

            void CreateAccount(string data)
            {
                StreamWriter _sw = new StreamWriter(_tcpClient.GetStream());
                try
                {
                    string _sql;
                    DataTable _dataTable;
                    SqlDataAdapter _sqlDataAdapter;
                    int _row;

                    string[] split = data.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                    string username = split[1];
                    string accountname = split[2];
                    string password = split[3];
                    _sql = "select USERNAME from ACCOUNT where USERNAME = '" + username + "'";
                    _dataTable = new DataTable();
                    _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                    _row = _sqlDataAdapter.Fill(_dataTable);
                    if (_row == 1)
                    {
                        _sw.WriteLine("Username has been existed");
                        _sw.Flush();
                    }
                    else
                    {
                        password = EncryptPass(password);
                        _sql = "insert into ACCOUNT (USERNAME, ACCOUNTNAME, PASSWORD, STATUS, CREATETIME, ISADMIN) values (";
                        _sql += "'" + username + "','" + accountname + "','" + password + "'," + 0 + ", getdate(), " + 0 + ")";
                        SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                        cmd.ExecuteNonQuery();
                        _frmServer.InfoMessage("Tài khoản " + username + " đã được tạo");
                        _sw.WriteLine("Success");
                        _sw.Flush();
                    }
                }
                catch
                {
                    _sw.WriteLine("Fail");
                    _sw.Flush();
                }
            }

            void Login(string data, Connection connection)
            {
                StreamWriter _sw = new StreamWriter(_tcpClient.GetStream());
                try
                {
                    string _sql;
                    DataTable _dataTable;
                    SqlDataAdapter _sqlDataAdapter;
                    int _row;

                    string[] split = data.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    string username = split[1];
                    string password = split[2];

                    _sql = "select USERNAME from ACCOUNT where USERNAME = '" + username + "'";
                    _dataTable = new DataTable();
                    _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                    _row = _sqlDataAdapter.Fill(_dataTable);
                    if (_row == 1)
                    {
                        if (_frmServer.ComparePassword(username,password) == true)
                        {
                            if (_frmServer.listUser.Contains(username) == true)
                            {
                                _sw.WriteLine("User is online.");
                                _sw.Flush();
                            }
                            else
                            {
                                _sql = "select ACCOUNTNAME,ISADMIN from ACCOUNT where USERNAME = '" + username + "'";
                                _dataTable = new DataTable();
                                _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                _row = _sqlDataAdapter.Fill(_dataTable);
                                string accountname = _dataTable.Rows[0].ItemArray[0].ToString();
                                bool isadmin;
                                if (_dataTable.Rows[0].ItemArray[1].ToString() == "True")
                                {
                                    isadmin = true;
                                }
                                else
                                {
                                    isadmin = false;
                                }
                                _frmServer.listUser.Add(username);
                                _sw.WriteLine(accountname + "?" + isadmin);
                                _sw.Flush();
                                _frmServer.UpdateStatus(username, 1);
                                _username = username;
                                _frmServer.InfoMessage("Tài khoản " + _username + " đã đăng nhập");
                                connection._login = true;
                            }
                        }
                        else
                        {
                            _sw.WriteLine("Password is not correct.");
                            _sw.Flush();
                        }
                    }
                    else
                    {
                        _sw.WriteLine("Username is not correct.");
                        _sw.Flush();
                    }
                }
                catch
                {
                    _swClient.WriteLine("Fail");
                    _swClient.Flush();
                }
            }

            void ChangeName(string data)
            {
                string[] splitData = data.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                if (_frmServer.ComparePassword(_username,splitData[1]) == true)
                {
                    string _sql = "update ACCOUNT set ACCOUNTNAME = '" + splitData[0] + "' where USERNAME = '" + _username + "'";
                    SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                    cmd.ExecuteNonQuery();
                    _swClient.WriteLine("ClientChangeName:Success");
                    _swClient.Flush();
                    _frmServer.InfoMessage("Tài khoản " + _username + " đã đổi tên người dùng thành " + splitData[0]);
                }
                else
                {
                    _swClient.WriteLine("ClientChangeName:Password wrong");
                    _swClient.Flush();
                }
            }

            void ChangePassword(string data)
            {
                string[] splitData = data.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                if (_frmServer.ComparePassword(_username, splitData[0]) == true)
                {
                    string password = EncryptPass(splitData[1]);
                    string _sql = "update ACCOUNT set PASSWORD = '" + password + "' where USERNAME = '" + _username + "'";
                    SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                    cmd.ExecuteNonQuery();
                    _swClient.WriteLine("ClientChangePassword:Success");
                    _swClient.Flush();
                    _frmServer.InfoMessage("Tài khoản " + _username + " đã thay đổi mật khẩu");
                }
                else
                {
                    _swClient.WriteLine("ClientChangePassword:Password wrong");
                    _swClient.Flush();
                }
            }

            void GetAccountInfo()
            {
                string _sql = "select USERNAME, PASSWORD, ACCOUNTNAME, STATUS, CREATETIME from ACCOUNT where ISADMIN = 0";
                DataTable _dataTable = new DataTable();
                SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                int _row = _sqlDataAdapter.Fill(_dataTable);
                _swClient.WriteLine("AdminManageAccount:" + _row);
                _swClient.Flush();
                if (_row > 0)
                {
                    for (int i = 0; i < _row; i++)
                    {
                        string data = _dataTable.Rows[i].ItemArray[0].ToString() + "|" + _dataTable.Rows[i].ItemArray[1].ToString()
                            + "|" + _dataTable.Rows[i].ItemArray[2].ToString() + "|" + _dataTable.Rows[i].ItemArray[3].ToString()
                            + "|" + _dataTable.Rows[i].ItemArray[4].ToString();
                        _swClient.WriteLine("AdminManageAccount:" + data);
                        _swClient.Flush();
                    }
                }
            }

            void AdminAddAccount(string data)
            {
                StreamWriter _sw = new StreamWriter(_tcpClient.GetStream());
                try
                {
                    string _sql;
                    DataTable _dataTable;
                    SqlDataAdapter _sqlDataAdapter;
                    int _row;

                    string[] split = data.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                    string username = split[1];
                    string accountname = split[2];
                    string password = split[3];
                    _sql = "select USERNAME from ACCOUNT where USERNAME = '" + username + "'";
                    _dataTable = new DataTable();
                    _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                    _row = _sqlDataAdapter.Fill(_dataTable);
                    if (_row == 1)
                    {
                        _sw.WriteLine("AdminManageAccount:Username has been existed");
                        _sw.Flush();
                    }
                    else
                    {
                        password = EncryptPass(password);
                        _sql = "insert into ACCOUNT (USERNAME, ACCOUNTNAME, PASSWORD, STATUS, CREATETIME, ISADMIN) values (";
                        _sql += "'" + username + "','" + accountname + "','" + password + "'," + 0 + ", getdate(), " + 0 + ")";
                        SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                        cmd.ExecuteNonQuery();
                        _frmServer.InfoMessage("Admin đã thêm tài khoản " + username);
                        _sw.WriteLine("AdminManageAccount:Success");
                        _sw.Flush();
                    }
                }
                catch
                {
                    _sw.WriteLine("AdminManageAccount:Fail");
                    _sw.Flush();
                }
            }

            void AdminDeleteAccount(string data)
            {
                try
                {
                    data = data.Replace("Command:AdminDeleteAccount:", "");
                    SqlCommand cmd = new SqlCommand(data, _frmServer._sqlConnection);
                    cmd.ExecuteNonQuery();
                    _swClient.WriteLine("AdminManageAccount:DeleteSuccess");
                    _swClient.Flush();
                    _frmServer.InfoMessage("Admin đã xóa tài khoản");
                }
                catch
                {
                    _swClient.WriteLine("AdminManageAccount:DeleteFail");
                    _swClient.Flush();
                }
            }

            void GetData(string url, bool type) //type = false: normal; type = true: hiddenfile.
            {
                try
                {
                    _frmServer.InfoMessage("Tài khoản " + _username + " yêu cầu đường dẫn: " + url);
                    DirectoryInfo di = new DirectoryInfo(url);
                    FileInfo[] fiArr;
                    DirectoryInfo[] directoryInfos;
                    if (type == true)
                    {
                        fiArr = di.GetFiles();
                        directoryInfos = di.GetDirectories();
                    }
                    else
                    {
                        fiArr = di.GetFiles().Where(file => (file.Attributes & FileAttributes.Hidden) == 0).ToArray();
                        directoryInfos = di.GetDirectories().Where(file => (file.Attributes & FileAttributes.Hidden) == 0).ToArray();
                    }
                    string sendData = "";
                    foreach (DirectoryInfo forder in directoryInfos)
                    {
                        if (forder.Extension == "")
                        {
                            sendData += forder.Name + "**null**" + "Thư mục" + "??";
                        }
                        else
                        {
                            sendData += forder.Name + "**" + forder.Extension + "**" + "Thư mục" + "??";
                        }
                    }
                    foreach (FileInfo fileinfo in fiArr)
                    {
                        if (fileinfo.Extension == "")
                        {
                            sendData += fileinfo.Name + "**null**" + "Tập tin" + "??";
                        }
                        else
                        {
                            sendData += fileinfo.Name + "**" + fileinfo.Extension + "**" + "Tập tin" + "??";
                        }
                    }
                    _swClient.WriteLine("ClientMainForm:"+ sendData);
                    _swClient.Flush();
                }
                catch
                {
                    _swClient.WriteLine("ClientMainForm: Thư mục không tồn tại");
                    _swClient.Flush();
                }
            }
        }

        public void UpdateStatus(string username, int status)
        {
            string _sql = "update ACCOUNT set STATUS = " + status + " where USERNAME = '" + username + "'";
            SqlCommand cmd = new SqlCommand(_sql, _sqlConnection);
            cmd.ExecuteNonQuery();
        }

        //Mã hóa và giải mã password base64
        public static string EncryptPass(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public string DecryptPass(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        //So sánh password với cơ sở dữ liệu
        public bool ComparePassword(string username, string password)
        {
            string _sql = "select PASSWORD from ACCOUNT where USERNAME = '" + username + "'";
            DataTable _dataTable = new DataTable();
            SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(_sql, _sqlConnection);
            _sqlDataAdapter.Fill(_dataTable);
            string PassDecrypt = DecryptPass(_dataTable.Rows[0].ItemArray[0].ToString());
            if (password == PassDecrypt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
