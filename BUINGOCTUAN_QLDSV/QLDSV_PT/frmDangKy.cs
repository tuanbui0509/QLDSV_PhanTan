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
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        String nLogin = "";
        String nPass = "";
        String nUserName = "";
        String nRole = "";

        public frmDangKy()
        {
            InitializeComponent();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.V_GETDSGV' table. You can move, or remove it, as needed.
            this.v_GETDSGVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_GETDSGVTableAdapter.Fill(this.dS.V_GETDSGV);

            if (Program.MGroup == "PGV")
            { 
                cmbRole.Items.Add("PGV");
                cmbRole.Items.Add("KHOA");
                cmbRole.Items.Add("USER");
            }
            else if (Program.MGroup == "KHOA")
            {
                cmbRole.Items.Add("KHOA");
                cmbRole.Items.Add("USER");
            }
            else if (Program.MGroup == "PKT")
            {
                cmbRole.Items.Add("PKT");          
            }
            cmbRole.SelectedIndex = 0;
            if (cmbGV.SelectedIndex == -1)
            {
                MessageBox.Show("Không có giảng viên để tạo tài khoản", "Thông báo !", MessageBoxButtons.OK);
            }
            else 
            txtMAGV.Text = cmbGV.SelectedValue.ToString().Trim();

        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.Properties.UseSystemPasswordChar = (chkShowPass.Checked) ? false : true;
        }

        private void cmbGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nUserName = cmbGV.SelectedValue.ToString().Trim();
                txtMAGV.Text = cmbGV.SelectedValue.ToString().Trim();
            }
            catch (Exception) { }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {

            if (txtLogin.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Login name", "Thông báo !", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }
            else if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo !", MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }
            else if (txtMAGV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn giảng viên", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            else
            {
                nLogin = txtLogin.Text.Trim();
                nPass = txtPass.Text.Trim();
                nRole = cmbRole.Text.Trim();
                
                try
                {
                    if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
                    String str_sp = "dbo.SP_TAOLOGIN";
                    Program.Sqlcmd = Program.Conn.CreateCommand();
                    Program.Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Program.Sqlcmd.CommandText = str_sp;
                    Program.Sqlcmd.Parameters.Add("@tendangnhap", SqlDbType.NChar).Value = nLogin;
                    Program.Sqlcmd.Parameters.Add("@matkhau", SqlDbType.NChar).Value = nPass;
                    Program.Sqlcmd.Parameters.Add("@tennguoidung", SqlDbType.NChar).Value = txtMAGV.Text;
                    Program.Sqlcmd.Parameters.Add("@phanquyen", SqlDbType.NChar).Value = nRole;
                    Program.Sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Tạo Login thành công !", "Thông báo !", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("server principal"))
                    {
                        MessageBox.Show("Login name bị trùng. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                        return;
                    }
                    else if (ex.Message.Contains("User, group, or role"))
                    {
                        MessageBox.Show("Giảng viên này đã được tạo login. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.MGroup == "PGV")
            {
                nRole = "PGV";
            }
            else
            {
                nRole = "KHOA";
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thật sự muốn hủy thao tác đăng ký tài khoản?",
                      "Xác thực", MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                return;
            }
            else if (dr == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}