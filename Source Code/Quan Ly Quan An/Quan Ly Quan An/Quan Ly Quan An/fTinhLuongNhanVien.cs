using Quan_Ly_Quan_An.Cons;
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
    public partial class fTinhLuongNhanVien : Form
    {
        public fTinhLuongNhanVien()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties
        private BindingSource NhanVienSource = new BindingSource();
        private List<BangLuongTempDTO> listNhanVien = new List<BangLuongTempDTO>();
        #endregion

        #region Method
        /// <summary>
        /// thực hiện khi vừa load form, cập nhật thông tin các controls
        /// </summary>
        void loadForm()
        {
            DateTime date = DateTime.Now;
            dtpkTuNgay.Value = new DateTime(date.Year, date.Month, 1);
            dtpkDenNgay.Value = dtpkTuNgay.Value.AddMonths(1).AddDays(-1);
            dtgvNhanVien.DataSource = NhanVienSource;
            NhanVienSource.DataSource = listNhanVien;
            lblNhanVienTemp.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MANV", true, DataSourceUpdateMode.Never));
            loadTongTien();
        }
        #endregion

        #region Event
        /// <summary>
        /// lấy thông tin  lương của tất cả nhân viên từ ngày đén ngày
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime dateTuNgay = dtpkTuNgay.Value;
            DateTime dateDenNgay = dtpkDenNgay.Value;
            listNhanVien= BangLuongNhanVienDAO.Instance.getBangLuongtemp(dateTuNgay, dateDenNgay);
            if(dtgvNhanVien.Rows.Count>1)
            {
                dtgvNhanVien.CurrentCell = dtgvNhanVien.Rows[0].Cells[0];
            }
            NhanVienSource.DataSource = listNhanVien;
            loadTongTien();
        }
        /// <summary>
        /// load tổng tiền vào controls
        /// </summary>
        void loadTongTien()
        {
            float totalPrice = 0;
            foreach (BangLuongTempDTO item in listNhanVien)
            {
                totalPrice += item.TIENLUONG;
            }
            txbTongLUONGall.Text = totalPrice.ToString();
        }
        /// <summary>
        /// Tim nhan vien theo ten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ptbSearch_Click(this, new EventArgs());
            }
        }
        /// <summary>
        /// Tim nhan vien theo ten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearch_Click(object sender, EventArgs e)
        {
            dtgvNhanVien.ClearSelection();
            dtgvNhanVien.CurrentCell = null;
            DateTime dateTuNgay = dtpkTuNgay.Value;
            DateTime dateDenNgay = dtpkDenNgay.Value;
            string ten = StaticClass.xoakhoangtrang(txbSearch.Text);
            listNhanVien = BangLuongNhanVienDAO.Instance.getBangLuongtemp(dateTuNgay, dateDenNgay, ten);
            NhanVienSource.DataSource = listNhanVien;
            loadTongTien();
        }
        /// <summary>
        /// binding thong tin chi tiet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNhanVienTemp_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNhanVienTemp.Text)) return;
            NhanVienDTO nhanvien = NhanVienDAO.Instance.getAccountByUserName(lblNhanVienTemp.Text).ToArray()[0];
            
            List<NgayLamSTTDTO> listNonCheck = NgayLamDAO.Instance.getDanhSachNgayChuaTinhLuongMANV(dtpkTuNgay.Value, dtpkDenNgay.Value, lblNhanVienTemp.Text);
            dtgvChuaTra.DataSource = listNonCheck;
            dtgvChuaTra.Columns["DayWork"].HeaderText = "Ngày làm việc";
            txbTongChua.Text = listNonCheck.Count.ToString();

            List<NgayLamSTTDTO> listCheck = NgayLamDAO.Instance.getDanhSachNgayDaTinhLuongMANV(lblNhanVienTemp.Text);
            dtgvDaTra.DataSource = listCheck;
            dtgvDaTra.Columns["DayWork"].HeaderText = "Ngày làm việc";
            txbTongDa.Text = listCheck.Count.ToString();
            float mucluong = float.Parse(nhanvien.MUCLUONG.ToString());
            float tongTien = mucluong * Int32.Parse(txbTongChua.Text);
            txbMucLuong.Text = mucluong.ToString();
            txbLuong.Text = tongTien.ToString();

        }
        private void ptbSearch_MouseEnter(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.fColor;
        }

        private void ptbSearch_MouseLeave(object sender, EventArgs e)
        {
            ptbSearch.BackColor = panel2.BackColor;
        }
        /// <summary>
        /// Thực hiên trả tiên luongw cho nhân viên.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNhanVienTemp.Text)) return;
            string mabl = StaticClass.Random(10);
            float tongtien = float.Parse(txbLuong.Text);
            if (!BangLuongNhanVienDAO.Instance.insertBangLuong(mabl, lblNhanVienTemp.Text, dtpkTuNgay.Value, dtpkDenNgay.Value, tongtien, DateTime.Now))
            {
                fMessageBoxOK.Show("Vui lòng thử thực hiện lại!");
                return;
            }

            if (!NgayLamDAO.Instance.updateNgayLam(lblNhanVienTemp.Text, dtpkTuNgay.Value, dtpkDenNgay.Value))
            {
                fMessageBoxOK.Show("Xãy ra lỗi khi cập nhật");
                return;
            }

            btnXem_Click(this, new EventArgs());
        }

        #endregion

    }
}
