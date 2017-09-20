using Quan_Ly_Quan_An.Cons;
using Quan_Ly_Quan_An.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quan_Ly_Quan_An
{
    public partial class fNhanVien : Form
    {
        public fNhanVien()
        {
            InitializeComponent();
            loadForm();
        }

        #region Properties
        BindingSource NhanVienSource = new BindingSource();
        #endregion
        #region method
        /// <summary>
        /// xUẤT  file excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPrintf_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(() =>
            {
                Invoke((MethodInvoker)(() =>
                {
                    string query = "USP_getListNhanVienReport";
                    DataTable data = DataProvider.Instance.ExecuteQuery(query);
                    ExportExcel.exportDataToExcel("DANH SÁCH NHÂN VIÊN", data);
                }));
            });
            thr.IsBackground = true;

            thr.Start();


        }
        /// <summary>
        /// chạy khi khởi động form
        /// </summary>
        void loadForm()
        {

            this.BackColor = StaticClass.fColor;
            pnlListMenuAccount.BackColor = pnlMenu.BackColor = StaticClass.pnlColorMenu;
            pnlListAccount.BackColor = pnlInfomationAccount.BackColor = StaticClass.pnlColorList;
            // gan source vào các dtgv
            dtgvNhanVien.DataSource = NhanVienSource;
            loadNhanVien();
            loadBinDing();
            // Load Quyen vao cb
            List<QuyenNhanVien> listPhanQuyen = new List<QuyenNhanVien>();
            listPhanQuyen.Add(new QuyenNhanVien(0, "Admin"));
            listPhanQuyen.Add(new QuyenNhanVien(1, "Nhân viên phục vụ"));
            listPhanQuyen.Add(new QuyenNhanVien(2, "Nhân viên nhà bếp"));
            listPhanQuyen.Add(new QuyenNhanVien(2, "Nhân viên kế toán"));
            cbChucVu.DataSource = listPhanQuyen;

        }
        /// <summary>
        /// thay đổi thuộc tính khi người dùng chọn nhân viên khác
        /// </summary>
        void loadBinDing()
        {
            txbMaNV.DataBindings.Add("Text", dtgvNhanVien.DataSource, "MANV", true, DataSourceUpdateMode.Never);
            lblMANVtemp.DataBindings.Add("Text", dtgvNhanVien.DataSource, "MANV", true, DataSourceUpdateMode.Never);
            txbTenNV.DataBindings.Add("Text", dtgvNhanVien.DataSource, "HOTEN", true, DataSourceUpdateMode.Never);
            dtpkNgaySinh.DataBindings.Add("Value", dtgvNhanVien.DataSource, "NGAYSINH", true, DataSourceUpdateMode.Never);
            txbDiaChi.DataBindings.Add("Text", dtgvNhanVien.DataSource, "DIACHI", true, DataSourceUpdateMode.Never);
            txbSDT.DataBindings.Add("Text", dtgvNhanVien.DataSource, "SDT", true, DataSourceUpdateMode.Never);
            dtpkngVL.DataBindings.Add("Value", dtgvNhanVien.DataSource, "NGVAOLAM", true, DataSourceUpdateMode.Never);
            txbMucLuong.DataBindings.Add("Text", dtgvNhanVien.DataSource, "MUCLUONG", true, DataSourceUpdateMode.Never);
            lblQuyenTemo.DataBindings.Add("Text", dtgvNhanVien.DataSource, "PHANQUYEN", true, DataSourceUpdateMode.Never);
        }
        /// <summary>
        /// Gán list nhân vên vào dtgv
        /// </summary>
        void loadNhanVien()
        {
            if (dtgvNhanVien.Rows.Count > 1)
                dtgvNhanVien.CurrentCell = dtgvNhanVien.Rows[0].Cells[0];
            NhanVienSource.DataSource = NhanVienDAO.Instance.getListNhanVien();
            dtgvNhanVien.Columns["MANV"].HeaderText = "Mã nhân viên";
            dtgvNhanVien.Columns["HOTEN"].HeaderText = "Họ tên";
            dtgvNhanVien.Columns["MATKHAU"].Visible = false;
            dtgvNhanVien.Columns["NGAYSINH"].Visible = false;
            dtgvNhanVien.Columns["DIACHI"].Visible = false;
            dtgvNhanVien.Columns["SDT"].Visible = false;
            dtgvNhanVien.Columns["NGVAOLAM"].Visible = false;
            dtgvNhanVien.Columns["MUCLUONG"].Visible = false;
            dtgvNhanVien.Columns["PHANQUYEN"].Visible = false;
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
        /// Dặt lại mật khẩu nhân viên đã chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvNhanVien.SelectedCells.Count <= 0) return;
            string MANV = (string)dtgvNhanVien.SelectedCells[0].OwningRow.Cells["MANV"].Value;
            if (MANV == null) return;
            if (!NhanVienDAO.Instance.resetPass(MANV))
            {
                fMessageBoxOK.Show("Xảy ra lỗi khi cập nhật!");
            }
        }
        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMANVtemp.Text)) return;
            if (fMessageBox.Show("Bạn muốn xóa nhân viên " + lblMANVtemp.Text + " ?") == DialogResult.Cancel) return;
            if (!NhanVienDAO.Instance.deleteNhanVien(lblMANVtemp.Text))
            {
                fMessageBoxOK.Show("Xảy ra lỗi khi xóa!");
            }
            else
            {
                fMessageBoxOK.Show("Xóa thành công!");
                NhanVienSource.DataSource = NhanVienDAO.Instance.getListNhanVien();
            }

        }
        /// <summary>
        /// Tìm kiếm nhân viên theo tên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearch_Click(object sender, EventArgs e)
        {
            string tenNV = StaticClass.xoakhoangtrang(txbSearchNV.Text);
            if (dtgvNhanVien.Rows.Count > 1)
            {
                dtgvNhanVien.CurrentCell = dtgvNhanVien.Rows[0].Cells[0];
            }
            NhanVienSource.DataSource = NhanVienDAO.Instance.getListNhanVien(tenNV);
        }
        /// <summary>
        /// không cho nhập enter và thực hiện search khi nhân enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSearchNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ptbSearch_Click(this, new EventArgs());
            }
        }
        /// <summary>
        /// chinh sua thong tin nhan vien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbedit_Click(object sender, EventArgs e)
        {
            string mANV = StaticClass.xoakhoangtrang(lblMANVtemp.Text);
            string hOTEN = StaticClass.xoakhoangtrang(txbTenNV.Text);
            DateTime nGAYSINH = dtpkNgaySinh.Value;
            string diaChi = StaticClass.xoakhoangtrang(txbDiaChi.Text);
            string sDT = StaticClass.xoakhoangtrang(txbSDT.Text);
            DateTime nGVAOLAM = dtpkngVL.Value;
            int pHANQUYEN = ((QuyenNhanVien)cbChucVu.SelectedItem).Quyen;
            float mUCLUONG = float.Parse(txbMucLuong.Text);
            if (!NhanVienDAO.Instance.updateNhanVien(mANV, hOTEN, nGAYSINH, diaChi, sDT, nGVAOLAM, pHANQUYEN, mUCLUONG))
            {
                fMessageBoxOK.Show("Xãy ra lỗi!");
            }
            else
            {
                fMessageBoxOK.Show("Thay đổi thành công!");

            }
            NhanVienSource.DataSource = NhanVienDAO.Instance.getListNhanVien();
        }
        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbadd_Click(object sender, EventArgs e)
        {

            string mANV = StaticClass.xoakhoangtrang(txbMaNV.Text);
            string hOTEN = StaticClass.xoakhoangtrang(txbTenNV.Text);
            DateTime nGAYSINH = dtpkNgaySinh.Value;
            string diaChi = StaticClass.xoakhoangtrang(txbDiaChi.Text);
            string sDT = StaticClass.xoakhoangtrang(txbSDT.Text);
            DateTime nGVAOLAM = dtpkngVL.Value;
            int pHANQUYEN = ((QuyenNhanVien)cbChucVu.SelectedItem).Quyen;
            float mUCLUONG = float.Parse(txbMucLuong.Text);
            string mATKhau = StaticClass.hasPass("1");
            if (string.IsNullOrEmpty(mANV))
            {
                fMessageBoxOK.Show("Chưa nhập mã nhân viên!");
                return;
            }
            if (NhanVienDAO.Instance.getAccountByUserName(mANV).Count > 0)
            {
                fMessageBoxOK.Show("Mã nhân viên đã tồn tại!");
                return;
            }
            if (!NhanVienDAO.Instance.insertNhanVien(mANV, hOTEN, nGAYSINH, diaChi, sDT, nGVAOLAM, pHANQUYEN, mUCLUONG, mATKhau))
            {
                fMessageBoxOK.Show("Xãy ra lỗi!");
            }
            NhanVienSource.DataSource = NhanVienDAO.Instance.getListNhanVien();
        }
        /// <summary>
        /// select quyen khi chon nhan vien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblQuyenTemo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblQuyenTemo.Text)) return;
            int quyen = Int32.Parse(lblQuyenTemo.Text);
            foreach (QuyenNhanVien item in cbChucVu.Items)
            {
                if (item.Quyen == quyen)
                {
                    cbChucVu.SelectedItem = item;
                    return;
                }
            }
        }
        /// <summary>
        /// Chi cho nhap so
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbMucLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Thực hiện chấm công những nhân viên đã chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbCheck_Click(object sender, EventArgs e)
        {
            if (dtgvNhanVien.SelectedCells.Count <= 0) return;
            bool isTonTaiNgayLam = NgayLamDAO.Instance.isTonTaiNgayLam(DateTime.Now);
            List<int> RowIndexSelect = new List<int>();
            for (int i = 0; i < dtgvNhanVien.SelectedCells.Count; i++)
            {
                foreach (int item in RowIndexSelect)
                {
                    if (dtgvNhanVien.SelectedCells[i].RowIndex == item)
                    {
                        return;
                    }
                }
                RowIndexSelect.Add(dtgvNhanVien.SelectedCells[i].RowIndex);
                string MANV = (string)dtgvNhanVien.SelectedCells[i].OwningRow.Cells["MANV"].Value;
                if (MANV == null) return;
                if (isTonTaiNgayLam)//nếu đã tồn tại ngày làm
                {
                    if (ctnlDAO.Instance.isCTNL(MANV, DateTime.Now))
                    {
                        fMessageBoxOK.Show("Nhân viên " + MANV + " đã xác nhận hôm nay!");
                        continue;
                    }
                    if (!ctnlDAO.Instance.insertCTNL(MANV, DateTime.Now))
                    {
                        fMessageBoxOK.Show("Lỗi hệ thống khi thêm ctnl!");
                        return;
                    }
                }
                else // nếu chưa tồn tại
                {
                    if (!NgayLamDAO.Instance.InsertNgayLam(DateTime.Now))
                    {
                        fMessageBoxOK.Show("Lỗi khi thêm ngày!");
                        return;
                    }
                    if (!ctnlDAO.Instance.insertCTNL(MANV, DateTime.Now))
                    {
                        fMessageBoxOK.Show("Lỗi hệ thống khi thêm ctnl!");
                        return;
                    }

                }
            }
            fMessageBoxOK.Show("Chấm công thành công!");
        }
        /// <summary>
        /// thực hiện trả lương cho nhân viên!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPay_Click(object sender, EventArgs e)
        {
            fTinhLuongNhanVien f = new fTinhLuongNhanVien();
            f.ShowDialog();
        }
        #region setColor
        private void ptbadd_MouseEnter(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Black;
        }

        private void ptbadd_MouseLeave(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Silver;
        }

        private void ptbedit_MouseEnter(object sender, EventArgs e)
        {
            lblEdit.ForeColor = Color.Black;
        }

        private void ptbedit_MouseLeave(object sender, EventArgs e)
        {
            lblEdit.ForeColor = Color.Silver;
        }

        private void ptbDelete_MouseEnter(object sender, EventArgs e)
        {
            lblDelete.ForeColor = Color.Black;
        }

        private void ptbDelete_MouseLeave(object sender, EventArgs e)
        {
            lblDelete.ForeColor = Color.Silver;
        }
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
        private void ptbCheck_MouseEnter(object sender, EventArgs e)
        {
            lblCheck.ForeColor = Color.Black;
        }

        private void ptbCheck_MouseLeave(object sender, EventArgs e)
        {
            lblCheck.ForeColor = Color.Silver;
        }

        private void lblCheck_MouseEnter(object sender, EventArgs e)
        {
            lblCheck.ForeColor = Color.Black;
        }

        private void lblCheck_MouseLeave(object sender, EventArgs e)
        {
            lblCheck.ForeColor = Color.Silver;
        }
        private void ptbPay_MouseEnter(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Black;
        }

        private void ptbPay_MouseLeave(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Silver;
        }

        private void lblPay_MouseEnter(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Black;
        }

        private void lblPay_MouseLeave(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Silver;
        }
        private void ptbPrintf_MouseEnter(object sender, EventArgs e)
        {
            lblPrintf.ForeColor = Color.Black;
        }

        private void ptbPrintf_MouseLeave(object sender, EventArgs e)
        {
            lblPrintf.ForeColor = Color.Silver;
        }

        private void lblPrintf_MouseEnter(object sender, EventArgs e)
        {
            lblPrintf.ForeColor = Color.Black;
        }

        private void lblPrintf_MouseLeave(object sender, EventArgs e)
        {
            lblPrintf.ForeColor = Color.Silver;
        }
        private void ptbSearch_MouseEnter(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.fColor;
        }

        private void ptbSearch_MouseLeave(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.pnlColorList;
        }

        #endregion

        #endregion
        
    }
}
