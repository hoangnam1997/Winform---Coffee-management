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
    public partial class fNhaCCvaKHACH : Form
    {
        public fNhaCCvaKHACH()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties
        BindingSource NhaCCSurce = new BindingSource();
        BindingSource KhachHangSurce = new BindingSource();
        bool isKhachHang = true, isNhaCC = true;

        #endregion
        #region Method
        /// <summary>
        /// Chayj khi khoi tao form
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
            pnlIMenu.BackColor = pnl.BackColor = pnlMenu.BackColor = StaticClass.pnlColorMenu;
            panelcontrols.BackColor=pnlList.BackColor = flowLayoutPanelInfomation.BackColor = StaticClass.pnlColorList;
            loadCbChoice();


        }
        /// <summary>
        /// load danh sách các boa cáo
        /// </summary>
        void loadCbChoice()
        {
            List<NhaCC_KhachHang> result = new List<NhaCC_KhachHang>();
            result.Add(new NhaCC_KhachHang(0, "Nhà cung cấp"));
            result.Add(new NhaCC_KhachHang(1, "Khách hàng"));
            cbChoice.DataSource = result;
            cbChoice.SelectedIndex = 0;
        }
        /// <summary>
        /// thoat
        /// </summary>
        void callBack()
        {
            this.Close();
        }
        #endregion

        #region Event
        #region setcolor
        private void ptbBack_MouseEnter(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.fColor;
        }

        private void ptbBack_MouseLeave(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.pnlColorMenu;
        }
        private void ptbSearch_MouseEnter(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.fColor;
        }

        private void ptbSearch_MouseLeave(object sender, EventArgs e)
        {
            ptbSearch.BackColor = StaticClass.pnlColorList;
        }
        private void ptbAdd_MouseEnter_1(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Black;
        }

        private void ptbAdd_MouseLeave_1(object sender, EventArgs e)
        {
            lblAdd.ForeColor = Color.Silver;
        }
        private void ptbEdit_MouseEnter(object sender, EventArgs e)
        {
            lblEdit.ForeColor = Color.Black;
        }
        private void ptbEdit_MouseLeave(object sender, EventArgs e)
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

        private void ptbSearch_Click(object sender, EventArgs e)
        {
            switch (((NhaCC_KhachHang)cbChoice.SelectedItem).I)
            {
                case 0:
                    NhaCCSurce.DataSource = NhaCungCapDAO.Instance.getListNhaCungCapbyNhaccganDung(txbTim.Text);
                    break;
                case 1:
                    KhachHangSurce.DataSource = KhachHangDAO.Instance.getListKhachHangByTen(txbTim.Text);
                    break;
            }
        }

        #endregion
        /// <summary>
        /// thoát khỏi form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbBack_Click(object sender, EventArgs e)
        {
            callBack();
        }
        /// <summary>
        /// Khong cho nhan enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// Them khach hang hoac nha cc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbAdd_Click(object sender, EventArgs e)
        {

            switch (((NhaCC_KhachHang)cbChoice.SelectedItem).I)
            {

                case 0:
                    string mancc = StaticClass.xoakhoangtrang(txbMaNhacc.Text);
                    string sotaikhoan = StaticClass.xoakhoangtrang(txbSoTaiKhoanNhaCC.Text);
                    string diachi = StaticClass.xoakhoangtrang(txbDiaChiNhacc.Text);
                    string sdt = StaticClass.xoakhoangtrang(txbsdtNhacc.Text);
                    if (string.IsNullOrEmpty(mancc))
                    {
                        fMessageBoxOK.Show("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }
                    if (NhaCungCapDAO.Instance.getSoLuongNCC(mancc) > 0)
                    {
                        fMessageBoxOK.Show("Đã tồn tại " + mancc);
                        return;
                    }
                    if(!NhaCungCapDAO.Instance.insertNHACC(mancc,sotaikhoan,diachi,sdt))
                    {
                        fMessageBoxOK.Show("Xảy ra lỗi! vui lòng thử lại sau");
                        return;
                    }
                    else
                    {
                        fMessageBoxOK.Show("Thêm thành công!");
                    }
                    NhaCCSurce.DataSource = NhaCungCapDAO.Instance.getListNhaCungCap();
                    break;
                case 1:
                    string makh = StaticClass.Random(10);
                    string tenkh = StaticClass.xoakhoangtrang(txbtenKH.Text);
                    string sdtkh = StaticClass.xoakhoangtrang(txbsdtKH.Text);
                    if (string.IsNullOrEmpty(makh))
                    {
                        fMessageBoxOK.Show("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }
                    if (KhachHangDAO.Instance.getKhachHangBySDTN(sdtkh) != null)
                    {
                        fMessageBoxOK.Show("Đã tồn tại khách hàng với số điện thoại!");
                        return;
                    }
                    if (KhachHangDAO.Instance.getSoLuongKhachHang(makh) > 0)
                    {
                        fMessageBoxOK.Show("Đã tồn tại " + makh);
                        return;
                    }
                    if (!KhachHangDAO.Instance.insertKhachHang(makh, tenkh,sdtkh))
                    {
                        fMessageBoxOK.Show("Xảy ra lỗi! vui lòng thử lại sau");
                        return;
                    }
                    else
                    {
                        fMessageBoxOK.Show("Thêm thành công!");
                    }
                    KhachHangSurce.DataSource = KhachHangDAO.Instance.getListKhachHang();
                    break;
            }
        }
        /// <summary>
        /// Sua khach hang hoac nha cc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbEdit_Click(object sender, EventArgs e)
        {
            switch (((NhaCC_KhachHang)cbChoice.SelectedItem).I)
            {

                case 0:
                    if (string.IsNullOrEmpty(StaticClass.xoakhoangtrang(lbltempNCC.Text)))
                        return;
                    if (!NhaCungCapDAO.Instance.updateNhacc(lbltempNCC.Text, txbSoTaiKhoanNhaCC.Text, txbDiaChiNhacc.Text, txbsdtNhacc.Text))
                    {
                        fMessageBoxOK.Show("Xảy ra lỗi! vui lòng thực hiện lại!");
                    }
                    else
                    {
                        fMessageBoxOK.Show("Cập nhật thành công!");
                        NhaCCSurce.DataSource = NhaCungCapDAO.Instance.getListNhaCungCap();
                    }
                    break;
                case 1:
                    if (string.IsNullOrEmpty(StaticClass.xoakhoangtrang(lblTemp.Text)))
                        return;
                    if (!KhachHangDAO.Instance.updateKhachHang(lblTemp.Text, txbtenKH.Text, txbsdtKH.Text))
                    {
                        fMessageBoxOK.Show("Xảy ra lỗi! vui lòng thực hiện lại!");
                    }
                    else
                    {
                        fMessageBoxOK.Show("Cập nhật thành công!");
                        KhachHangSurce.DataSource = KhachHangDAO.Instance.getListKhachHang();
                    }
                    break;
            }
        }
        /// <summary>
        /// Xoa khach hang hoac nha cc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbDelete_Click(object sender, EventArgs e)
        {
            switch (((NhaCC_KhachHang)cbChoice.SelectedItem).I)
            {
                case 0:
                    if (string.IsNullOrEmpty(StaticClass.xoakhoangtrang(lbltempNCC.Text)))
                        return;
                    if (fMessageBox.Show("Xóa nhà cung cấp " + lbltempNCC.Text + " và thông tin liên quan?") == DialogResult.Cancel) return;
                    if(NhaCungCapDAO.Instance.deleteNCC(lbltempNCC.Text))
                    {
                        fMessageBoxOK.Show("Xóa thành công!");
                    }
                    else
                    {
                        fMessageBoxOK.Show("Xảy ra lỗi! vui lòng thử lại!");
                        return;
                    }
                    NhaCCSurce.DataSource = NhaCungCapDAO.Instance.getListNhaCungCap();
                    break;
                case 1:
                    if (string.IsNullOrEmpty(StaticClass.xoakhoangtrang(lblTemp.Text)))
                        return;
                    if (fMessageBox.Show("Xóa khách hàng " + txbtenKH.Text + " và thông tin liên quan?") == DialogResult.Cancel) return;
                    if (KhachHangDAO.Instance.deleteKhachHang(lblTemp.Text))
                    {
                        fMessageBoxOK.Show("Xóa thành công!");
                    }
                    else
                    {
                        fMessageBoxOK.Show("Xảy ra lỗi! vui lòng thử lại!");
                        return;
                    }
                    KhachHangSurce.DataSource = KhachHangDAO.Instance.getListKhachHang();
                    break;
            }
        }

        /// <summary>
        /// Thay đổi truy xuất báo cáo danh sách khách hàng và nha cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((NhaCC_KhachHang)cbChoice.SelectedItem).I)
            {
                case 0:
                    lblTemp.Text = "";
                    List<NhaCungCapDTO> list = NhaCungCapDAO.Instance.getListNhaCungCap();
                    NhaCCSurce.DataSource = list;
                    dtgvNhaCC.DataSource = NhaCCSurce;
                    dtgvNhaCC.Refresh();
                    pnlInfomationSuplier.Visible = true;
                    pnlInfomationCustomer.Visible = false;
                    dtgvKhachHang.Visible = false;
                    dtgvNhaCC.Visible = true;
                    dtgvNhaCC.Columns["DIACHI"].Visible = false;
                    dtgvNhaCC.Columns["MANCC"].HeaderText = "Mã";
                    dtgvNhaCC.Columns["SOTAIKHOAN"].HeaderText = "Tài khoản";
                    if (isNhaCC)
                    {
                        txbMaNhacc.DataBindings.Add(new Binding("Text", dtgvNhaCC.DataSource, "MANCC", true, DataSourceUpdateMode.Never));
                        lbltempNCC.DataBindings.Add(new Binding("Text", dtgvNhaCC.DataSource, "MANCC", true, DataSourceUpdateMode.Never));
                        txbSoTaiKhoanNhaCC.DataBindings.Add(new Binding("Text", dtgvNhaCC.DataSource, "SOTAIKHOAN", true, DataSourceUpdateMode.Never));
                        txbDiaChiNhacc.DataBindings.Add(new Binding("Text", dtgvNhaCC.DataSource, "DIACHI", true, DataSourceUpdateMode.Never));
                        txbsdtNhacc.DataBindings.Add(new Binding("Text", dtgvNhaCC.DataSource, "SDT", true, DataSourceUpdateMode.Never));
                        isNhaCC = false;
                    }
                    break;
                case 1:
                    lbltempNCC.Text = "";
                    List<KhachHangDTO> listkh = KhachHangDAO.Instance.getListKhachHang();
                    KhachHangSurce.DataSource = listkh;
                    dtgvKhachHang.DataSource = KhachHangSurce;
                    dtgvKhachHang.Refresh();
                    dtgvKhachHang.Visible = true;
                    dtgvNhaCC.Visible = false;
                    pnlInfomationSuplier.Visible = false;
                    pnlInfomationCustomer.Visible = true;
                    dtgvKhachHang.Columns["MAKH"].Visible = false;
                    dtgvKhachHang.Columns["TENKH"].HeaderText = "Họ tên";
                    dtgvKhachHang.Columns["SODIENTHOAi"].HeaderText = "Số điện thoại";

                    if (isKhachHang)
                    {
                        txbtenKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "TENKH", true, DataSourceUpdateMode.Never));
                        txbsdtKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "SODIENTHOAI", true, DataSourceUpdateMode.Never));
                        lblTemp.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "MAKH", true, DataSourceUpdateMode.Never));
                        isKhachHang = false;
                    }

                    break;
                default:
                    break;
            }
        }
        #endregion


    }
}
