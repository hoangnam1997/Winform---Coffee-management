using Quan_Ly_Quan_An.DTO;
using Quan_Ly_Quan_An.Cons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Quan_An.DAO;
using System.Globalization;
using System.Threading;

namespace Quan_Ly_Quan_An
{
    public partial class fLapHoaDon : Form
    {
        public fLapHoaDon(NhanVienDTO ac)
        {
            InitializeComponent();
            Ac = ac;
            loadForm();
        }
        #region Properties
        private float preMoney = 0;
        private float totalMonney = 0;
        private NhanVienDTO Ac;
        private static List<ThongTinHoaDonDTO> listTemp = new List<ThongTinHoaDonDTO>();
        private static List<ThongTinHoaDonDTO> listHOADON = new List<ThongTinHoaDonDTO>();
        #endregion
        #region Method
        /// <summary>
        /// load lại stt trong list
        /// </summary>
        /// <param name="list"></param>
        void loadSTT(List<ThongTinHoaDonDTO> list)
        {
            int i = 0;
            foreach (ThongTinHoaDonDTO item in list)
            {
                i++;
                item.STT = i;
            }
        }
        /// <summary>
        /// hàm xử lý khi trở về.
        /// </summary>
        void CallBack()
        {
            this.Close();
        }

        /// <summary>
        /// thay đổi các thuộc tính, vẽ giao diện.
        /// </summary>
        void loadForm()
        {
            lblDoneFood.ForeColor = lblHD.ForeColor = lblListTable.ForeColor = lblTD.ForeColor = StaticClass.colorWord;
            pnlDoneFood.BackColor = ptbBack.BackColor = pnlMenu.BackColor = pnlDS.BackColor = pnlHD.BackColor = pnlTD.BackColor = StaticClass.pnlColorMenu;
            this.BackColor = StaticClass.fColor;
            pnlBill.BackColor = pnlFood.BackColor = fpnlListTable.BackColor = StaticClass.pnlColorList;
            LoadTable();
            LoadCategoryTocb(cbCategory);
            loadFoodtodtgv(dtgvListFood);
            loadDtgvTemp(listTemp);
            loadDtgvHOADON(listHOADON);
            loadDtgvDoneFood();
        }

        /// <summary>
        /// lấy danh sách bàn từ hệ thống lên
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
        /// <summary>
        /// load food vào dtgv
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
        /// Lấy tất cả hóa đơn 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            listTemp.Clear();
            loadDtgvTemp(listTemp);
            dtgvTemp.Tag = (sender as Button);
            BanAn tableClick = (BanAn)((Label)(sender as Button).Tag).Tag;
            dtgvBills.Tag = tableClick;
            listHOADON = cthdDAO.Instance.getListItemNonCheckByMABA(tableClick.MABA);
            loadDtgvHOADON(listHOADON);
            totalMonney = 0;
            preMoney = 0;
            foreach (ThongTinHoaDonDTO item in listHOADON)
            {
                totalMonney += item.SoLuongMA * item.GIA;
            }

