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
using System.Data.SqlClient;

namespace QLDSV_PT.Report
{
    public partial class frmINDSDHP : DevExpress.XtraEditors.XtraForm
    {
        private int position;
        public frmINDSDHP()
        {
            InitializeComponent();
        }

        private void load_1()
        {
            string sql = "SELECT NIENKHOA FROM HOCPHI GROUP BY NIENKHOA";
            try
            {
                Program.MyReader = Program.ExecSqlDataReader(sql);

                DataTable dt = new DataTable();
                dt.Load(Program.MyReader);
                cmbNienKhoa.DataSource = dt;
                cmbNienKhoa.DisplayMember = "NIENKHOA";
                cmbNienKhoa.ValueMember = "NIENKHOA";
                cmbNienKhoa.SelectedIndex = 0;
                Program.MyReader.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi khi load dữ liệu");
            }
        }

        private void frmINDSDHP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            cmbHocKy.Items.Add(1);
            cmbHocKy.Items.Add(2);
            cmbHocKy.SelectedIndex = 0;
            load_1();
            dS.EnforceConstraints = false;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

        }

        private void btnManHinh_Click(object sender, EventArgs e)
        {
            string malop = (((DataRowView)bdsLop[position])["MALOP"].ToString().Trim());
            string nienkhoa = cmbNienKhoa.SelectedValue.ToString();
            string hocky = cmbHocKy.SelectedItem.ToString();

            this.SP_DSHPTableAdapter.Fill(dS.SP_REPORT_HOCPHILOP, malop, nienkhoa, Int32.Parse(hocky));
            if (this.bdsDSHP.Count == 0)
            {
                MessageBox.Show("Không có thông tin để hiển thị !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        private string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        public string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }

        string ExcuteTotalPrice(string malop, string nkhoa, int hky)
        {
            SqlConnection sqlConnection = new SqlConnection(Program.connstr);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "SP_TONG_HOCPHI";
            sqlCommand.Parameters.Add(new SqlParameter("@MALOP", malop));
            sqlCommand.Parameters.Add(new SqlParameter("@HOCKY", hky));
            sqlCommand.Parameters.Add(new SqlParameter("@NIENKHOA", nkhoa));
            SqlParameter sqlParameter3 = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
            sqlParameter3.Direction = System.Data.ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(sqlParameter3);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            int result = (int)sqlCommand.Parameters["@return"].Value;
            return ChuyenSoSangChuoi(result);
        }

        private void btnMayIn_Click(object sender, EventArgs e)
        {
            string malop = (((DataRowView)bdsLop[position])["MALOP"].ToString().Trim());
            string nienkhoa = cmbNienKhoa.SelectedValue.ToString();
            string hocky = cmbHocKy.SelectedItem.ToString();
            INHOCPHI_LOP xpr = new INHOCPHI_LOP(malop, nienkhoa, Int32.Parse(hocky));
            xpr.txtLop.Text = "Lớp : " + malop.ToUpper();
            xpr.txtNK.Text = "Niên khóa : " + nienkhoa;
            xpr.txtHK.Text = "Học kỳ : " + hocky;
            xpr.txtTotalPrice.Text += ExcuteTotalPrice(malop.ToUpper(), nienkhoa, Int32.Parse( hocky));
            ReportPrintTool print = new ReportPrintTool(xpr);
            print.ShowPreviewDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            var selectedLop = cmbLop.GetSelectedDataRow() as DataRowView;
            position = this.bdsLop.Find("MALOP", selectedLop.Row["MALOP"].ToString());
            this.bdsLop.Position = position;
            dS.EnforceConstraints = false;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
        }
    }
}