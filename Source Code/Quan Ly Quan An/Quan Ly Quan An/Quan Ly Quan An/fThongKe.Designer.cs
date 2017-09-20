namespace Quan_Ly_Quan_An
{
    partial class fThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThongKe));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.ptbBack = new System.Windows.Forms.PictureBox();
            this.pnlResultMenu = new System.Windows.Forms.Panel();
            this.lblResultmenu = new System.Windows.Forms.Label();
            this.pnlResultList = new System.Windows.Forms.Panel();
            this.dtgvKetQua = new System.Windows.Forms.DataGridView();
            this.pnlStatisticalMenu = new System.Windows.Forms.Panel();
            this.lblStatisticalmenu = new System.Windows.Forms.Label();
            this.pnlStatisticalList = new System.Windows.Forms.Panel();
            this.cbThongKe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpkDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpkTuNgay = new System.Windows.Forms.DateTimePicker();
            this.txbSearchFood = new System.Windows.Forms.TextBox();
            this.lblFromDay = new System.Windows.Forms.Label();
            this.lblToday = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.ptbSearchFood = new System.Windows.Forms.PictureBox();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBack)).BeginInit();
            this.pnlResultMenu.SuspendLayout();
            this.pnlResultList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKetQua)).BeginInit();
            this.pnlStatisticalMenu.SuspendLayout();
            this.pnlStatisticalList.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSearchFood)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.ptbBack);
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1360, 30);
            this.pnlMenu.TabIndex = 12;
            // 
            // ptbBack
            // 
            this.ptbBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbBack.Image = global::Quan_Ly_Quan_An.Properties.Resources.goback;
            this.ptbBack.InitialImage = null;
            this.ptbBack.Location = new System.Drawing.Point(0, 0);
            this.ptbBack.Name = "ptbBack";
            this.ptbBack.Size = new System.Drawing.Size(30, 30);
            this.ptbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbBack.TabIndex = 0;
            this.ptbBack.TabStop = false;
            this.ptbBack.Click += new System.EventHandler(this.ptbBack_Click);
            this.ptbBack.MouseEnter += new System.EventHandler(this.ptbBack_MouseEnter);
            this.ptbBack.MouseLeave += new System.EventHandler(this.ptbBack_MouseLeave);
            // 
            // pnlResultMenu
            // 
            this.pnlResultMenu.Controls.Add(this.lblResultmenu);
            this.pnlResultMenu.Location = new System.Drawing.Point(599, 55);
            this.pnlResultMenu.Name = "pnlResultMenu";
            this.pnlResultMenu.Size = new System.Drawing.Size(715, 40);
            this.pnlResultMenu.TabIndex = 14;
            // 
            // lblResultmenu
            // 
            this.lblResultmenu.AutoSize = true;
            this.lblResultmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultmenu.ForeColor = System.Drawing.Color.Black;
            this.lblResultmenu.Location = new System.Drawing.Point(296, 9);
            this.lblResultmenu.Name = "lblResultmenu";
            this.lblResultmenu.Size = new System.Drawing.Size(72, 22);
            this.lblResultmenu.TabIndex = 2;
            this.lblResultmenu.Text = "Kết quả";
            // 
            // pnlResultList
            // 
            this.pnlResultList.Controls.Add(this.btnChiTiet);
            this.pnlResultList.Controls.Add(this.dtgvKetQua);
            this.pnlResultList.Location = new System.Drawing.Point(599, 105);
            this.pnlResultList.Name = "pnlResultList";
            this.pnlResultList.Size = new System.Drawing.Size(715, 555);
            this.pnlResultList.TabIndex = 1;
            // 
            // dtgvKetQua
            // 
            this.dtgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvKetQua.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvKetQua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKetQua.Location = new System.Drawing.Point(0, 0);
            this.dtgvKetQua.Name = "dtgvKetQua";
            this.dtgvKetQua.ReadOnly = true;
            this.dtgvKetQua.Size = new System.Drawing.Size(715, 491);
            this.dtgvKetQua.TabIndex = 3;
            // 
            // pnlStatisticalMenu
            // 
            this.pnlStatisticalMenu.Controls.Add(this.lblStatisticalmenu);
            this.pnlStatisticalMenu.Location = new System.Drawing.Point(48, 55);
            this.pnlStatisticalMenu.Name = "pnlStatisticalMenu";
            this.pnlStatisticalMenu.Size = new System.Drawing.Size(500, 40);
            this.pnlStatisticalMenu.TabIndex = 16;
            // 
            // lblStatisticalmenu
            // 
            this.lblStatisticalmenu.AutoSize = true;
            this.lblStatisticalmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticalmenu.ForeColor = System.Drawing.Color.Black;
            this.lblStatisticalmenu.Location = new System.Drawing.Point(174, 9);
            this.lblStatisticalmenu.Name = "lblStatisticalmenu";
            this.lblStatisticalmenu.Size = new System.Drawing.Size(86, 22);
            this.lblStatisticalmenu.TabIndex = 2;
            this.lblStatisticalmenu.Text = "Thống kê";
            // 
            // pnlStatisticalList
            // 
            this.pnlStatisticalList.Controls.Add(this.cbThongKe);
            this.pnlStatisticalList.Controls.Add(this.label5);
            this.pnlStatisticalList.Controls.Add(this.dtpkDenNgay);
            this.pnlStatisticalList.Controls.Add(this.dtpkTuNgay);
            this.pnlStatisticalList.Controls.Add(this.txbSearchFood);
            this.pnlStatisticalList.Controls.Add(this.lblFromDay);
            this.pnlStatisticalList.Controls.Add(this.lblToday);
            this.pnlStatisticalList.Controls.Add(this.label1);
            this.pnlStatisticalList.Controls.Add(this.panel3);
            this.pnlStatisticalList.Location = new System.Drawing.Point(48, 105);
            this.pnlStatisticalList.Name = "pnlStatisticalList";
            this.pnlStatisticalList.Size = new System.Drawing.Size(500, 555);
            this.pnlStatisticalList.TabIndex = 0;
            // 
            // cbThongKe
            // 
            this.cbThongKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThongKe.Location = new System.Drawing.Point(172, 153);
            this.cbThongKe.Name = "cbThongKe";
            this.cbThongKe.Size = new System.Drawing.Size(254, 28);
            this.cbThongKe.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(32, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Thống kê theo:";
            // 
            // dtpkDenNgay
            // 
            this.dtpkDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkDenNgay.Location = new System.Drawing.Point(171, 83);
            this.dtpkDenNgay.Name = "dtpkDenNgay";
            this.dtpkDenNgay.Size = new System.Drawing.Size(253, 27);
            this.dtpkDenNgay.TabIndex = 1;
            // 
            // dtpkTuNgay
            // 
            this.dtpkTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkTuNgay.Location = new System.Drawing.Point(170, 12);
            this.dtpkTuNgay.Name = "dtpkTuNgay";
            this.dtpkTuNgay.Size = new System.Drawing.Size(254, 27);
            this.dtpkTuNgay.TabIndex = 0;
            // 
            // txbSearchFood
            // 
            this.txbSearchFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearchFood.Location = new System.Drawing.Point(172, 219);
            this.txbSearchFood.Multiline = true;
            this.txbSearchFood.Name = "txbSearchFood";
            this.txbSearchFood.Size = new System.Drawing.Size(254, 28);
            this.txbSearchFood.TabIndex = 3;
            this.txbSearchFood.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSearchFood_KeyDown);
            // 
            // lblFromDay
            // 
            this.lblFromDay.AutoSize = true;
            this.lblFromDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDay.ForeColor = System.Drawing.Color.Black;
            this.lblFromDay.Location = new System.Drawing.Point(32, 12);
            this.lblFromDay.Name = "lblFromDay";
            this.lblFromDay.Size = new System.Drawing.Size(81, 22);
            this.lblFromDay.TabIndex = 8;
            this.lblFromDay.Text = "Từ ngày:";
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToday.ForeColor = System.Drawing.Color.Black;
            this.lblToday.Location = new System.Drawing.Point(32, 88);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(92, 22);
            this.lblToday.TabIndex = 9;
            this.lblToday.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblSearch);
            this.panel3.Controls.Add(this.ptbSearchFood);
            this.panel3.Location = new System.Drawing.Point(336, 281);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(88, 70);
            this.panel3.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblSearch.ForeColor = System.Drawing.Color.Silver;
            this.lblSearch.Location = new System.Drawing.Point(1, 42);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(86, 22);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Thống kê";
            this.lblSearch.Click += new System.EventHandler(this.ptbSearchFood_Click);
            this.lblSearch.MouseEnter += new System.EventHandler(this.lblSearch_MouseEnter);
            this.lblSearch.MouseLeave += new System.EventHandler(this.lblSearch_MouseLeave);
            // 
            // ptbSearchFood
            // 
            this.ptbSearchFood.Image = global::Quan_Ly_Quan_An.Properties.Resources.search;
            this.ptbSearchFood.Location = new System.Drawing.Point(26, 9);
            this.ptbSearchFood.Name = "ptbSearchFood";
            this.ptbSearchFood.Size = new System.Drawing.Size(28, 28);
            this.ptbSearchFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSearchFood.TabIndex = 4;
            this.ptbSearchFood.TabStop = false;
            this.ptbSearchFood.Click += new System.EventHandler(this.ptbSearchFood_Click);
            this.ptbSearchFood.MouseEnter += new System.EventHandler(this.ptbSearchFood_MouseEnter);
            this.ptbSearchFood.MouseLeave += new System.EventHandler(this.ptbSearchFood_MouseLeave);
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Location = new System.Drawing.Point(634, 499);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(78, 44);
            this.btnChiTiet.TabIndex = 4;
            this.btnChiTiet.Text = "Chi tiết";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // fThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.pnlResultMenu);
            this.Controls.Add(this.pnlResultList);
            this.Controls.Add(this.pnlStatisticalMenu);
            this.Controls.Add(this.pnlStatisticalList);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quan Ly Quan An";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBack)).EndInit();
            this.pnlResultMenu.ResumeLayout(false);
            this.pnlResultMenu.PerformLayout();
            this.pnlResultList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKetQua)).EndInit();
            this.pnlStatisticalMenu.ResumeLayout(false);
            this.pnlStatisticalMenu.PerformLayout();
            this.pnlStatisticalList.ResumeLayout(false);
            this.pnlStatisticalList.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSearchFood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox ptbBack;
        private System.Windows.Forms.Panel pnlResultMenu;
        private System.Windows.Forms.Label lblResultmenu;
        private System.Windows.Forms.Panel pnlResultList;
        private System.Windows.Forms.DataGridView dtgvKetQua;
        private System.Windows.Forms.Panel pnlStatisticalMenu;
        private System.Windows.Forms.Label lblStatisticalmenu;
        private System.Windows.Forms.Panel pnlStatisticalList;
        private System.Windows.Forms.ComboBox cbThongKe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpkDenNgay;
        private System.Windows.Forms.DateTimePicker dtpkTuNgay;
        private System.Windows.Forms.TextBox txbSearchFood;
        private System.Windows.Forms.Label lblFromDay;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.PictureBox ptbSearchFood;
        private System.Windows.Forms.Button btnChiTiet;
    }
}