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
    public partial class fThayDoiTrangThaiBanAn : Form
    {
        public fThayDoiTrangThaiBanAn()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties

        #endregion
        #region method
        /// <summary>
        /// thục hiện khi mới khởi tạo, lấy thông tin và gán vào các controls
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.fColor;
            loadStatusToCb(cbTRANGTHAI);
            loadData();

        }
        /// <summary>
        /// Thêm các item cho cb trạng thái
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
        /// thêm dử liệu bàn và trạng thái tương ứng cho bàn từ csdl
        /// </summary>
        void loadData()
        {
            cbMABA.Items.Clear();
            List<BanAn> list = BanAnDAO.Instance.getListTable();
            foreach (BanAn item in list)
            {
                cbMABA.Items.Add(item);
            }
            if (list.Count > 0)
                cbMABA.SelectedIndex = 0;

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
        /// Chỉnh sửa thuộc tính trạng thái bàn ăn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbMABA.SelectedItem == null)
            {
                fMessageBoxOK.Show("Không tìm thấy bàn ăn!");
                return;
            }
            string MABA = ((BanAn)cbMABA.SelectedItem).MABA;
            int TRANGTHAI = ((TrangThaiBanAN)cbTRANGTHAI.SelectedItem).IsTrangThai;
            if (!BanAnDAO.Instance.UpdateTable(MABA, TRANGTHAI))
            {
                fMessageBoxOK.Show("Xảy ra lỗi khi cập nhật! vi lòng thực hiện lại sau!");
                return;
            }
            fMessageBoxOK.Show("Thay đổi thành công!");
            loadData();
        }
        /// <summary>
        /// Hủy sửa đổi bàn ăn: không làm gì cả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// thay đổi trạng thía tương ứng với bàn ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMABA_SelectedIndexChanged(object sender, EventArgs e)
        {
            BanAn selected = (BanAn)(sender as ComboBox).SelectedItem;
            foreach (TrangThaiBanAN item in cbTRANGTHAI.Items)
            {
                if (item.IsTrangThai == selected.TRANGTHAI)
                {
                    cbTRANGTHAI.SelectedItem = item;
                }
            }
        }
        #endregion
        
    }
}
