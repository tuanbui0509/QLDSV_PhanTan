using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV_PT.Report
{
    public partial class INBDTK : DevExpress.XtraReports.UI.XtraReport
    {
        public INBDTK(string maLop)
        {
            InitializeComponent();

            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maLop;
            this.sqlDataSource1.Fill();
        }

    }
}
