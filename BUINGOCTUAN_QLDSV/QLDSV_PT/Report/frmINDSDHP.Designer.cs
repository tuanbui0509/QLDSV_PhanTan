namespace QLDSV_PT.Report
{
    partial class frmINDSDHP
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbLop = new DevExpress.XtraEditors.LookUpEdit();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV_PT.DS();
            this.label7 = new System.Windows.Forms.Label();
            this.sP_REPORT_HOCPHILOPGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsDSHP = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHỌTÊN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHỌCPHÍ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSỐTIỀNĐÃĐÓNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnManHinh = new System.Windows.Forms.Button();
            this.btnMayIn = new System.Windows.Forms.Button();
            this.cmbHocKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNienKhoa = new System.Windows.Forms.ComboBox();
            this.bdsReportDSDHP = new System.Windows.Forms.BindingSource(this.components);
            this.sP_REPORT_DSDHPTableAdapter = new QLDSV_PT.DSTableAdapters.SP_REPORT_DSDHPTableAdapter();
            this.tableAdapterManager = new QLDSV_PT.DSTableAdapters.TableAdapterManager();
            this.SP_DSHPTableAdapter = new QLDSV_PT.DSTableAdapters.SP_REPORT_HOCPHILOPTableAdapter();
            this.lOPTableAdapter = new QLDSV_PT.DSTableAdapters.LOPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_REPORT_HOCPHILOPGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsReportDSDHP)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbLop);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.sP_REPORT_HOCPHILOPGridControl);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnManHinh);
            this.panelControl1.Controls.Add(this.btnMayIn);
            this.panelControl1.Controls.Add(this.cmbHocKy);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.cmbNienKhoa);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1337, 630);
            this.panelControl1.TabIndex = 0;
            // 
            // cmbLop
            // 
            this.cmbLop.Location = new System.Drawing.Point(402, 139);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLop.Properties.Appearance.Options.UseFont = true;
            this.cmbLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLop.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MALOP", "MALOP", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbLop.Properties.DataSource = this.bdsLop;
            this.cmbLop.Properties.DisplayMember = "MALOP";
            this.cmbLop.Properties.NullText = "Nhập chọn mã lớp";
            this.cmbLop.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbLop.Properties.ValueMember = "MALOP";
            this.cmbLop.Size = new System.Drawing.Size(224, 28);
            this.cmbLop.TabIndex = 55;
            this.cmbLop.EditValueChanged += new System.EventHandler(this.cmbLop_EditValueChanged);
            // 
            // bdsLop
            // 
            this.bdsLop.DataMember = "LOP";
            this.bdsLop.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Firebrick;
            this.label7.Location = new System.Drawing.Point(717, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(471, 37);
            this.label7.TabIndex = 54;
            this.label7.Text = "DANH SÁCH ĐÓNG HỌC PHÍ";
            // 
            // sP_REPORT_HOCPHILOPGridControl
            // 
            this.sP_REPORT_HOCPHILOPGridControl.DataSource = this.bdsDSHP;
            this.sP_REPORT_HOCPHILOPGridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sP_REPORT_HOCPHILOPGridControl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sP_REPORT_HOCPHILOPGridControl.Location = new System.Drawing.Point(2, 408);
            this.sP_REPORT_HOCPHILOPGridControl.MainView = this.gridView1;
            this.sP_REPORT_HOCPHILOPGridControl.Name = "sP_REPORT_HOCPHILOPGridControl";
            this.sP_REPORT_HOCPHILOPGridControl.Size = new System.Drawing.Size(1333, 220);
            this.sP_REPORT_HOCPHILOPGridControl.TabIndex = 31;
            this.sP_REPORT_HOCPHILOPGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bdsDSHP
            // 
            this.bdsDSHP.DataMember = "SP_REPORT_HOCPHILOP";
            this.bdsDSHP.DataSource = this.dS;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colHỌTÊN,
            this.colHỌCPHÍ,
            this.colSỐTIỀNĐÃĐÓNG});
            this.gridView1.GridControl = this.sP_REPORT_HOCPHILOPGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
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
            // colHỌTÊN
            // 
            this.colHỌTÊN.FieldName = "HỌ TÊN";
            this.colHỌTÊN.MinWidth = 25;
            this.colHỌTÊN.Name = "colHỌTÊN";
            this.colHỌTÊN.OptionsColumn.AllowEdit = false;
            this.colHỌTÊN.Visible = true;
            this.colHỌTÊN.VisibleIndex = 1;
            this.colHỌTÊN.Width = 94;
            // 
            // colHỌCPHÍ
            // 
            this.colHỌCPHÍ.FieldName = "HỌC PHÍ";
            this.colHỌCPHÍ.MinWidth = 25;
            this.colHỌCPHÍ.Name = "colHỌCPHÍ";
            this.colHỌCPHÍ.OptionsColumn.AllowEdit = false;
            this.colHỌCPHÍ.Visible = true;
            this.colHỌCPHÍ.VisibleIndex = 2;
            this.colHỌCPHÍ.Width = 94;
            // 
            // colSỐTIỀNĐÃĐÓNG
            // 
            this.colSỐTIỀNĐÃĐÓNG.FieldName = "SỐ TIỀN ĐÃ ĐÓNG";
            this.colSỐTIỀNĐÃĐÓNG.MinWidth = 25;
            this.colSỐTIỀNĐÃĐÓNG.Name = "colSỐTIỀNĐÃĐÓNG";
            this.colSỐTIỀNĐÃĐÓNG.OptionsColumn.AllowEdit = false;
            this.colSỐTIỀNĐÃĐÓNG.Visible = true;
            this.colSỐTIỀNĐÃĐÓNG.VisibleIndex = 3;
            this.colSỐTIỀNĐÃĐÓNG.Width = 94;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(1001, 265);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(133, 49);
            this.btnThoat.TabIndex = 30;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnManHinh
            // 
            this.btnManHinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManHinh.Location = new System.Drawing.Point(778, 265);
            this.btnManHinh.Margin = new System.Windows.Forms.Padding(5);
            this.btnManHinh.Name = "btnManHinh";
            this.btnManHinh.Size = new System.Drawing.Size(134, 49);
            this.btnManHinh.TabIndex = 29;
            this.btnManHinh.Text = "Màn hình";
            this.btnManHinh.UseVisualStyleBackColor = true;
            this.btnManHinh.Click += new System.EventHandler(this.btnManHinh_Click);
            // 
            // btnMayIn
            // 
            this.btnMayIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMayIn.Location = new System.Drawing.Point(570, 265);
            this.btnMayIn.Margin = new System.Windows.Forms.Padding(5);
            this.btnMayIn.Name = "btnMayIn";
            this.btnMayIn.Size = new System.Drawing.Size(143, 49);
            this.btnMayIn.TabIndex = 27;
            this.btnMayIn.Text = "Preview";
            this.btnMayIn.UseVisualStyleBackColor = true;
            this.btnMayIn.Click += new System.EventHandler(this.btnMayIn_Click);
            // 
            // cmbHocKy
            // 
            this.cmbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHocKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHocKy.FormattingEnabled = true;
            this.cmbHocKy.Location = new System.Drawing.Point(1175, 143);
            this.cmbHocKy.Margin = new System.Windows.Forms.Padding(5);
            this.cmbHocKy.Name = "cmbHocKy";
            this.cmbHocKy.Size = new System.Drawing.Size(231, 30);
            this.cmbHocKy.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1086, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "HỌC KỲ : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(670, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 21);
            this.label2.TabIndex = 24;
            this.label2.Text = "NIÊN KHÓA : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "LỚP : ";
            // 
            // cmbNienKhoa
            // 
            this.cmbNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNienKhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNienKhoa.FormattingEnabled = true;
            this.cmbNienKhoa.Location = new System.Drawing.Point(798, 143);
            this.cmbNienKhoa.Margin = new System.Windows.Forms.Padding(5);
            this.cmbNienKhoa.Name = "cmbNienKhoa";
            this.cmbNienKhoa.Size = new System.Drawing.Size(231, 30);
            this.cmbNienKhoa.TabIndex = 22;
            // 
            // bdsReportDSDHP
            // 
            this.bdsReportDSDHP.DataMember = "SP_REPORT_DSDHP";
            this.bdsReportDSDHP.DataSource = this.dS;
            // 
            // sP_REPORT_DSDHPTableAdapter
            // 
            this.sP_REPORT_DSDHPTableAdapter.ClearBeforeFill = true;
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
            // SP_DSHPTableAdapter
            // 
            this.SP_DSHPTableAdapter.ClearBeforeFill = true;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // frmINDSDHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 630);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmINDSDHP";
            this.Text = "In DS Học Phí Lớp";
            this.Load += new System.EventHandler(this.frmINDSDHP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_REPORT_HOCPHILOPGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsReportDSDHP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnManHinh;
        private System.Windows.Forms.Button btnMayIn;
        private System.Windows.Forms.ComboBox cmbHocKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNienKhoa;
        private DS dS;
        private System.Windows.Forms.BindingSource bdsReportDSDHP;
        private DSTableAdapters.SP_REPORT_DSDHPTableAdapter sP_REPORT_DSDHPTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bdsDSHP;
        private DSTableAdapters.SP_REPORT_HOCPHILOPTableAdapter SP_DSHPTableAdapter;
        private DevExpress.XtraGrid.GridControl sP_REPORT_HOCPHILOPGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colHỌTÊN;
        private DevExpress.XtraGrid.Columns.GridColumn colHỌCPHÍ;
        private DevExpress.XtraGrid.Columns.GridColumn colSỐTIỀNĐÃĐÓNG;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LookUpEdit cmbLop;
        private System.Windows.Forms.BindingSource bdsLop;
        private DSTableAdapters.LOPTableAdapter lOPTableAdapter;
    }
}