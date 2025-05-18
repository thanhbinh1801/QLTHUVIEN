namespace QLTHUVIEN
{
    partial class Dangki
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHVT = new System.Windows.Forms.TextBox();
            this.lbTenNguoiDung = new System.Windows.Forms.Label();
            this.btnDKi = new System.Windows.Forms.Button();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtTenTK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtHVT);
            this.panel1.Controls.Add(this.lbTenNguoiDung);
            this.panel1.Controls.Add(this.btnDKi);
            this.panel1.Controls.Add(this.txtMK);
            this.panel1.Controls.Add(this.txtTenTK);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(82, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 339);
            this.panel1.TabIndex = 3;
            // 
            // txtHVT
            // 
            this.txtHVT.Location = new System.Drawing.Point(216, 95);
            this.txtHVT.Name = "txtHVT";
            this.txtHVT.Size = new System.Drawing.Size(197, 22);
            this.txtHVT.TabIndex = 10;
            // 
            // lbTenNguoiDung
            // 
            this.lbTenNguoiDung.AutoSize = true;
            this.lbTenNguoiDung.Location = new System.Drawing.Point(87, 95);
            this.lbTenNguoiDung.Name = "lbTenNguoiDung";
            this.lbTenNguoiDung.Size = new System.Drawing.Size(64, 16);
            this.lbTenNguoiDung.TabIndex = 9;
            this.lbTenNguoiDung.Text = "Họ và tên";
            // 
            // btnDKi
            // 
            this.btnDKi.Location = new System.Drawing.Point(183, 247);
            this.btnDKi.Name = "btnDKi";
            this.btnDKi.Size = new System.Drawing.Size(132, 53);
            this.btnDKi.TabIndex = 8;
            this.btnDKi.Text = "Đăng kí";
            this.btnDKi.UseVisualStyleBackColor = true;
            this.btnDKi.Click += new System.EventHandler(this.btnDKi_Click);
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(216, 184);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(197, 22);
            this.txtMK.TabIndex = 7;
            // 
            // txtTenTK
            // 
            this.txtTenTK.Location = new System.Drawing.Point(216, 135);
            this.txtTenTK.Name = "txtTenTK";
            this.txtTenTK.Size = new System.Drawing.Size(197, 22);
            this.txtTenTK.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên tài khoản";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng kí tài khoản";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.Red;
            this.label.Location = new System.Drawing.Point(289, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 16);
            this.label.TabIndex = 2;
            // 
            // Dangki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 403);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label);
            this.Name = "Dangki";
            this.Text = "Dang ki";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDKi;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lbTenNguoiDung;
        private System.Windows.Forms.TextBox txtHVT;
    }
}