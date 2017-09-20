using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Quan_Ly_Quan_An.DAO;
using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Quan_An
{
    public partial class fReport : Form
    {
        private DataTable data;
        private float TienThanhToan;
        /// <summary>
        /// thực hiện load khởi tạo và truyền tiền thanh toán vào report
        /// </summary>
        /// <param name="data"></param>
        /// <param name="TienThanhToan"></param>
        public fReport(DataTable data,float TienThanhToan)
        {
            InitializeComponent();
            this.data = data;
            this.TienThanhToan = TienThanhToan;
            loadForm();
        }
        /// <summary>
        /// thực hiện khởi tạo vớibáo cáo MAHDN
        /// </summary>
        /// <param name="MAHDN"></param>
        public fReport(string MAHDN,string MANCC)
        {
            InitializeComponent();
            CrystalReportHoaDonNhap cr = new CrystalReportHoaDonNhap();
            cr.SetDataSource(CTHDNdao.Instance.getListCTHDNbyMAHD(MAHDN));

            ParameterFieldDefinitions crParameterFieldDefinitions = cr.DataDefinition.ParameterFields;
            ParameterFieldDefinition crParameterFieldDefinition = crParameterFieldDefinitions["MANCC"];

            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = MANCC;

            ParameterValues crParameterValues = new ParameterValues();
            //reset lại value
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);

            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            
            crystalReportViewerBills.ReportSource = cr;
            crystalReportViewerBills.Refresh();
        }
        /// <summary>
        /// thực hiện khởi tạo và hiên thị report với Crystal truyền vào
        /// </summary>
        /// <param name="CrystalReport"></param>
        public fReport(object CrystalReport)
        {
            InitializeComponent();
            crystalReportViewerBills.ReportSource = CrystalReport;
            crystalReportViewerBills.Refresh();
        }
        /// <summary>
        /// load report
        /// </summary>
        void loadForm()
        {
            CrystalReportBills crReport = new CrystalReportBills();
            crReport.SetDataSource(data);

            ParameterFieldDefinitions crParameterFieldDefinitions=crReport.DataDefinition.ParameterFields;
            ParameterFieldDefinition crParameterFieldDefinition= crParameterFieldDefinitions["TienThanhToan"];

            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = TienThanhToan;

            ParameterValues crParameterValues = new ParameterValues();
            //reset lại value
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);

            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewerBills.ReportSource = crReport;
            crystalReportViewerBills.Refresh();
        }
    }
}
