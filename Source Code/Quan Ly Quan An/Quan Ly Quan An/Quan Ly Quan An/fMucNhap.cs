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
    public partial class fMucNhap : Form
    {
        public fMucNhap()
        {
            InitializeComponent();
            loadForm();
            loadImport();
        }
        #region Properties
        private QuanAnDTO QA;
        #endregion
        #region Method
        /// <summary>
        /// load mức nhập từ csdl
        /// </summary>
        void loadImport()
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
                txbMucNhap.Text = QA.ImPort.ToString();
            }
            catch (Exception e)
            {
                fMessageBoxOK.Show("Có lỗi xãy ra!");
                this.Close();
            }
        }
        /// <summary>
        /// load màu
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
        }
        #endregion

        #region Event
        /// <summary>
        /// không cho nhấn enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbMucNhap_KeyDown(object sender, KeyEventArgs e)
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
            QA.ImPort = float.Parse(txbMucNhap.Text.ToString());
            if (!QuanAnDAO.Instance.UpdateValue(QA.PrePersen, QA.ImPort))
            {
                fMessageBoxOK.Show("Có lỗi xãy ra trong quá trình cập nhật! vui lòng thực hiện lại!");
            }
            this.Close();
        }
        /// <summary>
        /// chỉ nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbMucNhap_KeyPress(object sender, KeyPressEventArgs e)
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
        #endregion

    }
}
