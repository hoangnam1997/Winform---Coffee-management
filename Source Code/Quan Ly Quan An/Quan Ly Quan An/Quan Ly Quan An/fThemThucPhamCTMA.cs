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
    public partial class fThemThucPhamCTMA : Form
    {
        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public fThemThucPhamCTMA()
        {
            InitializeComponent();
            loadForm();
        }
        /// <summary>
       /// Thực hiện load  form khi vưa mới khỏi tạo. khỏi tạo các controls
        /// </summary>
        void loadForm()
        {
            cbThucPham.DataSource = ThucPhamDAO.Instance.getListThucPham();
        }
        /// <summary>
        /// Thoát khỏi form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// không cho nhập chử
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbKhoiLuongTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //chỉ nhập 1 dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
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
        /// không cho nhâp enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbKhoiLuongTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if ((sender as TextBox).Name == "txbKhoiLuongTP")
                    btnAccept_Click(this, new EventArgs());
            }
        }
        /// <summary>
        /// thực hiện gửi thông tin thực phẩm gửi về form trước đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            float KhoiLuong=0;
            float.TryParse(StaticClass.xoakhoangtrang(txbKhoiLuongTP.Text),out KhoiLuong);
            if (KhoiLuong == 0)
            {
                fMessageBoxOK.Show("Bạn chưa nhập khối lượng thực phẩm!");
                return;
            }
            if (cbThucPham.SelectedItem == null)
            {
                fMessageBoxOK.Show("Bạn chưa chọn thực phẩm nào!");
                return;
            }
            ThucPhamDTO thucPham = (ThucPhamDTO)cbThucPham.SelectedItem;
            if (_eventAccept != null)
                _eventAccept(this,new EventThemThucPham(KhoiLuong, thucPham));

        }
        /// <summary>
        /// sự kiên trả qua fomr. trả về thông tin ctma
        /// </summary>

        private event EventHandler<EventThemThucPham> _eventAccept;
        public event EventHandler<EventThemThucPham> EventAccept
        {
            add { _eventAccept += value; }
            remove { _eventAccept -= value; }
        }
        }
    public class EventThemThucPham:EventArgs
    {
        private float khoiLuong;
        private ThucPhamDTO thucPham;
        public EventThemThucPham(float KhoiLuong,ThucPhamDTO thucpham)
        {
            this.KhoiLuong = KhoiLuong;
            this.ThucPham = thucpham;
        }

        public float KhoiLuong
        {
            get
            {
                return khoiLuong;
            }

            set
            {
                khoiLuong = value;
            }
        }

        public ThucPhamDTO ThucPham
        {
            get
            {
                return thucPham;
            }

            set
            {
                thucPham = value;
            }
        }
    }
}
