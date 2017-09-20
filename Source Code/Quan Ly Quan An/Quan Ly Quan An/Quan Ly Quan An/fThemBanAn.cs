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
    public partial class fThemBanAn : Form
    {
        public fThemBanAn()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties

        #endregion
        #region Method
        /// <summary>
        /// lấy các trạng thái gán vào cb
        /// </summary>
        /// <param name="cb"></param>
        void loadStatusToCb(ComboBox cb)
        {
            cb.Items.Add(new TrangThaiBanAN(-1));
            cb.Items.Add(new TrangThaiBanAN(0));
            cb.Items.Add(new TrangThaiBanAN(1));
            cb.Items.Add(new TrangThaiBanAN(2));
            cb.SelectedIndex = 0;
        }
        /// <summary>
        /// thựch iện load thông tin các controls khi khởi tạo form
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
            loadStatusToCb(cbTRANGTHAI);
        }
        #endregion

        #region Event
        /// <summary>
        /// Thêm bàn vào hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string MABA = StaticClass.xoakhoangtrang(txbMABA.Text.ToUpper());
            int TRANGTHAI = ((TrangThaiBanAN)cbTRANGTHAI.SelectedItem).IsTrangThai;
            if (string.IsNullOrEmpty(MABA))
            {
                fMessageBoxOK.Show("Vui lòng kiểm tra mã bàn ăn!");
                return;
            }
            List<BanAn> listTable = BanAnDAO.Instance.getListTable();
            foreach (BanAn item in listTable)
            {
                if(MABA==item.MABA)
                {
                    fMessageBoxOK.Show("Bàn ăn đã tồn tại!");
                    return;
                }
            }
            if(!BanAnDAO.Instance.InsertTable(MABA, TRANGTHAI))
            {
                fMessageBoxOK.Show("Xảy ra lỗi trong quá trình thêm bàn! vui lòng thực hiện lại!");
                return;
            }
            fMessageBoxOK.Show("Thêm thành công.");
        }
        /// <summary>
        /// hủy thêm bàn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Không cho nhập phím enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbMABA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

        }

        #endregion

    }
}
