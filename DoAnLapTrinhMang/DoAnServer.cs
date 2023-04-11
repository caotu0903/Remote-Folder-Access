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

namespace DoAnLapTrinhMang
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
            }
            /*else if (btStart.Text == "Kết thúc")
            {
                tbIP.Enabled = tbPort.Enabled = true;
                btStart.Text = "Bắt đầu";
                _sqlConnection.Close();
                thread.Abort();
            }*/
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
                    InfoMessage(ipClient.ToString() + " " + portClient.ToString() + " connected");
                    if (!listClient.Contains(tcpClient))
                    {
                        listClient.Add(tcpClient);
                        Connection newConnection = new Connection(tcpClient,this);
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
                            else
                            {
                                if (_login == true)
                                {
                                    GetData(_strReceive);
                                }
                            }
                        }
                    }
                    catch
                    {
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
                        _sql = "insert into ACCOUNT (USERNAME, ACCOUNTNAME, PASSWORD, STATUS, CREATETIME) values (";
                        _sql += "'" + username + "','" + accountname + "','" + password + "'," + 0 + ", getdate())";
                        SqlCommand cmd = new SqlCommand(_sql, _frmServer._sqlConnection);
                        cmd.ExecuteNonQuery();
                        _frmServer.InfoMessage("Account " + username + " has been created\r\n");
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
                        _sql = "select PASSWORD from ACCOUNT where USERNAME = '" + username + "'";
                        string DecryptPass;
                        _dataTable = new DataTable();
                        _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                        _sqlDataAdapter.Fill(_dataTable);
                        DecryptPass = _frmServer.DecryptPass(_dataTable.Rows[0].ItemArray[0].ToString());
                        if (password == DecryptPass)
                        {
                            if (_frmServer.listUser.Contains(username) == true)
                            {
                                _sw.WriteLine("User is online.");
                                _sw.Flush();
                            }
                            else
                            {
                                _sql = "select ACCOUNTNAME from ACCOUNT where USERNAME = '" + username + "'";
                                _dataTable = new DataTable();
                                _sqlDataAdapter = new SqlDataAdapter(_sql, _frmServer._sqlConnection);
                                _row = _sqlDataAdapter.Fill(_dataTable);
                                string accountname = _dataTable.Rows[0].ItemArray[0].ToString();
                                _frmServer.listUser.Add(username);
                                _sw.WriteLine(accountname);
                                _sw.Flush();
                                _frmServer.UpdateStatus(username, 1);
                                _username = username;
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

            void GetData(string url)
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(url);
                    FileInfo[] fiArr = di.GetFiles().Where(file => (file.Attributes & FileAttributes.Hidden) == 0).ToArray();
                    DirectoryInfo[] directoryInfos = di.GetDirectories().Where(file => (file.Attributes & FileAttributes.Hidden) == 0).ToArray();
                    string sendData = "";
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
                    _swClient.WriteLine(sendData);
                    _swClient.Flush();
                }
                catch
                {
                    _swClient.WriteLine("Thư mục không tồn tại");
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
    }
}
