using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Data.OracleClient;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO; //
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Office.Core;
using System.Data.OleDb;


namespace SocketServer
{
    public partial class server : Form
    {
        AutoSize asc = new AutoSize();  //實例化自適應窗體類
        static ArrayList arrText = new ArrayList();
        //public ArrayList robotTimeData = new ArrayList();
        private Microsoft.Office.Interop.Excel.Application myExcel = null;
        public Dictionary<string, Socket> dicClients = new Dictionary<string, Socket>();   // 存儲連接到服務端的客戶端信息
        //private BackgroundWorker backgroundWorker1;
        string[] robotTimeData = new string[7];
        public server()
        {
            InitializeComponent();      //初始化
            //RobotTime();
        }

        //定义回调
        //private delegate void setTextValueCallBack(string value);
        //声明回调
        //private setTextValueCallBack setCallBack;

        private void btConect_Click(object sender, EventArgs e)
        {
            try
            {
                
                IPAddress ip = IPAddress.Parse("192.168.1.60");
                //IPAddress ip = IPAddress.Any;
                //創建對象端口
                IPEndPoint point = new IPEndPoint(ip, 2000);
                //點擊開始監聽時，在服務端創建一個負責監聽客戶端IP和端口的Socket   serverSocket
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(point);//綁定端口號
                ShowMsg("監聽成功!");
                serverSocket.Listen(1000);//設置監聽個數
                Thread thread = new Thread(new ParameterizedThreadStart(ListenClientConect));//创建監聽线程
                //Thread thread = new Thread(ListenClientConect);
                thread.IsBackground = true;    //設置為後台線程
                thread.Start(serverSocket);    //開啟線程
                //thread.Start();  
            }
            catch{ }
        }

        Socket tSocket;  //創建一個用於通信的socket     
        //監聽函數
        private void ListenClientConect(object obj)
        {
            try
            {                
                Socket socket = obj as Socket;   
                while (true)
                {
                    //通信用的socket  tSocket
                    tSocket = socket.Accept();//等待接收客戶端的連接
                    string clientIp = tSocket.RemoteEndPoint.ToString();  // 獲取客戶端的標識：IP和端口
                    cboIpPort.Items.Add(clientIp);  //將識別到的客戶端IP和端口號存儲到集合控件中
                    dicClients.Add(clientIp, tSocket);    //將客戶端的IP和通信用的socket信息存儲到定義的字典裡
                    //if (!dicClients.ContainsKey(clientIp)) dicClients.Add(clientIp, socket);  // 将连接的客户端socket添加到clients中保存
                    //else dicClients[clientIp] = socket;
                    //IPEndPoint netPoint = serverSocket.RemoteEndPoint as IPEndPoint;
                    //開啟一個新的線程，執行接收消息的方法  
                    ShowMsg(clientIp + "已連接成功!");
                    Thread receiveThread = new Thread(ReceiveMessage);       //開啟一個新的線程用於執行接收消息的方法
                    receiveThread.IsBackground = true;  //設置為後台線程
                    receiveThread.Start(tSocket);  //開啟線程
                    //receiveThread.Start();
                    Thread.Sleep(1000);   //線程延遲一秒鐘
                    //receiveThread.Abort();  //终止线程
                }
            }
            catch(Exception ex)   //捕獲錯誤的信息
            {
                ShowMsg(ex.Message);
               
            }           
        }

