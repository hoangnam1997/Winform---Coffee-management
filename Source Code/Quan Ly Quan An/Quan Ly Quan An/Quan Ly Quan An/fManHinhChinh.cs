using Quan_Ly_Quan_An.Cons;
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
    public partial class fManHinhChinh : Form
    {
        public fManHinhChinh()
        {
            InitializeComponent();
            LoadForm();
        }
        #region Properties
        private static NhanVienDTO AccountLogin;

        #endregion
        #region Method
        /// <summary>
        /// Làm hiệu ứng khi đưa ra
        /// </summary>
        /// <param name="pnl"></param>
        /// <param name="btn"></param>
        /// <param name="lbl"></param>
        void setHieuUngLeave(Panel pnl, Button btn, Label lbl)
        {
            pnl.Width -= StaticClass.sizeLeave;
            pnl.Height -= StaticClass.sizeLeave;
            btn.Width -= StaticClass.sizeLeave;
            btn.Height -= StaticClass.sizeLeave;
            lbl.Font = new Font(lbl.Font.FontFamily, (lbl.Font.Size - StaticClass.sizeFont));
        }
        /// <summary>
        /// Làm hiệu ứng khi đưa vào
        /// </summary>
        /// <param name="pnl"></param>
        /// <param name="btn"></param>
        /// <param name="lbl"></param>
        void setHieuUngEnter(Panel pnl, Button btn, Label lbl)
        {
            pnl.Width += StaticClass.sizeLeave;
            pnl.Height += StaticClass.sizeLeave;
            btn.Width+= StaticClass.sizeLeave;
            btn.Height+= StaticClass.sizeLeave;
            lbl.Font = new Font(lbl.Font.FontFamily, (lbl.Font.Size + StaticClass.sizeFont));
        }
        /// <summary>
        /// load thông tin các controls
        /// </summary>
        private void LoadForm()
        {
            //this.BackColor = StaticClass.fColor;
            //flowLayoutPanelListJobs.BackColor = StaticClass.pnlColorList;
            //btnSupplier.ForeColor = btnStatistical.ForeColor = btnReport.ForeColor = btnPrevious.ForeColor = btnKitchen.ForeColor
            //   = btnImportFood.ForeColor = btnCreatBill.ForeColor = btnBunker.ForeColor = btnAccount.ForeColor
            //    = StaticClass.colorWord;
            //this.BackColor = StaticClass.fColor;
            MenuStripAccount.BackColor = StaticClass.pnlColorMenu;     
            
            pnlHello.BackColor = StaticClass.pnlColorMenu;
        }

        /// <summary>
        /// tạo 1 form kết nối csdl để đăng nhập.
        /// </summary>
        void Connect()
        {
            this.Visible = false;
            fDangNhap f = new fDangNhap();
            f.ValueChanged += F_ValueChanged;
            f.ShowDialog();

        }
        
        /// <summary>
        /// Xử lý sự kiện khi logout account
        /// </summary>
        void LogOut()
        {
            MenuStripAccount.Visible = false;
            pnlHello.Visible = false;
            flowLayoutPanelListJobs.Visible = false;

        }
        #endregion
        #region Event
        /// <summary>
        /// gọi form thực hiên việc sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThayDoiLoaiMonAN f = new fThayDoiLoaiMonAN();
            f.ShowDialog();
        }
        /// <summary>
        /// thực hiện xóa bàn ăn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fXoaBanAn f = new fXoaBanAn();
            f.ShowDialog();
        }
        /// <summary>
        /// thêm loại món ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCategoryLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThemLoaiMA f = new fThemLoaiMA();
            f.ShowDialog();
        }
        /// <summary>
        /// thay đổi trạng thái
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThayDoiTrangThaiBanAn f = new fThayDoiTrangThaiBanAn();
            f.ShowDialog();
        }
        /// <summary>
        /// Thêm bàn ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddtableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThemBanAn f = new fThemBanAn();
            f.ShowDialog();
        }
        
        /// <summary>
        /// Hiện thông tin làm việc của tài khoản nhân viên đang nhập
        /// hiển thị những ngày làm việc chưa được trả tiền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfomationWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNgayLamNhanVien f = new fNgayLamNhanVien(AccountLogin);
            f.ShowDialog();
        }
        /// <summary>
        /// cập nhật mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThayDoiMatKhau f = new fThayDoiMatKhau(AccountLogin);
            f.ShowDialog();
        }
        /// <summary>
        /// Cập nhật thông tin cá nhân
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myInfomationtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThayDoiThongTinNhanVien f = new fThayDoiThongTinNhanVien(AccountLogin);
            f.ChangeInfomation += F_ChangeInfomation;
            f.ShowDialog();
        }
        /// <summary>
        /// thay đổi thông tin account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_ChangeInfomation(object sender, eventChangeInfoomation e)
        {
            AccountLogin = e.getAccount();

        }


        /// <summary>
        /// Xử lý sự kiện khi đăng nhập thành công
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_ValueChanged(object sender, EventLogin e)
        {
            this.Visible = true;
            AccountLogin = e.getisConnect();
            AccountToolStripMenuItem.Visible = true;
            MenuStripAccount.Visible = true;
            pnlHello.Visible = true;
            flowLayoutPanelListJobs.Visible = true;
            switch (AccountLogin.PHANQUYEN)
            {
                case 0:
                    SettingToolStripMenuItem.Visible = true;
                    pnlCall.Visible = true;
                    pnlPre.Visible = true;
                    pnlKitchen.Visible = true;
                    pnlBunker.Visible = true;
                    pnlStatistical.Visible = true;
                    pnlImport.Visible = true;
                    pnlreport.Visible = true;
                    pnlAccount.Visible = true;
                    pnlSuplier.Visible = true;
                    break;
                case 1:
                    SettingToolStripMenuItem.Visible = false;
                    pnlCall.Visible = true;
                    pnlPre.Visible = true;
                    pnlKitchen.Visible = false;
                    pnlBunker.Visible = false;
                    pnlStatistical.Visible = false;
                    pnlImport.Visible = false;
                    pnlreport.Visible = false;
                    pnlAccount.Visible = false;
                    pnlSuplier.Visible = false;
                    break;
                case 2:
                    SettingToolStripMenuItem.Visible = false;
                    pnlCall.Visible = false;
                    pnlPre.Visible = false;
                    pnlKitchen.Visible = true;
                    pnlBunker.Visible = true;
                    pnlStatistical.Visible = false;
                    pnlImport.Visible = false;
                    pnlreport.Visible = false;
                    pnlAccount.Visible = false;
                    pnlSuplier.Visible = false;
                    break;
                case 3:
                    SettingToolStripMenuItem.Visible = false;
                    pnlCall.Visible = false;
                    pnlPre.Visible = false;
                    pnlKitchen.Visible = false;
                    pnlBunker.Visible = false;
                    pnlStatistical.Visible = true;
                    pnlImport.Visible = true;
                    pnlreport.Visible = true;
                    pnlAccount.Visible = false;
                    pnlSuplier.Visible = false;
                    break;
                default:
                    LogOut();
                    Connect();
                    break;

            }

               
        }
        /// <summary>
        /// hiển thị f đặt bàn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            fDatBanTruoc f = new fDatBanTruoc(AccountLogin);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f bếp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKitchen_Click(object sender, EventArgs e)
        {
            fBep f = new fBep();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBunker_Click(object sender, EventArgs e)
        {
            fQuanLyKho f = new fQuanLyKho();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f thống kê
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatistical_Click(object sender, EventArgs e)
        {
            fThongKe f = new fThongKe();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f báo cáo thu chi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            fBaoCaoThuChi f = new fBaoCaoThuChi();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f nhập thục phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportFood_Click(object sender, EventArgs e)
        {
            fNhapThucPham f = new fNhapThucPham();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f thông tin nhà cung câp và khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            fNhaCCvaKHACH f = new fNhaCCvaKHACH();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// hiển thị f lập hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatBill_Click(object sender, EventArgs e)
        {
            fLapHoaDon f = new fLapHoaDon(AccountLogin);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void fManager_Load(object sender, EventArgs e)
        {

            Connect();
        }

        private void fManager_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
            Connect();
        }

        #region setColor

        

        private void btnCreatBill_MouseEnter(object sender, EventArgs e)
        {
            lblCall.ForeColor = Color.Black;
            setHieuUngEnter(pnlCall, btnCreatBill, lblCall);
        }

        private void btnCreatBill_MouseLeave(object sender, EventArgs e)
        {
            lblCall.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlCall, btnCreatBill, lblCall);
        }
        private void btnPrevious_MouseLeave(object sender, EventArgs e)
        {
            lblPre.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlPre, btnPrevious, lblPre);
        }

        private void btnPrevious_MouseEnter(object sender, EventArgs e)
        {
            lblPre.ForeColor = Color.Black;
            setHieuUngEnter(pnlPre, btnPrevious, lblPre);
        }
        private void btnKitchen_MouseEnter(object sender, EventArgs e)
        {
            lblKitchen.ForeColor = Color.Black;
            setHieuUngEnter(pnlKitchen, btnKitchen, lblKitchen);
        }

        private void btnKitchen_MouseLeave(object sender, EventArgs e)
        {
            lblKitchen.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlKitchen, btnKitchen, lblKitchen);
        }
        private void btnBunker_MouseEnter(object sender, EventArgs e)
        {
            lblBunker.ForeColor = Color.Black;
            setHieuUngEnter(pnlBunker, btnBunker, lblBunker);
        }

        private void btnBunker_MouseLeave(object sender, EventArgs e)
        {
            lblBunker.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlBunker, btnBunker, lblBunker);
        }
        private void btnStatistical_MouseEnter(object sender, EventArgs e)
        {
            lblStatistical.ForeColor = Color.Black;
            setHieuUngEnter(pnlStatistical, btnStatistical, lblStatistical);
        }

        private void btnStatistical_MouseLeave(object sender, EventArgs e)
        {
            lblStatistical.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlStatistical, btnStatistical, lblStatistical);
        }
        private void btnImportFood_MouseEnter(object sender, EventArgs e)
        {
            lblImport.ForeColor = Color.Black;
            setHieuUngEnter(pnlImport, btnImportFood, lblImport);
        }

        private void btnImportFood_MouseLeave(object sender, EventArgs e)
        {
            lblImport.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlImport, btnImportFood, lblImport);
        }

        private void btnReport_MouseEnter(object sender, EventArgs e)
        {
            lblReport.ForeColor = Color.Black;
            setHieuUngEnter(pnlreport, btnReport, lblReport);
        }

        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            lblReport.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlreport, btnReport, lblReport);
        }
        private void btnAccount_MouseEnter(object sender, EventArgs e)
        {
            lblAccount.ForeColor = Color.Black;
            setHieuUngEnter(pnlAccount, btnAccount, lblAccount);
        }

        private void btnAccount_MouseLeave(object sender, EventArgs e)
        {
            lblAccount.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlAccount, btnAccount, lblAccount);
        }
        private void btnSupplier_MouseEnter(object sender, EventArgs e)
        {
            lblSupiler.ForeColor = Color.Black;
            setHieuUngEnter(pnlSuplier, btnSupplier, lblSupiler);
        }

        private void btnSupplier_MouseLeave(object sender, EventArgs e)
        {
            lblSupiler.ForeColor = Color.MidnightBlue;
            setHieuUngLeave(pnlSuplier, btnSupplier, lblSupiler);
        }
        #endregion
        /// <summary>
        /// hiển thị form thay đổi phần trăm trả trước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void persentPreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPhanTramTraTruoc f = new fPhanTramTraTruoc();
            f.ShowDialog();
        }
        /// <summary>
        /// Hiển thị form thay đổi mức nhập thực phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MucNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMucNhap f = new fMucNhap();
            f.ShowDialog();
        }
        /// <summary>
        /// gọi form thực hiện xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fXoaLoaiMonAn f = new fXoaLoaiMonAn();
            f.ShowDialog();
        }
        #endregion

    }
}
