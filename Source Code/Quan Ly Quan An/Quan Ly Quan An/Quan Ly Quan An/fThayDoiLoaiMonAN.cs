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
    public partial class fThayDoiLoaiMonAN : Form
    {
        /// <summary>
        /// hàm khơi tạo
        /// </summary>
        public fThayDoiLoaiMonAN()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties

        #endregion
        #region method
        /// <summary>
        /// load dah sách loại món an gán vào controls
        /// </summary>
        void loadData()
        {
            List<LoaiMonAnDTO> list = LoaiMonAnDAO.Instance.getListCategory();
            cbMALOAI.Items.Clear();
            foreach (LoaiMonAnDTO item in list)
            {
                cbMALOAI.Items.Add(item);
            }
            if (list.Count > 0)
                cbMALOAI.SelectedIndex = 0;
        }
        /// <summary>
        /// thực hiện khi vừa mới khởi tạo. load các controls
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
        /// thoát form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// thay doi ten theo tung ma loai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMALOAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMALOAI.SelectedItem == null) return;
            txbName.Text = ((LoaiMonAnDTO)cbMALOAI.SelectedItem).TENLOAIMA;
        }
        /// <summary>
        /// thực hiện thay đổi thông tin loại món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbMALOAI.SelectedItem == null)
            {
                fMessageBoxOK.Show("Không tìm thấy loại món ăn!");
                return;
            }
            LoaiMonAnDTO category = ((LoaiMonAnDTO)cbMALOAI.SelectedItem);
            string newName = StaticClass.xoakhoangtrang(txbName.Text);
            if (!LoaiMonAnDAO.Instance.updateCategory(category.MALOAIMA, newName))
            {
                fMessageBoxOK.Show("Xảy ra lỗi khi cập nhật!");
                return;
            }
            loadData();
        }
        /// <summary>
        /// khong cho nhap enter
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
}
