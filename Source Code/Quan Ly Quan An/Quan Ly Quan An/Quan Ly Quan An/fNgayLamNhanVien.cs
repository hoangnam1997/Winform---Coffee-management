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
    
    public partial class fNgayLamNhanVien : Form
    {
        private NhanVienDTO ac;
        public fNgayLamNhanVien(NhanVienDTO ac)
        {
            InitializeComponent();
            this.ac = ac;
            loadForm();
            loadData();
        }
        #region Properties

        #endregion
        #region method
        /// <summary>
        /// load danh thông tin các controls
        /// </summary>
        void loadForm()
        {
            this.BackColor = StaticClass.pnlColorList;
        }
        /// <summary>
        /// laod danh sách ngày làm viêc nhân viên
        /// </summary>
        void loadData()
        {
            List<NgayLamSTTDTO> listNonCheck = NgayLamDAO.Instance.getDanhSachNgayChuaTinhLuongMANV(ac.MANV);
            dtgvDayWork.DataSource = listNonCheck;
            dtgvDayWork.Columns["DayWork"].HeaderText = "Ngày làm việc";
            txbSum.Text = listNonCheck.Count.ToString();

            List<NgayLamSTTDTO> listCheck = NgayLamDAO.Instance.getDanhSachNgayDaTinhLuongMANV(ac.MANV);
            dtgvDayWorkCheck.DataSource = listCheck;
            dtgvDayWorkCheck.Columns["DayWork"].HeaderText = "Ngày làm việc";
            txbSumCheck.Text = listCheck.Count.ToString();
        }
        #endregion

        #region Event
        /// <summary>
        /// đồng ý và thoát khỏi màn hình xem ngày làm việc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
