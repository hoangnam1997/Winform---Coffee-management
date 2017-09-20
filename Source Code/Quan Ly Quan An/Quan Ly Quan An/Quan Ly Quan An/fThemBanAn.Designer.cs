namespace Quan_Ly_Quan_An
{
    partial class fThemBanAn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThemBanAn));
            this.txbMABA = new System.Windows.Forms.TextBox();
            this.lblmanv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTRANGTHAI = new System.Windows.Forms.ComboBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbMABA
            // 
            this.txbMABA.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMABA.Location = new System.Drawing.Point(162, 6);
            this.txbMABA.Multiline = true;
            this.txbMABA.Name = "txbMABA";
            this.txbMABA.Size = new System.Drawing.Size(183, 28);
            this.txbMABA.TabIndex = 0;
            this.txbMABA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbMABA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMABA_KeyDown);
            // 
            // lblmanv
            // 
            this.lblmanv.AutoSize = true;
            this.lblmanv.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanv.ForeColor = System.Drawing.Color.Black;
            this.lblmanv.Location = new System.Drawing.Point(12, 9);
            this.lblmanv.Name = "lblmanv";
            this.lblmanv.Size = new System.Drawing.Size(74, 22);
            this.lblmanv.TabIndex = 14;
            this.lblmanv.Text = "Mã bàn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Trạng thái:";
            // 
            // cbTRANGTHAI
            // 
            this.cbTRANGTHAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTRANGTHAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTRANGTHAI.FormattingEnabled = true;
            this.cbTRANGTHAI.Location = new System.Drawing.Point(162, 49);
            this.cbTRANGTHAI.Name = "cbTRANGTHAI";
            this.cbTRANGTHAI.Size = new System.Drawing.Size(183, 28);
            this.cbTRANGTHAI.TabIndex = 1;
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(268, 97);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(77, 32);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "Hủy";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(185, 97);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(77, 32);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Thêm";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // fThemBanAn
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cbTRANGTHAI);
            this.Controls.Add(this.txbMABA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblmanv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fThemBanAn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quan Ly Quan An";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbMABA;
        private System.Windows.Forms.Label lblmanv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTRANGTHAI;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnAccept;
    }
}