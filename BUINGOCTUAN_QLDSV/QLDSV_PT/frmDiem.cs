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
using System.Data.SqlClient;

namespace QLDSV_PT
{
    public partial class frmDiem : DevExpress.XtraEditors.XtraForm
    {
        List<int> check = new List<int>();
        List<int> soLanThi = new List<int>();
        int lanthi;
        bool hasPoinht = false;
        public frmDiem()
        {
            soLanThi.Add(1);
            soLanThi.Add(2);
            InitializeComponent();
        }

        void FisrtStatus()
        {
            hasPoinht = false;
            cmbKhoa.Enabled = true;
            sp_DANHSACHNHAPDIEMDataGridView.Visible = false;
            btnGhi.Enabled = false;
            btnThoat.Enabled = true;
            //ExitForm.Enabled = true;
            btnBatDau.Enabled = true;
            btnCapNhat.Enabled = false;
            groupBox1.Enabled = true;
        }

        void changeBtn()
        {
            cmbKhoa.Enabled = false;
            groupBox1.Enabled = false;
            sp_DANHSACHNHAPDIEMDataGridView.Visible = true;
            btnGhi.Enabled = true;
            btnThoat.Enabled = true;
            //ExitForm.Enabled = false;
            btnBatDau.Enabled = false;
            btnCapNhat.Enabled = true;
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            cmbKhoa.DataSource = Program.Bds_Dskhoa;
            cmbKhoa.DisplayMember = "TENCN";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            if (Program.MGroup == "KHOA" || Program.MGroup == "USER")
            {
                cmbKhoa.Enabled = false;
            }
            else
            {
                cmbKhoa.Enabled = true;
            }

            btnGhi.Enabled = btnCapNhat.Enabled = false;
            dS.EnforceConstraints = false;
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            cmbLanThi.DataSource = soLanThi;
            cmbLanThi.SelectedIndex = 0;
            txtLop.Text = cmbLop.SelectedValue.ToString().Trim();
            txtMonHoc.Text = cmbMonHoc.SelectedValue.ToString().Trim();

            sp_DANHSACHNHAPDIEMTableAdapter.Connection = Program.Conn;

        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtLop.Text = txtMonHoc.Text = "";
            if (cmbKhoa.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Program.ServerName = cmbKhoa.SelectedValue.ToString();
            }
            if (cmbKhoa.SelectedIndex != Program.MKhoa)
            {
                Program.MLogin = Program.RemoteLogin;
                Program.MPassword = Program.RemotePassword;
            }
            else
            {
                Program.MLogin = Program.MLoginDN;
                Program.MPassword = Program.PasswordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi chuyển khoa", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            else
            {
                dS.EnforceConstraints = false;
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.dS.LOP);
                //cmbLop.SelectedIndex = 1;
                //cmbLop.SelectedIndex = 0;
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
                //cmbMonHoc.SelectedIndex = 1;
                //cmbMonHoc.SelectedIndex = 0;
                this.sp_DANHSACHNHAPDIEMTableAdapter.Connection = Program.Conn;
            }

        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMonHoc.Text = cmbMonHoc.SelectedValue.ToString().Trim();
            }
            catch (Exception) { }
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtLop.Text = cmbLop.SelectedValue.ToString().Trim();
            }
            catch (Exception) { }
        }

        private void btnGhi_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<float> listDiem = new List<float>();

            int x = Int32.Parse(bdsDSSVNhapDiem.Count.ToString());
            for (int i = 0; i < x; i++)
            {
                String Diem = ((DataRowView)bdsDSSVNhapDiem[i])["DIEM"].ToString();
                float DiemFloat = float.Parse(Diem);
                if (DiemFloat >= 10 || DiemFloat < 0)
                {
                    String Ten = ((DataRowView)bdsDSSVNhapDiem[i])["HOTEN"].ToString();
                    System.Windows.Forms.MessageBox.Show("Mời bạn nhập lại điểm cho sinh viên với Điểm từ 0-10");
                    return;
                }
                listDiem.Add(DiemFloat);
            }
            for (int i = 0; i < x; i++)
            {
                String Diem = listDiem[i].ToString();
                String Masv = ((DataRowView)bdsDSSVNhapDiem[i])["MASV"].ToString();
                SqlConnection sqlConnection = new SqlConnection(Program.connstr);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_UPDATEDIEM";
                sqlCommand.Parameters.Add(new SqlParameter("@MASV", Masv));
                sqlCommand.Parameters.Add(new SqlParameter("@MAMH", txtMonHoc.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@DIEM", Diem));
                sqlCommand.Parameters.Add(new SqlParameter("@LAN", lanthi));
                SqlParameter sqlParameter = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
                sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();


            }
            System.Windows.Forms.MessageBox.Show("Ghi điểm thành công cho sinh viên của lớp " + txtLop.Text);
            FisrtStatus();
        }

        private void btnBatDau_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtLop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Lớp", "Thông báo !", MessageBoxButtons.OK);
            }
            else if (txtMonHoc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Môn học", "Thông báo !", MessageBoxButtons.OK);
            }
            else
            {
                changeBtn();
                this.check = new List<int>();
                lanthi = int.Parse(cmbLanThi.SelectedValue.ToString());

                SqlConnection sqlConnection2 = new SqlConnection(Program.connstr);
                SqlCommand sqlCommand2 = sqlConnection2.CreateCommand();
                this.sp_DANHSACHNHAPDIEMTableAdapter.Connection = sqlConnection2;
                sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand2.CommandText = "SP_KIEMTRADIEMTHEOLAN";
                sqlCommand2.Parameters.Add(new SqlParameter("@MALOP", txtLop.Text));
                sqlCommand2.Parameters.Add(new SqlParameter("@MAMH", txtMonHoc.Text));
                sqlCommand2.Parameters.Add(new SqlParameter("@LAN", 1));
                SqlParameter sqlParameter2 = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
                sqlParameter2.Direction = System.Data.ParameterDirection.ReturnValue;
                sqlCommand2.Parameters.Add(sqlParameter2);
                sqlConnection2.Open();
                sqlCommand2.ExecuteNonQuery();
                int result = (int)sqlCommand2.Parameters["@return"].Value;
                //Console.WriteLine(result);
                sqlConnection2.Close();
                if (result == 1 )
                {

                    if (lanthi == 2)
                    {
                        FisrtStatus();
                        MessageBox.Show("Môn này chưa nhập điểm lần 1");
                        return;
                    }
                }
                else
                {

                    SqlConnection sqlConnection3 = new SqlConnection(Program.connstr);
                    SqlCommand sqlCommand3 = sqlConnection3.CreateCommand();
                    sqlCommand3.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand3.CommandText = "SP_KIEMTRADIEMTHEOLAN";
                    sqlCommand3.Parameters.Add(new SqlParameter("@MALOP", txtLop.Text));
                    sqlCommand3.Parameters.Add(new SqlParameter("@MAMH", txtMonHoc.Text));
                    sqlCommand3.Parameters.Add(new SqlParameter("@LAN", 2));
                    SqlParameter sqlParameter3 = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
                    sqlParameter3.Direction = System.Data.ParameterDirection.ReturnValue;
                    sqlCommand3.Parameters.Add(sqlParameter3);
                    sqlConnection3.Open();
                    sqlCommand3.ExecuteNonQuery();
                    int result3 = (int)sqlCommand3.Parameters["@return"].Value;

                    if (lanthi == 1)
                    {
                        if (result3 == 2)
                        {
                            FisrtStatus();
                            MessageBox.Show("Sinh viên đã có điểm lần 2");
                            return;
                        }
                        //Đã có điểm lần 1 không xóa
                        this.sp_DANHSACHNHAPDIEMTableAdapter.Fill(this.dS.sp_DANHSACHNHAPDIEM, txtLop.Text, txtMonHoc.Text, (short)lanthi);
                        hasPoinht = true;
                    }
                    if (lanthi == 2)
                    {

                        if (result3 == 2)
                        {
                            // Đã có điểm lần 2 không xóa
                            sqlConnection3.Close();
                            this.sp_DANHSACHNHAPDIEMTableAdapter.Fill(this.dS.sp_DANHSACHNHAPDIEM, txtLop.Text, txtMonHoc.Text, (short)lanthi);
                            hasPoinht = true;
                        }
                    }
                }
 
                try
                {
                    string message = "Bạn có muốn nhập điểm lần " + lanthi + " không?";
                    string title = "Xác nhận nhập điểm";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult dialogResult = MessageBox.Show(message, title, buttons);
                    if (dialogResult == DialogResult.No)
                    {
                        FisrtStatus();
                        return;
                    }

                    String lenh = "SELECT MASV FROM SINHVIEN WHERE MALOP ='" + txtLop.Text + "'AND NGHIHOC = 0";
                    SqlDataReader kts = Program.ExecSqlDataReader(lenh);

                    int k = 0;
                    while (kts.Read())  //đọc từng sinh vien kiem tra diem co > 4 hay khong
                    {
                        SqlConnection sqlConnection = new SqlConnection(Program.connstr);
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.CommandText = "[dbo].[sp_KHOITAODIEMAOSINHVIEN]";
                        sqlCommand.Parameters.Add(new SqlParameter("@MASV", kts.GetString(0)));
                        sqlCommand.Parameters.Add(new SqlParameter("@MAMH", txtMonHoc.Text));
                        sqlCommand.Parameters.Add(new SqlParameter("@LAN", lanthi));
                        SqlParameter sqlParameter = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
                        sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        k++;
                        sqlConnection.Close();
                    }
                    Console.WriteLine(k);
                    kts.Close();
                    if (k == 0) { MessageBox.Show("Lớp không có sinh viên nhập điểm");
                        FisrtStatus();
                        return;
                    }

                    //fill điểm ra sp để nhập điểm
                    this.sp_DANHSACHNHAPDIEMTableAdapter.Fill(this.dS.sp_DANHSACHNHAPDIEM, txtLop.Text, txtMonHoc.Text, (short)lanthi);
                    if (lanthi == 2 && bdsDSSVNhapDiem.Count == 0)
                    {
                        MessageBox.Show("Tất cả sinh viên đã có điểm lần 1 lớn 4 nên không nhập điểm lần 2");
                        FisrtStatus();
                        return;
                    }
                }
                catch (System.Exception ex)
                {
                }
            }
        }

        private void btnCapNhat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (hasPoinht)
            {
                FisrtStatus();
                return;
            }
            string message = "Bạn có muốn hủy bỏ điểm lần " + lanthi + " không?";
            string title = "Xác nhận hủy bỏ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult dialogResult = MessageBox.Show(message, title, buttons);
            if (dialogResult == DialogResult.Yes)
            {
                FisrtStatus();
                for (int i = 0; i < bdsDSSVNhapDiem.Count; i++)
                {
                    String Diem = ((DataRowView)bdsDSSVNhapDiem[i])["DIEM"].ToString();
                    String Masv = ((DataRowView)bdsDSSVNhapDiem[i])["MASV"].ToString();
                    String Ten = ((DataRowView)bdsDSSVNhapDiem[i])["HOTEN"].ToString();
                    SqlConnection sqlConnection = new SqlConnection(Program.connstr);
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_XOADIEMKHONGLUU";
                    sqlCommand.Parameters.Add(new SqlParameter("@MASV", Masv));
                    sqlCommand.Parameters.Add(new SqlParameter("@MAMH", txtMonHoc.Text));
                    // sqlCommand.Parameters.Add(new SqlParameter("@DIEM", Diem));
                    sqlCommand.Parameters.Add(new SqlParameter("@LAN", lanthi));
                    SqlParameter sqlParameter = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
                    sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                MessageBox.Show("Dữ Liệu Đã Bị Hủy Bỏ");
            }
        }

        private void btnThoat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void sp_DANHSACHNHAPDIEMDataGridView_Click(object sender, EventArgs e)
        {

        }
    }

}