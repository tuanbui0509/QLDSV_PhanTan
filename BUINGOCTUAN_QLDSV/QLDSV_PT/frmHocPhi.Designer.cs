namespace QLDSV_PT
{
    partial class frmHocPhi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHocPhi));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_Save = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnRefesh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_Exit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnadd = new DevExpress.XtraBars.BarButtonItem();
            this.btnsearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnsave = new DevExpress.XtraBars.BarButtonItem();
            this.btnupdate = new DevExpress.XtraBars.BarButtonItem();
            this.btndelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnexit = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Add = new DevExpress.XtraBars.BarLargeButtonItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.hphoten = new System.Windows.Forms.TextBox();
            this.hplop = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSinhVien = new DevExpress.XtraEditors.LookUpEdit();
            this.bdsSinhVien = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV_PT.DS();
            this.txtSTDD = new System.Windows.Forms.TextBox();
            this.bdsDSHP = new System.Windows.Forms.BindingSource(this.components);
            this.txtHocPhi = new System.Windows.Forms.TextBox();
            this.txtHocKy = new System.Windows.Forms.TextBox();
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.sP_INDS_HOCPHI1GridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNIENKHOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCPHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIENDADONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIENDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbnienkhoa = new System.Windows.Forms.ComboBox();
            this.cmbHocKy = new System.Windows.Forms.ComboBox();
            this.hpSTD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tableAdapterManager = new QLDSV_PT.DSTableAdapters.TableAdapterManager();
            this.sP_INDS_HOCPHI1TableAdapter = new QLDSV_PT.DSTableAdapters.SP_INDS_HOCPHI1TableAdapter();
            this.sINHVIEN_HOCPHITableAdapter = new QLDSV_PT.DSTableAdapters.SINHVIEN_HOCPHITableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSinhVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_INDS_HOCPHI1GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnadd,
            this.btnsearch,
            this.btnsave,
            this.btnupdate,
            this.btndelete,
            this.btnexit,
            this.btn_Add,
            this.btn_Save,
            this.btnRefesh,
            this.btn_Exit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 11;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Save, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefesh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Exit)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btn_Save
            // 
            this.btn_Save.Caption = "ĐÓNG TIỀN";
            this.btn_Save.Id = 8;
            this.btn_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Save.ImageOptions.SvgImage")));
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Save_ItemClick);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Caption = "LÀM MỚI";
            this.btnRefesh.Id = 9;
            this.btnRefesh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefesh.ImageOptions.SvgImage")));
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefesh_ItemClick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "THOÁT";
            this.btn_Exit.Id = 10;
            this.btn_Exit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Exit.ImageOptions.SvgImage")));
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Exit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1538, 70);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 778);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1538, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 70);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 708);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1538, 70);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 708);
            // 
            // btnadd
            // 
            this.btnadd.Caption = "THÊM";
            this.btnadd.Id = 0;
            this.btnadd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.ImageOptions.Image")));
            this.btnadd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnadd.ImageOptions.LargeImage")));
            this.btnadd.Name = "btnadd";
            this.btnadd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnadd_ItemClick);
            // 
            // btnsearch
            // 
            this.btnsearch.Id = 6;
            this.btnsearch.Name = "btnsearch";
            // 
            // btnsave
            // 
            this.btnsave.Caption = "GHI";
            this.btnsave.Id = 2;
            this.btnsave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.ImageOptions.Image")));
            this.btnsave.Name = "btnsave";
            this.btnsave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsave_ItemClick);
            // 
            // btnupdate
            // 
            this.btnupdate.Caption = "CẬP NHẬT";
            this.btnupdate.Id = 3;
            this.btnupdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.ImageOptions.Image")));
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnupdate_ItemClick);
            // 
            // btndelete
            // 
            this.btndelete.Caption = "XÓA";
            this.btndelete.Id = 4;
            this.btndelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.ImageOptions.Image")));
            this.btndelete.Name = "btndelete";
            this.btndelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btndelete_ItemClick);
            // 
            // btnexit
            // 
            this.btnexit.Caption = "THOÁT";
            this.btnexit.Id = 5;
            this.btnexit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.ImageOptions.Image")));
            this.btnexit.Name = "btnexit";
            this.btnexit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnexit_ItemClick);
            // 
            // btn_Add
            // 
            this.btn_Add.Caption = "THÊM";
            this.btn_Add.Id = 7;
            this.btn_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.ImageOptions.Image")));
            this.btn_Add.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.ImageOptions.LargeImage")));
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Add_ItemClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "NHẬP MÃ SINH VIÊN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Họ Tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(682, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Học Kỳ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã Lớp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(682, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Học Phí:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(995, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Niên khóa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(995, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số tiền đã đóng:";
            // 
            // hphoten
            // 
            this.hphoten.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hphoten.Location = new System.Drawing.Point(427, 222);
            this.hphoten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hphoten.Name = "hphoten";
            this.hphoten.ReadOnly = true;
            this.hphoten.Size = new System.Drawing.Size(219, 29);
            this.hphoten.TabIndex = 27;
            // 
            // hplop
            // 
            this.hplop.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hplop.Location = new System.Drawing.Point(427, 296);
            this.hplop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hplop.Name = "hplop";
            this.hplop.ReadOnly = true;
            this.hplop.Size = new System.Drawing.Size(219, 29);
            this.hplop.TabIndex = 28;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.cmbSinhVien);
            this.groupControl1.Controls.Add(this.txtSTDD);
            this.groupControl1.Controls.Add(this.txtHocPhi);
            this.groupControl1.Controls.Add(this.txtHocKy);
            this.groupControl1.Controls.Add(this.txtNienKhoa);
            this.groupControl1.Controls.Add(this.sP_INDS_HOCPHI1GridControl);
            this.groupControl1.Controls.Add(this.cmbnienkhoa);
            this.groupControl1.Controls.Add(this.cmbHocKy);
            this.groupControl1.Controls.Add(this.hpSTD);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.hplop);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.hphoten);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 70);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1538, 708);
            this.groupControl1.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(478, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(696, 37);
            this.label9.TabIndex = 67;
            this.label9.Text = "ĐÓNG HỌC PHÍ CHO SINH VIÊN PTITHCM";
            // 
            // cmbSinhVien
            // 
            this.cmbSinhVien.Location = new System.Drawing.Point(779, 127);
            this.cmbSinhVien.MenuManager = this.barManager1;
            this.cmbSinhVien.Name = "cmbSinhVien";
            this.cmbSinhVien.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSinhVien.Properties.Appearance.Options.UseFont = true;
            this.cmbSinhVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSinhVien.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MASV", "MASV", 45, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbSinhVien.Properties.DataSource = this.bdsSinhVien;
            this.cmbSinhVien.Properties.DisplayMember = "MASV";
            this.cmbSinhVien.Properties.NullText = "Nhập lựa chọn Mã SV";
            this.cmbSinhVien.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbSinhVien.Properties.ValueMember = "MASV";
            this.cmbSinhVien.Size = new System.Drawing.Size(360, 32);
            this.cmbSinhVien.TabIndex = 66;
            this.cmbSinhVien.EditValueChanged += new System.EventHandler(this.cmbSinhVien_EditValueChanged);
            // 
            // bdsSinhVien
            // 
            this.bdsSinhVien.DataMember = "SINHVIEN_HOCPHI";
            this.bdsSinhVien.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSTDD
            // 
            this.txtSTDD.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDSHP, "SOTIENDADONG", true));
            this.txtSTDD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTDD.Location = new System.Drawing.Point(1162, 303);
            this.txtSTDD.Name = "txtSTDD";
            this.txtSTDD.ReadOnly = true;
            this.txtSTDD.Size = new System.Drawing.Size(171, 30);
            this.txtSTDD.TabIndex = 65;
            // 
            // bdsDSHP
            // 
            this.bdsDSHP.DataMember = "SP_INDS_HOCPHI1";
            this.bdsDSHP.DataSource = this.dS;
            // 
            // txtHocPhi
            // 
            this.txtHocPhi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDSHP, "HOCPHI", true));
            this.txtHocPhi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHocPhi.Location = new System.Drawing.Point(768, 296);
            this.txtHocPhi.Name = "txtHocPhi";
            this.txtHocPhi.ReadOnly = true;
            this.txtHocPhi.Size = new System.Drawing.Size(184, 30);
            this.txtHocPhi.TabIndex = 64;
            // 
            // txtHocKy
            // 
            this.txtHocKy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDSHP, "HOCKY", true));
            this.txtHocKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHocKy.Location = new System.Drawing.Point(765, 224);
            this.txtHocKy.Name = "txtHocKy";
            this.txtHocKy.ReadOnly = true;
            this.txtHocKy.Size = new System.Drawing.Size(187, 30);
            this.txtHocKy.TabIndex = 63;
            // 
            // txtNienKhoa
            // 
            this.txtNienKhoa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDSHP, "NIENKHOA", true));
            this.txtNienKhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNienKhoa.Location = new System.Drawing.Point(1162, 221);
            this.txtNienKhoa.Name = "txtNienKhoa";
            this.txtNienKhoa.ReadOnly = true;
            this.txtNienKhoa.Size = new System.Drawing.Size(171, 30);
            this.txtNienKhoa.TabIndex = 62;
            // 
            // sP_INDS_HOCPHI1GridControl
            // 
            this.sP_INDS_HOCPHI1GridControl.DataSource = this.bdsDSHP;
            this.sP_INDS_HOCPHI1GridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sP_INDS_HOCPHI1GridControl.Location = new System.Drawing.Point(2, 471);
            this.sP_INDS_HOCPHI1GridControl.MainView = this.gridView1;
            this.sP_INDS_HOCPHI1GridControl.MenuManager = this.barManager1;
            this.sP_INDS_HOCPHI1GridControl.Name = "sP_INDS_HOCPHI1GridControl";
            this.sP_INDS_HOCPHI1GridControl.Size = new System.Drawing.Size(1534, 235);
            this.sP_INDS_HOCPHI1GridControl.TabIndex = 61;
            this.sP_INDS_HOCPHI1GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.sP_INDS_HOCPHI1GridControl.Click += new System.EventHandler(this.sP_INDS_HOCPHI1GridControl_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNIENKHOA,
            this.colHOCKY,
            this.colHOCPHI,
            this.colSOTIENDADONG,
            this.colSOTIENDONG});
            this.gridView1.GridControl = this.sP_INDS_HOCPHI1GridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colNIENKHOA
            // 
            this.colNIENKHOA.Caption = "NIÊN KHÓA";
            this.colNIENKHOA.FieldName = "NIENKHOA";
            this.colNIENKHOA.MinWidth = 25;
            this.colNIENKHOA.Name = "colNIENKHOA";
            this.colNIENKHOA.OptionsColumn.AllowEdit = false;
            this.colNIENKHOA.Visible = true;
            this.colNIENKHOA.VisibleIndex = 0;
            this.colNIENKHOA.Width = 94;
            // 
            // colHOCKY
            // 
            this.colHOCKY.Caption = "HỌC KỲ";
            this.colHOCKY.FieldName = "HOCKY";
            this.colHOCKY.MinWidth = 25;
            this.colHOCKY.Name = "colHOCKY";
            this.colHOCKY.OptionsColumn.AllowEdit = false;
            this.colHOCKY.Visible = true;
            this.colHOCKY.VisibleIndex = 1;
            this.colHOCKY.Width = 94;
            // 
            // colHOCPHI
            // 
            this.colHOCPHI.Caption = "HỌC PHÍ";
            this.colHOCPHI.FieldName = "HOCPHI";
            this.colHOCPHI.MinWidth = 25;
            this.colHOCPHI.Name = "colHOCPHI";
            this.colHOCPHI.OptionsColumn.AllowEdit = false;
            this.colHOCPHI.Visible = true;
            this.colHOCPHI.VisibleIndex = 2;
            this.colHOCPHI.Width = 94;
            // 
            // colSOTIENDADONG
            // 
            this.colSOTIENDADONG.Caption = "SỐ TIỀN ĐÃ ĐÓNG";
            this.colSOTIENDADONG.FieldName = "SOTIENDADONG";
            this.colSOTIENDADONG.MinWidth = 25;
            this.colSOTIENDADONG.Name = "colSOTIENDADONG";
            this.colSOTIENDADONG.OptionsColumn.AllowEdit = false;
            this.colSOTIENDADONG.Visible = true;
            this.colSOTIENDADONG.VisibleIndex = 3;
            this.colSOTIENDADONG.Width = 94;
            // 
            // colSOTIENDONG
            // 
            this.colSOTIENDONG.FieldName = "SOTIENDONG";
            this.colSOTIENDONG.MinWidth = 25;
            this.colSOTIENDONG.Name = "colSOTIENDONG";
            this.colSOTIENDONG.Width = 94;
            // 
            // cmbnienkhoa
            // 
            this.cmbnienkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnienkhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbnienkhoa.FormattingEnabled = true;
            this.cmbnienkhoa.Location = new System.Drawing.Point(1175, 363);
            this.cmbnienkhoa.Name = "cmbnienkhoa";
            this.cmbnienkhoa.Size = new System.Drawing.Size(158, 30);
            this.cmbnienkhoa.TabIndex = 59;
            this.cmbnienkhoa.Visible = false;
            // 
            // cmbHocKy
            // 
            this.cmbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHocKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHocKy.FormattingEnabled = true;
            this.cmbHocKy.Location = new System.Drawing.Point(1175, 427);
            this.cmbHocKy.Name = "cmbHocKy";
            this.cmbHocKy.Size = new System.Drawing.Size(166, 30);
            this.cmbHocKy.TabIndex = 58;
            this.cmbHocKy.Visible = false;
            // 
            // hpSTD
            // 
            this.hpSTD.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpSTD.Location = new System.Drawing.Point(865, 381);
            this.hpSTD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hpSTD.MaxLength = 10;
            this.hpSTD.Name = "hpSTD";
            this.hpSTD.Size = new System.Drawing.Size(268, 29);
            this.hpSTD.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(721, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 22);
            this.label8.TabIndex = 54;
            this.label8.Text = "Số tiền đóng:";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CT_DONGHOCPHITableAdapter = null;
            this.tableAdapterManager.DIEMTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.HOCPHITableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIEN_HOCPHITableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV_PT.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sP_INDS_HOCPHI1TableAdapter
            // 
            this.sP_INDS_HOCPHI1TableAdapter.ClearBeforeFill = true;
            // 
            // sINHVIEN_HOCPHITableAdapter
            // 
            this.sINHVIEN_HOCPHITableAdapter.ClearBeforeFill = true;
            // 
            // frmHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 778);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHocPhi";
            this.Text = "Học phí";
            this.Load += new System.EventHandler(this.frmHocPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSinhVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_INDS_HOCPHI1GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnadd;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnsearch;
        private DevExpress.XtraBars.BarButtonItem btnsave;
        private DevExpress.XtraBars.BarButtonItem btnupdate;
        private DevExpress.XtraBars.BarButtonItem btndelete;
        private DevExpress.XtraBars.BarButtonItem btnexit;
        private System.Windows.Forms.TextBox hplop;
        private System.Windows.Forms.TextBox hphoten;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarLargeButtonItem btn_Add;
        private DevExpress.XtraBars.BarLargeButtonItem btn_Save;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefesh;
        private DevExpress.XtraBars.BarLargeButtonItem btn_Exit;
        private DS dS;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox hpSTD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbHocKy;
        private System.Windows.Forms.ComboBox cmbnienkhoa;
        private System.Windows.Forms.BindingSource bdsDSHP;
        private DSTableAdapters.SP_INDS_HOCPHI1TableAdapter sP_INDS_HOCPHI1TableAdapter;
        private DevExpress.XtraGrid.GridControl sP_INDS_HOCPHI1GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNIENKHOA;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCKY;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCPHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIENDADONG;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIENDONG;
        private System.Windows.Forms.TextBox txtSTDD;
        private System.Windows.Forms.TextBox txtHocPhi;
        private System.Windows.Forms.TextBox txtHocKy;
        private System.Windows.Forms.TextBox txtNienKhoa;
        private DevExpress.XtraEditors.LookUpEdit cmbSinhVien;
        private System.Windows.Forms.BindingSource bdsSinhVien;
        private DSTableAdapters.SINHVIEN_HOCPHITableAdapter sINHVIEN_HOCPHITableAdapter;
        private System.Windows.Forms.Label label9;
    }
}