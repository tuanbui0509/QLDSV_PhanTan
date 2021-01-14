namespace QLDSV_PT.Report
{
    partial class frmDSKTM
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
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnInDSKTM = new System.Windows.Forms.Button();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.txtMonHoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.bsdMonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV_PT.DS();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLanThi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.bsdLop = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bdsDSKTM = new System.Windows.Forms.BindingSource(this.components);
            this.sP_REPORT_DSKTMTableAdapter = new QLDSV_PT.DSTableAdapters.SP_REPORT_DSKTMTableAdapter();
            this.tableAdapterManager = new QLDSV_PT.DSTableAdapters.TableAdapterManager();
            this.lOPTableAdapter = new QLDSV_PT.DSTableAdapters.LOPTableAdapter();
            this.mONHOCTableAdapter = new QLDSV_PT.DSTableAdapters.MONHOCTableAdapter();
            this.sP_REPORT_DSKTMGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMASV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHỌVÀTÊN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colĐIỂM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHUKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateNThi = new DevExpress.XtraEditors.DateEdit();
            this.cmbHK = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsdMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsdLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSKTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_REPORT_DSKTMGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNThi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNThi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBatDau
            // 
            this.btnBatDau.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.Location = new System.Drawing.Point(731, 418);
            this.btnBatDau.Margin = new System.Windows.Forms.Padding(5);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(121, 54);
            this.btnBatDau.TabIndex = 52;
            this.btnBatDau.Text = "Màn hình";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(928, 418);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(121, 54);
            this.btnThoat.TabIndex = 51;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnInDSKTM
            // 
            this.btnInDSKTM.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInDSKTM.Location = new System.Drawing.Point(555, 418);
            this.btnInDSKTM.Margin = new System.Windows.Forms.Padding(5);
            this.btnInDSKTM.Name = "btnInDSKTM";
            this.btnInDSKTM.Size = new System.Drawing.Size(132, 54);
            this.btnInDSKTM.TabIndex = 50;
            this.btnInDSKTM.Text = "Preview";
            this.btnInDSKTM.UseVisualStyleBackColor = true;
            this.btnInDSKTM.Click += new System.EventHandler(this.btnInDSKTM_Click);
            // 
            // txtLop
            // 
            this.txtLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLop.Location = new System.Drawing.Point(1194, 184);
            this.txtLop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLop.Name = "txtLop";
            this.txtLop.ReadOnly = true;
            this.txtLop.Size = new System.Drawing.Size(215, 30);
            this.txtLop.TabIndex = 47;
            // 
            // txtMonHoc
            // 
            this.txtMonHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonHoc.Location = new System.Drawing.Point(1194, 240);
            this.txtMonHoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonHoc.Name = "txtMonHoc";
            this.txtMonHoc.ReadOnly = true;
            this.txtMonHoc.Size = new System.Drawing.Size(215, 30);
            this.txtMonHoc.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1025, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 22);
            this.label5.TabIndex = 49;
            this.label5.Text = "MÃ MÔN HỌC :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1025, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 22);
            this.label6.TabIndex = 48;
            this.label6.Text = "MÃ LỚP : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(235, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 22);
            this.label4.TabIndex = 45;
            this.label4.Text = "MÔN HỌC";
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.DataSource = this.bsdMonHoc;
            this.cmbMonHoc.DisplayMember = "TENMH";
            this.cmbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Location = new System.Drawing.Point(373, 246);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(536, 30);
            this.cmbMonHoc.TabIndex = 43;
            this.cmbMonHoc.ValueMember = "MAMH";
            this.cmbMonHoc.SelectedIndexChanged += new System.EventHandler(this.cmbMonHoc_SelectedIndexChanged);
            // 
            // bsdMonHoc
            // 
            this.bsdMonHoc.DataMember = "MONHOC";
            this.bsdMonHoc.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "LẦN THI";
            // 
            // cmbLanThi
            // 
            this.cmbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanThi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanThi.FormattingEnabled = true;
            this.cmbLanThi.Location = new System.Drawing.Point(373, 316);
            this.cmbLanThi.Name = "cmbLanThi";
            this.cmbLanThi.Size = new System.Drawing.Size(123, 30);
            this.cmbLanThi.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 22);
            this.label2.TabIndex = 41;
            this.label2.Text = "LỚP";
            // 
            // cmbLop
            // 
            this.cmbLop.DataSource = this.bsdLop;
            this.cmbLop.DisplayMember = "TENLOP";
            this.cmbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(373, 187);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(536, 30);
            this.cmbLop.TabIndex = 40;
            this.cmbLop.ValueMember = "MALOP";
            this.cmbLop.SelectedIndexChanged += new System.EventHandler(this.cmbLop_SelectedIndexChanged);
            // 
            // bsdLop
            // 
            this.bsdLop.DataMember = "LOP";
            this.bsdLop.DataSource = this.dS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 39;
            this.label1.Text = "KHOA";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(373, 133);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(350, 30);
            this.cmbKhoa.TabIndex = 38;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Firebrick;
            this.label7.Location = new System.Drawing.Point(690, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(532, 37);
            this.label7.TabIndex = 53;
            this.label7.Text = "DANH SÁCH THI HẾT MÔN HỌC";
            // 
            // bdsDSKTM
            // 
            this.bdsDSKTM.DataMember = "SP_REPORT_DSKTM";
            this.bdsDSKTM.DataSource = this.dS;
            // 
            // sP_REPORT_DSKTMTableAdapter
            // 
            this.sP_REPORT_DSKTMTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CT_DONGHOCPHITableAdapter = null;
            this.tableAdapterManager.DIEMTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.HOCPHITableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = this.lOPTableAdapter;
            this.tableAdapterManager.MONHOCTableAdapter = this.mONHOCTableAdapter;
            this.tableAdapterManager.SINHVIEN_HOCPHITableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV_PT.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // sP_REPORT_DSKTMGridControl
            // 
            this.sP_REPORT_DSKTMGridControl.DataSource = this.bdsDSKTM;
            this.sP_REPORT_DSKTMGridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sP_REPORT_DSKTMGridControl.Location = new System.Drawing.Point(0, 576);
            this.sP_REPORT_DSKTMGridControl.MainView = this.gridView1;
            this.sP_REPORT_DSKTMGridControl.Name = "sP_REPORT_DSKTMGridControl";
            this.sP_REPORT_DSKTMGridControl.Size = new System.Drawing.Size(1648, 220);
            this.sP_REPORT_DSKTMGridControl.TabIndex = 55;
            this.sP_REPORT_DSKTMGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colMASV,
            this.colHỌVÀTÊN,
            this.colSOTO,
            this.colĐIỂM,
            this.colCHUKY});
            this.gridView1.GridControl = this.sP_REPORT_DSKTMGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colSTT
            // 
            this.colSTT.FieldName = "STT";
            this.colSTT.MinWidth = 25;
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.AllowEdit = false;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 94;
            // 
            // colMASV
            // 
            this.colMASV.FieldName = "MASV";
            this.colMASV.MinWidth = 25;
            this.colMASV.Name = "colMASV";
            this.colMASV.OptionsColumn.AllowEdit = false;
            this.colMASV.Visible = true;
            this.colMASV.VisibleIndex = 1;
            this.colMASV.Width = 94;
            // 
            // colHỌVÀTÊN
            // 
            this.colHỌVÀTÊN.FieldName = " HỌ VÀ TÊN ";
            this.colHỌVÀTÊN.MinWidth = 25;
            this.colHỌVÀTÊN.Name = "colHỌVÀTÊN";
            this.colHỌVÀTÊN.OptionsColumn.AllowEdit = false;
            this.colHỌVÀTÊN.Visible = true;
            this.colHỌVÀTÊN.VisibleIndex = 2;
            this.colHỌVÀTÊN.Width = 94;
            // 
            // colSOTO
            // 
            this.colSOTO.FieldName = "SOTO";
            this.colSOTO.MinWidth = 25;
            this.colSOTO.Name = "colSOTO";
            this.colSOTO.OptionsColumn.AllowEdit = false;
            this.colSOTO.Visible = true;
            this.colSOTO.VisibleIndex = 3;
            this.colSOTO.Width = 94;
            // 
            // colĐIỂM
            // 
            this.colĐIỂM.FieldName = "ĐIỂM";
            this.colĐIỂM.MinWidth = 25;
            this.colĐIỂM.Name = "colĐIỂM";
            this.colĐIỂM.OptionsColumn.AllowEdit = false;
            this.colĐIỂM.Visible = true;
            this.colĐIỂM.VisibleIndex = 4;
            this.colĐIỂM.Width = 94;
            // 
            // colCHUKY
            // 
            this.colCHUKY.FieldName = "CHUKY";
            this.colCHUKY.MinWidth = 25;
            this.colCHUKY.Name = "colCHUKY";
            this.colCHUKY.OptionsColumn.AllowEdit = false;
            this.colCHUKY.Visible = true;
            this.colCHUKY.VisibleIndex = 5;
            this.colCHUKY.Width = 94;
            // 
            // DateNThi
            // 
            this.DateNThi.EditValue = null;
            this.DateNThi.Location = new System.Drawing.Point(1193, 130);
            this.DateNThi.Name = "DateNThi";
            this.DateNThi.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateNThi.Properties.Appearance.Options.UseFont = true;
            this.DateNThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateNThi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateNThi.Size = new System.Drawing.Size(215, 28);
            this.DateNThi.TabIndex = 56;
            // 
            // cmbHK
            // 
            this.cmbHK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHK.FormattingEnabled = true;
            this.cmbHK.Location = new System.Drawing.Point(1194, 313);
            this.cmbHK.Name = "cmbHK";
            this.cmbHK.Size = new System.Drawing.Size(217, 30);
            this.cmbHK.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1025, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 22);
            this.label8.TabIndex = 58;
            this.label8.Text = "NGÀY THI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1025, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 22);
            this.label9.TabIndex = 59;
            this.label9.Text = "HỌC KỲ";
            // 
            // frmDSKTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1648, 796);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbHK);
            this.Controls.Add(this.DateNThi);
            this.Controls.Add(this.sP_REPORT_DSKTMGridControl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnInDSKTM);
            this.Controls.Add(this.txtLop);
            this.Controls.Add(this.txtMonHoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMonHoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLanThi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKhoa);
            this.Name = "frmDSKTM";
            this.Text = "Bảng điểm môn học";
            this.Load += new System.EventHandler(this.frmDSKTM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsdMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsdLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSKTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_REPORT_DSKTMGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNThi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNThi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnInDSKTM;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.TextBox txtMonHoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLanThi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Label label7;
        private DS dS;
        private System.Windows.Forms.BindingSource bdsDSKTM;
        private DSTableAdapters.SP_REPORT_DSKTMTableAdapter sP_REPORT_DSKTMTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl sP_REPORT_DSKTMGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colMASV;
        private DevExpress.XtraGrid.Columns.GridColumn colHỌVÀTÊN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTO;
        private DevExpress.XtraGrid.Columns.GridColumn colĐIỂM;
        private DevExpress.XtraGrid.Columns.GridColumn colCHUKY;
        private DSTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.BindingSource bsdLop;
        private DSTableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private System.Windows.Forms.BindingSource bsdMonHoc;
        private DevExpress.XtraEditors.DateEdit DateNThi;
        private System.Windows.Forms.ComboBox cmbHK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}