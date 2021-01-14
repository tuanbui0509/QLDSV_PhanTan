using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

// sử dụng kiểu kết nối với Database là sqlclient
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;

namespace QLDSV_PT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        // tạo đối tượng kết nối Conn , kêt nối Database bằng mã lệnh
        public static SqlConnection Conn = new SqlConnection();
        // dùng để thực thi lệnh
        public static SqlCommand Sqlcmd = new SqlCommand();

        // chuỗi kết nối connection string để kết nối với csdl , nó bước đầu tiên để thực hiện kết nối      
        public static String connstr;

        public static SqlDataReader MyReader;

        // những dòng này dùng trong phần tạo connection string ở bên dưới
        public static String ServerName = "";
        public static String UserName = "";

        // lưu các login và password từ các form khi chương trình chạy.
        public static String MLogin = "";
        public static String MPassword = "";

        // RemoteLogin này là remote dùng để hỗ trợ kết nối ra ngoài ví dụ trong quá trình đăng nhập nó sẽ rẽ qua server 2
        // để đăng nhập truy vấn dữ liệu thì nó dùng login này để kết nối(hay là tạo link server)
        // vì nó giống nhau trên các phân mảnh là HTKN nối nó sẽ gán cứng vào.
        public static String Database = "QLDSV";
        public static String RemoteLogin = "HTKN";
        public static String RemotePassword = "123456";

        //MLoginDN là mã login đăng nhập và mật khẩu của nó
        public static String MLoginDN = "";
        public static String PasswordDN = "";

        // 3 Mgroup , MHoten, MKhoa dùng để hiển thi thông tin login vào
        // MGroup là mã nhóm quyền khi của login đó đăng nhập vào.
        public static String MGroup = "";

        // MHoten là mã họ tên của login đăng nhập vào 
        public static String MHoten = "";

        //MKhoa cho biết hiện tại khoa ta đăng nhập vô là khoa nào.
        public static int MKhoa = 0;

        //biến dùng để chứa danh sách các phân mãnh từ viewDSPM (bằng code, ko kéo thả)
        public static BindingSource Bds_Dspm = new BindingSource(); //giu DSPM khi dang nhap
        public static BindingSource Bds_Dskhoa = new BindingSource();
        // lưu các đối tượng form Main và form FrmDangNhap để thực hiển xử lý nghiệp vụ chuyển đổi từ frmMain sang frmDangNhap và ngược lại.
        public static frmMain frmMain;
        public static frmDangNhap FrmDangNhap;

        // lưu danh sách các nhóm quyền
        //public static string[] NhomQuyen = new string[3] { "PGV", "KHOA", "PKT" };

        // hàm thực hiện kết nối tới Database
        public static int KetNoi()
        {
            if (Program.Conn != null && Program.Conn.State == ConnectionState.Open)
                // đóng đối tượng kết nối
                Program.Conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.ServerName + ";Initial Catalog=" +
                      Program.Database + ";User ID=" +
                      Program.MLogin + ";Password=" + Program.MPassword;
                Program.Conn.ConnectionString = Program.connstr;

                // mở đối tượng kết nối
                Program.Conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("---> Lỗi kết nối cơ sở dữ liệu.\n---> Bạn xem lại Username và Password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        // ExecSqlDataReader tôc độ tải về nhanh hơn, dl chỉ để đọc, chỉ duyệt 1 chiều từ trên xuống
        // form báo cáo thì dùng datareader


        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myReader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.Conn);

            //xác định kiểu lệnh cho sqlcmd là kiểu text.
            sqlcmd.CommandType = CommandType.Text;
            if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
            try
            {
                myReader = sqlcmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException ex)
            {
                Program.Conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // datatable: dl cho phép xem xóa sửa ==> tốc độ tải chậm hơn datareader
        // duyệt 2 chiều dưới lên
        // form nhập liệu thì dùng datatable.

        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Conn);
            da.Fill(dt);
            Conn.Close();
            return dt;
        }

        public static int ExecSqlNonQuery(String cmd, String connectionstring)
        {
            Conn = new SqlConnection(connectionstring);
            SqlCommand Sqlcmd = new SqlCommand();
            Sqlcmd.Connection = Conn;
            Sqlcmd.CommandText = cmd;
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 300;
            if (Conn.State == ConnectionState.Closed) Conn.Open();
            try
            {

                Sqlcmd.ExecuteNonQuery(); Conn.Close(); return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Conn.Close();
                return 0;
            }
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Application.Run(new frmDangNhap());
        }
    }
}
