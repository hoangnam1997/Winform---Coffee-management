namespace Quan_Ly_Quan_An
{
    partial class fThayDoiSoLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThayDoiSoLuong));
            this.txbNumber = new System.Windows.Forms.TextBox();
            this.lblmaCategory = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbNumber
            // 
            this.txbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNumber.Location = new System.Drawing.Point(162, 6);
            this.txbNumber.Multiline = true;
            this.txbNumber.Name = "txbNumber";
            this.txbNumber.Size = new System.Drawing.Size(183, 28);
            this.txbNumber.TabIndex = 31;
            this.txbNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNumber_KeyPress);
            // 
            // lblmaCategory
            // 
            this.lblmaCategory.AutoSize = true;
            this.lblmaCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmaCategory.ForeColor = System.Drawing.Color.Black;
            this.lblmaCategory.Location = new System.Drawing.Point(12, 9);
            this.lblmaCategory.Name = "lblmaCategory";
            this.lblmaCategory.Size = new System.Drawing.Size(86, 22);
            this.lblmaCategory.TabIndex = 32;
            this.lblmaCategory.Text = "Số lượng:";
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(268, 50);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(77, 32);
            this.btnCancle.TabIndex = 34;
            this.btnCancle.Text = "Hủy";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(185, 50);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(77, 32);
            this.btnAccept.TabIndex = 33;
            this.btnAccept.Text = "Thêm";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // fThayDoiSoLuong
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(384, 109);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txbNumber);
            this.Controls.Add(this.lblmaCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fThayDoiSoLuong";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quan Ly Quan An";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbNumber;
        private System.Windows.Forms.Label lblmaCategory;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnAccept;
    }
}