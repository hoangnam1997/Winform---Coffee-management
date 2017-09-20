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
    public partial class fMessageBox : Form
    {
        public fMessageBox()
        {
            InitializeComponent();
        }

        #region propertise
        static DialogResult result = DialogResult.Cancel;
        #endregion

        #region method 
        #endregion

        /// <summary>
        /// hiện form message
        /// </summary>
        /// <param name="mess"></param>
        /// <returns></returns>
        public static DialogResult Show(string mess)
        {
            result = DialogResult.Cancel;
            fMessageBox f = new fMessageBox();
            f.lblMess.Text = mess;
            f.ShowDialog();
            return result;
        }
        #region event
        /// <summary>
        /// gán giá trị trả về cho DialogResult bằng cancle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// gán giá trị trả về cho DialogResult bằng cancle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            this.Close();
        }
        #endregion


    }
}
