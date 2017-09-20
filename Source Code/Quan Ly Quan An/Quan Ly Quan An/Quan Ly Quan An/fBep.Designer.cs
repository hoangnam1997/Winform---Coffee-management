namespace Quan_Ly_Quan_An
{
    partial class fBep
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBep));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.ptbBack = new System.Windows.Forms.PictureBox();
            this.pnlListFoodWaiting = new System.Windows.Forms.Panel();
            this.lblListFoodWaiting = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvWaiting = new System.Windows.Forms.DataGridView();
            this.ctmsW = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkToolStripMenuItemW = new System.Windows.Forms.ToolStripMenuItem();
            this.checkallToolStripMenuItemW = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlListFoodCooking = new System.Windows.Forms.Panel();
            this.lblListFoodCooking = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvCooking = new System.Windows.Forms.DataGridView();
            this.ctmsC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChecktoolStripMenuItemC = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckAlltoolStripMenuItemC = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlListFoodDone = new System.Windows.Forms.Panel();
            this.lblListFoodDone = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgvDone = new System.Windows.Forms.DataGridView();
            this.ctmsD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChecktoolStripMenuItemD = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckAlltoolStripMenuItemD = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBack)).BeginInit();
            this.pnlListFoodWaiting.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvWaiting)).BeginInit();
            this.ctmsW.SuspendLayout();
            this.pnlListFoodCooking.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCooking)).BeginInit();
            this.ctmsC.SuspendLayout();
            this.pnlListFoodDone.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDone)).BeginInit();
            this.ctmsD.SuspendLayout();
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
            // pnlListFoodWaiting
            // 
            this.pnlListFoodWaiting.Controls.Add(this.lblListFoodWaiting);
            this.pnlListFoodWaiting.Location = new System.Drawing.Point(27, 36);
            this.pnlListFoodWaiting.Name = "pnlListFoodWaiting";
            this.pnlListFoodWaiting.Size = new System.Drawing.Size(392, 40);
            this.pnlListFoodWaiting.TabIndex = 19;
            // 
            // lblListFoodWaiting
            // 
            this.lblListFoodWaiting.AutoSize = true;
            this.lblListFoodWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListFoodWaiting.Location = new System.Drawing.Point(106, 12);
            this.lblListFoodWaiting.Name = "lblListFoodWaiting";
            this.lblListFoodWaiting.Size = new System.Drawing.Size(148, 22);
            this.lblListFoodWaiting.TabIndex = 0;
            this.lblListFoodWaiting.Text = "Món ăn đang chờ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvWaiting);
            this.panel1.Location = new System.Drawing.Point(27, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 627);
            this.panel1.TabIndex = 20;
            // 
            // dtgvWaiting
            // 
            this.dtgvWaiting.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvWaiting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvWaiting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvWaiting.ContextMenuStrip = this.ctmsW;
            this.dtgvWaiting.Location = new System.Drawing.Point(0, 0);
            this.dtgvWaiting.Name = "dtgvWaiting";
            this.dtgvWaiting.ReadOnly = true;
            this.dtgvWaiting.Size = new System.Drawing.Size(392, 617);
            this.dtgvWaiting.TabIndex = 0;
            // 
            // ctmsW
            // 
            this.ctmsW.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItemW,
            this.checkallToolStripMenuItemW});
            this.ctmsW.Name = "ctmsW";
            this.ctmsW.Size = new System.Drawing.Size(236, 48);
            // 
            // checkToolStripMenuItemW
            // 
            this.checkToolStripMenuItemW.Name = "checkToolStripMenuItemW";
            this.checkToolStripMenuItemW.Size = new System.Drawing.Size(235, 22);
            this.checkToolStripMenuItemW.Text = "Xác nhận những món đã chọn";
            this.checkToolStripMenuItemW.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // checkallToolStripMenuItemW
            // 
            this.checkallToolStripMenuItemW.Name = "checkallToolStripMenuItemW";
            this.checkallToolStripMenuItemW.Size = new System.Drawing.Size(235, 22);
            this.checkallToolStripMenuItemW.Text = "Xác nhận tất cả";
            this.checkallToolStripMenuItemW.Click += new System.EventHandler(this.checkallToolStripMenuItem_Click);
            // 
            // pnlListFoodCooking
            // 
            this.pnlListFoodCooking.Controls.Add(this.lblListFoodCooking);
            this.pnlListFoodCooking.Location = new System.Drawing.Point(487, 36);
            this.pnlListFoodCooking.Name = "pnlListFoodCooking";
            this.pnlListFoodCooking.Size = new System.Drawing.Size(392, 40);
            this.pnlListFoodCooking.TabIndex = 19;
            // 
            // lblListFoodCooking
            // 
            this.lblListFoodCooking.AutoSize = true;
            this.lblListFoodCooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListFoodCooking.Location = new System.Drawing.Point(106, 12);
            this.lblListFoodCooking.Name = "lblListFoodCooking";
            this.lblListFoodCooking.Size = new System.Drawing.Size(147, 22);
            this.lblListFoodCooking.TabIndex = 0;
            this.lblListFoodCooking.Text = "Món ăn đang làm";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvCooking);
            this.panel3.Location = new System.Drawing.Point(487, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(392, 627);
            this.panel3.TabIndex = 20;
            // 
            // dtgvCooking
            // 
            this.dtgvCooking.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvCooking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvCooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCooking.ContextMenuStrip = this.ctmsC;
            this.dtgvCooking.Location = new System.Drawing.Point(0, 0);
            this.dtgvCooking.Name = "dtgvCooking";
            this.dtgvCooking.ReadOnly = true;
            this.dtgvCooking.Size = new System.Drawing.Size(392, 617);
            this.dtgvCooking.TabIndex = 0;
            // 
            // ctmsC
            // 
            this.ctmsC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChecktoolStripMenuItemC,
            this.CheckAlltoolStripMenuItemC});
            this.ctmsC.Name = "ctmsW";
            this.ctmsC.Size = new System.Drawing.Size(236, 48);
            // 
            // ChecktoolStripMenuItemC
            // 
            this.ChecktoolStripMenuItemC.Name = "ChecktoolStripMenuItemC";
            this.ChecktoolStripMenuItemC.Size = new System.Drawing.Size(235, 22);
            this.ChecktoolStripMenuItemC.Text = "Xác nhận những món đã chọn";
            this.ChecktoolStripMenuItemC.Click += new System.EventHandler(this.ChecktoolStripMenuItemC_Click);
            // 
            // CheckAlltoolStripMenuItemC
            // 
            this.CheckAlltoolStripMenuItemC.Name = "CheckAlltoolStripMenuItemC";
            this.CheckAlltoolStripMenuItemC.Size = new System.Drawing.Size(235, 22);
            this.CheckAlltoolStripMenuItemC.Text = "Xác nhận tất cả";
            this.CheckAlltoolStripMenuItemC.Click += new System.EventHandler(this.CheckAlltoolStripMenuItemC_Click);
            // 
            // pnlListFoodDone
            // 
            this.pnlListFoodDone.Controls.Add(this.lblListFoodDone);
            this.pnlListFoodDone.Location = new System.Drawing.Point(947, 36);
            this.pnlListFoodDone.Name = "pnlListFoodDone";
            this.pnlListFoodDone.Size = new System.Drawing.Size(392, 40);
            this.pnlListFoodDone.TabIndex = 19;
            // 
            // lblListFoodDone
            // 
            this.lblListFoodDone.AutoSize = true;
            this.lblListFoodDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListFoodDone.Location = new System.Drawing.Point(106, 12);
            this.lblListFoodDone.Name = "lblListFoodDone";
            this.lblListFoodDone.Size = new System.Drawing.Size(171, 22);
            this.lblListFoodDone.TabIndex = 0;
            this.lblListFoodDone.Text = "Món ăn đã làm xong";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtgvDone);
            this.panel5.Location = new System.Drawing.Point(947, 83);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(392, 627);
            this.panel5.TabIndex = 20;
            // 
            // dtgvDone
            // 
            this.dtgvDone.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvDone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvDone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDone.ContextMenuStrip = this.ctmsD;
            this.dtgvDone.Location = new System.Drawing.Point(0, 0);
            this.dtgvDone.Name = "dtgvDone";
            this.dtgvDone.ReadOnly = true;
            this.dtgvDone.Size = new System.Drawing.Size(392, 617);
            this.dtgvDone.TabIndex = 0;
            this.dtgvDone.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dtgvDone_MouseDoubleClick);
            // 
            // ctmsD
            // 
            this.ctmsD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChecktoolStripMenuItemD,
            this.CheckAlltoolStripMenuItemD});
            this.ctmsD.Name = "ctmsW";
            this.ctmsD.Size = new System.Drawing.Size(236, 48);
            // 
            // ChecktoolStripMenuItemD
            // 
            this.ChecktoolStripMenuItemD.Name = "ChecktoolStripMenuItemD";
            this.ChecktoolStripMenuItemD.Size = new System.Drawing.Size(235, 22);
            this.ChecktoolStripMenuItemD.Text = "Xác nhận những món đã chọn";
            this.ChecktoolStripMenuItemD.Click += new System.EventHandler(this.ChecktoolStripMenuItemD_Click);
            // 
            // CheckAlltoolStripMenuItemD
            // 
            this.CheckAlltoolStripMenuItemD.Name = "CheckAlltoolStripMenuItemD";
            this.CheckAlltoolStripMenuItemD.Size = new System.Drawing.Size(235, 22);
            this.CheckAlltoolStripMenuItemD.Text = "Xác nhận tất cả";
            this.CheckAlltoolStripMenuItemD.Click += new System.EventHandler(this.CheckAlltoolStripMenuItemD_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fBep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1354, 715);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlListFoodDone);
            this.Controls.Add(this.pnlListFoodCooking);
            this.Controls.Add(this.pnlListFoodWaiting);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fBep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quan Ly Quan An";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fKitchen_FormClosing);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBack)).EndInit();
            this.pnlListFoodWaiting.ResumeLayout(false);
            this.pnlListFoodWaiting.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvWaiting)).EndInit();
            this.ctmsW.ResumeLayout(false);
            this.pnlListFoodCooking.ResumeLayout(false);
            this.pnlListFoodCooking.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCooking)).EndInit();
            this.ctmsC.ResumeLayout(false);
            this.pnlListFoodDone.ResumeLayout(false);
            this.pnlListFoodDone.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDone)).EndInit();
            this.ctmsD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox ptbBack;
        private System.Windows.Forms.Panel pnlListFoodWaiting;
        private System.Windows.Forms.Label lblListFoodWaiting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvWaiting;
        private System.Windows.Forms.Panel pnlListFoodCooking;
        private System.Windows.Forms.Label lblListFoodCooking;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvCooking;
        private System.Windows.Forms.Panel pnlListFoodDone;
        private System.Windows.Forms.Label lblListFoodDone;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgvDone;
        private System.Windows.Forms.ContextMenuStrip ctmsW;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItemW;
        private System.Windows.Forms.ToolStripMenuItem checkallToolStripMenuItemW;
        private System.Windows.Forms.ContextMenuStrip ctmsC;
        private System.Windows.Forms.ToolStripMenuItem ChecktoolStripMenuItemC;
        private System.Windows.Forms.ToolStripMenuItem CheckAlltoolStripMenuItemC;
        private System.Windows.Forms.ContextMenuStrip ctmsD;
        private System.Windows.Forms.ToolStripMenuItem ChecktoolStripMenuItemD;
        private System.Windows.Forms.ToolStripMenuItem CheckAlltoolStripMenuItemD;
        private System.Windows.Forms.Timer timer1;
    }
}