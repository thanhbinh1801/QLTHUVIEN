namespace PBL3
{
    partial class Dangnhap
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
            this.label = new System.Windows.Forms.Label();
            this.txtTenTK = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.llbQuenMK = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.llbDangKi = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Enabled = false;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Red;
            this.label.Location = new System.Drawing.Point(320, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(277, 42);
            this.label.TabIndex = 1;
            this.label.Text = "Quản lí thư viện";
            // 
            // txtTenTK
            // 
            this.txtTenTK.Location = new System.Drawing.Point(579, 122);
            this.txtTenTK.Multiline = true;
            this.txtTenTK.Name = "txtTenTK";
            this.txtTenTK.Size = new System.Drawing.Size(240, 38);
            this.txtTenTK.TabIndex = 3;
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(579, 204);
            this.txtMK.Multiline = true;
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(240, 35);
            this.txtMK.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(613, 305);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(163, 59);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // llbQuenMK
            // 
            this.llbQuenMK.AutoSize = true;
            this.llbQuenMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbQuenMK.Location = new System.Drawing.Point(703, 264);
            this.llbQuenMK.Name = "llbQuenMK";
            this.llbQuenMK.Size = new System.Drawing.Size(131, 20);
            this.llbQuenMK.TabIndex = 6;
            this.llbQuenMK.TabStop = true;
            this.llbQuenMK.Text = "Quên mật khẩu?";
            this.llbQuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbQuenMK_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(609, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bạn chưa có tài khoản?";
            // 
            // llbDangKi
            // 
            this.llbDangKi.AutoSize = true;
            this.llbDangKi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbDangKi.Location = new System.Drawing.Point(665, 435);
            this.llbDangKi.Name = "llbDangKi";
            this.llbDangKi.Size = new System.Drawing.Size(70, 20);
            this.llbDangKi.TabIndex = 8;
            this.llbDangKi.TabStop = true;
            this.llbDangKi.Text = "Đăng kí ";
            this.llbDangKi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDangKi_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.ImageLocation = "E:\\DotNet\\Image\\logodut.jpg";
            this.pictureBox1.Location = new System.Drawing.Point(75, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 388);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(576, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(576, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mật khẩu";
            // 
            // Dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 493);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.llbDangKi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llbQuenMK);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTenTK);
            this.Controls.Add(this.label);
            this.Name = "Dangnhap";
            this.Text = "Dang nhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.LinkLabel llbQuenMK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llbDangKi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

