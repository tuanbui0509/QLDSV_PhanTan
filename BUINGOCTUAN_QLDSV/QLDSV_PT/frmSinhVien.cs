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
using QLDSV_PT.Object;

namespace QLDSV_PT
{
    public partial class frmSinhVien : DevExpress.XtraEditors.XtraForm
    {
        string maKhoa = "";

        Int32 vitriSV = 0;
        Boolean isEditingSV = true;
        Int32 vitriLop = 0;
        Boolean isEditingLop = true;

        String beforeUpdateClass;
        Student beforeUpdateStudent;
        String statement;
        UndoAndRedo undoStack;
        UndoAndRedo redoStack;

        public frmSinhVien()
        {
            InitializeComponent();
        }

        public void studentInit()
        {
            beforeUpdateStudent.MASV1 = ((DataRowView)bdsSV[0])["MASV"].ToString();
            beforeUpdateStudent.MALOP1 = ((DataRowView)bdsSV[0])["MALOP"].ToString();
            beforeUpdateStudent.HO1 = ((DataRowView)bdsSV[0])["HO"].ToString();
            beforeUpdateStudent.TEN1 = ((DataRowView)bdsSV[0])["TEN"].ToString();
            beforeUpdateStudent.PHAI1 = Boolean.Parse(((DataRowView)bdsSV[0])["PHAI"].ToString());
            beforeUpdateStudent.NGAYSINH1 = DateTime.Parse(((DataRowView)bdsSV[0])["NGAYSINH"].ToString());
            beforeUpdateStudent.NOISINH1 = ((DataRowView)bdsSV[0])["NOISINH"].ToString();
            beforeUpdateStudent.DIACHI1 = ((DataRowView)bdsSV[0])["DIACHI"].ToString();
            beforeUpdateStudent.GHICHU1 = ((DataRowView)bdsSV[0])["GHICHU"].ToString();
            beforeUpdateStudent.NGHIHOC1 = Boolean.Parse(((DataRowView)bdsSV[0])["NGHIHOC"].ToString());
        }
        public void studentPosition()
        {
            beforeUpdateStudent.MASV1 = ((DataRowView)bdsSV[bdsSV.Position])["MASV"].ToString();
            beforeUpdateStudent.MALOP1 = ((DataRowView)bdsSV[bdsSV.Position])["MALOP"].ToString();
            beforeUpdateStudent.HO1 = ((DataRowView)bdsSV[bdsSV.Position])["HO"].ToString();
            beforeUpdateStudent.TEN1 = ((DataRowView)bdsSV[bdsSV.Position])["TEN"].ToString();
            beforeUpdateStudent.PHAI1 = Boolean.Parse(((DataRowView)bdsSV[bdsSV.Position])["PHAI"].ToString());
            beforeUpdateStudent.NGAYSINH1 = DateTime.Parse(((DataRowView)bdsSV[bdsSV.Position])["NGAYSINH"].ToString());
            beforeUpdateStudent.NOISINH1 = ((DataRowView)bdsSV[bdsSV.Position])["NOISINH"].ToString();
            beforeUpdateStudent.DIACHI1 = ((DataRowView)bdsSV[bdsSV.Position])["DIACHI"].ToString();
            beforeUpdateStudent.GHICHU1 = ((DataRowView)bdsSV[bdsSV.Position])["GHICHU"].ToString();
            beforeUpdateStudent.NGHIHOC1 = Boolean.Parse(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"].ToString());
        }

        public void studentSelected(string masv)
        {
            String lenh1 = "SELECT HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC FROM [dbo].SINHVIEN WHERE MASV ='" + masv + "'";

            Program.MyReader = Program.ExecSqlDataReader(lenh1);
            if (!Program.MyReader.HasRows)
            {
                MessageBox.Show("SINHVIEN nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                Program.MyReader.Close();
                return;
            }
            Program.MyReader.Read();
            beforeUpdateStudent.HO1 = Program.MyReader.GetString(0);
            beforeUpdateStudent.TEN1 = Program.MyReader.GetString(1);
            beforeUpdateStudent.MALOP1 = Program.MyReader.GetString(2);
            beforeUpdateStudent.PHAI1 = Program.MyReader.GetBoolean(3);
            beforeUpdateStudent.NGAYSINH1 = Program.MyReader.GetDateTime(4);
            beforeUpdateStudent.NOISINH1 = Program.MyReader.GetString(5);
            beforeUpdateStudent.DIACHI1 = Program.MyReader.GetString(6);
            beforeUpdateStudent.GHICHU1 = Program.MyReader.GetString(7);
            beforeUpdateStudent.NGHIHOC1 = Program.MyReader.GetBoolean(8);
            Program.MyReader.Close();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {

            undoStack = new UndoAndRedo();
            redoStack = new UndoAndRedo();

            dS.EnforceConstraints = false;
            cmbKhoa.DataSource = Program.Bds_Dskhoa;
            cmbKhoa.DisplayMember = "TENCN";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;
            if (Program.MGroup == "KHOA" || Program.MGroup == "USER")
            {
                cmbKhoa.Enabled = false;
                btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }


            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            txtKhoa.Text = maKhoa = ((DataRowView)bdsKHOA[0])["MAKH"].ToString().Trim();
            txtMaLop.Text = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
            txtTenLop.Text = ((DataRowView)bdsLOP[bdsLOP.Position])["TENLOP"].ToString().Trim();
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            // TODO: This line of code loads data into the 'dS.DIEM' table. You can move, or remove it, as needed.
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.dS.DIEM);


            panelLop.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Visible = false;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            // Lưu lớp đầu tiên trước
            beforeUpdateClass = ((DataRowView)bdsLOP[0])["TENLOP"].ToString();
            beforeUpdateStudent = new Student();
            // Lưu sinh viên đầu tiên trước
            if (bdsSV.Count > 0)
            {
                studentInit();
            }

            if (bdsSV.Count > 0)
            {
                Boolean nghihoc = (Boolean)(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"]);
                if (nghihoc) {  panelSV.Enabled = false; btnCapNhatSV.Visible = false; }
                else { btnCapNhatSV.Visible = true; panelSV.Enabled = true; }
            }
            else { btnCapNhatSV.Visible = false; panelSV.Enabled = false; }
            txtMaSV.ReadOnly = true;
            panelNghiHoc.Visible = true;
            btnGhiSV.Enabled = false;
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
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr; // lấy data của Site tương ứng
                    this.lOPTableAdapter.Fill(this.dS.LOP);

                    this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOATableAdapter.Fill(this.dS.KHOA);
                    maKhoa = ((DataRowView)bdsKHOA[0])["MAKH"].ToString().Trim();

                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

                    this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.dIEMTableAdapter.Fill(this.dS.DIEM);

                    this.hOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                    this.hOCPHITableAdapter.Fill(this.dS.HOCPHI);


                    if (bdsSV.Count > 0)
                    {
                        Boolean nghihoc = (Boolean)(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"]);
                        if (nghihoc)
                            panelSV.Enabled = false;
                        else panelSV.Enabled = true;
                    }
                    else panelSV.Enabled = false;
                }
                catch (Exception) { }
            }
            undoStack.stack.Clear();
            redoStack.stack.Clear();
            btnUndo.Enabled = false;
            beforeUpdateClass = "";
            beforeUpdateStudent = null;
            beforeUpdateStudent = new Student();
        }

        #region code cũ


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }


        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitriLop = bdsLOP.Position;
            isEditingLop = false;
            bdsLOP.AddNew();
            txtKhoa.Text = maKhoa;
            txtMaLop.ReadOnly = false;
            editInterface(false);
            panelSV.Enabled = false;
            panelLop.Enabled = true;
            btnSave.Enabled = true;
            txtMaLop.Focus();
        }

