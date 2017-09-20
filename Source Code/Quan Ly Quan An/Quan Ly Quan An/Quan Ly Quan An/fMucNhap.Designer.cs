namespace Quan_Ly_Quan_An
{
    partial class fMucNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMucNhap));
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txbMucNhap = new System.Windows.Forms.TextBox();
            this.lblmanv = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(269, 52);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(77, 32);
            this.btnCancle.TabIndex = 16;
            this.btnCancle.Text = "Hủy";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(186, 52);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(77, 32);
            this.btnAccept.TabIndex = 15;
            this.btnAccept.Text = "Cập nhật";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txbMucNhap
            // 
            this.txbMucNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMucNhap.Location = new System.Drawing.Point(186, 6);
            this.txbMucNhap.Multiline = true;
            this.txbMucNhap.Name = "txbMucNhap";
            this.txbMucNhap.Size = new System.Drawing.Size(159, 28);
            this.txbMucNhap.TabIndex = 13;
            this.txbMucNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbMucNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMucNhap_KeyDown);
            this.txbMucNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbMucNhap_KeyPress);
            // 
            // lblmanv
            // 
            this.lblmanv.AutoSize = true;
            this.lblmanv.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanv.ForeColor = System.Drawing.Color.Black;
            this.lblmanv.Location = new System.Drawing.Point(12, 9);
            this.lblmanv.Name = "lblmanv";
            this.lblmanv.Size = new System.Drawing.Size(129, 22);
            this.lblmanv.TabIndex = 14;
            this.lblmanv.Text = "Mức nhập (kg):";
            // 
            // fMucNhap
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txbMucNhap);
            this.Controls.Add(this.lblmanv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMucNhap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quan Ly Quan An";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txbMucNhap;
        private System.Windows.Forms.Label lblmanv;
    }
}