using Quan_Ly_Quan_An.Cons;
using Quan_Ly_Quan_An.DAO;
using Quan_Ly_Quan_An.DTO;
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
    public partial class fDatBanTruoc : Form
    {
        public fDatBanTruoc(NhanVienDTO ac)
        {
            InitializeComponent();
            this.ac = ac;
            ThamSo = QuanAnDAO.Instance.getListQuanAn();
            LoadForm();
        }
        #region Properties
        private QuanAnDTO ThamSo;
        private float TotalPrice = 0;
        private float PrePrice = 0;
        private NhanVienDTO ac;
        private List<ThongTinHoaDonDTO> listHOADON = new List<ThongTinHoaDonDTO>();
        private List<KhachHangHoaDonDTO> listKhachHang = new List<KhachHangHoaDonDTO>();
        #endregion
        #region method
        /// <summary>
        /// hiển thị tổng tiền và tiền cần trả
        /// </summary>
        /// <param name="total"></param>
        /// <param name="TraTruoc"></param>
        void loadLblMoney(float total, float TraTruoc)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            lblNumberPrice.Text = total.ToString("c", culture);
            lblTienCanTra.Text = TraTruoc.ToString("c", culture);
        }
        /// <summary>
        /// Load dử liệu vào hóa đơn, dử liệu từ list
        /// </summary>
        /// <param name="list"></param>
        void loadDtgvHOADON(List<ThongTinHoaDonDTO> list)
        {
            dtgvBills.DataSource = null;
            dtgvBills.DataSource = list;
            dtgvBills.Columns[1].HeaderText = "Tên món ăn";
            dtgvBills.Columns[2].HeaderText = "Giá";
            dtgvBills.Columns[3].HeaderText = "Số lượng";
            dtgvBills.Columns[4].HeaderText = "Thành tiền";
            dtgvBills.Columns[5].Visible = false;
            dtgvBills.Columns["MABA"].Visible = false;
            dtgvBills.Columns[7].Visible = false;
        }
        /// <summary>
        /// Reset các control lại từ đầu
        /// </summary>
        void clear()
        {
            txbSDT.Text = "";
            listHOADON.Clear();
            loadDtgvBills("", "");
            listKhachHang.Clear();
            cbTenKhachHang.DataSource = null;
            dtpkThoiGianDen.Value = DateTime.Now;
        }
        /// <summary>
        /// hàm khởi tạo khi bvừa mới load form
        /// </summary>
        void LoadForm()
        {
            lblHD.ForeColor = lblListTable.ForeColor = lblTD.ForeColor = StaticClass.colorWord;
            ptbBack.BackColor = pnlMenu.BackColor = pnlDS.BackColor = pnlHD.BackColor = pnlTD.BackColor = StaticClass.pnlColorMenu;
            this.BackColor = StaticClass.fColor;
            pnlBill.BackColor = pnlFood.BackColor = fpnlListTable.BackColor = StaticClass.pnlColorList;

            LoadTable();
            loadFoodtodtgv(dtgvFood);
            LoadCategoryTocb(cbCategory);
            loadListBillByMaba("");


        }
        /// <summary>
        /// load danh sách hóa đơn đặt trước theo mã khách hàng
        /// </summary>
        /// <param name="Maba"></param>
        void loadListBillByMaba(string Maba)
        {
            List<string> listMAHD = HoaDonDAO.Instance.GETHOADONPreByMABA(Maba);
            foreach (string item in listMAHD)
            {
                listKhachHang.Add(KhachHangDAO.Instance.getKhachHangHoaDonByMAHD(item));
            }
            if (listKhachHang.Count > 0)
            {
                cbTenKhachHang.DataSource = listKhachHang;
                cbTenKhachHang.SelectedIndex = 0;
            }
            else
            {
                clear();
            }
        }
        /// <summary>
        /// Tải danh sách bàn, trạng thái
        /// </summary>
        void LoadTable()
        {
            List<BanAn> listTable = BanAnDAO.Instance.getListTable();

            fpnlListTable.Controls.Clear();
            foreach (BanAn item in listTable)
            {
                FlowLayoutPanel pnl = new FlowLayoutPanel();
                pnl.Margin = new Padding(0, 0, 0, 0);
                pnl.Width = 65;
                pnl.Height = 85;


                Label lbl = new Label();
                lbl.Text = item.MABA;
                lbl.Font = new Font("Microsoft Sans Serif", 13);
                lbl.ForeColor = Color.Silver;
                lbl.Tag = item;

                Button btn = new Button();
                btn.Width = 65;
                btn.Height = 65;
                btn.Margin = new Padding(0, 0, 0, 0);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = Properties.Resources.tableFood;
                btn.Tag = lbl;
                btn.MouseEnter += Btn_MouseEnter;
                btn.MouseLeave += Btn_MouseLeave;
                btn.Click += Btn_Click;
                switch (item.TRANGTHAI)
                {
                    case -1:
                        btn.BackColor = StaticClass.colorNonTable;
                        break;
                    case 1:
                        btn.BackColor = StaticClass.colorFullTable;
                        break;
                    case 2:
                        btn.BackColor = StaticClass.colorPreTable;
                        break;
                    default:
                        btn.BackColor = StaticClass.colorfreeTable;
                        break;
                }
                pnl.Controls.Add(lbl);
                pnl.Controls.Add(btn);
                fpnlListTable.Controls.Add(pnl);

            }
        }
        /// <summary>
        /// Trở lại, đóng form hiện tại
        /// </summary>
        void CallBack()
        {
            this.Close();
        }
        /// <summary>
        /// load dử liệu vào hóa đơn. thông tin hóa đơn
        /// </summary>
        /// <param name="list"></param>
        void loadDtgvBills(string MAKH, string MAHD)
        {
            listHOADON = cthdDAO.Instance.getListItemPreByMAKHandMAHD(MAKH, MAHD);
            TotalPrice = 0;
            dtgvBills.DataSource = null;
            dtgvBills.DataSource = listHOADON;
            dtgvBills.Columns[1].HeaderText = "Tên món ăn";
            dtgvBills.Columns[2].HeaderText = "Giá";
            dtgvBills.Columns[3].HeaderText = "Số lượng";
            dtgvBills.Columns[4].HeaderText = "Thành tiền";
            dtgvBills.Columns[5].Visible = false;
            dtgvBills.Columns["MABA"].Visible = false;
            dtgvBills.Columns[7].Visible = false;
            dtgvBills.Columns["MAHD"].Visible = false;

            foreach (ThongTinHoaDonDTO item in listHOADON)
            {
                TotalPrice += item.GIA * item.SoLuongMA;
            }
            PrePrice = 0;
            HoaDonDTO hoaDon = HoaDonDAO.Instance.getHoaDonbyMaHD(MAHD);
            if (hoaDon != null)
            {
                PrePrice = (TotalPrice * ThamSo.PrePersen / 100) - hoaDon.TIENDATHANHTOAN;
            }
            loadLblMoney(TotalPrice, PrePrice);
        }
        /// <summary>
        /// load food, load danh sách thức ăn
        /// </summary>
        /// <param name="dtgv"></param>
        void loadFoodtodtgv(DataGridView dtgv)
        {
            List<MonANvaSLmaDTO> list = MonAnDAO.Instance.getListFood();
            dtgv.DataSource = list;
            dtgv.Columns["MAMA"].Visible = false;
            dtgv.Columns["MALOAIMA"].Visible = false;
            dtgv.Columns["TENMA"].HeaderText = "Tên món ăn";
            dtgv.Columns["GIA"].HeaderText = "Giá";
        }
        /// <summary>
        /// Lấy danh sách loại món ăn vào cb
        /// </summary>
        /// <param name="cb"></param>
        void LoadCategoryTocb(ComboBox cb)
        {
            cb.Items.Clear();
            List<LoaiMonAn> cate = LoaiMonAnDAO.Instance.getListCategoryClassCategoryName();
            foreach (LoaiMonAn item in cate)
            {
                cb.Items.Add(item);
            }
        }
        #endregion
        #region Event'
        /// <summary>
        /// Tính tiền hóa đơn trả trước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPay_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            KhachHangHoaDonDTO kh = (KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem;
            if (fMessageBox.Show("Bạn muốn tính tiền cho khách hàng " + kh.TENKH + " ?") == DialogResult.Cancel) return;
            if (fMessageBox.Show("Bạn muốn in hóa đơn không ?") == DialogResult.OK) ptbPrint_Click(ptbPrint, e);
            if (!HoaDonDAO.Instance.checkOutHoaDonPre(kh.MAHD))
                fMessageBoxOK.Show("Xảy ra lỗi!");
            loadDtgvBills(kh.MAKH, kh.MAHD);
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
        /// Xóa tất cả hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            string MAHD = ((KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem).MAHD;
            foreach (DataGridViewRow item in dtgvBills.Rows)
            {
                string mama = (string)item.Cells["MAMA"].Value;
                cthdDAO.Instance.deleteCTHDbyMAHDandMAMA(MAHD, mama);
            }
            cbTenKhachHang_SelectedIndexChanged(cbTenKhachHang, e);
            loadFoodtodtgv(dtgvFood);
        }
        /// <summary>
        /// Chỉnh sửa số lượng món ăn pre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            if (dtgvBills.SelectedCells.Count <= 0) return;
            int SlOld = (int)dtgvBills.SelectedCells[0].OwningRow.Cells["SoLuongMA"].Value;
            int SlNew = (int)fThayDoiSoLuong.show(SlOld);
            if (SlOld == SlNew) return;
            string MAMA = (string)dtgvBills.SelectedCells[0].OwningRow.Cells["MAMA"].Value;
            string MAHD = ((KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem).MAHD;
            cthdDAO.Instance.updateCTHDbyMAHDandMAMA(MAHD, MAMA, SlNew);
            cbTenKhachHang_SelectedIndexChanged(cbTenKhachHang, e);
            loadFoodtodtgv(dtgvFood);
        }
        /// <summary>
        /// Xóa các món ăn đã chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteFoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            if (dtgvBills.SelectedCells.Count <= 0) return;
            string MAHD = ((KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem).MAHD;
            for (int i = 0; i < dtgvBills.SelectedCells.Count; i++)
            {
                string mama = (string)dtgvBills.SelectedCells[i].OwningRow.Cells["MAMA"].Value;
                cthdDAO.Instance.deleteCTHDbyMAHDandMAMA(MAHD, mama);
            }
            cbTenKhachHang_SelectedIndexChanged(cbTenKhachHang, e);
            loadFoodtodtgv(dtgvFood);
        }
        /// <summary>
        /// Lấy tất cả hóa đơn 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            clear();
            dtgvBills.Tag = (sender as Button);
            BanAn tableClick = (BanAn)((Label)(sender as Button).Tag).Tag;
            dtgvBills.Tag = tableClick;
            loadListBillByMaba(tableClick.MABA);

        }
        /// <summary>
        /// tìm kím thức ăn theo tên gần đúng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearch_Click(object sender, EventArgs e)
        {
            string namefood = StaticClass.xoakhoangtrang(txbSearch.Text);
            if (string.IsNullOrEmpty(namefood))
            {
                loadFoodtodtgv(dtgvFood);
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    List<MonANvaSLmaDTO> list = MonAnDAO.Instance.getListFoodByName(namefood);
                    dtgvFood.DataSource = list;
                    dtgvFood.Columns["MAMA"].Visible = false;
                    dtgvFood.Columns["MALOAIMA"].Visible = false;
                    dtgvFood.Columns["TENMA"].HeaderText = "Tên món ăn";
                    dtgvFood.Columns["GIA"].HeaderText = "Giá";
                }));
            }
        }
        /// <summary>
        /// Quay trở lại form trước..thoát form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbBack_Click(object sender, EventArgs e)
        {
            CallBack();
        }
        /// <summary>
        /// tìm kiếm món ăn theo loại món ăn. khi cb selected index thay đổi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem == null) return;
            List<MonANvaSLmaDTO> list = MonAnDAO.Instance.getListFoodByMALOAIMA(((LoaiMonAn)cbCategory.SelectedItem).MALOAIMA);
            dtgvFood.DataSource = list;
            dtgvFood.Columns["MAMA"].Visible = false;
            dtgvFood.Columns["MALOAIMA"].Visible = false;
            dtgvFood.Columns["TENMA"].HeaderText = "Tên món ăn";
            dtgvFood.Columns["GIA"].HeaderText = "Giá";
        }
        /// <summary>
        /// không cho nhập enter và thêm vào chạy luôn tìm kiếm món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ptbSearch_Click(ptbSearch, e);
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// nhập enter sẽ qua addfood
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ptbAddFood_Click(ptbAddFood, new EventArgs());
            }
        }
        /// <summary>
        /// thêm món ăn vào hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAddFood_Click(object sender, EventArgs e)
        {
            ptbAddFood_Click(ptbAddFood, e);
        }
        /// <summary>
        /// thêm thực món ăn vào hóa đơn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ptbAddFood_Click(object sender, EventArgs e)
        {
            if (dtgvBills.Tag == null) { fMessageBoxOK.Show("Vui vòng chọn bàn ăn!"); return; }
            BanAn table = ((BanAn)dtgvBills.Tag);
            if (cbTenKhachHang.SelectedItem == null)
            {
                fMessageBoxOK.Show("Bạn chưa chọn hóa đơn đặt trước nào!");
                return;
            }
            KhachHangHoaDonDTO kh = (KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem;
            string MAHD = kh.MAHD;
            if (dtgvFood.SelectedCells.Count <= 0)
            {
                fMessageBoxOK.Show("Vui lòng chọn món ăn!");
                return;
            }
            string mama = (string)dtgvFood.SelectedCells[0].OwningRow.Cells["MAMA"].Value;
            int soluong = 0;
            Int32.TryParse(txbCount.Text, out soluong);
            if (soluong == 0)
            {
                fMessageBoxOK.Show("Vui lòng nhập số lượng muốn thêm!");
                return;
            }
            cthdDAO.Instance.insertCTHD(MAHD, mama, soluong, -1);
            cbTenKhachHang_SelectedIndexChanged(cbTenKhachHang, e);
            loadFoodtodtgv(dtgvFood);
        }



        /// <summary>
        /// Lấy danh sách itemhoadon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTenKhachHang.SelectedItem == null) return;
            KhachHangHoaDonDTO kh = (KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem;
            loadDtgvBills(kh.MAKH, kh.MAHD);
            txbSDT.Text = kh.SODIENTHOAI;
            dtpkThoiGianDen.Value = kh.THOIGIANBATDAU;

        }
        /// <summary>
        /// chỉ nhập sô
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// thực hiện thêm hóa đơn mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbAddNew_Click(object sender, EventArgs e)
        {
            if (dtgvBills.Tag == null)
            {
                fMessageBoxOK.Show("Vui lòng chọn bàn ăn!");
                return;
            }
            BanAn table = (BanAn)dtgvBills.Tag;
            if (table.TRANGTHAI == -1)
            {
                fMessageBoxOK.Show("Bàn không hoạt động!");
                return;
            }
            string mahd = fThemHoaDonDatTruoc.Show(ac.MANV, table.MABA);
            if (string.IsNullOrEmpty(mahd))
            {
                return;
            }
            clear();
            loadListBillByMaba(table.MABA);
            foreach (KhachHangHoaDonDTO item in cbTenKhachHang.Items)
            {
                if (item.MAHD == mahd)
                {
                    cbTenKhachHang.SelectedItem = item;
                }
            }
            LoadTable();
        }
        /// <summary>
        /// thay đổi thời gian đến của hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpkThoiGianDen_ValueChanged(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            KhachHangHoaDonDTO kh = (KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem;
            kh.THOIGIANBATDAU = dtpkThoiGianDen.Value;
            HoaDonDTO hd = HoaDonDAO.Instance.getHoaDonbyMaHD(kh.MAHD);
            HoaDonDAO.Instance.updateTHOIGIANDEN(hd.MAHD, dtpkThoiGianDen.Value);

        }
        /// <summary>
        /// Hủy đăng ký đặt trước.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbDelete_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            BanAn table = (BanAn)dtgvBills.Tag;
            KhachHangHoaDonDTO kh = (KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem;
            if (fMessageBox.Show("Bạn muốn xóa hóa đơn của " + kh.TENKH) == DialogResult.Cancel) return;
            string MAHD = kh.MAHD;
            if (!HoaDonDAO.Instance.deletePreHoaDon(MAHD))
            { fMessageBoxOK.Show("Xảy ra lỗi!"); }
            clear();
            loadListBillByMaba(table.MABA);
            LoadTable();
            loadFoodtodtgv(dtgvFood);
        }
        /// <summary>
        /// cập nhật hóa đơn đã đến bàn ăn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbCOme_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            BanAn table = (BanAn)dtgvBills.Tag;
            KhachHangHoaDonDTO kh = (KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem;
            if (fMessageBox.Show(kh.TENKH + " đã đến?") == DialogResult.Cancel) return;
            string MAHD = kh.MAHD;
            if (!HoaDonDAO.Instance.checkCome(MAHD))
            { fMessageBoxOK.Show("Xảy ra lỗi!"); }
            clear();
            loadListBillByMaba(table.MABA);
            LoadTable();
            loadFoodtodtgv(dtgvFood);
        }
        /// <summary>
        /// in hóa đơn đặt bàn trước!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPrint_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedItem == null) return;
            KhachHangHoaDonDTO kh = (KhachHangHoaDonDTO)cbTenKhachHang.SelectedItem;
            DataTable data = cthdDAO.Instance.getListPrintBillsbyMAHD(kh.MAHD);
            fReport f = new fReport(data, PrePrice);
            f.ShowDialog();
        }

        #region SetColor
        private void ptbDelete_MouseEnter(object sender, EventArgs e)
        {
            lblDelete.ForeColor = Color.Black;
        }

        private void ptbDelete_MouseLeave(object sender, EventArgs e)
        {
            lblDelete.ForeColor = Color.Silver;
        }


        /// <summary>
        /// Call back
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
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            ((Label)(((Button)sender).Tag)).ForeColor = Color.Silver;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            ((Label)(((Button)sender).Tag)).ForeColor = Color.Black;
        }
        private void ptbPrint_MouseEnter(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Black;
        }

        private void lblPrint_MouseEnter(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Black;
        }

        private void ptbPrint_MouseLeave(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Silver;
        }

        private void lblPrint_MouseLeave(object sender, EventArgs e)
        {
            lblPrint.ForeColor = Color.Silver;
        }

        private void ptbPay_MouseEnter(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Black;
        }

        private void lblPay_MouseEnter(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Black;
        }

        private void lblPay_MouseLeave(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Silver;
        }

        private void ptbPay_MouseLeave(object sender, EventArgs e)
        {
            lblPay.ForeColor = Color.Silver;
        }
        private void ptbAddFood_MouseEnter(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Black;
        }

        private void ptbAddFood_MouseLeave(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Silver;
        }

        private void lblAddFood_MouseEnter(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Black;
        }

        private void lblAddFood_MouseLeave(object sender, EventArgs e)
        {
            lblAddFood.ForeColor = Color.Silver;
        }


        private void ptbSearch_MouseEnter(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.fColor;

        }

        private void ptbSearch_MouseLeave(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.pnlColorList;
        }
        private void lblCheckCome_MouseEnter(object sender, EventArgs e)
        {
            lblCheckCome.ForeColor = Color.Black;
        }

        private void lblCheckCome_MouseLeave(object sender, EventArgs e)
        {
            lblCheckCome.ForeColor = Color.Silver;
        }

        private void ptbCOme_MouseEnter(object sender, EventArgs e)
        {
            lblCheckCome.ForeColor = Color.Black;
        }

        private void ptbCOme_MouseLeave(object sender, EventArgs e)
        {
            lblCheckCome.ForeColor = Color.Silver;
        }

        private void ptbAddNew_MouseEnter(object sender, EventArgs e)
        {
            lblAddNew.ForeColor = Color.Black;
        }

        private void ptbAddNew_MouseLeave(object sender, EventArgs e)
        {
            lblAddNew.ForeColor = Color.Silver;
        }





        #endregion

        #endregion
        
    }
}
