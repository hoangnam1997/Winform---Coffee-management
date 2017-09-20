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
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties
        private NhanVienDTO account;

        public NhanVienDTO Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
            }
        }

        private event EventHandler<EventLogin> _ValueChanged;
        public event EventHandler<EventLogin> ValueChanged
        {
            add
            {
                _ValueChanged += value;
            }
            remove
            {
                _ValueChanged -= value;
            }
        }
        #endregion
        #region Method
        /// <summary>
        /// kiểm tra mật khẩu và tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        private bool checkUsernameAndPasswork(string username, string pass)
        {
            List<NhanVienDTO> listAccount = NhanVienDAO.Instance.getAccountByUserName(username);
            string hasPass = StaticClass.hasPass(pass);
            foreach (NhanVienDTO item in listAccount)
            {
                if (item.MATKhau == hasPass)
                {
                    this.Account = item;
                    return true;
                }
            }
            return false;
        }
        void loadForm()
        {
            //this.BackColor = StaticClass.pnlColorMenu;
        }
        #endregion
        #region Event
        /// <summary>
        /// exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        ///xử lý đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text.ToUpper();
            string passWord = txbPasswork.Text;
            try
            {
                if (checkUsernameAndPasswork(userName, passWord))
                {
                    if (_ValueChanged != null)
                    {
                        _ValueChanged(this, new EventLogin(this.Account));
                    }
                    this.Close();
                }
                else
                {
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                fMessageBoxOK.Show("Vui lòng kiểm tra kết nối!\n" + ex.Message);
            }

        }


        #endregion
    }

    /// <summary>
    /// Class event sent Account Login from fLogin
    /// </summary>
    public class EventLogin : EventArgs
    {
        public NhanVienDTO isConnect;
        public EventLogin(NhanVienDTO isConnect)
        {
            this.isConnect = isConnect;

        }
        public NhanVienDTO getisConnect()
        {
            return isConnect;
        }
    }
}
