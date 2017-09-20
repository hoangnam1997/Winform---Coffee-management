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
    public partial class fXoaLoaiMonAn : Form
    {
        public fXoaLoaiMonAn()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties

        #endregion
        #region method
        /// <summary>
        /// Hàm thực hiện load các thông tinkhi vừa khởi tạ form
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
            loadData();
        }
        /// <summary>
        /// load danh sách các mã loại ma lên cb
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
        /// thực hiện xóa loại món ăn
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
            string maloaima = ((LoaiMonAnDTO)cbMALOAI.SelectedItem).MALOAIMA;
            if (MessageBox.Show("Bạn có muốn xóa ''" + ((LoaiMonAnDTO)cbMALOAI.SelectedItem).TENLOAIMA + "'' ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
                List<MonAnDTO> listMA = MonAnDAO.Instance.getListMonAnbyLoaiMonAn(maloaima);
            foreach (MonAnDTO item in listMA)
            {
                if (!MonAnDAO.Instance.deleteMonAn(item.MAMA))
                {
                    fMessageBoxOK.Show("Xảy ra lỗi khi xóa!");
                    return;
                }
            }
            if (!LoaiMonAnDAO.Instance.deleteCategory(maloaima))
            {
                fMessageBoxOK.Show("Xảy ra lỗi khi xóa!");
                return;
            }
            fMessageBoxOK.Show("Xóa thành công!");
            loadData();
        }
        #endregion

    }
}
