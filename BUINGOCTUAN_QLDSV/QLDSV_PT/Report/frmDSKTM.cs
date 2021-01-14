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
using DevExpress.XtraReports.UI;

namespace QLDSV_PT.Report
{
    public partial class frmDSKTM : DevExpress.XtraEditors.XtraForm
    {

        List<int> soLanThi = new List<int>();
        List<int> hocky = new List<int>();
        int hky;
        int lanthi;
        public frmDSKTM()
        {
            soLanThi.Add(1);
            soLanThi.Add(2);
            hocky.Add(1);
            hocky.Add(2);
            InitializeComponent();
        }

        private void frmDSKTM_Load(object sender, EventArgs e)
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

            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            btnInDSKTM.Enabled = false;
            cmbLanThi.DataSource = soLanThi;
            cmbLanThi.SelectedIndex = 0;
            cmbHK.DataSource = hocky;
            cmbHK.SelectedIndex = 0;
            sP_REPORT_DSKTMTableAdapter.Connection = Program.Conn;
            txtLop.Text = cmbLop.SelectedValue.ToString().Trim();
            txtMonHoc.Text = cmbMonHoc.SelectedValue.ToString().Trim();
            DateNThi.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
        }

        private void btnInDSKTM_Click(object sender, EventArgs e)
        {

            INDSKTM rpt = new INDSKTM(txtLop.Text, txtMonHoc.Text, (short)lanthi);
            rpt.lblLop.Text = "LỚP: " + txtLop.Text;
            rpt.lblLan.Text = "LẦN THI: " + lanthi.ToString();
            rpt.lblMonHoc.Text = "MÔN HỌC: " + txtMonHoc.Text;
            rpt.lblNgayThi.Text = "NGÀY THI: " + DateNThi.Text;
            rpt.lblHocky.Text = "HỌC KỲ: " + cmbHK.Text.ToString();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (txtLop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Lớp", "Thông báo !", MessageBoxButtons.OK);
            }
            else if (txtMonHoc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Môn học", "Thông báo !", MessageBoxButtons.OK);
            }
            else if (DateNThi.ToString().Trim() =="")
            {
                MessageBox.Show("Vui lòng chọn Ngày thi", "Thông báo !", MessageBoxButtons.OK);

            }
            else
            {
                try
                {
                    lanthi = int.Parse(cmbLanThi.SelectedValue.ToString());
                    hky = int.Parse(cmbHK.SelectedValue.ToString());

                    MessageBox.Show("Mã lớp: " + txtLop.Text.Trim() + ", Mã môn học: " + txtMonHoc.Text.Trim() + ", Lần thi: " + lanthi,
                                                    "Xác nhận", MessageBoxButtons.OK);
                    sP_REPORT_DSKTMTableAdapter.Fill(dS.SP_REPORT_DSKTM, txtLop.Text, txtMonHoc.Text, (short)lanthi);
                    if (bdsDSKTM.Count == 0)
                    {
                        MessageBox.Show("Sinh viên chưa có điểm để in", "Thông báo !", MessageBoxButtons.OK);
                        btnInDSKTM.Enabled = false;
                    }
                    else
                    {
                        btnInDSKTM.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("NO STUDENT"))
                    {
                        MessageBox.Show("Mã sinh viên không tồn tại", "Thông báo !", MessageBoxButtons.OK);
                        btnInDSKTM.Enabled = false;
                        return;
                    }
                }
            }
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
                this.sP_REPORT_DSKTMTableAdapter.Connection = Program.Conn;
            }
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                txtLop.Text = cmbLop.SelectedValue.ToString().Trim();
            }
            catch (Exception) { }
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMonHoc.Text = cmbMonHoc.SelectedValue.ToString().Trim();
            }
            catch (Exception) { }
        }

       
    }
}