            foreach (string item in HoaDonDAO.Instance.GETHOADONNonCheckByMABA(tableClick.MABA))
            {
                preMoney += cthdDAO.Instance.getTienDaThanhToanByHoaDon(item);
            }
            loadLblMoney(totalMonney, totalMonney - preMoney);

        }
        /// <summary>
        /// hiển thị tổng tiền và tiền cần phải trả
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
        /// load dnah sách món ăn chọn đưa vào temp
        /// </summary>
        /// <param name="list"></param>
        void loadDtgvTemp(List<ThongTinHoaDonDTO> list)
        {
            if (dtgvTemp != null)
                dtgvTemp.DataSource = null;
            dtgvTemp.DataSource = list;
            dtgvTemp.Columns[1].HeaderText = "Tên món ăn";
            dtgvTemp.Columns[2].HeaderText = "Giá";
            dtgvTemp.Columns[3].HeaderText = "Số lượng";
            dtgvTemp.Columns[4].HeaderText = "Thành tiền";
            dtgvTemp.Columns[5].Visible = false;
            dtgvTemp.Columns["MABA"].Visible = false;
            dtgvTemp.Columns[7].Visible = false;
            dtgvTemp.Columns["MAHD"].Visible = false;

        }
        /// <summary>
        /// Load dử liệu vào hóa đơn
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
            dtgvBills.Columns["MAHD"].Visible = false;
        }
        /// <summary>
        /// load with bingdings
        /// </summary>
        void loadDtgvDoneFood()
        {
            ThongTinMonAnBingdingDAO.Instance.Change += Instance_Change;

            dtgvDoneFood.DataSource = ThongTinMonAnBingdingDAO.Instance.getListItemCheckDone();
            dtgvDoneFood.Columns[1].HeaderText = "Tên món ăn";
            dtgvDoneFood.Columns[2].HeaderText = "Giá";
            dtgvDoneFood.Columns[3].HeaderText = "Số lượng";
            dtgvDoneFood.Columns[4].Visible = false;
            dtgvDoneFood.Columns[5].Visible = false;
            dtgvDoneFood.Columns["MABA"].HeaderText = "Mã bàn ăn";
            dtgvDoneFood.Columns[7].Visible = false;
            dtgvDoneFood.Columns["MAHD"].Visible = false;
        }
        /// <summary>
        ///     load danh sách thức ăn đa làm xong. sử dugj sqldepency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Instance_Change(object sender, EventArgs e)
        {
            if(dtgvDoneFood.InvokeRequired)
            Invoke((MethodInvoker)(() =>
            {
                loadDtgvDoneFood();
            }));
        }

        #endregion
        #region Event
        /// <summary>
        /// hiện thức ăn theo mã loại món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem == null) return;
            List<MonANvaSLmaDTO> list = MonAnDAO.Instance.getListFoodByMALOAIMA(((LoaiMonAn)cbCategory.SelectedItem).MALOAIMA);
            dtgvListFood.DataSource = list;
            dtgvListFood.Columns["MAMA"].Visible = false;
            dtgvListFood.Columns["MALOAIMA"].Visible = false;
            dtgvListFood.Columns["TENMA"].HeaderText = "Tên món ăn";
            dtgvListFood.Columns["GIA"].HeaderText = "Giá";

        }
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            ((Label)(((Button)sender).Tag)).ForeColor = Color.Silver;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            ((Label)(((Button)sender).Tag)).ForeColor = Color.Black;
        }
        private void ptbCall_MouseLeave(object sender, EventArgs e)
        {
            lblCall.ForeColor = Color.Silver;
        }
        /// <summary>
        /// Cập nhật dtgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode==Keys.Enter)
            {
                ComboBox cb = sender as ComboBox;
                foreach (var item in cb.Items)
                {
                    // so sánh các gần đúng.
                    if(StaticClass.ConvertToUnsign(item.ToString().ToUpper()).IndexOf(StaticClass.ConvertToUnsign(cb.Text.ToUpper()))>=0)
                    {
                        cb.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        private void lblCall_MouseLeave(object sender, EventArgs e)
        {
            lblCall.ForeColor = Color.Silver;
        }
        private void lblCall_MouseEnter(object sender, EventArgs e)
        {
            lblCall.ForeColor = Color.Black;
        }
        private void ptbCall_MouseEnter(object sender, EventArgs e)
        {
            lblCall.ForeColor = Color.Black;
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
        private void ptbBack_Click(object sender, EventArgs e)
        {
            CallBack();
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
        /// <summary>
        /// tìm kím thức ăn theo tên gần đúng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSearch_Click(object sender, EventArgs e)
        {
            string NameFood = StaticClass.xoakhoangtrang(txbSearch.Text);
            if (string.IsNullOrEmpty(NameFood))
            {
                loadFoodtodtgv(dtgvListFood);
                return;
            }
            Invoke((MethodInvoker)(() =>
            {
                List<MonANvaSLmaDTO> list = MonAnDAO.Instance.getListFoodByName(NameFood);
                dtgvListFood.DataSource = list;
                dtgvListFood.Columns["MAMA"].Visible = false;
                dtgvListFood.Columns["MALOAIMA"].Visible = false;
                dtgvListFood.Columns["TENMA"].HeaderText = "Tên món ăn";
                dtgvListFood.Columns["GIA"].HeaderText = "Giá";
            }));



        }

        private void ptbSearch_MouseEnter(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.fColor;

        }

        private void ptbSearch_MouseLeave(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.pnlColorList;
        }
        /// <summary>
        /// khong cho nhap phim enter
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
        /// Thực hiện thêm món ăn vào bảng tạm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbAddFood_Click(object sender, EventArgs e)
        {
            if (dtgvListFood.SelectedCells.Count > 0)
            {
                BanAn table;
                if (dtgvBills.Tag != null)
                {
                    table = (BanAn)dtgvBills.Tag;
                }
                else
                {
                    fMessageBoxOK.Show("Vui lòng chọn bàn");
                    return;
                }
                if (table.TRANGTHAI == -1)
                {
                    fMessageBoxOK.Show("Bàn không hoạt động!");
                    return;
                }
                if (table.TRANGTHAI == 2)
                {
                    List<DateTime> temp = cthdDAO.Instance.getListDateTimePreByMaBa(table.MABA);
                    string date = "";
                    foreach (DateTime item in temp)
                    {
                        date += "[" + item + "] ";
                    }
                    if (fMessageBox.Show("Có khách đặt trước vào " + date + "! Bạn có chắc chắn muốn tiếp tục") == DialogResult.Cancel)
                        return;
                }
                string mama = (string)dtgvListFood.SelectedCells[0].OwningRow.Cells["MAMA"].Value;
                string NAMEfood = (string)dtgvListFood.SelectedCells[0].OwningRow.Cells["TENMA"].Value;
                float gia = (float)dtgvListFood.SelectedCells[0].OwningRow.Cells["GIA"].Value;
                string MALOAIMA = (string)dtgvListFood.SelectedCells[0].OwningRow.Cells["MALOAIMA"].Value;
                int sl = (int)MonAnDAO.Instance.getCountFoodByMAMA(mama);
                // Lấy ra food được chọn.
                MonANvaSLmaDTO food = new MonANvaSLmaDTO(mama, NAMEfood, gia, MALOAIMA, sl);
                int SoLuong = 0;
                // lấy ra số lượng
                if (!string.IsNullOrEmpty(txbCount.Text))
                    SoLuong = int.Parse(txbCount.Text);
                if (SoLuong == 0)
                {
                    fMessageBoxOK.Show("Vui lòng nhập số lượng muốn thêm!");
                    return;
                }
                List<ThongTinHoaDonDTO> listResult = new List<ThongTinHoaDonDTO>();
                bool isTrue = false;
                foreach (ThongTinHoaDonDTO item in listTemp)
                {
                    if (item.MAMA == food.MAMA)
                    {
                        int tempSL = item.SoLuongMA + SoLuong;
                        if (tempSL > food.SL)
                        {
                            fMessageBoxOK.Show("Số lượng bạn nhập vượt quá mức tồn kho!");
                            return;
                        }
                        item.SoLuongMA += SoLuong;
                        item.THANHTIEN = item.SoLuongMA * item.GIA;
                        loadDtgvTemp(listTemp);
                        isTrue = true;
                    }
                    listResult.Add(item);
                }
                if (!isTrue)
                    listResult.Add(new ThongTinHoaDonDTO(listTemp.Count + 1, food.MAMA, food.TENMA, food.GIA, SoLuong, table.MABA, DateTime.Now, ""));
                listTemp = listResult;
                loadDtgvTemp(listTemp);
            }
        }
        /// <summary>
        /// Thực hiện thêm món ăn vào bảng tạm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAddFood_Click(object sender, EventArgs e)
        {
            ptbAddFood_Click(ptbAddFood, e);
        }
        /// <summary>
        /// chỉ cho nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Chỉnh sửa số lượng 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvTemp.SelectedCells.Count > 0)
            {
                float sTT = (int)dtgvTemp.SelectedCells[0].OwningRow.Cells["STT"].Value;
                float SoLuong = (int)dtgvTemp.SelectedCells[0].OwningRow.Cells["SoLuongMA"].Value;
                SoLuong = fThayDoiSoLuong.show(SoLuong);

                foreach (ThongTinHoaDonDTO item in listTemp)
                {

                    if (item.STT == sTT)
                    {

                        if (SoLuong == 0)
                        {
                            listTemp.Remove(item);
                            break;
                        }

                        item.SoLuongMA = (int)SoLuong;
                        item.THANHTIEN = item.SoLuongMA * item.GIA;
                        break;
                    }

                }
                loadSTT(listTemp);
                loadDtgvTemp(listTemp);

            }
        }
        /// <summary>
        /// Xóa tất cả các món đã thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteFoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvTemp.SelectedCells.Count > 0)
            {
                List<int> listDelete = new List<int>();
                for (int i = 0; i < dtgvTemp.SelectedCells.Count; i++)
                {
                    int sTT = (int)dtgvTemp.SelectedCells[i].OwningRow.Cells["STT"].Value;
                    listDelete.Add(sTT);
                }
                foreach (int item in listDelete)
                {

                    foreach (ThongTinHoaDonDTO itemxHoaDon in listTemp)
                    {

                        if (itemxHoaDon.STT == item)
                        {
                            listTemp.Remove(itemxHoaDon);
                            break;
                        }

                    }

                }
                loadSTT(listTemp);
                loadDtgvTemp(listTemp);
            }
        }
        /// <summary>
        /// xóa tất cả món ăn trong list temp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listTemp.Clear();
            loadDtgvTemp(listTemp);
        }

        /// <summary>
        /// Thực hiện tạo hóa đơn và thông tin hóa đơn. chi tiết hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbCall_Click(object sender, EventArgs e)
        {

            if (dtgvBills.Tag == null) { fMessageBoxOK.Show("Vui vòng chọn bàn ăn!"); return; }
            BanAn table = ((BanAn)dtgvBills.Tag);
            if (table.TRANGTHAI < 0) {
                MessageBox.Show("Bàn không hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listTemp.Count <= 0)
            {
                MessageBox.Show("Vui lòng nhập món ăn muốn gọi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> listHD = HoaDonDAO.Instance.GETHOADONNonCheckByMABA(table.MABA);
            if (listHD.Count > 0)
            {
                foreach (ThongTinHoaDonDTO item in listTemp)
                {
                    if (item.SoLuongMA <= MonAnDAO.Instance.getCountFoodByMAMA(item.MAMA))
                        cthdDAO.Instance.insertCTHD(listHD[0], item.MAMA, item.SoLuongMA, -1);
                    else
                    {
                        fMessageBoxOK.Show("Số lượng " + item.TENMA + " vượt quá mức tồ kho");
                    }
                }
            }
            else
            {
                string mahd = StaticClass.Random(10);
                if (HoaDonDAO.Instance.insertHoaDon(mahd, DateTime.Now, DateTime.Now, 0, 0, 0, null, Ac.MANV, table.MABA))
                {
                    foreach (ThongTinHoaDonDTO item in listTemp)
                    {
                        cthdDAO.Instance.insertCTHD(mahd, item.MAMA, item.SoLuongMA, -1);
                    }
                }
                else
                {
                    fMessageBoxOK.Show("Lỗi khi thêm hóa đơn.");
                }

            }
            listHOADON = cthdDAO.Instance.getListItemNonCheckByMABA(table.MABA);
            totalMonney = 0;
            float preMoney = 0;
            foreach (string item in HoaDonDAO.Instance.GETHOADONNonCheckByMABA(table.MABA))
            {
                preMoney += cthdDAO.Instance.getTienDaThanhToanByHoaDon(item);
            }
            foreach (ThongTinHoaDonDTO item in listHOADON)
            {
                totalMonney += item.THANHTIEN;
            }
            loadLblMoney(totalMonney, totalMonney - preMoney);
            loadDtgvHOADON(listHOADON);
            listTemp.Clear();
            loadDtgvTemp(listTemp);
            LoadTable();
            loadFoodtodtgv(dtgvListFood);
        }
        /// <summary>
        /// Chuyển listTemp sang list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCall_Click(object sender, EventArgs e)
        {
            ptbCall_Click(ptbCall, e);
        }
        /// <summary>
        /// Tính tiền. set hóa đơn thành 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPay_Click(object sender, EventArgs e)
        {
            if (dtgvBills.Tag == null) { fMessageBoxOK.Show("Vui vòng chọn bàn ăn!"); return; }


            BanAn table = ((BanAn)dtgvBills.Tag);
            if (fMessageBox.Show("Bạn có muốn tính tiền cho bàn " + table.MABA) == DialogResult.Cancel) return;
            List<string> listHD = HoaDonDAO.Instance.GETHOADONNonCheckByMABA(table.MABA);
            foreach (string item in listHD)
            {
                cthdDAO.Instance.xoaCTHDChuaCheBienCTHD(item);
            }
            if (fMessageBox.Show("Bạn có muốn in hóa đơn không?") == DialogResult.OK)
            {
                ptbPrint_Click(ptbPrint, e);
            }
            foreach (string item in listHD)
            {
                HoaDonDAO.Instance.UpdateHoaDonCheckOut(item);
            }
            clear();
        }
        public void clear()
        {
            listHOADON.Clear();
            loadDtgvHOADON(listHOADON);
            LoadTable();
            preMoney = 0;
            totalMonney = 0;
            loadLblMoney(0, 0);
            loadFoodtodtgv(dtgvListFood);
        }
        /// <summary>
        /// Tính tiền. set hóa đơn thành 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPay_Click(object sender, EventArgs e)
        {
            ptbPay_Click(ptbPay, e);
        }
        /// <summary>
        /// thoát và reset lại các hóa đơn list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fCreatBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            listTemp.Clear();
            listHOADON.Clear();
        }
        /// <summary>
        /// thực hiện thao tác in hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbPrint_Click(object sender, EventArgs e)
        {
            //CrystalReport1 cr = new CrystalReport1();
            //cr.SetDataSource(DataProvider.Instance.ExecuteQuery("SELECT *FROM dbo.BANAN"));
            //fReport f = new fReport(cr);
            //f.ShowDialog();
            if (dtgvBills.Tag == null) { fMessageBoxOK.Show("Vui lòng chọn bàn ăn!"); return; }
            BanAn table = (BanAn)dtgvBills.Tag;
            totalMonney = 0;
            foreach (ThongTinHoaDonDTO item in cthdDAO.Instance.getListItemNonCheckByMABA(table.MABA))
            {
                totalMonney += item.SoLuongMA * item.GIA;
            }
            preMoney = 0;
            foreach (string item in HoaDonDAO.Instance.GETHOADONNonCheckByMABA(table.MABA))
            {
                preMoney += cthdDAO.Instance.getTienDaThanhToanByHoaDon(item);
            }
            if (dtgvBills.Rows.Count <= 0) return;
            string mahd = (string)dtgvBills.Rows[0].Cells["MAHD"].Value;
            DataTable data = cthdDAO.Instance.getListPrintBillsbyMAHD(mahd);
            fReport f = new fReport(data, totalMonney - preMoney);
            f.ShowDialog();

        }
        /// <summary>
        /// thực hiện thao tác in hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPrint_Click(object sender, EventArgs e)
        {
            ptbPrint_Click(ptbPrint, e);
        }
        #endregion
        
    }
}
