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

namespace QLDSV_PT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Boolean dangxuat = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Program.MGroup == "PKT")
            {
                btnChuyenLop.Enabled = btn_Class.Enabled = btn_Subject.Enabled = btn_Student.Enabled = btn_Mark.Enabled = btn_Change.Enabled = false;
                btn_InDSSV.Enabled = btn_DSKTM.Enabled = btn_InPD.Enabled = btn_InBDMH.Enabled = btn_InBDTK.Enabled = false;
            }
            else
            {
                btn_Fee.Enabled = btn_InDSHPL.Enabled = btnThemHP.Enabled = false;
            }
            if (Program.MGroup == "USER")
            {
                btn_Change.Enabled = btn_TaoTK.Enabled = btnChuyenLop.Enabled = ribBaoCao.Visible = false;

            }

            

        }

        private void ShowMdiChildren(Type fType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    f.Activate();
                    return;
                }
            }
            Form form = (Form)Activator.CreateInstance(fType);
            form.MdiParent = this;
            form.Show();
        }

        private void btn_Class_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(Program.MGroup == "PKT"))
            {
                ShowMdiChildren(typeof(frmLop));
            }
        }

        private void btn_Subject_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(Program.MGroup == "PKT"))
            {
                ShowMdiChildren(typeof(frmMonHoc));
            }
        }

        private void btn_Student_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(Program.MGroup == "PKT"))
            {
                ShowMdiChildren(typeof(frmSinhVien));
            }
        }

        private void btn_Mark_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(Program.MGroup == "PKT"))
            {
                ShowMdiChildren(typeof(frmDiem));
            }
        }

        private void btn_Change_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(Program.MGroup == "PKT"))
            {
                ShowMdiChildren(typeof(frmChuyenLop));
            }
        }

        private void btn_Fee_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((Program.MGroup == "PKT"))
            {
                ShowMdiChildren(typeof(frmHocPhi));
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!dangxuat)
            {
                if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    this.Dispose();
                    Program.FrmDangNhap.Close();
                }

            }
        }

        private void btn_TaoTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(frmDangKy));
        }

        private void btn_DangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn đăng xuất không ?", "Thông báo !", MessageBoxButtons.YesNo);
            if (ds == DialogResult.Yes)
            {
                this.Hide();

                Program.FrmDangNhap.Visible = true;
            }
        }

        private void btn_InDSSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmINDSSV));
        }

        private void btn_InHPL_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmINDSDHP));
        }

        private void btn_InPD_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmINPD));
        }

        private void btn_InBDMH_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmBDMH));

        }

        private void btn_InBDTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmBDTK));
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmDSKTM));

        }

        private void btn_InDSThi_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnDSKTM_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmDSKTM));

        }

        private void btn_InDSHPL_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(Report.frmINDSDHP));
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(ThemHocPhi));
        }

        private void btnChuyenLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildren(typeof(frmChuyenLop));
        }
    }
}