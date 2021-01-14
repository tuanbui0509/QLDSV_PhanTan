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
using System.Data.SqlClient;

namespace QLDSV_PT
{
    public partial class frmLop : DevExpress.XtraEditors.XtraForm
    {
        string maKhoa = "";
        Int32 vitri = 0;
        Boolean isEditing = true;
        String beforeUpdate;
        String statement;
        UndoAndRedo undoStack;
        UndoAndRedo redoStack;
        public frmLop()
        {
            InitializeComponent();
        }


        private void ToolbarForm1_Load(object sender, EventArgs e)
        {
            undoStack = new UndoAndRedo();
            redoStack = new UndoAndRedo();

            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            kHOAComboBox.DataSource = Program.Bds_Dskhoa;
            kHOAComboBox.DisplayMember = "TENCN";
            kHOAComboBox.ValueMember = "TENSERVER";
            kHOAComboBox.SelectedIndex = Program.MKhoa;
            if (Program.MGroup == "KHOA" || Program.MGroup == "USER")
            {
                kHOAComboBox.Enabled = false;
                btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }

            dS.EnforceConstraints = false;
            btnSave.Enabled = false;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'qLDSVDataSet.KHOA' table. You can move, or remove it, as needed.

            maKhoa = ((DataRowView)bsdKHOA[0])["MAKH"].ToString().Trim();
            // TODO: This line of code loads data into the 'qLDSVDataSet.LOP' table. You can move, or remove it, as needed.
            btnEdit.Visible = true;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;

            beforeUpdate = ((DataRowView)bsdLOP[0])["TENLOP"].ToString();
        }



