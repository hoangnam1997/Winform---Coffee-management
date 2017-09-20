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
    public partial class fNhapThucPham : Form
    {
        public fNhapThucPham()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties
        BindingSource ThucPhamSource = new BindingSource();
        BindingSource HoaDonNhapSource = new BindingSource();
        List<CTHDNdto> listCTHDN = new List<CTHDNdto>();
        #endregion

        #region Method
        /// <summary>
        /// trở lại
        /// </summary>
        void callBack()
        {
            this.Close();
        }
        /// <summary>
        /// thựch hiện load các controls. hiển thị thông tin các controls
        /// </summary>
        void loadForm()
        {
            tpCheck.BackColor = tpImport.BackColor = this.BackColor = StaticClass.fColor;
            pnlCheckMenu.BackColor = pnlTabControl.BackColor = pnlImportMenu.BackColor = pnlMenu.BackColor = StaticClass.pnlColorMenu;
            pnlListImport.BackColor = pnlInfomation.BackColor = pnlImportBody.BackColor = StaticClass.pnlColorList;
            lblAcceptmenu.ForeColor = lblImport.ForeColor = StaticClass.colorWord;
            ckbIsBelow.Checked = true;
            //gan source cho cb
            cbNameMaterial.DataSource = ThucPhamSource;
            loadNhaCungCap();
            dtgvCTHDN.DataSource = listCTHDN;
            dtgvCTHDN.Columns["MAHDN"].Visible = false;
            dtgvCTHDN.Columns["MATP"].HeaderText = "Mã thực phẩm";
            dtgvCTHDN.Columns["SoLuongThucPham"].HeaderText = "Số lượng nhập";
            dtgvCTHDN.Columns["ThanhTien"].HeaderText = "Thành tiền";
            loadTongTien();

            dtgvListHoaDonNhap.DataSource = HoaDonNhapSource;
            HoaDonNhapSource.DataSource = HoaDonNhapDAO.Instance.getListHoaDonNhapChuaNhapbyMAHD("");
            dtgvListHoaDonNhap.Columns["TRANGTHAI"].Visible = false;
            dtgvListHoaDonNhap.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvListHoaDonNhap.Columns["MAHDN"].HeaderText = "Mã hóa đơn nhập";
            dtgvListHoaDonNhap.Columns["NGAYLAP"].HeaderText = "Ngày lập";
            dtgvListHoaDonNhap.Columns["TONGTIEN"].HeaderText = "Tổng tiền";
            loadBinDing();
        }
        /// <summary>
        /// thuc hien khi chon item moi
        /// </summary>
        void loadBinDing()
        {
            lblTemp.DataBindings.Add(new Binding("Text", dtgvListHoaDonNhap.DataSource, "MAHDN", true, DataSourceUpdateMode.Never));
        }
        /// <summary>
        /// lay danh sach nha cung cap
        /// </summary>
        void loadNhaCungCap()
        {
            cbSuplier.DataSource = NhaCungCapDAO.Instance.getListNhaCungCap();
        }
        #endregion
        #region Event
        /// <summary>
        /// Thay đổi nhà cung cấp thực phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSuplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            XoaTatCaToolStripMenuItem_Click(this, new EventArgs());
            NhaCungCapDTO nhacc = (NhaCungCapDTO)cbSuplier.SelectedItem;
            if (nhacc == null) return;
            
            if (ckbIsBelow.Checked == true)
            {
                ThucPhamSource.DataSource = ThucPhamDAO.Instance.getListThucPhamDuoiMucNhap(nhacc.MANCC);
            }
            else
            {
                ThucPhamSource.DataSource = ThucPhamDAO.Instance.getListThucPham(nhacc.MANCC);
            }
            if (cbNameMaterial.SelectedItem == null)
            {
                txbGia.Text = "0";
                return;
            }
            ThucPhamDTO tp = (ThucPhamDTO)cbNameMaterial.SelectedItem;
            txbGia.Text = tp.GiaTP.ToString();
        }
        /// <summary>
        /// Xóa hóa đơn đang chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblTemp.Text)) return;
            if (HoaDonNhapDAO.Instance.deleteHoaDonNhap(lblTemp.Text))
            {
                fMessageBoxOK.Show("Xóa thành công!");
                HoaDonNhapSource.DataSource = HoaDonNhapDAO.Instance.getListHoaDonNhapChuaNhapbyMAHD("");
            }
            else
            {
                fMessageBoxOK.Show("Xảy ra lỗi!");
                return;
            }
        }
        /// <summary>
        /// Xac nhan da nhap thuc pham
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblTemp.Text)) return;
            if (HoaDonNhapDAO.Instance.updateHoaDonNhap(lblTemp.Text))
            {
                fMessageBoxOK.Show("Cập nhật thành công!");
                HoaDonNhapSource.DataSource = HoaDonNhapDAO.Instance.getListHoaDonNhapChuaNhapbyMAHD("");

            }
            else
            {
                fMessageBoxOK.Show("Xảy ra lỗi!");
                return;
            }

        }
        /// <summary>
        /// Lay danh sach theo ten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearch_Click(object sender, EventArgs e)
        {
            string mahd = StaticClass.xoakhoangtrang(txbSearch.Text);
            HoaDonNhapSource.DataSource = HoaDonNhapDAO.Instance.getListHoaDonNhapChuaNhapbyMAHD(mahd);
        }
        /// <summary>
        /// Hien thi thong tin hoa don nhap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTemp_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblTemp.Text))
            {
                dtgvThongtin.DataSource = CTHDNdao.Instance.getListCTHDNbyMAHD("");
                return;

            }

            dtgvThongtin.DataSource = CTHDNdao.Instance.getListCTHDNbyMAHD(lblTemp.Text);
            dtgvThongtin.Columns["MAHDN"].Visible = false;
            dtgvThongtin.Columns["MATP"].HeaderText = "Thực phẩm";
            dtgvThongtin.Columns["SoLuongThucPham"].HeaderText = "Số lượng nhập";
            dtgvThongtin.Columns["THANHTIEN"].HeaderText = "Thành tiền";
        }
        /// <summary>
        /// Xóa tất cả tp đã chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XoaTatCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listCTHDN.Clear();
            listCTHDN = new List<CTHDNdto>();
            dtgvCTHDN.DataSource = listCTHDN;
            loadTongTien();
        }
        /// <summary>
        /// Lấy giá thực phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbNameMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNameMaterial.SelectedItem == null)
            {
                if (cbNameMaterial.SelectedItem == null)
                {
                    txbGia.Text = "0";
                    return;
                }
                return;
            }
            ThucPhamDTO tp = (ThucPhamDTO)cbNameMaterial.SelectedItem;
            txbGia.Text = tp.GiaTP.ToString();
        }
        /// <summary>
        /// Them vao cthdn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbAdd_Click(object sender, EventArgs e)
        {
            if (cbNameMaterial.SelectedItem == null)
            {
                fMessageBoxOK.Show("Chưa chọn thực phẩm!");
                return;
            }
            if (cbSuplier.SelectedItem == null)
            {
                fMessageBoxOK.Show("Chưa chọn nhà cung cấp!");
                return;
            }
            ThucPhamDTO tp = ((ThucPhamDTO)cbNameMaterial.SelectedItem);
            float SoLuong = 0;
            float.TryParse(txbSoLuong.Text, out SoLuong);
            if (SoLuong == 0)
            {
                fMessageBoxOK.Show("Vui lòng nhập số lượng!");
                return;
            }
            double ThanhTien = SoLuong * tp.GiaTP;
            List<CTHDNdto> listnew = new List<CTHDNdto>();
            bool isTrung = false;
            foreach (CTHDNdto item in listCTHDN)
            {
                if (tp.MATP == item.MATP)
                {
                    item.SoLuongThucPham += SoLuong;
                    item.ThanhTien = item.SoLuongThucPham * tp.GiaTP;
                    isTrung = true;
                }
                listnew.Add(item);
            }
            if (!isTrung)
            {
                listnew.Add(new CTHDNdto(null, tp.MATP, SoLuong, ThanhTien));
            }
            listCTHDN.Clear();
            listCTHDN = listnew;
            dtgvCTHDN.DataSource = listCTHDN;
            loadTongTien();

        }
        /// <summary>
        /// load tông tiền vào controls
        /// </summary>
        void loadTongTien()
        {
            double tongtien = 0;
            foreach (CTHDNdto item in listCTHDN)
            {
                tongtien += item.ThanhTien;
            }
            txbTongTien.Text = tongtien.ToString();
        }
        /// <summary>
        /// Xoa tat ca danh sách đã chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XoaDaChonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvCTHDN.SelectedCells.Count <= 0) return;
            List<CTHDNdto> listnew = new List<CTHDNdto>();
            List<int> rowIndex = new List<int>();
            for (int i = 0; i < dtgvCTHDN.SelectedCells.Count; i++)
            {
                bool isTrung = false;

                foreach (int items in rowIndex)
                {
                    if (dtgvCTHDN.SelectedCells[i].RowIndex == items)
                    {
                        isTrung = true;
                        break;
                    }
                }
                if (!isTrung)
                {
                    rowIndex.Add(dtgvCTHDN.SelectedCells[i].RowIndex);
                    listCTHDN.RemoveAt(dtgvCTHDN.SelectedCells[i].RowIndex);
                }
            }
            foreach (CTHDNdto item in listCTHDN)
            {
                listnew.Add(item);
            }
            listCTHDN.Clear();
            listCTHDN = listnew;
            dtgvCTHDN.DataSource = listCTHDN;
            loadTongTien();
        }
        private void cbNameMaterial_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                ComboBox cb = sender as ComboBox;
                foreach (var item in cb.Items)
                {
                    // so sánh các gần đúng.
                    if (StaticClass.ConvertToUnsign(item.ToString().ToUpper()).IndexOf(StaticClass.ConvertToUnsign(cb.Text.ToUpper())) >= 0)
                    {
                        cb.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Thay đổi chỉ load những thực phẩm dưới mức quy định
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbIsBelow_CheckedChanged(object sender, EventArgs e)
        {

            NhaCungCapDTO nhacc=(NhaCungCapDTO)cbSuplier.SelectedItem;
            if (nhacc == null) return;
            if (ckbIsBelow.Checked == true)
            {
                ThucPhamSource.DataSource = ThucPhamDAO.Instance.getListThucPhamDuoiMucNhap(nhacc.MANCC);
            }
            else
            {
                ThucPhamSource.DataSource = ThucPhamDAO.Instance.getListThucPham(nhacc.MANCC);
            }
            if (cbNameMaterial.SelectedItem == null)
            {
                txbGia.Text = "0";
                return;
            }
            ThucPhamDTO tp = (ThucPhamDTO)cbNameMaterial.SelectedItem;
            txbGia.Text = tp.GiaTP.ToString();
        }
        /// <summary>
        /// khong cho nhap enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// chỉ cho phép nhập số thực
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// chỉ cho phép nhập số thực
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Thuc hiện tạo hóa đơn nhập và in hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPrint_Click(object sender, EventArgs e)
        {
            if (listCTHDN.Count <= 0) return;
            if (fMessageBox.Show("Tạo hóa đơn nhập thực phẩm?") == DialogResult.Cancel) return;
            NhaCungCapDTO nhacc = ((NhaCungCapDTO)cbSuplier.SelectedItem);
            string MAHD = StaticClass.Random(10);
            if (!HoaDonNhapDAO.Instance.insertHoaDonNhap(MAHD, DateTime.Now, 0, 0))
            {
                fMessageBoxOK.Show("Vui long thuc hien lai!");
                return;
            }
            foreach (CTHDNdto item in listCTHDN)
            {
                CTHDNdao.Instance.insertCTHDN(MAHD, item.MATP, item.SoLuongThucPham);
                CTTPdao.Instance.insertCTTP(item.MATP, nhacc.MANCC);
            }
            fReport f = new fReport(MAHD, nhacc.MANCC);
            f.ShowDialog();
            listCTHDN.Clear();
            listCTHDN = new List<CTHDNdto>();
            dtgvCTHDN.DataSource = listCTHDN;
            ptbSearch_Click(this, new EventArgs());
        }
        #region setcolor
        private void ptbDelete_MouseEnter(object sender, EventArgs e)
        {
            lblXoa.ForeColor = Color.Black;
        }
        private void ptbDelete_MouseLeave(object sender, EventArgs e)
        {
            lblXoa.ForeColor = Color.Silver;
        }
        private void ptbSearch_MouseEnter(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.fColor;

        }

        private void ptbSearch_MouseLeave(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.pnlColorList;
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
        private void ptbAccept_MouseEnter(object sender, EventArgs e)
        {
            lblAccept.ForeColor = Color.Black;
        }

        private void ptbAccept_MouseLeave(object sender, EventArgs e)
        {
            lblAccept.ForeColor = Color.Silver;
        }

        private void lblAccept_MouseEnter(object sender, EventArgs e)
        {
            lblAccept.ForeColor = Color.Black;
        }

        private void lblAccept_MouseLeave(object sender, EventArgs e)
        {
            lblAccept.ForeColor = Color.Silver;
        }
        private void ptbAdd_MouseEnter(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Black;
        }

        private void ptbAdd_MouseLeave(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Silver;
        }

        private void lblAdd_MouseEnter(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Black;
        }

        private void lblAdd_MouseLeave(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Silver;
        }

        private void ptbPrint_MouseEnter(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Black;
        }

        private void ptbPrint_MouseLeave(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Silver;
        }

        private void lblPrint_MouseEnter(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Black;
        }

        private void lblPrint_MouseLeave(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Silver;
        }



        #endregion

        #endregion
        
    }
}
