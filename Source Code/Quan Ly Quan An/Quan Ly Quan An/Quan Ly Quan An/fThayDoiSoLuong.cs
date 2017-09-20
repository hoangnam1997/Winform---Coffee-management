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
    public partial class fThayDoiSoLuong : Form
    {
        private static float result;
        public static fThayDoiSoLuong f;
        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        /// <param name="text"></param>
        public fThayDoiSoLuong(float text)
        {
            InitializeComponent();
            txbNumber.Text = text.ToString();
        }
        /// <summary>
        /// thoát fomr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// trả về số luong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            result = int.Parse(txbNumber.Text);
            this.Close();
        }
        /// <summary>
        /// hàm thực hiện lấy số lượng và trả về số lượng
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static float show(float text)
        {
            result = text;
            f = new fThayDoiSoLuong(text);
            f.ShowDialog();
            return result;
        }
        /// <summary>
        /// không cho nhập chử
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbNumber_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
