namespace QLTHUVIEN
{
    partial class Doimatkhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhapMKMoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNhapLaiMK = new System.Windows.Forms.TextBox();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đổi mật khẩu";
            // 
            // txtNhapMKMoi
            // 
            this.txtNhapMKMoi.Location = new System.Drawing.Point(175, 115);
            this.txtNhapMKMoi.Name = "txtNhapMKMoi";
            this.txtNhapMKMoi.Size = new System.Drawing.Size(132, 22);
            this.txtNhapMKMoi.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhập mật khẩu mới";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nhập lại mật khẩu";
            // 
            // txtNhapLaiMK
            // 
            this.txtNhapLaiMK.Location = new System.Drawing.Point(175, 163);
            this.txtNhapLaiMK.Name = "txtNhapLaiMK";
            this.txtNhapLaiMK.Size = new System.Drawing.Size(132, 22);
            this.txtNhapLaiMK.TabIndex = 8;
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.Location = new System.Drawing.Point(110, 215);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(137, 42);
            this.btnXacnhan.TabIndex = 9;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.UseVisualStyleBackColor = true;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // Doimatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 296);
            this.Controls.Add(this.btnXacnhan);
            this.Controls.Add(this.txtNhapLaiMK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNhapMKMoi);
            this.Controls.Add(this.label1);
            this.Name = "Doimatkhau";
            this.Text = "Doimatkhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNhapMKMoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNhapLaiMK;
        private System.Windows.Forms.Button btnXacnhan;
    }
}