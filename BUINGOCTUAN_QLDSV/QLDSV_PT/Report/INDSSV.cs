using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV_PT.Report
{
    public partial class INDSSV : DevExpress.XtraReports.UI.XtraReport
    {
        public INDSSV(string MALOP)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            Console.WriteLine(Program.connstr);
            this.sqlDataSource1.Queries[0].Parameters[0].Value = MALOP;
            this.sqlDataSource1.Fill();
        }

    }
}
