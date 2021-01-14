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

    public partial class frmMonHoc : DevExpress.XtraEditors.XtraForm
    {
        string maKhoa = "";
        Int32 vitri = 0;
        bool isEditing = true;
        string connString = Program.connstr;

        String beforeUpdate;
        String statement;
        UndoAndRedo undoStack;
        UndoAndRedo redoStack;

        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            undoStack = new UndoAndRedo();
            redoStack = new UndoAndRedo();

            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            kHOAComboBox.DataSource = Program.Bds_Dskhoa;
            kHOAComboBox.DisplayMember = "TENCN";
            kHOAComboBox.ValueMember = "TENSERVER";
            kHOAComboBox.SelectedIndex = Program.MKhoa;
            if (Program.MGroup == "KHOA" || Program.MGroup == "USER")
            {
                kHOAComboBox.Enabled = false;
            }
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.DIEM' table. You can move, or remove it, as needed.
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.dS.DIEM);
            btnSave.Enabled = false;
            txtMaMH.ReadOnly = true;


            btnEdit.Visible = true;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            beforeUpdate = ((DataRowView)bdsMONHOC[0])["TENMH"].ToString();
        }

        #region code cũ
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        #endregion

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
                    this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr; // lấy data của Site tương ứng
                    this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
                    this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.dIEMTableAdapter.Fill(this.dS.DIEM);
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

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMONHOC.Position;
            bdsMONHOC.AddNew();

            isEditing = false;
            gcMonHoc.Enabled = false;
            kHOAComboBox.Enabled = false;
            txtMaMH.ReadOnly = false;
            txtMaMH.Focus();
            btnAdd.Enabled = btnRemove.Enabled = btnExit.Enabled = false;

            btnSave.Enabled = true;
            btnEdit.Visible = false;
            btnUndo.Enabled = false;
        }

        private void btnGhii_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtMaMH.Focus();
            }
            else if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtTenMH.Focus();
            }
            else
            {
                try
                {
                    bdsMONHOC.EndEdit();        // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                    bdsMONHOC.ResetCurrentItem();       // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                    this.mONHOCTableAdapter.Update(this.dS.MONHOC);         // cập nhật dl từ dataset về database thông qua tableadapter
                    btnAdd.Enabled = btnRemove.Enabled = btnExit.Enabled = true;
                    txtMaMH.ReadOnly = true;
                    isEditing = true;
                    kHOAComboBox.Enabled = true;
                    gcMonHoc.Enabled = true;


                    btnSave.Enabled = false;
                    btnEdit.Visible = true;
                    beforeUpdate = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["TENMH"].ToString();
                    statement = "delete from MONHOC where MAMH = '" + txtMaMH.Text + "'";
                    undoStack.pushStack(statement);
                    btnUndo.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("PRIMARY"))
                    {
                        MessageBox.Show("Mã môn học bị trùng. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                        return;
                    }
                    else if (ex.Message.Contains("UNIQUE KEY"))
                    {
                        MessageBox.Show("Tên môn học bị trùng. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi ghi Môn học. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                    }
                }

            }
        }

        private void btnLammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMONHOC.CancelEdit();         //bỏ qua các dl đang chỉnh sửa trong row, chỉ có tác dụng khi dl chưa ghi vào dataset
            if (isEditing == false)
            {
                bdsMONHOC.Position = vitri;
                btnAdd.Enabled = btnRemove.Enabled = btnExit.Enabled = true;
                gcMonHoc.Enabled = true;
                txtMaMH.ReadOnly = true;
                kHOAComboBox.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Visible = true;
                if (undoStack.stack.Count > 0)
                    btnUndo.Enabled = true;
                else
                    btnUndo.Enabled = false;
                if (redoStack.stack.Count > 0)
                    btnRedo.Enabled = true;
                else
                    btnRedo.Enabled = false;
            }
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
        }

        private void btnThoatt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            undoStack.stack.Clear();
            redoStack.stack.Clear();
            this.Close();
        }

      
        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMONHOC.CancelEdit();
            if (Program.KetNoi() == 0) return;
            String lenh = undoStack.popStack();
            if (lenh.Contains("delete"))
            {
                int str1 = lenh.IndexOf('\'');
                int str2 = lenh.LastIndexOf('\'');
                string maMH = lenh.Substring(str1 + 1, str2 - str1 - 1);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENMH FROM [dbo].MONHOC WHERE MAMH ='" + maMH + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("MONHOC nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                string tenmh = Program.MyReader.GetString(0);
                Program.MyReader.Close();

                String removeBack = "insert into MONHOC(MAMH,TENMH) values('" + maMH + "',N'" + tenmh + "')";
                redoStack.pushStack(removeBack);
            }

            if (lenh.Contains("insert"))
            {
                int str1 = lenh.IndexOf('\'');
                string maMH = lenh.Substring(str1 + 1, 6);
                if (Program.KetNoi() == 0) return;
                String removeBack = "delete from MONHOC where MAMH = '" + maMH + "'";
                redoStack.pushStack(removeBack);
            }

            if (lenh.Contains("update".ToUpper()))
            {
                int str1 = lenh.LastIndexOf('\'');
                string maMH = lenh.Substring(str1 - 6 ,6);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENMH FROM [dbo].MONHOC WHERE MAMH ='" + maMH + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("môn học nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                beforeUpdate = Program.MyReader.GetString(0);
                statement = "UPDATE MONHOC SET TENMH = N'" + beforeUpdate + "' WHERE MAMH = '" + maMH + "';";
                redoStack.pushStack(statement);
            }
            int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            if (undoStack.stack.Count > 0)
                btnUndo.Enabled = true;
            else
                btnUndo.Enabled = false;
            if (redoStack.stack.Count > 0)
                btnRedo.Enabled = true;
            else
                btnRedo.Enabled = false;
        }

        private void gcMonHoc_Click(object sender, EventArgs e)
        {
            beforeUpdate = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["TENMH"].ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tên", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }

            if (beforeUpdate != ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["TENMH"].ToString())
            {
                bdsMONHOC.EndEdit();        // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                bdsMONHOC.ResetCurrentItem();       // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                this.mONHOCTableAdapter.Update(this.dS.MONHOC);         // cập nhật dl từ dataset về database thông qua tableadapter
                statement = "UPDATE MONHOC SET TENMH = N'" + beforeUpdate + "' WHERE MAMH = '" + txtMaMH.Text + "';";
                undoStack.stack.Push(statement);
                beforeUpdate = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["TENMH"].ToString();
                btnUndo.Enabled = true;
            }
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsMONHOC.Count == 0)
            {
                return;
            }
            else
            {
                if (bdsDIEM.Count > 0)
                {
                    MessageBox.Show("Môn học hiện đang có điểm sinh viên, không thể xóa !", "Thông báo !", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn xóa Môn học ?", "Thông báo !", MessageBoxButtons.YesNo);
                    if (ds == DialogResult.Yes)
                    {
                        try
                        {
                            String removeBack = "insert into MONHOC(MAMH,TENMH) values('" + txtMaMH.Text + "',N'" + txtTenMH.Text + "')";
                            undoStack.pushStack(removeBack);
                            bdsMONHOC.RemoveCurrent();          //xóa row đang chọn ra khỏi dataset
                            this.mONHOCTableAdapter.Update(this.dS.MONHOC);
                            btnUndo.Enabled = true;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa Môn học. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMONHOC.CancelEdit();
            if (Program.KetNoi() == 0) return;
            string lenh = redoStack.popStack();

            if (lenh.Contains("insert"))
            {
                int str1 = lenh.IndexOf('\'');
                string maMH = lenh.Substring(str1 + 1, 6);
                if (Program.KetNoi() == 0) return;
                String removeBack = "delete from MONHOC where MAMH = '" + maMH + "'";
                undoStack.pushStack(removeBack);
            }
            if (lenh.Contains("delete"))
            {
                int str1 = lenh.IndexOf('\'');
                int str2 = lenh.LastIndexOf('\'');
                string maMH = lenh.Substring(str1 + 1, str2 - str1 - 1);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENMH FROM [dbo].MONHOC WHERE MAMH ='" + maMH + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("môn học nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                string tenmh = Program.MyReader.GetString(0);
                Program.MyReader.Close();

                String removeBack = "insert into MONHOC(MAMH,TENMH) values('" + maMH + "',N'" + tenmh + "')";
                undoStack.pushStack(removeBack);
            }
            if (lenh.Contains("update".ToUpper()))
            {
                int str1 = lenh.LastIndexOf('\'');
                string maMH = lenh.Substring(str1 - 6 ,6);
                if (Program.KetNoi() == 0) return;
                String lenh1 = "SELECT TENMH FROM [dbo].MONHOC WHERE MAMH ='" + maMH + "'";
                Program.MyReader = Program.ExecSqlDataReader(lenh1);
                if (!Program.MyReader.HasRows)
                {
                    MessageBox.Show("môn học nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                    Program.MyReader.Close();
                    return;
                }
                Program.MyReader.Read();
                beforeUpdate = Program.MyReader.GetString(0);
                statement = "UPDATE MONHOC SET TENMH = N'" + beforeUpdate + "' WHERE MAMH = '" + maMH + "';";
                undoStack.pushStack(statement);
            }
            int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            if (undoStack.stack.Count > 0)
                btnUndo.Enabled = true;
            else
                btnUndo.Enabled = false;
            if (redoStack.stack.Count > 0)
                btnRedo.Enabled = true;
            else
                btnRedo.Enabled = false;
        }
    }
}