using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;

namespace QLVT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            IsMdiContainer = true;
            laythongtinuser();


        }

        public Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void laythongtinuser()
        {
            try
            {
                Program.sql = "EXEC SP_DANGNHAP " + Program.cnnStrLoginName;
                Program.sqlCommand = new SqlCommand(Program.sql, Program.conn);
                Program.dataReader = Program.sqlCommand.ExecuteReader();
                Program.dataReader.Read();
                Program.userId = Program.dataReader.GetValue(0).ToString();
                Program.userName = Program.dataReader.GetValue(1).ToString();
                Program.userGroup = Program.dataReader.GetValue(2).ToString();
                Program.dataReader.Close();
                this.txtMANV.Caption = "Mã NV: " + Program.userId;
                this.txtTENNV.Caption = "Tên NV: " + Program.userName;
                this.txtNHOM.Caption = "Nhóm: " + Program.userGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNhanVien));
            if (frm != null) frm.Activate();
            else
            {
                Program.formNV = new frmNhanVien();
                Program.formNV.MdiParent = this;  //ép form con vào form chính
                Program.formNV.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDonDatHang));
            if (frm != null) frm.Activate();
            else
            {
                Program.formDDH = new frmDonDatHang();
                Program.formDDH.MdiParent = this;  //ép form con vào form chính
                Program.formDDH.Show();
            }
        }

        private void barStaticItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}