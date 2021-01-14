namespace QLDSV_PT
{
    partial class frmChuyenLop
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
            this.panel = new System.Windows.Forms.Panel();
            this.gBClassNew = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.txtMaLopMoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV_PT.DS();
            this.txtMaSVMoi = new System.Windows.Forms.TextBox();
            this.butonCancel = new System.Windows.Forms.Button();
            this.labelSupport = new System.Windows.Forms.Label();
            this.buttonChuyenLop = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gBClassOld = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaLopCu = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.cmbSinhVien = new DevExpress.XtraEditors.LookUpEdit();
            this.bdsSinhVien = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sINHVIENTableAdapter = new QLDSV_PT.DSTableAdapters.SINHVIENTableAdapter();
            this.kHOABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kHOATableAdapter = new QLDSV_PT.DSTableAdapters.KHOATableAdapter();
            this.tableAdapterManager = new QLDSV_PT.DSTableAdapters.TableAdapterManager();
            this.lOPTableAdapter = new QLDSV_PT.DSTableAdapters.LOPTableAdapter();
            this.panel.SuspendLayout();
            this.gBClassNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            this.gBClassOld.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSinhVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHOABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.gBClassNew);
            this.panel.Controls.Add(this.gBClassOld);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1562, 940);
            this.panel.TabIndex = 0;
            // 
            // gBClassNew
            // 
            this.gBClassNew.Controls.Add(this.label6);
            this.gBClassNew.Controls.Add(this.cmbKhoa);
            this.gBClassNew.Controls.Add(this.txtMaLopMoi);
            this.gBClassNew.Controls.Add(this.label2);
            this.gBClassNew.Controls.Add(this.cmbLop);
            this.gBClassNew.Controls.Add(this.txtMaSVMoi);
            this.gBClassNew.Controls.Add(this.butonCancel);
            this.gBClassNew.Controls.Add(this.labelSupport);
            this.gBClassNew.Controls.Add(this.buttonChuyenLop);
            this.gBClassNew.Controls.Add(this.label9);
            this.gBClassNew.Controls.Add(this.label8);
            this.gBClassNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBClassNew.Location = new System.Drawing.Point(0, 306);
            this.gBClassNew.Name = "gBClassNew";
            this.gBClassNew.Size = new System.Drawing.Size(1562, 521);
            this.gBClassNew.TabIndex = 39;
            this.gBClassNew.TabStop = false;
            this.gBClassNew.Text = "Lớp Mới";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(977, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 22);
            this.label6.TabIndex = 49;
            this.label6.Text = "Mã lớp chuyển đến";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(689, 57);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(445, 30);
            this.cmbKhoa.TabIndex = 26;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // txtMaLopMoi
            // 
            this.txtMaLopMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLopMoi.Location = new System.Drawing.Point(1152, 137);
            this.txtMaLopMoi.Name = "txtMaLopMoi";
            this.txtMaLopMoi.ReadOnly = true;
            this.txtMaLopMoi.Size = new System.Drawing.Size(245, 30);
            this.txtMaLopMoi.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Khoa: ";
            // 
            // cmbLop
            // 
            this.cmbLop.DataSource = this.bdsLop;
            this.cmbLop.DisplayMember = "TENLOP";
            this.cmbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(363, 139);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(521, 30);
            this.cmbLop.TabIndex = 46;
            this.cmbLop.ValueMember = "MALOP";
            this.cmbLop.SelectedIndexChanged += new System.EventHandler(this.cmbLop_SelectedIndexChanged);
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
            // txtMaSVMoi
            // 
            this.txtMaSVMoi.Location = new System.Drawing.Point(850, 228);
            this.txtMaSVMoi.Name = "txtMaSVMoi";
            this.txtMaSVMoi.Size = new System.Drawing.Size(250, 30);
            this.txtMaSVMoi.TabIndex = 36;
            // 
            // butonCancel
            // 
            this.butonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butonCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonCancel.ForeColor = System.Drawing.Color.White;
            this.butonCancel.Location = new System.Drawing.Point(1130, 329);
            this.butonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butonCancel.Name = "butonCancel";
            this.butonCancel.Size = new System.Drawing.Size(129, 62);
            this.butonCancel.TabIndex = 5;
            this.butonCancel.Text = "Hủy";
            this.butonCancel.UseVisualStyleBackColor = false;
            this.butonCancel.Click += new System.EventHandler(this.butonCancel_Click);
            // 
            // labelSupport
            // 
            this.labelSupport.AutoSize = true;
            this.labelSupport.Location = new System.Drawing.Point(567, 133);
            this.labelSupport.Name = "labelSupport";
            this.labelSupport.Size = new System.Drawing.Size(0, 22);
            this.labelSupport.TabIndex = 33;
            // 
            // buttonChuyenLop
            // 
            this.buttonChuyenLop.BackColor = System.Drawing.Color.Green;
            this.buttonChuyenLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChuyenLop.ForeColor = System.Drawing.Color.White;
            this.buttonChuyenLop.Location = new System.Drawing.Point(700, 329);
            this.buttonChuyenLop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonChuyenLop.Name = "buttonChuyenLop";
            this.buttonChuyenLop.Size = new System.Drawing.Size(145, 62);
            this.buttonChuyenLop.TabIndex = 4;
            this.buttonChuyenLop.Text = "Chuyển Lớp";
            this.buttonChuyenLop.UseVisualStyleBackColor = false;
            this.buttonChuyenLop.Click += new System.EventHandler(this.buttonChuyenLop_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(209, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 22);
            this.label9.TabIndex = 29;
            this.label9.Text = "Chọn lớp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(696, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 22);
            this.label8.TabIndex = 27;
            this.label8.Text = "Mã sinh viên: ";
            // 
            // gBClassOld
            // 
            this.gBClassOld.Controls.Add(this.label4);
            this.gBClassOld.Controls.Add(this.txtMaLopCu);
            this.gBClassOld.Controls.Add(this.txtHoten);
            this.gBClassOld.Controls.Add(this.cmbSinhVien);
            this.gBClassOld.Controls.Add(this.label1);
            this.gBClassOld.Controls.Add(this.label3);
            this.gBClassOld.Controls.Add(this.label5);
            this.gBClassOld.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBClassOld.Location = new System.Drawing.Point(0, 0);
            this.gBClassOld.Name = "gBClassOld";
            this.gBClassOld.Size = new System.Drawing.Size(1562, 306);
            this.gBClassOld.TabIndex = 38;
            this.gBClassOld.TabStop = false;
            this.gBClassOld.Text = "Tìm kiếm nhanh sinh viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(681, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 43);
            this.label4.TabIndex = 13;
            this.label4.Text = "CHUYỂN LỚP";
            // 
            // txtMaLopCu
            // 
            this.txtMaLopCu.Location = new System.Drawing.Point(1121, 217);
            this.txtMaLopCu.Name = "txtMaLopCu";
            this.txtMaLopCu.ReadOnly = true;
            this.txtMaLopCu.Size = new System.Drawing.Size(184, 30);
            this.txtMaLopCu.TabIndex = 24;
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(515, 217);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.ReadOnly = true;
            this.txtHoten.Size = new System.Drawing.Size(203, 30);
            this.txtHoten.TabIndex = 23;
            // 
            // cmbSinhVien
            // 
            this.cmbSinhVien.Location = new System.Drawing.Point(763, 140);
            this.cmbSinhVien.Name = "cmbSinhVien";
            this.cmbSinhVien.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSinhVien.Properties.Appearance.Options.UseFont = true;
            this.cmbSinhVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSinhVien.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MASV", "MASV", 57, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbSinhVien.Properties.DataSource = this.bdsSinhVien;
            this.cmbSinhVien.Properties.DisplayMember = "MASV";
            this.cmbSinhVien.Properties.NullText = "Chọn hoặc gõ mã sinh viên....";
            this.cmbSinhVien.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbSinhVien.Properties.ValueMember = "MASV";
            this.cmbSinhVien.Size = new System.Drawing.Size(280, 28);
            this.cmbSinhVien.TabIndex = 22;
            this.cmbSinhVien.EditValueChanged += new System.EventHandler(this.lookUpEditChuyenLop_EditValueChanged);
            // 
            // bdsSinhVien
            // 
            this.bdsSinhVien.DataMember = "SINHVIEN";
            this.bdsSinhVien.DataSource = this.dS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1041, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã lớp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tên sinh viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mã Sinh Viên:";
            // 
            // sINHVIENTableAdapter
            // 
            this.sINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // kHOABindingSource
            // 
            this.kHOABindingSource.DataMember = "KHOA";
            this.kHOABindingSource.DataSource = this.dS;
            // 
            // kHOATableAdapter
            // 
            this.kHOATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CT_DONGHOCPHITableAdapter = null;
            this.tableAdapterManager.DIEMTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.HOCPHITableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = this.kHOATableAdapter;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIEN_HOCPHITableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = this.sINHVIENTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLDSV_PT.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // frmChuyenLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 940);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmChuyenLop";
            this.Text = "Chuyển lớp";
            this.Load += new System.EventHandler(this.frmChuyenLop_Load);
            this.panel.ResumeLayout(false);
            this.gBClassNew.ResumeLayout(false);
            this.gBClassNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            this.gBClassOld.ResumeLayout(false);
            this.gBClassOld.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSinhVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHOABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butonCancel;
        private System.Windows.Forms.Button buttonChuyenLop;
        private DS dS;
        private System.Windows.Forms.TextBox txtMaLopCu;
        private System.Windows.Forms.TextBox txtHoten;
        private DevExpress.XtraEditors.LookUpEdit cmbSinhVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSVMoi;
        private System.Windows.Forms.Label labelSupport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gBClassNew;
        private System.Windows.Forms.GroupBox gBClassOld;
        private System.Windows.Forms.BindingSource bdsSinhVien;
        private DSTableAdapters.SINHVIENTableAdapter sINHVIENTableAdapter;
        private System.Windows.Forms.BindingSource kHOABindingSource;
        private DSTableAdapters.KHOATableAdapter kHOATableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaLopMoi;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.BindingSource bdsLop;
        private DSTableAdapters.LOPTableAdapter lOPTableAdapter;
    }
}