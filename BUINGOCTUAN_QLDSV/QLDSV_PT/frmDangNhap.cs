using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_PT
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        string servernameStr ;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            string chuoiketnoi = "Data Source=DESKTOP-Q470HD2;Initial Catalog=" + Program.Database + ";Integrated Security=True";
            Program.Conn.ConnectionString = chuoiketnoi;
            Program.Conn.Open();
            DataTable dt = new DataTable();
            //gọi 1 view và trả về dưới dạng datatable
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            // cất dt vào biến toàn cục Bds_Dspm
            Program.Bds_Dspm.DataSource = dt;

            //lấy 2 khoa
            DataTable dt2 = new DataTable();
            dt2 = Program.ExecSqlDataTable("SELECT TOP 2 * FROM V_DS_PHANMANH");
            Program.Bds_Dskhoa.DataSource = dt2;

            cmbKhoa.DataSource = dt;
            cmbKhoa.DisplayMember = "TENCN";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = -1;
            cmbKhoa.SelectedIndex = Program.MKhoa;
            txtLogin.Focus();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // gán server đã chọn vào biến toàn cục.
                Program.ServerName = cmbKhoa.SelectedValue.ToString();
                servernameStr = Program.ServerName;
            }
            catch (Exception) { };
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được trống.", "Lỗi đăng nhập!", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }

            Program.MLogin = txtLogin.Text;
            Program.MPassword = txtPass.Text;
            Program.ServerName = servernameStr;
            if (Program.KetNoi() == 0) return;
  
            Program.MKhoa = cmbKhoa.SelectedIndex;// 0: CNTT ,  1: VT, 2: HỌC PHÍ

            Program.MLoginDN = Program.MLogin;
            Program.PasswordDN = Program.MPassword;


            String strLenh = "EXEC SP_DANGNHAP '" + Program.MLogin + "'";
            Program.MyReader = Program.ExecSqlDataReader(strLenh);
            if (Program.MyReader == null) return;
            Program.MyReader.Read();

            Program.UserName = Program.MyReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.UserName))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\nBạn xem lại username, password.", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                Program.MHoten = Program.MyReader.GetString(1);
                Program.MGroup = Program.MyReader.GetString(2);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("---> Lỗi: " + ex.ToString());
                MessageBox.Show("Login bạn nhập không có quyền truy cập vào chương trình.", "", MessageBoxButtons.OK);
                return;
            }

            Program.MyReader.Close();
            Program.Conn.Close();

            // truy cập vào frm main 
            Program.frmMain = new frmMain();

            // hiện thông tin tài khoản
            Program.frmMain.tsslMAGV.Text = "MÃ GIẢNG VIÊN: " + Program.UserName.Trim();
            Program.frmMain.tsslHOTEN.Text = "HỌ VÀ TÊN: " + Program.MHoten.Trim();
            Program.frmMain.tsslNHOM.Text = "NHÓM: " + Program.MGroup;

            Program.frmMain.Show();
            Program.FrmDangNhap = this;
            this.Visible= false;
            txtLogin.Text = "";
            txtPass.Text = "";
            txtLogin.Focus();
        }

        
        //private void frmDangNhap_VisibleChanged(object sender, EventArgs e)
        //{
        //    Program.Bds_Dspm.RemoveFilter();
        //    cmbKhoa_SelectedIndexChanged(sender, e);
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn thoát không ?", "Thông báo !", MessageBoxButtons.YesNo);
            if (ds == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
