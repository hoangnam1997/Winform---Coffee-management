using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Quan_Ly_Quan_An.Cons;
using Quan_Ly_Quan_An.DAO;
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
    public partial class fThongKe : Form
    {
        public fThongKe()
        {
            InitializeComponent();
            formLoad();
        }

        #region Properties

        #endregion
        #region method
        /// <summary>
        /// Load phương thức tìm kiêm theo tên hoặc theo loại món ăn vào cb
        /// </summary>
        void loadPhuongThucTimKiem()
        {
            List<PhuongThuctimKiem> listCb = new List<PhuongThuctimKiem>();
            listCb.Add(new PhuongThuctimKiem(0, "Theo tên món ăn"));
            listCb.Add(new PhuongThuctimKiem(1, "Theo loại món ăn"));
            cbThongKe.DataSource = listCb;
        }
        /// <summary>
        /// trở về
        /// </summary>
        void callBack()
        {
            this.Close();
        }
        /// <summary>
        /// Load các controls khi mới khởi tạo form
        /// </summary>
        void formLoad()
        {
            this.BackColor = StaticClass.fColor;
            pnlStatisticalMenu.BackColor = pnlResultMenu.BackColor = pnlMenu.BackColor = StaticClass.pnlColorMenu;
            pnlResultList.BackColor = pnlStatisticalList.BackColor = StaticClass.pnlColorList;
            lblResultmenu.ForeColor = lblStatisticalmenu.ForeColor = StaticClass.colorWord;
            loadPhuongThucTimKiem();
            DateTime dateNow = DateTime.Now;
            DateTime dateTuNgay = new DateTime(dateNow.Year, dateNow.Month, 1, 0, 0, 0);
            DateTime dateDenNgay = dateTuNgay.AddMonths(1).AddDays(-1).AddMinutes(1439);
            dtpkTuNgay.Value = dateTuNgay;
            dtpkDenNgay.Value = dateDenNgay;
        }

        #endregion

        #region Event
        /// <summary>
        /// Thuc hien tim kiem theo loai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearchFood_Click(object sender, EventArgs e)
        {
            if (cbThongKe.SelectedItem == null) return;
            switch (((PhuongThuctimKiem)cbThongKe.SelectedItem).Loai)
            {
                case 0:
                    string tenma = StaticClass.xoakhoangtrang(txbSearchFood.Text);
                    dtgvKetQua.DataSource = HoaDonDAO.Instance.gethoaDonbyMAMAvaThoiGian(tenma, dtpkTuNgay.Value, dtpkDenNgay.Value);
                    dtgvKetQua.Columns["MAMA"].HeaderText = "Mã món ăn";
                    dtgvKetQua.Columns["TENMA"].HeaderText = "Tên món ăn";
                    dtgvKetQua.Columns["SoLan"].HeaderText = "Số lần yêu cầu";
                    break;
                case 1:
                    string ten = StaticClass.xoakhoangtrang(txbSearchFood.Text);
                    dtgvKetQua.DataSource = HoaDonDAO.Instance.gethoaDonbyLoaiMAvaThoiGian(ten, dtpkTuNgay.Value, dtpkDenNgay.Value);
                    dtgvKetQua.Columns["MALOAIMA"].HeaderText = "Mã loại món ăn";
                    dtgvKetQua.Columns["TENLOAIMA"].HeaderText = "Tên loại";
                    dtgvKetQua.Columns["SoLan"].HeaderText = "Số lần yêu cầu";
                    break;
            }
        }
        /// <summary>
        /// không cho nhấn enter và gọi sự kiện search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSearchFood_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ptbSearchFood_Click(this, new EventArgs());
            }
        }
        /// <summary>
        /// Xem chi tiết báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            switch (((PhuongThuctimKiem)cbThongKe.SelectedItem).Loai)
            {
                case 0:
                    string tenma = StaticClass.xoakhoangtrang(txbSearchFood.Text);
                    DateTime tuNgay = dtpkTuNgay.Value;
                    DateTime denNgay = dtpkDenNgay.Value;

                    CrystalReportThongKeTenMonAn cr = new CrystalReportThongKeTenMonAn();
                    cr.SetDataSource(HoaDonDAO.Instance.USP_getThongKeTheoTenchiTiet(tenma,tuNgay, denNgay));
                    ParameterFieldDefinitions crParameterFieldDefinitions = cr.DataDefinition.ParameterFields;

                    ParameterFieldDefinition crParameterFieldDefinition = crParameterFieldDefinitions["TuNgay"];
                    ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                    crParameterDiscreteValue.Value = tuNgay;
                    ParameterValues crParameterValues = new ParameterValues();
                    //reset lại value
                    crParameterValues = crParameterFieldDefinition.CurrentValues;
                    crParameterValues.Add(crParameterDiscreteValue);
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                    ParameterFieldDefinition crParameterFieldDefinitionDenNgay = crParameterFieldDefinitions["DenNgay"];
                    ParameterDiscreteValue crParameterDiscreteValueDenNgay = new ParameterDiscreteValue();
                    crParameterDiscreteValueDenNgay.Value = denNgay;
                    ParameterValues crParameterValuesDenNgay = new ParameterValues();
                    //reset lại value
                    crParameterValuesDenNgay = crParameterFieldDefinitionDenNgay.CurrentValues;
                    crParameterValuesDenNgay.Add(crParameterDiscreteValueDenNgay);
                    crParameterFieldDefinitionDenNgay.ApplyCurrentValues(crParameterValuesDenNgay);
                    fReport f = new fReport(cr);
                    f.ShowDialog();
                    break;
                case 1:
                    string tenLoai = StaticClass.xoakhoangtrang(txbSearchFood.Text);
                    DateTime tuNgayLoai = dtpkTuNgay.Value;
                    DateTime denNgayLoai = dtpkDenNgay.Value;
                    CrystalReportThongKeLoaiMonAn crLoai = new CrystalReportThongKeLoaiMonAn();
                    crLoai.SetDataSource(HoaDonDAO.Instance.USP_getThongKeTheoLoaichiTiet(tenLoai, tuNgayLoai, denNgayLoai));
                    ParameterFieldDefinitions crParameterFieldDefinitionsLoai = crLoai.DataDefinition.ParameterFields;

                    ParameterFieldDefinition crParameterFieldDefinitionLoai = crParameterFieldDefinitionsLoai["TuNgay"];
                    ParameterDiscreteValue crParameterDiscreteValueLoai = new ParameterDiscreteValue();
                    crParameterDiscreteValueLoai.Value = tuNgayLoai;
                    ParameterValues crParameterValuesLoai = new ParameterValues();
                    //reset lại value
                    crParameterValues = crParameterFieldDefinitionLoai.CurrentValues;
                    crParameterValues.Add(crParameterDiscreteValueLoai);
                    crParameterFieldDefinitionLoai.ApplyCurrentValues(crParameterValues);

                    ParameterFieldDefinition crParameterFieldDefinitionDenNgayLoai = crParameterFieldDefinitionsLoai["DenNgay"];
                    ParameterDiscreteValue crParameterDiscreteValueDenNgayLoai = new ParameterDiscreteValue();
                    crParameterDiscreteValueDenNgayLoai.Value = denNgayLoai;
                    ParameterValues crParameterValuesDenNgayLoai = new ParameterValues();
                    //reset lại value
                    crParameterValuesDenNgayLoai = crParameterFieldDefinitionDenNgayLoai.CurrentValues;
                    crParameterValuesDenNgayLoai.Add(crParameterDiscreteValueDenNgayLoai);
                    crParameterFieldDefinitionDenNgayLoai.ApplyCurrentValues(crParameterValuesDenNgayLoai);
                    fReport fLoai = new fReport(crLoai);
                    fLoai.ShowDialog();
                    break;
            }
            
        }
        #region setcolor
        private void ptbBack_Click(object sender, EventArgs e)
        {
            callBack();
        }
        private void ptbBack_MouseEnter(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.fColor;
        }

        private void ptbBack_MouseLeave(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.pnlColorMenu;
        }

        private void ptbSearchFood_MouseEnter(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.Black;
        }

        private void ptbSearchFood_MouseLeave(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.Silver;
        }

        private void lblSearch_MouseEnter(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.Black;
        }

        private void lblSearch_MouseLeave(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.Silver;
        }

        #endregion

        #endregion

    }
}