        //接收數據函數       
        private  void ReceiveMessage(object obj)
        {
            Socket client = obj as Socket;
            string reciveData = "";
            //string okTime = "";
                //clients.Add(clientIp, myClientSocket);               
                while (true)
                {
                    try
                    {
                        byte[] buffer = new byte[1024 * 1024 * 3];//客戶端連接服務端成功後，服務端接收客戶端發來的數據並存儲到buffer中
                        int len = client.Receive(buffer); //返回實際接收到的數據長度
                        if (len == 0)
                        {
                            break;
                        }
                        reciveData = Encoding.UTF8.GetString(buffer, 0, len);//將接收到的數據進行編碼
                        ShowMsg(client.RemoteEndPoint + "：" + "" + reciveData + " "+"------CurrentTime：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\r\n");
                        if (IsNumeric(reciveData)) {
                            robotTimeData[Convert.ToInt16(reciveData) - 1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            if (reciveData == "7")
                            {
                                TimeSpan t1 = (Convert.ToDateTime(robotTimeData[1]) - Convert.ToDateTime(robotTimeData[0]));
                                TimeSpan t2 = (Convert.ToDateTime(robotTimeData[2]) - Convert.ToDateTime(robotTimeData[1]));
                                TimeSpan t3 = (Convert.ToDateTime(robotTimeData[3]) - Convert.ToDateTime(robotTimeData[2]));
                                TimeSpan t4 = (Convert.ToDateTime(robotTimeData[4]) - Convert.ToDateTime(robotTimeData[3]));
                                TimeSpan t5 = (Convert.ToDateTime(robotTimeData[5]) - Convert.ToDateTime(robotTimeData[4]));
                                TimeSpan t6 = (Convert.ToDateTime(robotTimeData[6]) - Convert.ToDateTime(robotTimeData[5]));
                                TimeSpan t7 = (Convert.ToDateTime(robotTimeData[6]) - Convert.ToDateTime(robotTimeData[0]));
                                double total1 = t1.TotalSeconds;
                                double total2 = t2.TotalSeconds;
                                double total3 = t3.TotalSeconds;
                                double total4 = t4.TotalSeconds;
                                double total5 = t5.TotalSeconds;
                                double total6 = t6.TotalSeconds;
                                double totalAll = t7.TotalSeconds;
                                string strQuery = "insert into test_Data(startTime,data1,t1,data2,t2,data3,t3,data4,t4,data5,t5,endTime,t6,totalTime) values('" + robotTimeData[0] + "','" + robotTimeData[1] + "','" + total1 + "','" + robotTimeData[2] + "','" + total2 + "','" + robotTimeData[3] + "','" + total3 + "','" + robotTimeData[4] + "','" + total4 + "','" + robotTimeData[5] + "','" + total5 + "','" + robotTimeData[6] + "','" + total6 + "','" + totalAll + "')";
                                ExceSQL(strQuery);
                                //okTime = "";
                                //robotTimeData.Clear();
                            }
                        }
                    }
                        
                    catch(Exception ex)
                    {
                        ShowMsg(ex.Message);
                    }
                }
               
        }

        //發送數據函數
        private void Send(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            tSocket.Send(buffer);  //通過通信用的socket發送數據
        }
        //顯示數據函數
        private void ShowMsg(string msg)        
        {
            tbShowMsg.AppendText(msg +  "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);  
            //this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            //this.WindowState = FormWindowState.Maximized;    //最大化窗体 
            Control.CheckForIllegalCrossThreadCalls = false;    //取消跨線程的訪問.屏蔽掉C#編譯器對跨線程調用的檢查，記得在設計那裡加上本事件
        }

        //點擊發送按鈕觸發事件函數
        private void btSend_Click(object sender, EventArgs e)           
        {
            try
            {
                string ip = cboIpPort.Text;   //選擇一個IP號
                byte[] buffer = Encoding.UTF8.GetBytes(tbSend.Text);
                dicClients[ip].Send(buffer);  //選擇IP之後即可將編輯區的數據發送到客戶端
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
            finally
            {
                tbSend.Text = "";    //清空編輯框的信息
                tbSend.Focus();      //將光標定在最前面
            }           
        }        

        private void ExceSQL(string str)
        {
            //string strConnection = "User ID=QREPORT;Password=dellselect0406!;Data source =(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 10.120.171.105)(PORT = 1527)))(CONNECT_DATA =(SERVICE_NAME = NNAPDB)))";
            //OracleOperation op = new OracleOperation(strConnection);
            string sqlCon = @"server=(local);database=Robot;uid=sa;pwd=123";
            SqlConnection con = new SqlConnection(sqlCon);
            SqlCommand com = new SqlCommand(str, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            com.Dispose();
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }  

        //public static bool Delay(int delayTime)
        //{
        //    DateTime now = DateTime.Now;
        //    int s;
        //    do
        //    {
        //        TimeSpan spand = DateTime.Now - now;
        //        s = spand.Seconds;
        //        Application.DoEvents();
        //    }
        //    while (s < delayTime);
        //    return true;
        //}

        //判斷字符串是否為純數字
        public static bool IsNumeric(string s)
        {
            double v;
            if (double.TryParse(s, out v))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 导出Excel 把一个dataset的多个datatable导入到一个excel的多个sheet中
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="tableNames">ds里每个表的表名</param>
        /// <param name="strExcelFileName">导出Excel名称(.xls)</param>
        public string ToExceL(DataSet ds, string tableNames, string strExcelFileName)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            object misValue = System.Reflection.Missing.Value;//獲取缺少的object类型值
            //增加一个工作簿
            Workbook _workbook = excel.Workbooks.Add(true);
            //添加工作表
            Worksheet sheets = (Microsoft.Office.Interop.Excel.Worksheet)_workbook.Worksheets.Add(misValue, misValue, 1, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
            Microsoft.Office.Interop.Excel.Range range;
            try
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    System.Data.DataTable table = ds.Tables[i];
                    int RowNo = table.Rows.Count;
                    int ColNo = table.Columns.Count;
                    int colIndex = 0;
                    if (RowNo == 0)
                    {
                        return null;
                    }
                    //获取一个工作表
                    Worksheet sheet = _workbook.Worksheets[i + 1] as Worksheet;

                    foreach (DataColumn col in table.Columns)
                    {
                        colIndex++;
                        sheet.Cells[1, colIndex] = col.ColumnName;
                    }
                    object[,] objData = new object[RowNo, ColNo];
                    for (int r = 0; r < RowNo; r++)
                    {
                        for (int c = 0; c < ColNo; c++)
                        {
                            objData[r, c] = table.Rows[r][c];
                        }
                    }
                    range = sheet.Range[sheet.Cells[2, 1], sheet.Cells[RowNo + 1, ColNo]];
                    range.Value2 = objData;
                    //設置表格內容居中
                    range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //設置標題內容居中
                    Excel.Range rangeTitle = excel.Range[sheet.Cells[1, 1], sheet.Cells[1, ColNo]];
                    rangeTitle.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //加粗
                    rangeTitle.Font.Bold = true;
                    //设置边框
                    Excel.Range rangeBorder = excel.Range[sheet.Cells[1, 1], sheet.Cells[RowNo + 1, ColNo]];
                    rangeBorder.Borders.LineStyle = BorderStyle.FixedSingle;
                    excel.Cells.ColumnWidth = 12;
                    excel.Cells.RowHeight = 25;
                    excel.Cells.WrapText = true;
                    sheet.Name = tableNames;
                }
                excel.Visible = false;
                //设置禁止弹出保存和覆盖的询问提示框
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                _workbook.SaveAs(strExcelFileName, misValue, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                _workbook.Close(true, misValue, misValue);
                //關閉Excel
                excel.Quit();
                //清空excel中的内容
                excel = null;
                GC.Collect();//垃圾回收  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (excel != null)
                {
                    KillProcess(excel);
                }
                excel = null;
                GC.Collect();//垃圾回收  
            }
            if (!File.Exists(strExcelFileName))
            {
                return null;
            }
            return strExcelFileName;
        }
        //導出報表
        //private void startToExcel()
        //{
        //    //string sqlconn = @"server=10.120.115.21;database=SMT_154;uid=sa;pwd=123";
        //    string sqlconn = @"server=(local);database=Robot;uid=sa;pwd=123";
        //    SqlConnection cn = new SqlConnection(sqlconn);
        //    string cmdText = "select * from testData";
        //    SqlDataAdapter da = new SqlDataAdapter(cmdText, cn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "table1");
        //    ToExceL(ds, "ErrorMessage", @"D:\errorMessage\" + "TestData" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        //    //Dispose();
        //}

        /// <summary>
        /// 刪除應用程序對應的進程
        /// </summary>      
        private void KillProcess(Excel.Application excelApp)
        {
            IntPtr t = new IntPtr(excelApp.Hwnd);
            int k = 0;
            GetWindowThreadProcessId(t, out k);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            p.Kill();
        }
        [System.Runtime.InteropServices.DllImport("User32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);


        private void btnOut_Click_1(object sender, EventArgs e)
        {
            //string sqlconn = @"server=10.120.115.21;database=SMT_154;uid=sa;pwd=123";
            string sqlconn = @"server=(local);database=Robot;uid=sa;pwd=123";
            SqlConnection cn = new SqlConnection(sqlconn);
            string cmdText = "select * from testData";
            SqlDataAdapter da = new SqlDataAdapter(cmdText, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "table1");
            ToExceL(ds, "ErrorMessage", @"D:\errorMessage\" + "TestData" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            //Dispose();
        }
    }
}
