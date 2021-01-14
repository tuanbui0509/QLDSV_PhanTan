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

namespace QLDSV_PT
{
    public partial class frmChuyenLop : DevExpress.XtraEditors.XtraForm
    {
        private int position;
        private String masvCu = "";

        public frmChuyenLop()
        {
            InitializeComponent();
        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            cmbKhoa.DataSource = Program.Bds_Dskhoa;
            cmbKhoa.DisplayMember = "TENCN";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;
            if (Program.MGroup == "KHOA" || Program.MGroup == "USER")
            {
                cmbKhoa.Enabled = false;
                //btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }
            txtMaLopMoi.Text = cmbLop.SelectedValue.ToString().Trim();

        }

        private void butonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Program.ServerName = cmbKhoa.SelectedValue.ToString();
                //Program.MKhoa = cmbKhoa.SelectedIndex;
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
                try
                {
                    dS.EnforceConstraints = false;
                    // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
                    this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOATableAdapter.Fill(this.dS.KHOA);
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.dS.LOP);
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                    txtMaLopMoi.Text = cmbLop.SelectedValue.ToString().Trim();
                }
                catch (Exception) { }
            }
        }

        private void buttonChuyenLop_Click(object sender, EventArgs e)
        {
            if (txtMaSVMoi.Text.Trim() == "")
            {
                MessageBox.Show("VUI LÒNG NHẬP MÃ SINH VIÊN !", "THÔNG BÁO", MessageBoxButtons.OK);
                txtMaSVMoi.Focus();
                return;
            }
            else
            {
                if (Program.KetNoi() == 0) return;
                String lenh = "EXEC SP_CHUYENLOP '" +txtMaLopCu.Text  + "','" + txtMaLopMoi.Text + "','" + masvCu + "','" + txtMaSVMoi.Text + "'";
                int k = Program.ExecSqlNonQuery(lenh, Program.connstr);
                if (k == 1)
                {
                    MessageBox.Show("CHUYỂN LỚP THÀNH CÔNG ", "THÔNG BÁO", MessageBoxButtons.OK);
                }

            }

        }

        private void lookUpEditChuyenLop_EditValueChanged(object sender, EventArgs e)
        {
            var selectedSV = cmbSinhVien.GetSelectedDataRow() as DataRowView;
            if (Boolean.Parse(selectedSV.Row["NGHIHOC"].ToString()) == true)
            {
                MessageBox.Show("Sinh viên này đã nghỉ học nên không thể chuyển lớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            txtHoten.Text = selectedSV.Row["HO"] + " " + selectedSV.Row["TEN"];
            txtMaLopCu.Text = selectedSV.Row["MALOP"].ToString();
            position = this.bdsSinhVien.Find("MASV", selectedSV.Row["MASV"].ToString());
            this.bdsSinhVien.Position = position;
            masvCu = (((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString().Trim());

            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
        }


        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaLopMoi.Text = cmbLop.SelectedValue.ToString().Trim();
            }
            catch (Exception) { }
        }
    }
}