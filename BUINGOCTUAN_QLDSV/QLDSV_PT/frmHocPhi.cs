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
using System.Globalization;

namespace QLDSV_PT
{
    public partial class frmHocPhi : DevExpress.XtraEditors.XtraForm
    {
        private int position;
        List<int> sohocky = new List<int>();
        List<string> sonienkhoa = new List<string>();
        String masv = "";
        public frmHocPhi()
        {
            sohocky.Add(1);
            sohocky.Add(2);
            InitializeComponent();
        }

        private void frmHocPhi_Load(object sender, EventArgs e)
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
            cmbnienkhoa.DataSource = sonienkhoa;

            cmbnienkhoa.SelectedIndex = 10;
            //this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            btn_Save.Enabled = false;
            this.sINHVIEN_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIEN_HOCPHITableAdapter.Fill(this.dS.SINHVIEN_HOCPHI);
            this.sP_INDS_HOCPHI1TableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDS_HOCPHI1TableAdapter.Fill(this.dS.SP_INDS_HOCPHI1, "");
            btnRefesh.Enabled = true;

        }

        void bonnut(bool flag)
        {
            btndelete.Enabled = flag;
            btnsave.Enabled = flag;
            btnadd.Enabled = flag;
            btnupdate.Enabled = flag;
            //hpmssv1.ReadOnly = flag;
        }

        public string xnienkhoa = "";
        public string xhocky = "";

        void XuatDSHPCuaSinhVien(string mssv)
        {
            string strLenh = "EXEC [dbo].[SP_INDS_HOCPHI] '" + mssv + "' ";

            Program.MyReader = Program.ExecSqlDataReader(strLenh);

            if (Program.MyReader == null) return;
            Program.MyReader.Read();

            Program.MyReader.Close();
        }

        private void btnadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnupdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btndelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnsave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnexit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int hocphi = Int32.Parse(((DataRowView)bdsDSHP[bdsDSHP.Position])["HOCPHI"].ToString());
                int stdd = Int32.Parse(((DataRowView)bdsDSHP[bdsDSHP.Position])["SOTIENDADONG"].ToString());
                int std = Int32.Parse(hpSTD.Text);
                if (std == 0)
                {
                    MessageBox.Show("Số tiền đóng không hợp lệ ", "Thông báo", MessageBoxButtons.OK);
                }
                else if (hocphi < stdd + std)
                {
                    MessageBox.Show("Số tiền đóng không được lớn hơn học phí ", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    if (Program.KetNoi() == 0) return;
                    String lenh = "EXEC SP_DONGHOCPHI_SINHVIEN '" + masv.ToUpper() + "','" + txtNienKhoa.Text + "','" + Int32.Parse(txtHocKy.Text) + "','" + Int32.Parse(hpSTD.Text) + "'";
                    int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
                    if (n == 1)
                    {
                        this.sP_INDS_HOCPHI1TableAdapter.Connection.ConnectionString = Program.connstr;
                        this.sP_INDS_HOCPHI1TableAdapter.Fill(this.dS.SP_INDS_HOCPHI1, masv);
                        MessageBox.Show("Đóng tiền thành công sinh viên \n  MSSV: " + masv.ToUpper() + "\n  Họ và tên: " + hphoten.Text, "Thông báo", MessageBoxButtons.OK);
                        this.sP_INDS_HOCPHI1TableAdapter.Connection.ConnectionString = Program.connstr;
                        this.sP_INDS_HOCPHI1TableAdapter.Fill(this.dS.SP_INDS_HOCPHI1, masv);
                        hocphi = Int32.Parse(((DataRowView)bdsDSHP[bdsDSHP.Position])["HOCPHI"].ToString());
                        if (hocphi == stdd) { hpSTD.Enabled = false; hpSTD.Text = "Đã đóng đủ tiền!"; }
                        else
                        {
                            hpSTD.Enabled = true;
                            hpSTD.Text = "0";
                        }
                    }
                    hpSTD.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số tiền đóng không hợp lệ ", "Thông báo", MessageBoxButtons.OK);
                //System.Windows.Forms.MessageBox.Show(ex.Message);

            }


        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btn_Save.Enabled = false;
            hphoten.Text = hplop.Text = txtHocKy.Text =
                txtHocPhi.Text = txtNienKhoa.Text = txtSTDD.Text  = "";
            hpSTD.Text = "0";
            this.sP_INDS_HOCPHI1TableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDS_HOCPHI1TableAdapter.Fill(this.dS.SP_INDS_HOCPHI1, "");
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }



        private void sP_INDS_HOCPHI1GridControl_Click(object sender, EventArgs e)
        {
            if (bdsDSHP.Count > 0)
            {
                int hocphi = Int32.Parse(((DataRowView)bdsDSHP[bdsDSHP.Position])["HOCPHI"].ToString());
                int stdd = Int32.Parse(((DataRowView)bdsDSHP[bdsDSHP.Position])["SOTIENDADONG"].ToString());
                if (hocphi == stdd) { hpSTD.Enabled = false; hpSTD.Text = "Đã đóng đủ tiền!"; }
                else
                {
                    hpSTD.Enabled = true;
                    hpSTD.Text = "0";
                }
            }

        }

        private void cmbSinhVien_EditValueChanged(object sender, EventArgs e)
        {
            var selectedSV = cmbSinhVien.GetSelectedDataRow() as DataRowView;
            if (Boolean.Parse(selectedSV.Row["NGHIHOC"].ToString()) == true)
            {
                MessageBox.Show("Sinh viên này đã nghỉ học nên không thể đóng học phí", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            hphoten.Text = selectedSV.Row["HO"] + " " + selectedSV.Row["TEN"];
            hplop.Text = selectedSV.Row["MALOP"].ToString();
            position = this.bdsSinhVien.Find("MASV", selectedSV.Row["MASV"].ToString());
            this.bdsSinhVien.Position = position;
            masv = (((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString().Trim());

            this.sINHVIEN_HOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIEN_HOCPHITableAdapter.Fill(this.dS.SINHVIEN_HOCPHI);
            this.sP_INDS_HOCPHI1TableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDS_HOCPHI1TableAdapter.Fill(this.dS.SP_INDS_HOCPHI1, masv);
            if (bdsDSHP.Count > 0)
            {
                btn_Save.Enabled = true;
                int hocphi = Int32.Parse(((DataRowView)bdsDSHP[bdsDSHP.Position])["HOCPHI"].ToString());
                int stdd = Int32.Parse(((DataRowView)bdsDSHP[bdsDSHP.Position])["SOTIENDADONG"].ToString());
                if (hocphi == stdd) { hpSTD.Enabled = false; hpSTD.Text = "Đã đóng đủ tiền!"; }
                else
                {
                    hpSTD.Enabled = true;
                    hpSTD.Text = "0";
                }
            }
            else { btn_Save.Enabled = false; hpSTD.Text = "0"; }

        }
    }
}