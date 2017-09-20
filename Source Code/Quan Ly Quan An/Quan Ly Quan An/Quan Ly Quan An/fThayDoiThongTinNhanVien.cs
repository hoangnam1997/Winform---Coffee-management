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
    public partial class fThayDoiThongTinNhanVien : Form
    {
        private NhanVienDTO ac;
        public fThayDoiThongTinNhanVien(NhanVienDTO account)
        {
            InitializeComponent();
            this.ac = account;
            loadForm();
        }
        #region Properties
        private event EventHandler<eventChangeInfoomation> _ChangeInfomation;
        public event EventHandler<eventChangeInfoomation> ChangeInfomation
        {
            add { _ChangeInfomation += value; }
            remove { _ChangeInfomation -= value; }
        }
        #endregion
        #region Method
        /// <summary>
        /// Thực hiện lấy các thông tin gán vào các controls
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
            txbName.Text = ac.HOTEN;
            txbAddress.Text = ac.DiaChi;
            txbNumberPhone.Text = ac.SDT;
            dtpkBorn.Value = ac.NGAYSINH;
        }
        /// <summary>
        /// quay trở lại, thoát khỏi form
        /// </summary>
        void callBack()
        {
            this.Close();
        }

        #endregion
        #region event
        private void fInfomationAccountChange_Load(object sender, EventArgs e)
        {
            ///không làm gì cả
        }
        /// <summary>
        /// quay trở lại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            callBack();
        }
        /// <summary>
        ///cập nhật thông tin tài khoản.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //gán giá trị đã thay đổi
            ac.HOTEN = txbName.Text;
            ac.DiaChi = txbAddress.Text;
            ac.SDT = txbNumberPhone.Text;
            ac.NGAYSINH = dtpkBorn.Value;
            //cập nhật
            if (NhanVienDAO.Instance.updateAccountInfomation(ac.MANV, ac.HOTEN, ac.DiaChi, ac.SDT, ac.NGAYSINH))
            {
                _ChangeInfomation(this, new eventChangeInfoomation(this.ac));
                this.Close();
            }
            else
            {
                fMessageBox.Show("Cập nhật xảy ra lỗi! vui lòng kiểm tra lại!");
            }



        }
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



        #endregion

        
    }
    public class eventChangeInfoomation : EventArgs
    {
        private NhanVienDTO ac;
        public eventChangeInfoomation(NhanVienDTO ac)
        {
            this.ac = ac;
        }
        public NhanVienDTO getAccount()
        {
            return this.ac;
        }
    }
}
