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
    public partial class fThemLoaiMA : Form
    {
        public fThemLoaiMA()
        {
            InitializeComponent();
            loadForm();


        }
        #region Properties
        #endregion
        #region Method
        /// <summary>
        /// Load form khi vừa khỏi tạo
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
        }

        #endregion
        #region Event
        /// <summary>
        /// khong cho nhap phim enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbMALOAI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// khong cho nhap phim enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// thoat form, huy them loai mon an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// thuc hien them loai mon an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string maloaima = StaticClass.xoakhoangtrang(txbMALOAI.Text.ToUpper());
            string tenloaima = txbName.Text;
            if (string.IsNullOrEmpty(maloaima) || string.IsNullOrEmpty(tenloaima))
            {
                fMessageBoxOK.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            List<LoaiMonAnDTO> list = LoaiMonAnDAO.Instance.getListCategory();
            foreach (LoaiMonAnDTO item in list)
            {
                if (maloaima == item.MALOAIMA.ToUpper())
                {
                    fMessageBoxOK.Show("Loại món ăn đã tồn tại!");
                    return;
                }
            }
            if(!LoaiMonAnDAO.Instance.insertCategory(maloaima,tenloaima))
            {
                fMessageBoxOK.Show("Xảy ra sự cố khi thêm! vui lòng thực hiện lại");
                return;
            }
            fMessageBoxOK.Show("Thêm thành công.");

        }
        #endregion

    }
}
