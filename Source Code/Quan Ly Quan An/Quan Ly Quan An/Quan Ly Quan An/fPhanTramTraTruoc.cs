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
    public partial class fPhanTramTraTruoc : Form
    {
        
        public fPhanTramTraTruoc()
        {
            InitializeComponent();
            loadForm();
            loadPrepersen();
        }
        #region Properties
        private QuanAnDTO QA;
        #endregion
        #region Method
        /// <summary>
        /// load phần trăm trả trước từ csdl
        /// </summary>
        void loadPrepersen()
        {
            try
            {
                QuanAnDTO list = QuanAnDAO.Instance.getListQuanAn();
                if (!(list !=null))
                {
                    QuanAnDAO.Instance.insertDefaultValueQuanAn();
                    list = QuanAnDAO.Instance.getListQuanAn();
                }
                QA = list;
                txbPrePersen.Text = QA.PrePersen.ToString();
            }
            catch (Exception e)
            {
                fMessageBoxOK.Show("Có lỗi xãy ra!");
                this.Close();
            }
        }
        /// <summary>
        /// load hiển thị các controls
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
        }
        #endregion

        #region Event
        /// <summary>
        /// chỉ nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbPrePersen_KeyPress(object sender, KeyPressEventArgs e)
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
        /// không cho nhập phím enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbPrePersen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// hủy thay đổi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Cập nhật dử liệu tra trước khi đặt món
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            QA.PrePersen = float.Parse(txbPrePersen.Text.ToString());
            if (!QuanAnDAO.Instance.UpdateValue(QA.PrePersen, QA.ImPort))
            {
                fMessageBoxOK.Show("Có lỗi xãy ra trong quá trình cập nhật! vui lòng thực hiện lại!");
            }
            this.Close();
        }
        #endregion
        
    }
}