        private void lOPBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bsdLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void kHOAComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (kHOAComboBox.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Program.ServerName = kHOAComboBox.SelectedValue.ToString();

            }
            if (kHOAComboBox.SelectedIndex != Program.MKhoa)
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
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr; // lấy data của Site tương ứng
                    this.lOPTableAdapter.Fill(this.dS.LOP);
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                    this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOATableAdapter.Fill(this.dS.KHOA);
                    maKhoa = ((DataRowView)bsdKHOA[0])["MAKH"].ToString().Trim();

                }
                catch (Exception) { }
            }
            undoStack.stack.Clear();
            redoStack.stack.Clear();
            btnUndo.Enabled = false;
            beforeUpdate = "";
        }

        #region CODE CŨ


        private void btnThem_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void btnGhi_ItemClick_1(object sender, ItemClickEventArgs e)
        {



        }

        private void btnXoa_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPhucHoi_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }
        #endregion
        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            vitri = bsdLOP.Position;
            isEditing = false;
            bsdLOP.AddNew();
            lOPGridControl.Enabled = false;
            txtKhoa.Text = maKhoa;
            txtMaLop.ReadOnly = false;
            txtMaLop.Focus();
            btnAdd.Enabled = btnExit.Enabled = btnRemove.Enabled = false;
            kHOAComboBox.Enabled = false;

            btnSave.Enabled = true;
            btnEdit.Visible = false;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;

        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtMaLop.Focus();
            }
            else if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtTenLop.Focus();
            }
            else
            {
                if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
                String str_sp = "dbo.SP_CHECKTRUNGMALOP";
                Program.Sqlcmd = Program.Conn.CreateCommand();
                Program.Sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.Sqlcmd.CommandText = str_sp;
                Program.Sqlcmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = txtMaLop.Text;
                Program.Sqlcmd.Parameters.Add("@TENLOP", SqlDbType.VarChar).Value = txtTenLop.Text;
                Program.Sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.Sqlcmd.ExecuteNonQuery();
                String ret = Program.Sqlcmd.Parameters["@Ret"].Value.ToString();
                if (ret == "1" && isEditing == false)
                {
                    MessageBox.Show("Mã lớp đã tồn tại. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    try
                    {
                        bsdLOP.EndEdit();       // kết thúc quá trình hiệu chỉnh
                        bsdLOP.ResetCurrentItem();      // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực
                        this.lOPTableAdapter.Update(this.dS.LOP);       // đẩy dl vừa ghi tạm về CSDL -> adapter (liên quan đến database)

                        lOPGridControl.Enabled = true;
                        btnAdd.Enabled = btnExit.Enabled = btnRemove.Enabled = true;

                        txtMaLop.ReadOnly = true;
                        isEditing = true;
                        kHOAComboBox.Enabled = true;

                        btnSave.Enabled = false;
                        btnEdit.Visible = true;
                        beforeUpdate = ((DataRowView)bsdLOP[bsdLOP.Position])["TENLOP"].ToString();
                        statement = "delete from LOP where MALOP = '" + txtMaLop.Text + "'";
                        undoStack.pushStack(statement);
                        btnUndo.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("UNIQUE KEY"))
                        {
                            MessageBox.Show("Tên lớp bị trùng. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi ghi Lớp. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                        }
                    }
                }
            }

        }

        private void btnRemove_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bsdLOP.Count == 0)
            {
                return;
            }
            else
            {
                if (bsdSV.Count > 0)
                {
                    MessageBox.Show("Lớp có sinh viên, không được xóa", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn xóa Lớp ?", "Thông báo !", MessageBoxButtons.YesNo);
                    if (ds == DialogResult.Yes)
                    {
                        try
                        {
                            String removeBack = "insert into LOP(MALOP,TENLOP,MAKH) values('" + txtMaLop.Text + "',N'" + txtTenLop.Text + "','" + txtKhoa.Text + "')";
                            undoStack.pushStack(removeBack);
                            bsdLOP.RemoveCurrent();         //xóa row đang chọn ra khỏi dataset
                            this.lOPTableAdapter.Update(this.dS.LOP);
                            btnUndo.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa Lớp. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            bsdLOP.CancelEdit();
            this.lOPTableAdapter.Fill(this.dS.LOP);
            if (isEditing == false)
            {
                bsdLOP.Position = vitri;
                lOPGridControl.Enabled = true;
                btnAdd.Enabled = btnExit.Enabled = btnRemove.Enabled = true;
                txtMaLop.ReadOnly = true;
                isEditing = true;
                btnSave.Enabled = false;
                btnEdit.Visible = true;
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            undoStack.stack.Clear();
            redoStack.stack.Clear();

            this.Close();
        }

        private void lOPGridControl_Click(object sender, EventArgs e)
        {
            beforeUpdate = ((DataRowView)bsdLOP[bsdLOP.Position])["TENLOP"].ToString();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tên", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }

            if (beforeUpdate != ((DataRowView)bsdLOP[bsdLOP.Position])["TENLOP"].ToString())
            {
                bsdLOP.EndEdit();        // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                bsdLOP.ResetCurrentItem();       // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                this.lOPTableAdapter.Update(this.dS.LOP);         // cập nhật dl từ dataset về database thông qua tableadapter
                statement = "UPDATE LOP SET TENLOP = N'" + beforeUpdate + "' WHERE MALOP = '" + txtMaLop.Text + "';";
                undoStack.stack.Push(statement);
                beforeUpdate = ((DataRowView)bsdLOP[bsdLOP.Position])["TENLOP"].ToString();
                btnUndo.Enabled = true;
            }
        }

       

        private void btnUndo_ItemClick(object sender, ItemClickEventArgs e)
        {
            bsdLOP.CancelEdit();
            if (Program.KetNoi() == 0) return;
            String lenh = undoStack.popStack();
            if (lenh.Contains("delete"))
            {
                int str1 = lenh.IndexOf('\'');
                int str2 = lenh.LastIndexOf('\'');
                string malop = lenh.Substring(str1 + 1, str2 - str1 - 1);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENLOP,MAKH FROM [dbo].LOP WHERE MALOP ='" + malop + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("Lop nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                string tenlop = Program.MyReader.GetString(0);
                string makhoa = Program.MyReader.GetString(1);
                Program.MyReader.Close();

                String removeBack = "insert into LOP(MALOP,TENLOP,MAKH) values('" + malop + "',N'" + tenlop + "','" + makhoa + "')";
                redoStack.pushStack(removeBack);
            }

            if (lenh.Contains("insert"))
            {
                int str1 = lenh.IndexOf('\'');
                string malop = lenh.Substring(str1 + 1, 6);
                if (Program.KetNoi() == 0) return;
                String removeBack = "delete from LOP where MALOP = '" + malop + "'";
                redoStack.pushStack(removeBack);
            }

            if (lenh.Contains("update".ToUpper()))
            {
                int str1 = lenh.LastIndexOf('\'');
                string malop = lenh.Substring(str1 -8, 8);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENLOP FROM [dbo].LOP WHERE MALOP ='" + malop + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("Lop nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                beforeUpdate = Program.MyReader.GetString(0);
                statement = "UPDATE LOP SET TENLOP = N'" + beforeUpdate + "' WHERE MALOP = '" + malop + "';";
                redoStack.pushStack(statement);
            }
            int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
            this.lOPTableAdapter.Fill(this.dS.LOP);
            if (undoStack.stack.Count > 0)
                btnUndo.Enabled = true;
            else
                btnUndo.Enabled = false;
            //if (lenh.Contains("insert")) redoStack.pushStack(lenh.Replace("insert", "delete"));
            if (redoStack.stack.Count > 0)
                btnRedo.Enabled = true;
            else
                btnRedo.Enabled = false;
        }

        private void btnRedo_ItemClick(object sender, ItemClickEventArgs e)
        {
            bsdLOP.CancelEdit();
            if (Program.KetNoi() == 0) return;
            string lenh = redoStack.popStack();

            if (lenh.Contains("insert"))
            {
                int str1 = lenh.IndexOf('\'');
                string malop = lenh.Substring(str1 + 1, 6);
                if (Program.KetNoi() == 0) return;
                String removeBack = "delete from LOP where MALOP = '" + malop + "'";
                undoStack.pushStack(removeBack);
            }
            if (lenh.Contains("delete"))
            {
                int str1 = lenh.IndexOf('\'');
                int str2 = lenh.LastIndexOf('\'');
                string malop = lenh.Substring(str1 + 1, str2 - str1 - 1);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENLOP,MAKH FROM [dbo].LOP WHERE MALOP ='" + malop + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("Lop nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                string tenlop = Program.MyReader.GetString(0);
                string makhoa = Program.MyReader.GetString(1);
                Program.MyReader.Close();

                String removeBack = "insert into LOP(MALOP,TENLOP,MAKH) values('" + malop + "',N'" + tenlop + "','" + makhoa + "')";
                undoStack.pushStack(removeBack);
            }
            if (lenh.Contains("update".ToUpper()))
            {
                int str1 = lenh.LastIndexOf('\'');
                string malop = lenh.Substring(str1 - 8, 8);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENLOP FROM [dbo].LOP WHERE MALOP ='" + malop + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("Lop nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                beforeUpdate = Program.MyReader.GetString(0);
                statement = "UPDATE LOP SET TENLOP = N'" + beforeUpdate + "' WHERE MALOP = '" + malop + "';";
                undoStack.pushStack(statement);
            }
            int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
            this.lOPTableAdapter.Fill(this.dS.LOP);
            if (redoStack.stack.Count > 0)
                btnRedo.Enabled = true;
            else
                btnRedo.Enabled = false;
            if (undoStack.stack.Count > 0)
                btnUndo.Enabled = true;
            else
                btnUndo.Enabled = false;
        }
    }
}