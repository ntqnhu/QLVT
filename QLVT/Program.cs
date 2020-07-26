using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace QLVT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static string cnnStrServer1 = "LAPTOP-MO10S7PT\\SRV1";// co so 1
        public static string cnnStrServer2 = "LAPTOP-MO10S7PT\\SRV2";// co so 2

        public static string cnnStrServer = "";
        public static string cnnStrDatabase = "QLVT_DATHANG";
        public static string cnnStrLoginName = "";
        public static string cnnStrPassword = "";

        public static SqlConnection conn;
        public static String connstr = ""; // chuoi ket noi
        public static SqlCommand sqlCommand;
        public static SqlDataReader dataReader;
        public static string sql, output = "";


        public static String remoteLogin = "HTKN";
        public static String remotePass = "123456";

        public static string userId = "";//ma nv
        public static string userName = "";//ho va ten
        public static string userGroup = "";


        //form
        public static frmMain formMain;
        public static frmDangNhap formDN;
        public static frmNhanVien formNV;
        public static frmDonDatHang formDDH;

        public static bool TryConnect()
        {
            if (Program.cnnStrLoginName == "sa" && Program.cnnStrPassword == "12")
            {
                MessageBox.Show("Kết nối thất bại , xem lại login va pasword");
                // Program.conn.Close();
                return false;
            }
            else
            {
                Program.connstr = "Server=" + Program.cnnStrServer + ";"
               + "Database=" + Program.cnnStrDatabase + ";"
               + "User Id=" + Program.cnnStrLoginName + ";"
               + "Password=" + Program.cnnStrPassword;
                Program.conn = new SqlConnection(Program.connstr);
                try
                {

                    Program.conn.Open();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Kết nối thất bại , xem lại login va pasword");
                    Program.conn.Close();
                    return false;
                }

            }

        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formDN = new frmDangNhap();
            Application.Run(formDN);
        }
    }
}