        private void brnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                if (ret == "1" && isEditingLop == false)
                {
                    MessageBox.Show("Mã lớp đã tồn tại. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    try
                    {
                        bdsLOP.EndEdit();       // kết thúc quá trình hiệu chỉnh
                        bdsLOP.ResetCurrentItem();      // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực
                        this.lOPTableAdapter.Update(this.dS.LOP);   // đẩy dl vừa ghi tạm về CSDL -> adapter (liên quan đến database)
                        btnAdd.Enabled = btnExit.Enabled = btnRemove.Enabled = true;
                        gcClass.Enabled = true;
                        txtMaLop.ReadOnly = true;
                        isEditingLop = true;


                        cmbKhoa.Enabled = true;
                        btnSave.Enabled = false;
                        btnEdit.Visible = false;
                        // push thông tin lớp vào trong stack
                        beforeUpdateClass = ((DataRowView)bdsLOP[bdsLOP.Position])["TENLOP"].ToString();
                        statement = "delete from LOP where MALOP = '" + txtMaLop.Text + "'";
                        undoStack.pushStack(statement);
                        btnUndo.Enabled = true;
                        panelLop.Enabled = false;
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

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsLOP.Count == 0)
            {
                return;
            }
            else
            {
                if (bdsSV.Count > 0)
                {
                    MessageBox.Show("Lớp đang có sinh viên học, không thể xóa !", "Thông báo !", MessageBoxButtons.OK);
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
                            bdsLOP.RemoveCurrent();         //xóa row đang chọn ra khỏi dataset
                            this.lOPTableAdapter.Update(this.dS.LOP);
                            btnUndo.Enabled = true;
                            MessageBox.Show("Xóa lớp thành công!", "Thông báo !", MessageBoxButtons.OK);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa Lớp. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.CancelEdit();
            if (isEditingLop == false)
            {
                bdsLOP.Position = vitriLop;
                gcClass.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnThoat.Enabled = true;
                txtMaLop.ReadOnly = true;
                isEditingLop = true;
                btnAdd.Enabled = btnRemove.Enabled = true;
            }
            lOPTableAdapter.Fill(this.dS.LOP);

            editInterface(true);
            bdsSV.CancelEdit();
            if (isEditingSV == false)
            {
                bdsSV.Position = vitriSV;
                isEditingSV = true;
                btnSave.Enabled = true;
                txtMaSV.ReadOnly = true;

                editInterface(true);
                btnThemSV.Enabled = btnXoaSV.Enabled = true;
            }
            sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            editInterface(true);
            initialStatus();
            beforeUpdateClass = ((DataRowView)bdsLOP[bdsLOP.Position])["TENLOP"].ToString();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void nGHIHOCCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkeditNghiHoc_Click(object sender, EventArgs e)
        {
            if (checkeditNghiHoc.Checked == true) { }
            else
            {
                DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn cho Sinh viên này nghỉ học không ?", "Thông báo nguy hiểm!", MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    try
                    {
                        bdsSV.EndEdit();            // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                        bdsSV.ResetCurrentItem();           // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                        this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);         // cập nhật dl từ dataset về database thông qua tableadapter
                        isEditingSV = true;
                        checkeditNghiHoc.Checked = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa Sinh viên. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                    }
                }
            }

        }

        private void sINHVIENDataGridView_Click(object sender, EventArgs e)
        {
            if (bdsSV.Count > 0)
            {
                Boolean nghihoc = (Boolean)(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"]);
                if (nghihoc) { btnCapNhatSV.Visible = false; panelSV.Enabled = false; }
                else { btnCapNhatSV.Visible = true; panelSV.Enabled = true; }
                
            }
            else { btnCapNhatSV.Visible = false; panelSV.Enabled = false; }

            if (bdsSV.Count == 0)
            {
                btnXoaSV.Enabled = false;
            }
            else
            {
                btnXoaSV.Enabled = true;
                studentPosition();
            }
            txtMaSV.ReadOnly = true;


        }

        private void editInterface(Boolean flag)
        {
            gcClass.Enabled = flag;
            cmbKhoa.Enabled = flag;
            sINHVIENDataGridView.Enabled = flag;
            btnEdit.Visible = btnAdd.Enabled = btnRemove.Enabled = btnEditClass.Enabled
            = btnUndo.Enabled = btnRedo.Enabled = btnSave.Enabled = flag;
            btnExit.Enabled = btnRefesh.Enabled = !flag;
        }
        private void initialStatus()
        {
            btnExit.Enabled = btnRefesh.Enabled = true;
            panelLop.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Visible = false;
            if (bdsSV.Count > 0)
            {
                Boolean nghihoc = (Boolean)(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"]);
                if (nghihoc)
                    panelSV.Enabled = false;
                else panelSV.Enabled = true;
            }
            else panelSV.Enabled = false;

            if (redoStack.stack.Count > 0)
                btnRedo.Enabled = true;
            else
                btnRedo.Enabled = false;
            if (undoStack.stack.Count > 0)
                btnUndo.Enabled = true;
            else
                btnUndo.Enabled = false;
        }

        private void btnThemSV_Click_1(object sender, EventArgs e)
        {
            vitriSV = bdsSV.Position;
            isEditingSV = false;
            bdsSV.AddNew();
            checkeditNam.Checked = false;
            checkeditNghiHoc.Checked = false;
            panelNghiHoc.Visible = false;
            txtMaSV.ReadOnly = false;
            txtMaLopSV.Text = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
            btnThemSV.Enabled = btnXoaSV.Enabled = false;
            btnGhiSV.Enabled = btnPhucHoiSV.Enabled = true;
            editInterface(false);
            panelSV.Enabled = true;
            panelLop.Enabled = false;
            txtMaLopSV.ReadOnly = true;
            btnCapNhatSV.Visible = false;

            txtMaSV.Focus();
        }

        private void btnGhiSV_Click(object sender, EventArgs e)
        {

            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtMaSV.Focus();
            }
            else if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ sinh viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtHo.Focus();
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên sinh viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtTen.Focus();
            }
            else if (txtNoiSinh.Text.Trim() == "")
            {
                MessageBox.Show("Nơi sinh không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtNoiSinh.Focus();
            }
            else if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtDiaChi.Focus();
            }
            else if (dateeditNgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ngày sinh !", "Thông báo !", MessageBoxButtons.OK);
            }
            else if (txtGhiChu.Text == "")
            {
                MessageBox.Show("Ghi chú không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
            }
            else
            {

                if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
                String str_sp = "dbo.SP_CHECKTRUNGMASV";
                Program.Sqlcmd = Program.Conn.CreateCommand();
                Program.Sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.Sqlcmd.CommandText = str_sp;
                Program.Sqlcmd.Parameters.Add("@MASV", SqlDbType.VarChar).Value = txtMaSV.Text;
                Program.Sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.Sqlcmd.ExecuteNonQuery();
                String ret = Program.Sqlcmd.Parameters["@RET"].Value.ToString();
                if (ret == "1" && isEditingSV == false)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    try
                    {
                        bdsSV.EndEdit();            // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                        bdsSV.ResetCurrentItem();           // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                        this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);         // cập nhật dl từ dataset về database thông qua tableadapter
                        // la dang them moi sinh vien
                        if (!isEditingSV)
                        {
                            studentPosition();
                            statement = "DELETE dbo.SINHVIEN WHERE MASV = '" + txtMaSV.Text + "'";
                            undoStack.pushStack(statement);
                            btnUndo.Enabled = true;
                        }
                        isEditingSV = true;
                        txtMaSV.ReadOnly = true;
                        btnCapNhatSV.Visible = true;
                        panelNghiHoc.Visible = true;
                        btnGhiSV.Enabled = false;
                        editInterface(true);
                        btnThemSV.Enabled = btnXoaSV.Enabled = true;
                        initialStatus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi Sinh viên. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                    }
                }
            }
            txtMaSV.ReadOnly = true;
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (Program.Conn.State == ConnectionState.Closed) Program.Conn.Open();
            String str_sp = "dbo.SP_CHECKHOCPHISINHVIEN";
            Program.Sqlcmd = Program.Conn.CreateCommand();
            Program.Sqlcmd.CommandType = CommandType.StoredProcedure;
            Program.Sqlcmd.CommandText = str_sp;
            Program.Sqlcmd.Parameters.Add("@MASV", SqlDbType.VarChar).Value = txtMaSV.Text;
            Program.Sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.Sqlcmd.ExecuteNonQuery();
            String ret = Program.Sqlcmd.Parameters["@RET"].Value.ToString();
            if (ret == "1")
            {
                MessageBox.Show("Sinh viên đã có học phí, không thể xóa !", "Thông báo !", MessageBoxButtons.OK);
                return;
            }

            if (bdsSV.Count == 0)
            {
                MessageBox.Show("Lớp này không có sinh viên nào để xóa!", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (bdsDIEMSV.Count > 0)
                {
                    MessageBox.Show("Sinh viên đã có điểm, không thể xóa !", "Thông báo !", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn xóa Sinh viên này ?", "Thông báo !", MessageBoxButtons.YesNo);
                    if (ds == DialogResult.Yes)
                    {
                        try
                        {

                            String removeBack = "INSERT INTO dbo.SINHVIEN (MASV, HO,  TEN,  MALOP, PHAI, NGAYSINH,  " +
                                "NOISINH,  DIACHI, GHICHU,NGHIHOC)VALUES('" + txtMaSV.Text + "',N'" + txtHo.Text + "',N'"
                                + txtTen.Text + "',N'" + txtMaLopSV.Text + "',N'" + (checkeditNam).Checked.ToString()
                                + "',N'" + dateeditNgaySinh.Text + "',N'" + txtNoiSinh.Text + "',N'"
                                + txtDiaChi.Text + "',N'" + txtGhiChu.Text + "',N'" + checkeditNghiHoc.Checked.ToString() + "')";

                            undoStack.pushStack(removeBack);
                            bdsSV.RemoveCurrent();          //xóa row đang chọn ra khỏi dataset
                            this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);
                            btnUndo.Enabled = true;
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo !", MessageBoxButtons.OK);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa Sinh viên. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnPhucHoiSV_Click(object sender, EventArgs e)
        {
            bdsSV.CancelEdit();
            if (isEditingSV == false)
            {
                bdsSV.Position = vitriSV;
                isEditingSV = true;
                btnSave.Enabled = true;
                txtMaSV.ReadOnly = true;
                panelNghiHoc.Visible = true;
                btnThemSV.Enabled = btnXoaSV.Enabled = true;
            }
            sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            editInterface(true);
            initialStatus();
        }

        private void gcClass_Click(object sender, EventArgs e)
        {
            txtKhoa.Text = ((DataRowView)bdsLOP[bdsLOP.Position])["MAKH"].ToString().Trim();
            txtMaLop.Text = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
            txtTenLop.Text = ((DataRowView)bdsLOP[bdsLOP.Position])["TENLOP"].ToString().Trim();
            if (bdsSV.Count > 0)
            {
                Boolean nghihoc = (Boolean)(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"]);
                if (nghihoc) { btnCapNhatSV.Visible = false; panelSV.Enabled = false; }
                else { btnCapNhatSV.Visible = true; panelSV.Enabled = true; }
               
            }
            else { btnCapNhatSV.Visible = false; panelSV.Enabled = false; }

            beforeUpdateClass = ((DataRowView)bdsLOP[bdsLOP.Position])["TENLOP"].ToString();

            if (bdsSV.Count > 0)
            {
                studentPosition();
            }
           
            txtMaSV.ReadOnly = true;

        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.CancelEdit();
            if (Program.KetNoi() == 0) return;
            String lenh = undoStack.popStack();
            if (lenh.Contains("delete") || lenh.Contains("delete".ToUpper()))
            {
                if (lenh.Contains("SINHVIEN"))
                {
                    int str1 = lenh.IndexOf('\'');
                    int str2 = lenh.LastIndexOf('\'');
                    string masv = lenh.Substring(str1 + 1, str2 - str1 - 1);
                    if (Program.KetNoi() == 0) return;
                    String lenh1 = "SELECT HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC FROM [dbo].SINHVIEN WHERE MASV ='" + masv + "'";
                    Program.MyReader = Program.ExecSqlDataReader(lenh1);
                    if (!Program.MyReader.HasRows)
                    {
                        MessageBox.Show("SINHVIEN nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                        Program.MyReader.Close();
                        return;
                    }
                    Program.MyReader.Read();
                    string ho = Program.MyReader.GetString(0);
                    string ten = Program.MyReader.GetString(1);
                    string malop = Program.MyReader.GetString(2);
                    Boolean phai = Program.MyReader.GetBoolean(3);
                    DateTime ngaysinh = Program.MyReader.GetDateTime(4);
                    string noisinh = Program.MyReader.GetString(5);
                    string diachi = Program.MyReader.GetString(6);
                    String ghichu = Program.MyReader.GetString(7);

                    Boolean nghihoc = Program.MyReader.GetBoolean(8);
                    Program.MyReader.Close();
                    String removeBack = "INSERT INTO dbo.SINHVIEN (MASV, HO,  TEN,  MALOP, PHAI, NGAYSINH," +
                               "NOISINH,  DIACHI, GHICHU,NGHIHOC)VALUES('" + masv + "',N'" + ho + "',N'"
                               + ten + "',N'" + malop + "',N'" + phai + "',N'" + ngaysinh
                               + "',N'" + noisinh + "',N'" + diachi + "',N'" + ghichu + "',N'"
                               + nghihoc + "')";
                    redoStack.pushStack(removeBack);
                }
                else
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

            }

            if (lenh.Contains("insert") || lenh.Contains("insert".ToUpper()))
            {
                if (lenh.Contains("SINHVIEN"))
                {
                    int str1 = lenh.IndexOf('\'');
                    string masv = lenh.Substring(str1 + 1, 12);
                    if (Program.KetNoi() == 0) return;
                    String removeBack = "DELETE dbo.SINHVIEN WHERE MASV = '" + masv + "'";
                    redoStack.pushStack(removeBack);
                }
                else
                {
                    int str1 = lenh.IndexOf('\'');
                    string malop = lenh.Substring(str1 + 1, 8);
                    if (Program.KetNoi() == 0) return;
                    String removeBack = "delete from LOP where MALOP = '" + malop + "'";
                    redoStack.pushStack(removeBack);
                }

            }

            if (lenh.Contains("update") || lenh.Contains("update".ToUpper()))
            {
                if (lenh.Contains("SINHVIEN"))
                {
                    int str1 = lenh.LastIndexOf('\'');
                    string masv = lenh.Substring(str1 - 12, 12);
                    if (Program.KetNoi() == 0) return;
                    studentSelected(masv);
                    statement = "UPDATE dbo.SINHVIEN SET HO = N'" + beforeUpdateStudent.HO1 + "',PHAI = '" +
                                    beforeUpdateStudent.PHAI1 + "',MALOP = '" + beforeUpdateStudent.MALOP1 + "',NGAYSINH = '"
                                    + beforeUpdateStudent.NGAYSINH1 + "',NOISINH = N'" + beforeUpdateStudent.NOISINH1 + "',DIACHI =  N'"
                                    + beforeUpdateStudent.DIACHI1 + "',TEN =  N'" + beforeUpdateStudent.TEN1 + "',GHICHU =N'"
                                    + beforeUpdateStudent.GHICHU1 + "',NGHIHOC = '" + beforeUpdateStudent.NGHIHOC1
                                    + "' WHERE MASV = '" + masv + "';";
                    redoStack.stack.Push(statement);
                }
                else
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
                    beforeUpdateClass = Program.MyReader.GetString(0);
                    statement = "UPDATE LOP SET TENLOP = N'" + beforeUpdateClass + "' WHERE MALOP = '" + malop + "';";
                    redoStack.pushStack(statement);
                }

            }
            int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
            this.lOPTableAdapter.Fill(this.dS.LOP);
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);


            if (undoStack.stack.Count > 0)
                btnUndo.Enabled = true;
            else
                btnUndo.Enabled = false;
            //if (lenh.Contains("insert")||lenh.Contains("insert".ToUpper())) redoStack.pushStack(lenh.Replace("insert", "delete"));
            if (redoStack.stack.Count > 0)
                btnRedo.Enabled = true;
            else
                btnRedo.Enabled = false;
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.CancelEdit();
            if (Program.KetNoi() == 0) return;
            string lenh = redoStack.popStack();

            if (lenh.Contains("insert") || lenh.Contains("insert".ToUpper()))
            {
                if (lenh.Contains("SINHVIEN"))
                {
                    int str1 = lenh.IndexOf('\'');
                    string masv = lenh.Substring(str1 + 1, 12);
                    if (Program.KetNoi() == 0) return;
                    String removeBack = "DELETE dbo.SINHVIEN WHERE MASV = '" + masv + "'";
                    undoStack.pushStack(removeBack);
                }
                else
                {
                    int str1 = lenh.IndexOf('\'');
                    string malop = lenh.Substring(str1 + 1, 8);
                    if (Program.KetNoi() == 0) return;
                    String removeBack = "delete from LOP where MALOP = '" + malop + "'";
                    undoStack.pushStack(removeBack);
                }

            }
            if (lenh.Contains("delete") || lenh.Contains("delete".ToUpper()))
            {
                if (lenh.Contains("SINHVIEN"))
                {
                    int str1 = lenh.IndexOf('\'');
                    int str2 = lenh.LastIndexOf('\'');
                    string masv = lenh.Substring(str1 + 1, str2 - str1 - 1);
                    if (Program.KetNoi() == 0) return;
                    String lenh1 = "SELECT HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC FROM [dbo].SINHVIEN WHERE MASV ='" + masv + "'";
                    Program.MyReader = Program.ExecSqlDataReader(lenh1);
                    if (!Program.MyReader.HasRows)
                    {
                        MessageBox.Show("SINHVIEN nay khong ton tai", "Thông báo", MessageBoxButtons.OK);
                        Program.MyReader.Close();
                        return;
                    }
                    Program.MyReader.Read();
                    string ho = Program.MyReader.GetString(0);
                    string ten = Program.MyReader.GetString(1);
                    string malop = Program.MyReader.GetString(2);
                    Boolean phai = Program.MyReader.GetBoolean(3);
                    DateTime ngaysinh = Program.MyReader.GetDateTime(4);
                    string noisinh = Program.MyReader.GetString(5);
                    string diachi = Program.MyReader.GetString(6);
                    string ghichu = Program.MyReader.GetString(7);
                    Boolean nghihoc = Program.MyReader.GetBoolean(8);
                    Program.MyReader.Close();
                    String removeBack = "INSERT INTO dbo.SINHVIEN (MASV, HO,  TEN,  MALOP, PHAI, NGAYSINH," +
                               "NOISINH,  DIACHI, GHICHU,NGHIHOC)VALUES('" + masv + "',N'" + ho + "',N'"
                               + ten + "',N'" + malop + "',N'" + phai + "',N'" + ngaysinh
                               + "',N'" + noisinh + "',N'" + diachi + "',N'" + ghichu + "',N'"
                               + nghihoc + "')";
                    undoStack.pushStack(removeBack);
                }
                else
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

            }
            if (lenh.Contains("update") || lenh.Contains("update".ToUpper()))
            {
                if (lenh.Contains("SINHVIEN"))
                {
                    int str1 = lenh.LastIndexOf('\'');
                    string masv = lenh.Substring(str1 - 12, 12);
                    if (Program.KetNoi() == 0) return;
                    studentSelected(masv);
                    statement = "UPDATE dbo.SINHVIEN SET HO = N'" + beforeUpdateStudent.HO1 + "',PHAI = '" +
                                    beforeUpdateStudent.PHAI1 + "',MALOP = '" + beforeUpdateStudent.MALOP1 + "',NGAYSINH = '"
                                    + beforeUpdateStudent.NGAYSINH1 + "',NOISINH = N'" + beforeUpdateStudent.NOISINH1 + "',DIACHI =  N'"
                                    + beforeUpdateStudent.DIACHI1 + "',TEN =  N'" + beforeUpdateStudent.TEN1 + "',GHICHU = N'"
                                    + beforeUpdateStudent.GHICHU1 + "',NGHIHOC = '" + beforeUpdateStudent.NGHIHOC1
                                    + "' WHERE MASV = '" + masv + "';";
                    undoStack.stack.Push(statement);
                }
                else
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
                    beforeUpdateClass = Program.MyReader.GetString(0);
                    statement = "UPDATE LOP SET TENLOP = N'" + beforeUpdateClass + "' WHERE MALOP = '" + malop + "';";
                    undoStack.pushStack(statement);
                }

            }
            int n = Program.ExecSqlNonQuery(lenh, Program.connstr);
            dS.EnforceConstraints = false;

            this.lOPTableAdapter.Fill(this.dS.LOP);
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            if (redoStack.stack.Count > 0)
                btnRedo.Enabled = true;
            else
                btnRedo.Enabled = false;
            if (undoStack.stack.Count > 0)
                btnUndo.Enabled = true;
            else
                btnUndo.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenLop.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin tên", "", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }

                if (beforeUpdateClass != ((DataRowView)bdsLOP[bdsLOP.Position])["TENLOP"].ToString())
                {
                    bdsLOP.EndEdit();        // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                    bdsLOP.ResetCurrentItem();       // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                    this.lOPTableAdapter.Update(this.dS.LOP);         // cập nhật dl từ dataset về database thông qua tableadapter
                    statement = "UPDATE LOP SET TENLOP = N'" + beforeUpdateClass + "' WHERE MALOP = '" + txtMaLop.Text + "';";
                    undoStack.stack.Push(statement);
                    beforeUpdateClass = ((DataRowView)bdsLOP[bdsLOP.Position])["TENLOP"].ToString();
                    btnUndo.Enabled = true;
                }
                editInterface(true);
                initialStatus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi lớp. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
            }


        }

        private void btnEditClass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editInterface(false);
            panelLop.Enabled = true;
            if (bdsSV.Count > 0)
            {
                Boolean nghihoc = (Boolean)(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"]);
                if (nghihoc)
                    panelSV.Enabled = false;
                else panelSV.Enabled = true;
            }
            else panelSV.Enabled = false;
            btnEdit.Visible = true;
        }

        private void btnChinhSuaSV_Click(object sender, EventArgs e)
        {

            if (bdsSV.Count > 0)
            {
                Boolean nghihoc = (Boolean)(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"]);
                if (nghihoc)
                {
                    MessageBox.Show("Sinh viên này đã nghỉ học, không thể hiệu chỉnh !", "Thông báo !", MessageBoxButtons.OK);
                    return;
                }
            }

            editInterface(false);
            panelSV.Enabled = true;
            panelLop.Enabled = false;
            btnThemSV.Enabled = btnXoaSV.Enabled = false;
            txtMaLopSV.ReadOnly = txtMaSV.ReadOnly = true;

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void sINHVIENDataGridView_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnCapNhatSV_Click(object sender, EventArgs e)
        {

            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ sinh viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtHo.Focus();
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên sinh viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtTen.Focus();
            }
            else if (txtNoiSinh.Text.Trim() == "")
            {
                MessageBox.Show("Nơi sinh không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtNoiSinh.Focus();
            }
            else if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtDiaChi.Focus();
            }
            else if (dateeditNgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ngày sinh !", "Thông báo !", MessageBoxButtons.OK);
            }
            else if (txtGhiChu.Text == "")
            {
                MessageBox.Show("Ghi chú không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    bdsSV.EndEdit();            // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                    bdsSV.ResetCurrentItem();           // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                    this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);         // cập nhật dl từ dataset về database thông qua tableadapter                                                     // la dang them moi sinh vien
                    if (beforeUpdateStudent.HO1 != ((DataRowView)bdsSV[bdsSV.Position])["HO"].ToString() ||
                        beforeUpdateStudent.TEN1 != ((DataRowView)bdsSV[bdsSV.Position])["TEN"].ToString() ||
                        beforeUpdateStudent.PHAI1 != Boolean.Parse(((DataRowView)bdsSV[bdsSV.Position])["PHAI"].ToString()) ||
                        beforeUpdateStudent.NGAYSINH1 != DateTime.Parse(((DataRowView)bdsSV[bdsSV.Position])["NGAYSINH"].ToString()) ||
                        beforeUpdateStudent.NOISINH1 != ((DataRowView)bdsSV[bdsSV.Position])["NOISINH"].ToString() ||
                        beforeUpdateStudent.DIACHI1 != ((DataRowView)bdsSV[bdsSV.Position])["DIACHI"].ToString() ||
                        beforeUpdateStudent.GHICHU1 != ((DataRowView)bdsSV[bdsSV.Position])["GHICHU"].ToString() ||
                        beforeUpdateStudent.NGHIHOC1 != Boolean.Parse(((DataRowView)bdsSV[bdsSV.Position])["NGHIHOC"].ToString()))
                    {
                        bdsLOP.EndEdit();        // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                        bdsLOP.ResetCurrentItem();       // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                        this.lOPTableAdapter.Update(this.dS.LOP);         // cập nhật dl từ dataset về database thông qua tableadapter
                        statement = "UPDATE dbo.SINHVIEN SET HO = N'" +
                            beforeUpdateStudent.HO1 + "',PHAI = '" +
                            beforeUpdateStudent.PHAI1 + "',MALOP = '" +
                            beforeUpdateStudent.MALOP1 + "',NGAYSINH = '" +
                            beforeUpdateStudent.NGAYSINH1 + "',NOISINH = N'" +
                            beforeUpdateStudent.NOISINH1 + "',TEN =  N'" +
                            beforeUpdateStudent.TEN1 + "',DIACHI =  N'" +
                            beforeUpdateStudent.DIACHI1 + "',GHICHU =N'" +
                            beforeUpdateStudent.GHICHU1 + "',NGHIHOC = '" +
                            beforeUpdateStudent.NGHIHOC1 +
                            "' WHERE MASV = '" + txtMaSV.Text + "';";
                        undoStack.stack.Push(statement);
                        studentPosition();
                        btnUndo.Enabled = true;
                    }
                    isEditingSV = true;
                    txtMaSV.ReadOnly = true;
                    editInterface(true);
                    btnThemSV.Enabled = btnXoaSV.Enabled = true;
                    initialStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi Sinh viên. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                }

            }
            txtMaSV.ReadOnly = true;
        }
    }
}