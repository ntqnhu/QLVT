using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLVT
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet.V_CHINHANH' table. You can move, or remove it, as needed.
            this.v_CHINHANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_CHINHANH);

        }


        public Boolean kiemtrahople()
        {
            if (txtTenDangNhap.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không được rỗng", "Lỗi đăng nhập", MessageBoxButtons.OK);
                txtTenDangNhap.Focus();
                return false;
            }
            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được rỗng", "Lỗi đăng nhập", MessageBoxButtons.OK);
                txtMatKhau.Focus();
                return false;
            }
            if (Program.cnnStrServer == "")
            {
                Program.cnnStrServer = Program.cnnStrServer1;
            }
            return true;

        }

        private void tENCSLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Program.cnnStrLoginName = txtTenDangNhap.Text.Trim();
            Program.cnnStrPassword = txtMatKhau.Text.Trim();
            if (kiemtrahople())
            {
                if (Program.TryConnect())
                {
                    Program.formMain = new frmMain();
                    Program.formMain.Activate();
                    Program.formMain.Show();
                    Program.formDN.Visible = false;

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}