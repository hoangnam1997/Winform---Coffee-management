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
    public partial class fThemHoaDonDatTruoc : Form
    {
        public fThemHoaDonDatTruoc(string MANV, string MABA)
        {
            InitializeComponent();
            this.MABA = MABA;
            this.MANV = MANV;

        }
        KhachHangDTO khach = null;
        private static string MAHD = null;
        private string MABA = null;
        private string MANV = null;
        private static fThemHoaDonDatTruoc f;

        /// <summary>
        /// thoát khỏi form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// khong cho nhap phim enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }


        /// <summary>
        /// Thực hiện thêm khách hàng và hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string TenKhachHang = StaticClass.xoakhoangtrang(txbName.Text);
            string SDT = StaticClass.xoakhoangtrang(txbSDT.Text);
            DateTime dateCome = dtpkThoiGianDen.Value;
            if (string.IsNullOrEmpty(TenKhachHang) || string.IsNullOrEmpty(SDT))
            {
                fMessageBoxOK.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            //thực hiện khi không có thong tin khach hàng
            if (khach == null)
            {
                string makh;

                makh = StaticClass.Random(10);
                KhachHangDAO.Instance.insertKhachHang(makh, TenKhachHang, SDT);

                string MAHDtem;
                MAHDtem = StaticClass.Random(10);
                if (!HoaDonDAO.Instance.insertHoaDon(MAHDtem, DateTime.Now, dateCome, 0, 0, -1, makh, MANV, MABA))
                {
                    fMessageBoxOK.Show("Vui lòng thực hiện lại!");
                    return;
                }
                MAHD = MAHDtem;
                this.Close();
            }
            else//thực hiện khi khách hàng đẫ tồn tại
            {
                string MAHDtem;
                MAHDtem = StaticClass.Random(10);
                if (!HoaDonDAO.Instance.insertHoaDon(MAHDtem, DateTime.Now, dateCome, 0, 0, -1, khach.MAKH, MANV, MABA))
                {
                    fMessageBoxOK.Show("Vui lòng thực hiện lại!");
                    return;
                }
                MAHD = MAHDtem;
                this.Close();
            }

        }
        /// <summary>
        /// Hàm thêm hóa đơn đạt trước và trả về mã hóa đơn.
        /// </summary>
        /// <param name="MANV"></param>
        /// <param name="MABA"></param>
        /// <returns></returns>
        public static string Show(string MANV, string MABA)
        {
            MAHD = null;
            f = new fThemHoaDonDatTruoc(MANV, MABA);
            f.ShowDialog();
            return MAHD;
        }
        /// <summary>
        /// Thực hiện lây thông tin khách hàng đã có
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSDT_Leave(object sender, EventArgs e)
        {
            KhachHangDTO khach = KhachHangDAO.Instance.getKhachHangBySDTN(txbSDT.Text);
            if (khach == null)
                return;
            txbName.Text = khach.TENKH;
        }
    }
}
