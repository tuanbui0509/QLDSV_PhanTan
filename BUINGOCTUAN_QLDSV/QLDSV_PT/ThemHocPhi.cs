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
    public partial class ThemHocPhi : DevExpress.XtraEditors.XtraForm
    {
        private int position;
        List<int> sohocky = new List<int>();
        List<string> sonienkhoa = new List<string>();
        String masv = "";
        public ThemHocPhi()
        {
            sohocky.Add(1);
            sohocky.Add(2);
            InitializeComponent();
        }
        private void ThemHocPhi_Load(object sender, EventArgs e)
        {
            cmbHocKy.DataSource = sohocky;
            cmbHocKy.SelectedIndex = 0;
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            string currentyear = datevalue.Year.ToString();
            int oldyear = int.Parse(currentyear) - 10;
            for (int i = 0; i < 13; i++)
            {
                string tmp = oldyear + "-" + (oldyear + 1);
                oldyear = oldyear + 1;
                sonienkhoa.Add(tmp);
            }
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.SINHVIEN_HOCPHI' table. You can move, or remove it, as needed.
            this.sINHVIEN_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIEN_HOCPHITableAdapter.Fill(this.dS.SINHVIEN_HOCPHI);
            // TODO: This line of code loads data into the 'dS.HOCPHI' table. You can move, or remove it, as needed.
            this.sP_INDS_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDS_HOCPHITableAdapter.Fill(this.dS.SP_INDS_HOCPHI, " ");
            cmbnienkhoa.DataSource = sonienkhoa;
            cmbnienkhoa.SelectedIndex = 10;
            btnDelete.Enabled = btnUpdate.Enabled  = btnSave.Enabled = false;
            btnRefesh.Enabled = true;
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int hocphi = Int32.Parse(txtHocPhi.Text);

                if (Program.KetNoi() == 0) return;
                String lenh = "EXEC SP_TAOHOCPHICHOSINHVIEN '" + masv.ToUpper() + "','" + cmbnienkhoa.Text + "','" + Int32.Parse(cmbHocKy.Text) + "','" + Int32.Parse(txtHocPhi.Text) + "'";
                int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
                if (n == 1)
                {
                    MessageBox.Show("Tạo học phí thành công cho sinh viên có mã " + masv.ToUpper(), "Thông báo", MessageBoxButtons.OK);
                }
                txtHocPhi.Text = " ";
            }
            catch (Exception)
            {
                MessageBox.Show("Số tiền đóng không hợp lệ ", "Thông báo", MessageBoxButtons.OK);
            }
            this.sP_INDS_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDS_HOCPHITableAdapter.Fill(this.dS.SP_INDS_HOCPHI, masv);

        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDelete.Enabled = btnUpdate.Enabled = btnSave.Enabled  = false;
            txtHocPhi.Text = txtHoten.Text = txtLop.Text = txtHocPhi.Text = "";
            cmbHocKy.SelectedIndex = 0;
            cmbnienkhoa.SelectedIndex = 0;
            this.sP_INDS_HOCPHITableAdapter.Fill(this.dS.SP_INDS_HOCPHI, " ");
            cmbSinhVien.Text = " ";
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void cmbSinhVien_EditValueChanged(object sender, EventArgs e)
        {
            
            var selectedSV = cmbSinhVien.GetSelectedDataRow() as DataRowView;
            if (Boolean.Parse(selectedSV.Row["NGHIHOC"].ToString()) == true)
            {
                MessageBox.Show("Sinh viên này đã nghỉ học nên không thể thêm học phí", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            txtHoten.Text = selectedSV.Row["HO"] + " " + selectedSV.Row["TEN"];
            txtLop.Text = selectedSV.Row["MALOP"].ToString();
            position = this.bdsSinhVien.Find("MASV", selectedSV.Row["MASV"].ToString());
            this.bdsSinhVien.Position = position;
            masv = (((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString().Trim());

            this.sINHVIEN_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIEN_HOCPHITableAdapter.Fill(this.dS.SINHVIEN_HOCPHI);
            this.sP_INDS_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDS_HOCPHITableAdapter.Fill(this.dS.SP_INDS_HOCPHI, masv);
            if (bdsHocPhi.Count > 0)
            {
                btnDelete.Enabled = btnUpdate.Enabled = btnSave.Enabled =  true;
            }
            else btnDelete.Enabled = btnUpdate.Enabled = btnSave.Enabled = false;

        }

        private void sP_INDS_HOCPHIGridControl_Click(object sender, EventArgs e)
        {
            txtHocPhi.Text = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCPHI"].ToString();
            cmbHocKy.Text = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCKY"].ToString();
            cmbnienkhoa.Text = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["NIENKHOA"].ToString();

        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            String hocphi = txtHocPhi.Text.Trim();
            String hocky = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCKY"].ToString();
            String nienkhoa = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["NIENKHOA"].ToString();
            try
            {
                int hp = Int32.Parse(hocphi);
                if (hp < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Học phí phải lớn hơn 0!");
                }
                else
                {
                    int stdd = Int32.Parse(((DataRowView)bdsHocPhi[bdsHocPhi.Position])["SOTIENDADONG"].ToString());
                    if (stdd > hp)
                    {
                        System.Windows.Forms.MessageBox.Show("Chỉnh sửa học phí không được nhỏ hơn số tiền đã đóng!");
                    }
                    else
                    {
                        SqlConnection sqlConnection = new SqlConnection(Program.connstr);
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.CommandText = "SP_UPDATEHOCPHI";
                        sqlCommand.Parameters.Add(new SqlParameter("@MASV", masv));
                        sqlCommand.Parameters.Add(new SqlParameter("@NIENKHOA", nienkhoa));
                        sqlCommand.Parameters.Add(new SqlParameter("@HOCKY", Int32.Parse(hocky)));
                        sqlCommand.Parameters.Add(new SqlParameter("@HOCPHI", hp));
                        SqlParameter sqlParameter = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
                        sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                this.sP_INDS_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.sP_INDS_HOCPHITableAdapter.Fill(this.dS.SP_INDS_HOCPHI, masv);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Dữ liệu không đúng định dạng!");
            }
            
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlConnection sqlConnection2 = new SqlConnection(Program.connstr);
            SqlCommand sqlCommand2 = sqlConnection2.CreateCommand();
            this.sP_INDS_HOCPHITableAdapter.Connection = sqlConnection2;
            sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand2.CommandText = "[dbo].[SP_TONTAI_CT_HOCPHI]";
            sqlCommand2.Parameters.Add(new SqlParameter("@MASV", masv));
            sqlCommand2.Parameters.Add(new SqlParameter("@NIENKHOA", (cmbnienkhoa.Text.Trim())));
            sqlCommand2.Parameters.Add(new SqlParameter("@HOCKY", Int32.Parse(cmbHocKy.Text.Trim())));
            SqlParameter sqlParameter2 = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
            sqlParameter2.Direction = System.Data.ParameterDirection.ReturnValue;
            sqlCommand2.Parameters.Add(sqlParameter2);
            sqlConnection2.Open();
            sqlCommand2.ExecuteNonQuery();
            int result = (int)sqlCommand2.Parameters["@return"].Value;
            //Console.WriteLine(result);
            sqlConnection2.Close();
            if (result == 1)
            {
                System.Windows.Forms.MessageBox.Show("Học phí đã đóng không được xóa!");
            }
            else
            {
                DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn xóa học phí không ?", "Thông báo !", MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    SqlConnection sqlConnection = new SqlConnection(Program.connstr);
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_DELETEHOCPHI";
                    sqlCommand.Parameters.Add(new SqlParameter("@MASV", masv));
                    sqlCommand.Parameters.Add(new SqlParameter("@NIENKHOA", (cmbnienkhoa.Text.Trim())));
                    sqlCommand.Parameters.Add(new SqlParameter("@HOCKY", Int32.Parse(cmbHocKy.Text.Trim())));
                    SqlParameter sqlParameter = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
                    sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            this.sP_INDS_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDS_HOCPHITableAdapter.Fill(this.dS.SP_INDS_HOCPHI, masv);
        }
    }
}