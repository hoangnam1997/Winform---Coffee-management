namespace Quan_Ly_Quan_An
{
    partial class fThemThucPhamCTMA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThemThucPhamCTMA));
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaTP = new System.Windows.Forms.Label();
            this.txbKhoiLuongTP = new System.Windows.Forms.TextBox();
            this.cbThucPham = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(268, 74);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(77, 32);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "Hủy";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(185, 74);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(77, 32);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Thêm";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Khối lượng:";
            // 
            // lblMaTP
            // 
            this.lblMaTP.AutoSize = true;
            this.lblMaTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTP.ForeColor = System.Drawing.Color.Black;
            this.lblMaTP.Location = new System.Drawing.Point(12, 9);
            this.lblMaTP.Name = "lblMaTP";
            this.lblMaTP.Size = new System.Drawing.Size(110, 22);
            this.lblMaTP.TabIndex = 20;
            this.lblMaTP.Text = "Nguyên liệu:";
            // 
            // txbKhoiLuongTP
            // 
            this.txbKhoiLuongTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbKhoiLuongTP.Location = new System.Drawing.Point(162, 40);
            this.txbKhoiLuongTP.Multiline = true;
            this.txbKhoiLuongTP.Name = "txbKhoiLuongTP";
            this.txbKhoiLuongTP.Size = new System.Drawing.Size(183, 28);
            this.txbKhoiLuongTP.TabIndex = 2;
            this.txbKhoiLuongTP.Text = "1";
            this.txbKhoiLuongTP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbKhoiLuongTP_KeyDown);
            this.txbKhoiLuongTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbKhoiLuongTP_KeyPress);
            // 
            // cbThucPham
            // 
            this.cbThucPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThucPham.Location = new System.Drawing.Point(162, 6);
            this.cbThucPham.Name = "cbThucPham";
            this.cbThucPham.Size = new System.Drawing.Size(183, 28);
            this.cbThucPham.TabIndex = 0;
            this.cbThucPham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_KeyDown);
            // 
            // fThemThucPhamCTMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(384, 124);
            this.Controls.Add(this.cbThucPham);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txbKhoiLuongTP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMaTP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fThemThucPhamCTMA";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quan Ly Quan An";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaTP;
        private System.Windows.Forms.TextBox txbKhoiLuongTP;
        private System.Windows.Forms.ComboBox cbThucPham;
    }
}