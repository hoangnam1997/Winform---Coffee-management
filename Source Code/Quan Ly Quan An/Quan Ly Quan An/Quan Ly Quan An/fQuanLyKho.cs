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
    public partial class fQuanLyKho : Form
    {
        public fQuanLyKho()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties
        BindingSource MonAnSource = new BindingSource();
        BindingSource ThucPhamMonAnSource = new BindingSource();
        BindingSource ThucPhamSource = new BindingSource();
        BindingSource NhaCCSource = new BindingSource();
        private List<CTMADTO> listCTMA = new List<CTMADTO>();
        private List<MonAnDTO> listMA = new List<MonAnDTO>();
        private List<ThucPhamDTO> listThucPham = new List<ThucPhamDTO>();
        #endregion

        #region method
        /// <summary>
        /// Chạy khi khởi động, load hiển thị các controls
        /// </summary>
        void loadForm()
        {
            this.BackColor =
                tpFood.BackColor = tpMaterial.BackColor = StaticClass.fColor;
            pnlMaterialMenu.BackColor = pnlMaterialList.BackColor =
            pnlListFoodMenu.BackColor = pnlFoodInfomationMenu.BackColor = pnlInfomationMaterialMenu.BackColor =
                pnlTabControl.BackColor = pnlMenu.BackColor = StaticClass.pnlColorMenu;
            pnlMaterialList.BackColor = pnlInfomationMaterial.BackColor =
            pnlListFood.BackColor = pnlInFoodfomation.BackColor = StaticClass.pnlColorList;
            lblMaterialInfomation.ForeColor = lblMaterial.ForeColor = lblFood.ForeColor = lblInfomation.ForeColor = StaticClass.colorWord;

            dtgvListFood.DataSource = MonAnSource;
            dtgvMaterial.DataSource = ThucPhamMonAnSource;
            dtgvThucPham.DataSource = ThucPhamSource;
            dtgvNCC.DataSource = NhaCCSource;
            //tải danh sách khi khởi động form.
            listMA.Clear();
            listMA = MonAnDAO.Instance.getListMonAn();
            loadListMonAn(listMA);
            //Lây danh sách loại món ăn
            loadLoaiMonAn();
            loadListThucPhamMonAn(listCTMA);
            //danh sach thuc pham
            loadListThucPham(listThucPham);
            //Tạo trạng thái cho cbTrangThai
            List<TrangThaiThucPham> listTrangThai = new List<TrangThaiThucPham>();
            listTrangThai.Add(new TrangThaiThucPham(1, "Dưới mức quy định"));
            listTrangThai.Add(new TrangThaiThucPham(0, "Trên mức quy định"));
            cbTrangThaiTP.DataSource = listTrangThai;
            //tạo binding vào khi click
            loadBingDing();
        }
        /// <summary>
        /// lấy list thực phẩm gán thông tin vào dtgv
        /// </summary>
        /// <param name="list"></param>
        void loadListThucPham(List<ThucPhamDTO> list)
        {
            ThucPhamSource.DataSource = list;
            dtgvThucPham.Columns["TENTP"].HeaderText = "Tên thực phẩm";
            dtgvThucPham.Columns["KHOILUONGTONKHO"].Visible = false;
            dtgvThucPham.Columns["GiaTP"].Visible = false;
            dtgvThucPham.Columns["MATP"].HeaderText = "Mã thực phẩm";
        }
        /// <summary>
        /// thực hiện lấy danh sách loại món ăn
        /// </summary>
        void loadLoaiMonAn()
        {
            cbCategory.DataSource = LoaiMonAnDAO.Instance.getListCategoryClassCategoryName();
            cbMaterial.DataSource = LoaiMonAnDAO.Instance.getListCategoryClassCategoryName();
        }

        /// <summary>
        /// lấy danh sách thực phẩm từ list vào dtgv
        /// </summary>
        /// <param name="list"></param>
        public void loadListThucPhamMonAn(List<CTMADTO> list)
        {
            ThucPhamMonAnSource.DataSource = list;
            dtgvMaterial.Columns["TENTP"].HeaderText = "Tên thực phẩm";
            dtgvMaterial.Columns["KhoiLuongTP"].HeaderText = "Khối lượng thực phẩm";
            dtgvMaterial.Columns["MAMA"].Visible = false;
            dtgvMaterial.Columns["MATP"].Visible = false;
        }
        /// <summary>
        /// lấy tất cả danh sách món ăn vào dtgv
        /// </summary>
        public void loadListMonAn(List<MonAnDTO> list)
        {
            MonAnSource.DataSource = list;
            dtgvListFood.Columns["MAMA"].Visible = false;
            dtgvListFood.Columns["MALOAIMA"].Visible = false;
            dtgvListFood.Columns["TENMA"].HeaderText = "Tên món ăn";
            dtgvListFood.Columns["MAMA"].HeaderText = "Mã món ăn";
            dtgvListFood.Columns["GIA"].HeaderText = "Giá";
        }
        /// <summary>
        /// thực hiện bingding khi có thay đổi
        /// </summary>
        public void loadBingDing()
        {
            //bingding món ăn
            txbMAMA.DataBindings.Add(new Binding("Text", dtgvListFood.DataSource, "MAMA", true, DataSourceUpdateMode.Never));
            lblMAMAtemp.DataBindings.Add(new Binding("Text", dtgvListFood.DataSource, "MAMA", true, DataSourceUpdateMode.Never));
            tbNameFood.DataBindings.Add(new Binding("Text", dtgvListFood.DataSource, "TENMA", true, DataSourceUpdateMode.Never));
            txbPrice.DataBindings.Add(new Binding("Text", dtgvListFood.DataSource, "GIA", true, DataSourceUpdateMode.Never));

            //bingding thuc pham
            txbMaTP.DataBindings.Add(new Binding("Text", dtgvThucPham.DataSource, "MATP", true, DataSourceUpdateMode.Never));
            lblMATPtemp.DataBindings.Add(new Binding("Text", dtgvThucPham.DataSource, "MATP", true, DataSourceUpdateMode.Never));
            txbTenThucPham.DataBindings.Add(new Binding("Text", dtgvThucPham.DataSource, "TENTP", true, DataSourceUpdateMode.Never));
            txbTonKho.DataBindings.Add(new Binding("Text", dtgvThucPham.DataSource, "KHOILUONGTONKHO", true, DataSourceUpdateMode.Never));
            txbPriceTP.DataBindings.Add(new Binding("Text", dtgvThucPham.DataSource, "GiaTP", true, DataSourceUpdateMode.Never));
        }
        /// <summary>
        /// thực hiện quay trở lại.
        /// </summary>
        void Callback()
        {
            this.Close();
        }
        #endregion
        #region Event
        /// <summary>
        /// xử lý khi chọn món ăn từ dtgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMAMAtemp_TextChanged(object sender, EventArgs e)
        {

            Label lbl = sender as Label;
            string mama = lbl.Text;
            if (string.IsNullOrEmpty(mama)) return;
            if (dtgvMaterial.Rows.Count > 1)
                dtgvMaterial.CurrentCell = dtgvMaterial.Rows[0].Cells[0];
            listCTMA.Clear();
            listCTMA = ctmaDAO.Instance.getListCTMAbyMAMA(mama);
            ThucPhamMonAnSource.DataSource = listCTMA;
            LoaiMonAnDTO loai = LoaiMonAnDAO.Instance.getLoaiMAbyMAMA(mama);
            if (loai == null) return;
            foreach (LoaiMonAn item in cbCategory.Items)
            {
                if (loai.MALOAIMA == item.MALOAIMA)
                {
                    cbCategory.SelectedItem = item;
                    return;
                }
            }
        }
        /// <summary>
        /// Tìm kiếm theo tên món ăn, tìm kiếm gần đúng.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearchFood_Click(object sender, EventArgs e)
        {
            string TenMA = StaticClass.xoakhoangtrang(txbSearchFood.Text);
            if (dtgvListFood.Rows.Count > 1)
                dtgvListFood.CurrentCell = dtgvListFood.Rows[0].Cells[0];
            listMA.Clear();
            listMA = MonAnDAO.Instance.getListMonAnbyTenMA(TenMA);
            MonAnSource.DataSource = listMA;
        }
        private void cb_KeyDown(object sender, KeyEventArgs e)
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
        /// load món ăn theo loại món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaterial.SelectedItem == null) return;

            LoaiMonAn loai = (LoaiMonAn)cbMaterial.SelectedItem;
            MonAnSource.DataSource = MonAnDAO.Instance.getListMonAnbyLoaiMonAn(loai.MALOAIMA);
        }
        /// <summary>
        /// Không cho nhập phím enter
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
        /// thay đổi số lượng TP của món ăn đang chọn// thay đổi tạm thời trên List. nếu bấm Sửa thì sẽ thay đổi. không sẽ không thay đổi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvMaterial.SelectedCells.Count <= 0) return;
            string matp = (string)dtgvMaterial.SelectedCells[0].OwningRow.Cells["MATP"].Value;
            float oldSL = (float)dtgvMaterial.SelectedCells[0].OwningRow.Cells["KhoiLuongTP"].Value;
            float newSL = fThayDoiSoLuong.show(oldSL);
            if (oldSL == newSL) return;

            foreach (CTMADTO item in listCTMA)
            {
                if (item.MATP == matp)
                {
                    if (newSL == 0)
                    {
                        List<CTMADTO> newlist = new List<CTMADTO>();
                        //foreach (var item in collection)
                        //{

                        //}
                        listCTMA.Remove(item);

                        foreach (CTMADTO items in listCTMA)
                        {
                            newlist.Add(items);
                        }
                        listCTMA.Clear();
                        listCTMA = newlist;
                        ThucPhamMonAnSource.DataSource = listCTMA;
                        break;
                    }

                    item.KhoiLuongTP = newSL;
                    break;
                }
            }

            dtgvMaterial.Refresh();

        }
        /// <summary>
        /// Xóa tạm thời tất cả thực phẩm trong list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listCTMA.Clear();
            listCTMA = new List<CTMADTO>();
            ThucPhamMonAnSource.DataSource = listCTMA;
        }
        /// <summary>
        /// Xóa tất thực phẩm đã chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvMaterial.SelectedCells.Count <= 0) return;
            List<string> listMATP = new List<string>();
            for (int i = 0; i < dtgvMaterial.SelectedCells.Count; i++)
            {
                listMATP.Add((string)dtgvMaterial.SelectedCells[i].OwningRow.Cells["MATP"].Value);
            }
            List<CTMADTO> newlist = new List<CTMADTO>();

            foreach (CTMADTO item in listCTMA)
            {
                bool isdelete = false;
                foreach (string ite in listMATP)
                {
                    if (item.MATP == ite)
                    {
                        isdelete = true;
                    }
                }
                if (!isdelete)
                {
                    newlist.Add(item);
                }

            }
            listCTMA = newlist;
            ThucPhamMonAnSource.DataSource = listCTMA;


        }
        /// <summary>
        /// thêm thực phẩm vào ctma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemThucPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThemThucPhamCTMA f = new fThemThucPhamCTMA();
            f.EventAccept += F_EventAccept;
            f.ShowDialog();
        }
        /// <summary>
        /// sự kiên khi có sẽ thêm thực phẩm vào dtgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_EventAccept(object sender, EventThemThucPham e)
        {
            if (dtgvMaterial.Rows.Count > 1)
                dtgvMaterial.CurrentCell = dtgvMaterial.Rows[0].Cells[0];
            List<CTMADTO> listnew = new List<CTMADTO>();
            foreach (CTMADTO item in listCTMA)
            {
                if (item.MATP == e.ThucPham.MATP)
                {
                    item.KhoiLuongTP = e.KhoiLuong;
                    dtgvMaterial.Refresh();
                    return;
                }
                listnew.Add(item);
            }
            listnew.Add(new CTMADTO(e.ThucPham.TENTP, e.KhoiLuong, e.ThucPham.MATP, txbMAMA.Text));

            listCTMA.Clear();
            listCTMA = listnew;
            ThucPhamMonAnSource.DataSource = listCTMA;

        }
        /// <summary>
        /// Thực hiện thêm mới món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbAddFood_Click(object sender, EventArgs e)
        {
            string mama = StaticClass.Random(10);
            string tenma = tbNameFood.Text;
            float gia = 0;
            float.TryParse(txbPrice.Text, out gia);
            string maloaima = ((LoaiMonAn)cbCategory.SelectedItem).MALOAIMA;
            if (MonAnDAO.Instance.CheckMonAn(mama))
            {
                fMessageBoxOK.Show("Mã món ăn đã tồn tại!");
                return;
            }
            if (!MonAnDAO.Instance.insertMonAn(mama, tenma, gia, maloaima))
            {
                fMessageBoxOK.Show("Xảy ra lỗi!");
                return;
            }
            foreach (CTMADTO item in listCTMA)
            {
                if (!ctmaDAO.Instance.insertCTMA(mama, item.MATP, item.KhoiLuongTP))
                {
                    fMessageBoxOK.Show("Xảy ra lỗi!");
                    return;
                }
            }
            listMA.Clear();
            listMA = MonAnDAO.Instance.getListMonAn();
            MonAnSource.DataSource = listMA;
        }
        /// <summary>
        /// Thực hiện chỉnh sửa món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbEditFood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StaticClass.xoakhoangtrang(lblMAMAtemp.Text)))
            {
                return;
            }
            if (fMessageBox.Show("Bạn muốn chỉnh sửa " + lblMAMAtemp.Text + " ?") == DialogResult.Cancel) return;
            string mama = lblMAMAtemp.Text;
            string tenma = tbNameFood.Text;
            float gia = 0;
            float.TryParse(txbPrice.Text, out gia);
            string maloaima = ((LoaiMonAn)cbCategory.SelectedItem).MALOAIMA;
            if (!MonAnDAO.Instance.updateMonAn(mama, tenma, gia, maloaima))
            {
                fMessageBoxOK.Show("Xảy ra lỗi!");
                return;
            }
            if (!ctmaDAO.Instance.deleteCTMAbyMAMA(mama))
            {
                fMessageBoxOK.Show("Xảy ra lỗi!");
                return;
            }
            foreach (CTMADTO item in listCTMA)
            {
                if (!ctmaDAO.Instance.insertCTMA(mama, item.MATP, item.KhoiLuongTP))
                {
                    fMessageBoxOK.Show("Xảy ra lỗi!");
                    return;
                }
            }

            listMA.Clear();
            listMA = MonAnDAO.Instance.getListMonAn();
            MonAnSource.DataSource = listMA;
        }
        /// <summary>
        /// Thực hiện xóa món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbDeleteFood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StaticClass.xoakhoangtrang(lblMAMAtemp.Text)))
            {
                return;
            }
            if (fMessageBox.Show("Xóa món ăn " + lblMAMAtemp.Text + " sẽ xóa tất cả những thông tin liên quan?") == DialogResult.Cancel) return;
            if (!MonAnDAO.Instance.deleteMonAn(lblMAMAtemp.Text))
            {
                fMessageBoxOK.Show("Xảy ra lỗi!");
                return;
            }
            listMA.Clear();
            listMA = MonAnDAO.Instance.getListMonAn();
            MonAnSource.DataSource = listMA;
        }
        /// <summary>
        /// chỉ cho nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbPrice_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Thực hiện lấy thông tin nhà cung cấp lên dtgv từ thực phẩm chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMATPtemp_TextChanged(object sender, EventArgs e)
        {
            string matp = StaticClass.xoakhoangtrang(lblMATPtemp.Text);
            if (string.IsNullOrEmpty(matp)) return;
            NhaCCSource.DataSource = NhaCungCapDAO.Instance.getListNhaCungCapbyMATP(matp);
            dtgvNCC.Columns["MANCC"].HeaderText = "Mã";
            dtgvNCC.Columns["SOTAIKHOAN"].HeaderText = "Số tài khoản";
            dtgvNCC.Columns["DIACHI"].HeaderText = "Địa chỉ";
        }
        /// <summary>
        /// tìm kiếm theo tên gần đúng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearchMaterial_Click(object sender, EventArgs e)
        {
            string tenTP = StaticClass.xoakhoangtrang(txbSearchMaterial.Text);
            if (dtgvListFood.Rows.Count > 1)
                dtgvListFood.CurrentCell = dtgvListFood.Rows[0].Cells[0];
            listThucPham.Clear();
            listThucPham = ThucPhamDAO.Instance.getListThucPhambtTenTP(tenTP);
            ThucPhamSource.DataSource = listThucPham;
        }
        /// <summary>
        /// không cho nhập phím enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSearchMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ptbSearchMaterial_Click(this, new EventArgs());
            }
        }
        /// <summary>
        /// load các thực phẩm theo trạng thái được chọn: 0: trên 1:dưới mức
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTrangThaiTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTrangThaiTP.SelectedItem == null) return;
            TrangThaiThucPham trangthai = (TrangThaiThucPham)cbTrangThaiTP.SelectedItem;
            if (dtgvThucPham.Rows.Count > 1)
                dtgvThucPham.CurrentCell = dtgvThucPham.Rows[0].Cells[0];
            if (trangthai.TrangThai == 0)
            {
                listThucPham.Clear();
                listThucPham = ThucPhamDAO.Instance.getListThucPhamTrenMucNhap();
                ThucPhamSource.DataSource = listThucPham;
            }
            else
            {
                listThucPham.Clear();
                listThucPham = ThucPhamDAO.Instance.getListThucPhamDuoiMucNhap();
                ThucPhamSource.DataSource = listThucPham;
            }
        }
        /// <summary>
        /// xóa thực phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMATPtemp.Text)) return;
            if (fMessageBox.Show("Xóa " + lblMATPtemp.Text + " sẽ xóa những thông tin liên quan?") == DialogResult.Cancel) return;
            if (!ThucPhamDAO.Instance.deleteThucPham(lblMATPtemp.Text))
            {
                fMessageBoxOK.Show("Xảy ra lỗi khi xóa!");
            }
            if (dtgvThucPham.Rows.Count > 1)
                dtgvThucPham.CurrentCell = dtgvThucPham.Rows[0].Cells[0];
            listThucPham = ThucPhamDAO.Instance.getListThucPham();
            ThucPhamSource.DataSource = listThucPham;
        }
        /// <summary>
        /// Thêm thực phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbAddMaterial_Click(object sender, EventArgs e)
        {
            string MATP = StaticClass.Random(10);
            string TenTP = StaticClass.xoakhoangtrang(txbTenThucPham.Text);
            float KhoiLuong = 0;
            float.TryParse(StaticClass.xoakhoangtrang(txbTonKho.Text), out KhoiLuong);
            float Gia = 0;
            float.TryParse(StaticClass.xoakhoangtrang(txbPriceTP.Text), out Gia);
            if (string.IsNullOrEmpty(MATP) || string.IsNullOrEmpty(TenTP))
            {
                fMessageBoxOK.Show("Bạn cần nhập đủ thông tin!");
                return;
            }
            if(ThucPhamDAO.Instance.checkMATP(MATP))
            {
                fMessageBoxOK.Show("Đẫ tồn tại mã thực phẩm");
                return;
            }
            if (!ThucPhamDAO.Instance.insertThucPham(MATP, TenTP, Gia, KhoiLuong))
            {
                fMessageBoxOK.Show("Có lỗi xảy ra khi thêm!");
            }
            if (dtgvThucPham.Rows.Count > 1)
                dtgvThucPham.CurrentCell = dtgvThucPham.Rows[0].Cells[0];
            listThucPham = ThucPhamDAO.Instance.getListThucPham();
            ThucPhamSource.DataSource = listThucPham;
        }

        /// <summary>
        /// Cập nhật thông tin thực phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbEditMaterial_Click(object sender, EventArgs e)
        {
            if (fMessageBox.Show("Sửa " + txbMaTP.Text + " ?") == DialogResult.Cancel) return;
            string MATP = StaticClass.xoakhoangtrang(lblMATPtemp.Text);
            string TenTP = StaticClass.xoakhoangtrang(txbTenThucPham.Text);
            float KhoiLuong = 0;
            float.TryParse(StaticClass.xoakhoangtrang(txbTonKho.Text), out KhoiLuong);
            float Gia = 0;
            float.TryParse(StaticClass.xoakhoangtrang(txbPriceTP.Text), out Gia);
            if (string.IsNullOrEmpty(MATP))
            {
                return;
            }

            if (!ThucPhamDAO.Instance.updateThucPham(MATP, TenTP, Gia, KhoiLuong))
            {
                fMessageBoxOK.Show("Có lỗi xảy ra khi thêm!");
            }
            if (dtgvThucPham.Rows.Count > 1)
                dtgvThucPham.CurrentCell = dtgvThucPham.Rows[0].Cells[0];
            listThucPham = ThucPhamDAO.Instance.getListThucPham();
            ThucPhamSource.DataSource = listThucPham;
        }
        /// <summary>
        /// xóa nhà cung cấp ra khỏi list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvNCC.SelectedCells.Count <= 0) return;
            List<int> rowIndex = new List<int>();
            for (int i = 0; i < dtgvNCC.SelectedCells.Count; i++)
            {
                bool isTrung = false;
                foreach (int item in rowIndex)
                {
                    if (item == dtgvNCC.SelectedCells[i].RowIndex)
                    {
                        lblMATPtemp_TextChanged(this, new EventArgs());
                        isTrung = true;
                        break;
                    }
                }
                if (!isTrung)
                {
                    rowIndex.Add(dtgvNCC.SelectedCells[i].RowIndex);

                    string MATP = txbMaTP.Text;
                    string MANCC = (string)dtgvNCC.SelectedCells[i].OwningRow.Cells["MANCC"].Value;
                    if (!CTTPdao.Instance.deleteCTTP(MATP, MANCC))
                        fMessageBoxOK.Show("Xảy ra lỗi!");
                }
            }
            lblMATPtemp_TextChanged(this, new EventArgs());
        }
        #region setColor
        private void ptbBack_Click(object sender, EventArgs e)
        {
            Callback();
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
            ptbSearchFood.BackColor = StaticClass.fColor;
        }

        private void ptbSearchFood_MouseLeave(object sender, EventArgs e)
        {
            ptbSearchFood.BackColor = StaticClass.pnlColorList;
        }
        private void ptbSearchMaterial_MouseEnter(object sender, EventArgs e)
        {
            ptbSearchMaterial.BackColor = StaticClass.fColor;
        }

        private void ptbSearchMaterial_MouseLeave(object sender, EventArgs e)
        {
            ptbSearchMaterial.BackColor = StaticClass.pnlColorList;
        }

        private void ptbAddFood_MouseEnter(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Black;
        }

        private void lblAddFood_MouseEnter(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Black;
        }

        private void ptbAddFood_MouseLeave(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Silver;
        }

        private void lblAddFood_MouseLeave(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Silver;
        }
        private void ptbEditFood_MouseEnter(object sender, EventArgs e)
        {
            lblEditFood.ForeColor = Color.Black;
        }

        private void lblEditFood_MouseEnter(object sender, EventArgs e)
        {
            lblEditFood.ForeColor = Color.Black;
        }

        private void ptbEditFood_MouseLeave(object sender, EventArgs e)
        {
            lblEditFood.ForeColor = Color.Silver;
        }

        private void lblEditFood_MouseLeave(object sender, EventArgs e)
        {
            lblEditFood.ForeColor = Color.Silver;
        }
        private void ptbDeleteFood_MouseEnter(object sender, EventArgs e)
        {
            lblDeleteFood.ForeColor = Color.Black;
        }

        private void ptbDeleteFood_MouseLeave(object sender, EventArgs e)
        {
            lblDeleteFood.ForeColor = Color.Silver;
        }

        private void lblDeleteFood_MouseEnter(object sender, EventArgs e)
        {
            lblDeleteFood.ForeColor = Color.Black;
        }

        private void lblDeleteFood_MouseLeave(object sender, EventArgs e)
        {
            lblDeleteFood.ForeColor = Color.Silver;
        }
        private void ptbAddMaterial_MouseEnter(object sender, EventArgs e)
        {
            lblAddMaterial.ForeColor = Color.Black;
        }

        private void lblAddMaterial_MouseEnter(object sender, EventArgs e)
        {
            lblAddMaterial.ForeColor = Color.Black;
        }

        private void ptbAddMaterial_MouseLeave(object sender, EventArgs e)
        {
            lblAddMaterial.ForeColor = Color.Silver;
        }

        private void lblAddMaterial_MouseLeave(object sender, EventArgs e)
        {
            lblAddMaterial.ForeColor = Color.Silver;
        }
        private void ptbEditMaterial_MouseEnter(object sender, EventArgs e)
        {
            lblEditMaterial.ForeColor = Color.Black;
        }

        private void ptbEditMaterial_MouseLeave(object sender, EventArgs e)
        {
            lblEditMaterial.ForeColor = Color.Silver;
        }

        private void lblEditMaterial_MouseEnter(object sender, EventArgs e)
        {
            lblEditMaterial.ForeColor = Color.Black;
        }

        private void lblEditMaterial_MouseLeave(object sender, EventArgs e)
        {
            lblEditMaterial.ForeColor = Color.Silver;
        }

        private void ptbDeleteMaterial_MouseEnter(object sender, EventArgs e)
        {
            lblDeleteMaterial.ForeColor = Color.Black;
        }

        private void ptbDeleteMaterial_MouseLeave(object sender, EventArgs e)
        {
            lblDeleteMaterial.ForeColor = Color.Silver;
        }

        private void lblDeleteMaterial_MouseEnter(object sender, EventArgs e)
        {
            lblDeleteMaterial.ForeColor = Color.Black;
        }

        private void lblDeleteMaterial_MouseLeave(object sender, EventArgs e)
        {
            lblDeleteMaterial.ForeColor = Color.Silver;
        }




        #endregion

        #endregion
        /// <summary>
        /// thực hiên form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemNHAccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThemNhaCungCap_CTTP f = new fThemNhaCungCap_CTTP();
            f.Event += F_Event;
            f.ShowDialog();
            lblMATPtemp_TextChanged(this, new EventArgs());
        }
        /// <summary>
        /// thực hiện thêm ncc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_Event(object sender, themNCC e)
        {
            if(!CTTPdao.Instance.insertCTTP(txbMaTP.Text,e.NhaCC.MANCC))
            {
                fMessageBoxOK.Show("Vui lòng thực hiện lại!");
            }
        }
    }
}
