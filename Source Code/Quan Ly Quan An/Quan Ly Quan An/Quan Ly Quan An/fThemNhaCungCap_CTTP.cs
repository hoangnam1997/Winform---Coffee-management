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
    public partial class fThemNhaCungCap_CTTP : Form
    {
        public fThemNhaCungCap_CTTP()
        {
            InitializeComponent();
            cbThucPham.DataSource = NhaCungCapDAO.Instance.getListNhaCungCap();
        }
        /// <summary>
        /// Thực hiện tim kiêm trong dnah sách item cb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbThucPham_KeyDown(object sender, KeyEventArgs e)
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

        private event EventHandler<themNCC> _eventSent;
        public event EventHandler<themNCC> Event
        {
            add { _eventSent += value; }
            remove { _eventSent -= value; }
        }

        /// <summary>
        /// thoát khỏi forrm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO ncc = cbThucPham.SelectedItem as NhaCungCapDTO;
            if (ncc!=null)
            {
                if(_eventSent!=null)
                {
                    _eventSent(this, new themNCC(ncc));
                    this.Close();
                }
            }
        }
    }
    public class themNCC : EventArgs
    {
        NhaCungCapDTO nhaCC;
        public themNCC(NhaCungCapDTO nhcc)
        {
            this.NhaCC = nhcc;
        }

        public NhaCungCapDTO NhaCC
        {
            get
            {
                return nhaCC;
            }

            set
            {
                nhaCC = value;
            }
        }
    }
}
