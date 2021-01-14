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
    public partial class frmBDTK : DevExpress.XtraEditors.XtraForm
    {
        public frmBDTK()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmBDTK_Load(object sender, EventArgs e)
        {
            //sP_REPORT_BDMHTableAdapter.Connection.ConnectionString = Program.connstr;
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
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            txtLop.Text = cmbLop.SelectedValue.ToString().Trim();
            btnInBDTK.Enabled = false;

        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLop.Text  = "";
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
                //this.sP_REPORT_BDMHTableAdapter.Connection = Program.Conn;
            }
        }

        private void lOPComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtLop.Text = cmbLop.SelectedValue.ToString().Trim();
            }
            catch (Exception) { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnInBDTK_Click(object sender, EventArgs e)
        {
            INBDTK rpt = new INBDTK(txtLop.Text.Trim());
            rpt.txtLop.Text += txtLop.Text.Trim();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            this.sP_REPORT_BDTKTableAdapter.Fill(dS.SP_REPORT_BDTK, cmbLop.SelectedValue.ToString());
            if (bdsBDTK.Count == 0)
            {
                MessageBox.Show("Lớp không có sinh viên. Không có dữ liệu để in", "Thông báo !", MessageBoxButtons.OK);
                btnInBDTK.Enabled = false;
            }
            else
            {
                btnInBDTK.Enabled = true;
            }
        }
    }
}