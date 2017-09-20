using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Quan_Ly_Quan_An.Cons;
using Quan_Ly_Quan_An.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Quan_An
{
    public partial class fBaoCaoThuChi : Form
    {
        public fBaoCaoThuChi()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties
        #endregion
        #region Method
        /// <summary>
        /// thực hiện load form. load các thông tin cơ bản của các controls
        /// </summary>
        void loadForm()
        {
            tpExport.BackColor = tpReportImport.BackColor=this.BackColor = StaticClass.fColor;
            pnlImportMenu.BackColor=pnlExportMenu.BackColor=pnlMenu.BackColor = StaticClass.pnlColorMenu;
            pnlImport.BackColor = pnlExport.BackColor = StaticClass.pnlColorList;
            lblImportMenu.ForeColor = StaticClass.colorWord;

            DateTime dateNow = DateTime.Now;
            DateTime dateTuNgay = new DateTime(dateNow.Year, dateNow.Month, 1, 0, 0, 0);
            DateTime dateDenNgay = dateTuNgay.AddMonths(1).AddDays(-1).AddMinutes(1439);
            dtpkTuNgayChi.Value = dateTuNgay;
            dtpkTuNgayThu.Value = dateTuNgay;
            dtpkDenNgayChi.Value = dtpkDenNgayThu.Value = dateDenNgay;
            loadCBBaoCaoChi();
            ptbSearchImport_Click(this, new EventArgs());
            ptbTimKiemBaoCaochi_Click(this, new EventArgs());
            
        }
        /// <summary>
        /// Load cac trnag thai bao cao
        /// 0: bao cao chi nhap thuc pham
        /// 1: bao cao chi bang luong
        /// </summary>
        void loadCBBaoCaoChi()
        {
            List<BaoCaoChi> listCB = new List<BaoCaoChi>();
            listCB.Add(new BaoCaoChi(0, "Nhập thực phẩm"));
            listCB.Add(new BaoCaoChi(1, "Lương nhân viên"));
            cbChi.DataSource = listCB;
        }
        /// <summary>
        /// thoát form
        /// </summary>
        void callBack()
        {
            this.Close();
        }
        #endregion
        #region Event
        /// <summary>
        /// In báo cáo chi. 0 hóa đơn nhâp. 1 tiền lương nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPrintExport_Click(object sender, EventArgs e)
        {
            switch (((BaoCaoChi)cbChi.SelectedItem).BaoCao)
            {
                case 0:
                    DateTime TuNgay = dtpkTuNgayChi.Value;
                    DateTime denNgay = dtpkDenNgayChi.Value;
                    

                    CrystalReportBaoCaoChiNhapThucPham cr = new CrystalReportBaoCaoChiNhapThucPham();
                    cr.SetDataSource(HoaDonNhapDAO.Instance.getListHoaDonNhapTuNgayDenNgay(TuNgay, denNgay));
                    ParameterFieldDefinitions crParameterFieldDefinitions = cr.DataDefinition.ParameterFields;

                    ParameterFieldDefinition crParameterFieldDefinition = crParameterFieldDefinitions["TuNgay"];
                    ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                    crParameterDiscreteValue.Value = TuNgay;
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
                    DateTime TuNgaya = dtpkTuNgayChi.Value;
                    DateTime denNgaya = dtpkDenNgayChi.Value;

                    CrystalReportBaoCaoChiLuongNhanVien cr1 = new CrystalReportBaoCaoChiLuongNhanVien();
                    cr1.SetDataSource(BangLuongNhanVienDAO.Instance.getListBangLuongTuNgayDenNgay(TuNgaya, denNgaya));
                    ParameterFieldDefinitions crParameterFieldDefinitions1 = cr1.DataDefinition.ParameterFields;

                    ParameterFieldDefinition crParameterFieldDefinition1 = crParameterFieldDefinitions1["TuNgay"];
                    ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
                    crParameterDiscreteValue1.Value = TuNgaya;
                    ParameterValues crParameterValues1 = new ParameterValues();
                    //reset lại value
                    crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
                    crParameterValues1.Add(crParameterDiscreteValue1);
                    crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

                    ParameterFieldDefinition crParameterFieldDefinitionDenNgay1 = crParameterFieldDefinitions1["DenNgay"];
                    ParameterDiscreteValue crParameterDiscreteValueDenNgay1 = new ParameterDiscreteValue();
                    crParameterDiscreteValueDenNgay1.Value = denNgaya;
                    ParameterValues crParameterValuesDenNgay1 = new ParameterValues();
                    //reset lại value
                    crParameterValuesDenNgay1 = crParameterFieldDefinitionDenNgay1.CurrentValues;
                    crParameterValuesDenNgay1.Add(crParameterDiscreteValueDenNgay1);
                    crParameterFieldDefinitionDenNgay1.ApplyCurrentValues(crParameterValuesDenNgay1);
                    fReport f1 = new fReport(cr1);
                    f1.ShowDialog();
                    break;
            }
        }
        /// <summary>
        /// Thuc hien báo cáo chi theo cb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbTimKiemBaoCaochi_Click(object sender, EventArgs e)
        {
            double TongTien = 0;
            switch (((BaoCaoChi)cbChi.SelectedItem).BaoCao)
            {
                case 0:
                    DateTime TuNgay = dtpkTuNgayChi.Value;
                    DateTime denNgay = dtpkDenNgayChi.Value;
                    DataTable data = HoaDonNhapDAO.Instance.getListHoaDonNhapTuNgayDenNgay(TuNgay, denNgay);
                    dtgvChi.DataSource = data;
                    dtgvChi.Columns["MAHDN"].HeaderText = "Mã hóa đơn";
                    dtgvChi.Columns["NGAYLAP"].HeaderText = "Thời gian";
                    dtgvChi.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dtgvChi.Columns["TONGTIEN"].HeaderText = "Tổng tiền";
                    dtgvChi.Columns["TRANGTHAI"].Visible = false;
                    foreach (DataRow item in data.Rows)
                    {
                        TongTien += double.Parse(item["TONGTIEN"].ToString());
                    }
                    break;
                case 1:
                    DateTime TuNgaya = dtpkTuNgayChi.Value;
                    DateTime denNgaya = dtpkDenNgayChi.Value;
                    DataTable dataNV = BangLuongNhanVienDAO.Instance.getListBangLuongTuNgayDenNgay(TuNgaya, denNgaya); ;
                    dtgvChi.DataSource = dataNV;
                    dtgvChi.Columns["MABL"].Visible = false;
                    dtgvChi.Columns["MANV"].HeaderText = "Mã nhân viên";
                    dtgvChi.Columns["NGAYLAP"].HeaderText = "Ngày lập";
                    dtgvChi.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dtgvChi.Columns["THOIGIANBATDAU"].Visible = false;
                    dtgvChi.Columns["THOIGIANKETTHUC"].Visible = false;
                    dtgvChi.Columns["TONGTIENLUONG"].HeaderText = "Tổng tiền lương";
                    foreach (DataRow item in dataNV.Rows)
                    {
                        TongTien += double.Parse(item["TONGTIENLUONG"].ToString());
                    }
                    break;
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTongTienChi.Text = TongTien.ToString("c", culture);
        }
        /// <summary>
        /// Xem báo cáo thu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearchImport_Click(object sender, EventArgs e)
        {
            float TongTien = 0;
            float TongTienDaThanhToan = 0;
            DateTime TuNgay = dtpkTuNgayThu.Value;
            DateTime denNgay = dtpkDenNgayThu.Value;
            DataTable data= HoaDonDAO.Instance.getHoaDonbyThoiGian(TuNgay, denNgay);
            foreach (DataRow item in data.Rows)
            {
                TongTien += float.Parse(item["TONGTIEN"].ToString());
                TongTienDaThanhToan += float.Parse(item["TIENDATHANHTOAN"].ToString());
            }
            
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTongTienDaThanhToan.Text = TongTienDaThanhToan.ToString("c", culture);
            txbTong.Text = TongTien.ToString("c",culture);
            dtgvImport.DataSource = data;
            dtgvImport.Columns["MAHD"].Visible = false;
            dtgvImport.Columns["THOIGIANBATDAU"].Visible = false;
            dtgvImport.Columns["TRANGTHAI"].Visible = false;
            dtgvImport.Columns["MAKH"].Visible = false;
            dtgvImport.Columns["NGAYLAP"].HeaderText = "Thời gian";
            dtgvImport.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvImport.Columns["TONGTIEN"].HeaderText = "Tổng tiền";
            dtgvImport.Columns["TIENDATHANHTOAN"].HeaderText = "Đã thanh toán";
            dtgvImport.Columns["MABA"].HeaderText = "Bàn ăn";
            dtgvImport.Columns["MANV"].HeaderText = "Nhân viên";
        }
        /// <summary>
        /// In báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPrintImport_Click(object sender, EventArgs e)
        {
            DateTime TuNgay = dtpkTuNgayThu.Value;
            DateTime denNgay = dtpkDenNgayThu.Value;
            CrystalReportBaoCaoThu cr = new CrystalReportBaoCaoThu();
            cr.SetDataSource(HoaDonDAO.Instance.getHoaDonbyThoiGian(TuNgay, denNgay));
            ParameterFieldDefinitions crParameterFieldDefinitions = cr.DataDefinition.ParameterFields;

            ParameterFieldDefinition crParameterFieldDefinition = crParameterFieldDefinitions["TuNgay"];
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = TuNgay;
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
        }
        /// <summary>
        /// Thay đổi báo cáo theo selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ptbTimKiemBaoCaochi_Click(this, new EventArgs());
        }
        private void ptbBack_Click(object sender, EventArgs e)
        {
            callBack();
        }
        /// <summary>
        /// set hiệu ứng chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbBack_MouseEnter(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.fColor;
        }

        private void ptbBack_MouseLeave(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.pnlColorMenu;
        }
        private void ptbSearchImport_MouseEnter(object sender, EventArgs e)
        {
            ptbSearchImport.BackColor = StaticClass.fColor;
        }

        private void ptbSearchImport_MouseLeave(object sender, EventArgs e)
        {
            ptbSearchImport.BackColor = StaticClass.pnlColorList;
        }
        private void ptbPrintImport_MouseEnter(object sender, EventArgs e)
        {
            lblPrintImport.ForeColor = Color.Black;
        }

        private void ptbPrintImport_MouseLeave(object sender, EventArgs e)
        {
            lblPrintImport.ForeColor = Color.Silver;
        }

        private void lblPrintImport_MouseEnter(object sender, EventArgs e)
        {
            lblPrintImport.ForeColor = Color.Black;
        }

        private void lblPrintImport_MouseLeave(object sender, EventArgs e)
        {
            lblPrintImport.ForeColor = Color.Silver;
        }

        private void ptbSerchExport_MouseEnter(object sender, EventArgs e)
        {
            ptbTimKiemBaoCaochi.BackColor = StaticClass.fColor;
        }

        private void ptbSerchExport_MouseLeave(object sender, EventArgs e)
        {
            ptbTimKiemBaoCaochi.BackColor = StaticClass.pnlColorList;
        }
        private void ptbPrintExport_MouseEnter(object sender, EventArgs e)
        {
            lblPrintExport.ForeColor = Color.Black;
        }

        private void ptbPrintExport_MouseLeave(object sender, EventArgs e)
        {
            lblPrintExport.ForeColor = Color.Silver;
        }

        private void lblPrintExport_MouseEnter(object sender, EventArgs e)
        {
            lblPrintExport.ForeColor = Color.Black;
        }

        private void lblPrintExport_MouseLeave(object sender, EventArgs e)
        {
            lblPrintExport.ForeColor = Color.Silver;
        }

        #endregion
        
    }
}
