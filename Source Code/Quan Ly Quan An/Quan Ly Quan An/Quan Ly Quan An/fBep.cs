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
    public partial class fBep : Form
    {
        public fBep()
        {
            InitializeComponent();
            loadForm();
        }
        #region Properties

        #endregion
        #region method
        void Callback()
        {
            this.Close();
        }
        /// <summary>
        /// chạy khi khở động form
        /// </summary>
        void loadForm()
        {
            lblListFoodCooking.ForeColor = lblListFoodDone.ForeColor = lblListFoodWaiting.ForeColor = StaticClass.colorWord;
            pnlMenu.BackColor = pnlListFoodCooking.BackColor = pnlListFoodDone.BackColor = pnlListFoodWaiting.BackColor = ptbBack.BackColor = StaticClass.pnlColorMenu;
            this.BackColor = StaticClass.fColor;
            loadFoodWaiting();
            loadFoodCooking();
            loadFoodDone();
            timer1.Start();
        }
        /// <summary>
        /// load danh sách thức ăn đã làm xong.
        /// </summary>
        private void loadFoodDone()
        {
            dtgvDone.DataSource = cthdDAO.Instance.getDanhSachMonAnDaXong();
            dtgvDone.Columns["STT"].Width = 50;
            dtgvDone.Columns["TENMA"].HeaderText = "Tên món ăn";
            dtgvDone.Columns["GIA"].Visible = false;
            dtgvDone.Columns["SoLuongMA"].HeaderText = "Số lượng";
            dtgvDone.Columns["SoLuongMA"].Width = 75;
            dtgvDone.Columns["THANHTIEN"].Visible = false;
            dtgvDone.Columns["MAMA"].Visible = false;
            dtgvDone.Columns["MABA"].Visible = false;
            dtgvDone.Columns["DataCome"].HeaderText = "Thời gian đến";
            dtgvDone.Columns["DataCome"].DefaultCellStyle.Format = "hh:mm tt (dd/MM/yyyy)";
            dtgvDone.Columns["DataCome"].Width = 124;
            dtgvDone.Columns["MAHD"].Visible = false;
        }

        /// <summary>
        /// load danh sách món ăn đang chờ
        /// </summary>
        private void loadFoodWaiting()
        {
            List<ThongTinHoaDonDTO> item = cthdDAO.Instance.getDanhSachMonANDangdoi();
            dtgvWaiting.DataSource = item;
            dtgvWaiting.Columns["STT"].Width = 50;
            dtgvWaiting.Columns["TENMA"].HeaderText = "Tên món ăn";
            dtgvWaiting.Columns["GIA"].Visible = false;
            dtgvWaiting.Columns["SoLuongMA"].HeaderText = "Số lượng";
            dtgvWaiting.Columns["SoLuongMA"].Width = 75;
            dtgvWaiting.Columns["THANHTIEN"].Visible = false;
            dtgvWaiting.Columns["MAMA"].Visible = false;
            dtgvWaiting.Columns["MABA"].Visible = false;
            dtgvWaiting.Columns["DataCome"].HeaderText = "Thời gian đến";
            dtgvWaiting.Columns["DataCome"].DefaultCellStyle.Format = "hh:mm tt (dd/MM/yyyy)";
            dtgvWaiting.Columns["DataCome"].Width = 124;
            dtgvWaiting.Columns["MAHD"].Visible = false;

        }
        /// <summary>
        /// load dah sach mónăn đang nấu
        /// </summary>
        private void loadFoodCooking()
        {
            List<ThongTinHoaDonDTO> item = cthdDAO.Instance.getDanhSachMonANDangLam();
            dtgvCooking.DataSource = item;
            dtgvCooking.Columns["STT"].Width = 50;
            dtgvCooking.Columns["TENMA"].HeaderText = "Tên món ăn";
            dtgvCooking.Columns["GIA"].Visible = false;
            dtgvCooking.Columns["SoLuongMA"].HeaderText = "Số lượng";
            dtgvCooking.Columns["SoLuongMA"].Width = 75;
            dtgvCooking.Columns["THANHTIEN"].Visible = false;
            dtgvCooking.Columns["MAMA"].Visible = false;
            dtgvCooking.Columns["MABA"].Visible = false;
            dtgvCooking.Columns["DataCome"].HeaderText = "Thời gian đến";
            dtgvCooking.Columns["DataCome"].DefaultCellStyle.Format = "hh:mm tt (dd/MM/yyyy)";
            dtgvCooking.Columns["DataCome"].Width = 124;
            dtgvCooking.Columns["MAHD"].Visible = false;

        }

        #endregion
        #region Event
        /// <summary>
        /// xác nhận đã lấy đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChecktoolStripMenuItemD_Click(object sender, EventArgs e)
        {

            if (dtgvDone.SelectedCells.Count <= 0) return;
            List<int> rowIndex = new List<int>();
            for (int i = 0; i < dtgvDone.SelectedCells.Count; i++)
            {

                foreach (int item in rowIndex)
                {
                    if (item == dtgvDone.SelectedCells[i].RowIndex)
                    {
                        return;
                    }
                }
                rowIndex.Add(dtgvDone.SelectedCells[i].RowIndex);
                string mahd = (string)dtgvDone.SelectedCells[i].OwningRow.Cells["MAHD"].Value;
                string mama = (string)dtgvDone.SelectedCells[i].OwningRow.Cells["MAMA"].Value;
                if (!cthdDAO.Instance.updateCTHD(mahd, mama, 1, 2))
                    fMessageBoxOK.Show("Xảy ra lỗi!");
            }
            loadFoodDone();
        }
        /// <summary>
        /// xác nhận đã lấy đi all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAlltoolStripMenuItemD_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dtgvDone.Rows)
            {
                string mahd = (string)item.Cells["MAHD"].Value;
                string mama = (string)item.Cells["MAMA"].Value;
                if (!cthdDAO.Instance.updateCTHD(mahd, mama, 1, 2))
                    fMessageBoxOK.Show("Xảy ra lỗi!");
            }
            loadFoodDone();
        }
        /// <summary>
        /// chuyển qua đã làm xong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChecktoolStripMenuItemC_Click(object sender, EventArgs e)
        {
            if (dtgvCooking.SelectedCells.Count <= 0) return;
            List<int> rowIndex = new List<int>();
            for (int i = 0; i < dtgvCooking.SelectedCells.Count; i++)
            {
                foreach (int item in rowIndex)
                {
                    if (item == dtgvCooking.SelectedCells[i].RowIndex)
                    {
                        return;
                    }
                }
                rowIndex.Add(dtgvCooking.SelectedCells[i].RowIndex);
                string mahd = (string)dtgvCooking.SelectedCells[i].OwningRow.Cells["MAHD"].Value;
                string mama = (string)dtgvCooking.SelectedCells[i].OwningRow.Cells["MAMA"].Value;
                if (!cthdDAO.Instance.updateCTHD(mahd, mama, 0, 1))
                    fMessageBoxOK.Show("Xảy ra lỗi!");
            }
            loadFoodCooking();
            loadFoodDone();
        }
        /// <summary>
        /// chuyển qua đã làm xong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAlltoolStripMenuItemC_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dtgvCooking.Rows)
            {
                string mahd = (string)item.Cells["MAHD"].Value;
                string mama = (string)item.Cells["MAMA"].Value;
                if (!cthdDAO.Instance.updateCTHD(mahd, mama, 0, 1))
                    fMessageBoxOK.Show("Xảy ra lỗi!");
            }
            loadFoodCooking();
            loadFoodDone();
        }
        /// <summary>
        /// Thay đổi tất cả đang chọn trạng thái sang đang làm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvWaiting.SelectedCells.Count <= 0) return;
            List<int> rowIndex = new List<int>();
            for (int i = 0; i < dtgvWaiting.SelectedCells.Count; i++)
            {
                foreach (int item in rowIndex)
                {
                    if (item == dtgvWaiting.SelectedCells[i].RowIndex)
                    {
                        return;
                    }
                }
                rowIndex.Add(dtgvWaiting.SelectedCells[i].RowIndex);
                string mahd = (string)dtgvWaiting.SelectedCells[i].OwningRow.Cells["MAHD"].Value;
                string mama = (string)dtgvWaiting.SelectedCells[i].OwningRow.Cells["MAMA"].Value;
                if (!cthdDAO.Instance.updateCTHD(mahd, mama, -1, 0))
                    fMessageBoxOK.Show("Xảy ra lỗi!");
            }
            loadFoodCooking();
            loadFoodWaiting();
        }
        /// <summary>
        /// Thay đổi tất cả trạng thái sang đang làm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dtgvWaiting.Rows)
            {
                string mahd = (string)item.Cells["MAHD"].Value;
                string mama = (string)item.Cells["MAMA"].Value;
                if (!cthdDAO.Instance.updateCTHD(mahd, mama, -1, 0))
                    fMessageBoxOK.Show("Xảy ra lỗi!");
            }
            loadFoodCooking();
            loadFoodWaiting();
        }
        /// <summary>
        /// thoát khỏi fomr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbBack_Click(object sender, EventArgs e)
        {
            Callback();
        }
        private void ptbBack_MouseEnter(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.fColor;
        }

        private void ptbBack_MouseLeave(object sender, EventArgs e)
        {
            ptbBack.BackColor = StaticClass.pnlColorMenu;
        }
        /// <summary>
        /// xử lý xét form có start không
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fKitchen_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        /// <summary>
        /// thực hiện done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvDone_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChecktoolStripMenuItemD_Click(this, new EventArgs());
        }
        /// <summary>
        /// Load list waiting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            loadFoodWaiting();
        }
        #endregion

    }
}
