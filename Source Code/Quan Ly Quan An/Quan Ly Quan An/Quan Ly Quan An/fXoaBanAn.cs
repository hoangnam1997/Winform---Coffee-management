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
    public partial class fXoaBanAn : Form
    {
        public fXoaBanAn()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties

        #endregion
        #region Method
        /// <summary>
        /// lấy dử liệu gán vào cb. lấy danh sách bàn gán vào cb
        /// </summary>
        void loadData()
        {
            List<BanAn> listTable = BanAnDAO.Instance.getListTable();
            cbMABA.Items.Clear();
            foreach (BanAn item in listTable)
            {
                cbMABA.Items.Add(item);
            }
            if (listTable.Count > 0)
                cbMABA.SelectedIndex = 0;

        }
        /// <summary>
        /// thực hiện load hiển thị các controls
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
            loadData();
        }
        #endregion
        #region Event
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
        /// hủy thao tác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Thực hiện lệnh xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbMABA.SelectedItem == null)
            {
                fMessageBoxOK.Show("Không tìm thấy bàn ăn");
                return;
            }

            string maba = ((BanAn)(cbMABA.SelectedItem)).MABA;
            if (MessageBox.Show("Bạn có muốn xóa ''" + maba + "'' ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            if (!BanAnDAO.Instance.deleteTable(maba))
            {
                fMessageBoxOK.Show("Xảy ra lỗi trong quá trình xóa!");
                return;
            }
            else
            {
                fMessageBoxOK.Show("Xóa thành công!");
            }
            loadData();
        }
        #endregion

    }
}
