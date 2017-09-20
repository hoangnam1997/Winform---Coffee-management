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
    public partial class fThayDoiMatKhau : Form
    {
        private NhanVienDTO ac;
        /// <summary>
        /// hàm khơi tạo
        /// </summary>
        /// <param name="ac"></param>
        public fThayDoiMatKhau(NhanVienDTO ac)
        {
            InitializeComponent();
            this.ac = ac;
            loadForm();
        }
        #region properties

        #endregion
        #region method
        /// <summary>
        /// thực hiện load các controls khi vừa khởi tạo
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
        }
        /// <summary>
        /// thoát form
        /// </summary>
        void callBack()
        {
            this.Close();
        }
        #endregion
        #region event
        /// <summary>
        /// không cho nhập phím enter
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
        /// Hủy cập nhật mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            callBack();
        }
        /// <summary>
        /// Xử lý xác nhận thay đổi mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string oldPass = txbOld.Text;
            string newPass = txbNew.Text;
            string preNewPass = txbPreNew.Text;
            if (String.IsNullOrEmpty(oldPass) || String.IsNullOrEmpty(newPass)|| String.IsNullOrEmpty(preNewPass))
            {
                fMessageBoxOK.Show("Bạn chưa nhập cái gi kìa! Vui lòng kiểm tra lại!");
                return;
            }
            if(!newPass.Equals(preNewPass))
            {
                fMessageBoxOK.Show("Mật khẩu mới bạn nhập không trùng nhau kia! Vui lòng kiểm tra lại!");
                return;
            }
            string hasPassOld = StaticClass.hasPass(oldPass);
            string hasPassNew = StaticClass.hasPass(newPass);
            if (hasPassOld == NhanVienDAO.Instance.getPassByMANV(ac.MANV))
            {
                //Cập nhật mật khẩu
                if (!NhanVienDAO.Instance.updateAccountPass(ac.MANV, hasPassNew))
                {
                    fMessageBoxOK.Show("Xảy ra lỗi trong quá trình cập nhật! vui lòng thực hiện lại sau!");
                }
                this.Close();
            }
            else
            {
                fMessageBoxOK.Show("Vui lòng kiểm tra lại mật khẩu củ!");
                return;
            }
        }
        #endregion
    }
}
