
namespace WF_QuanLyXeBus.GUI
{
    partial class frmMain
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
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnTaiXe = new System.Windows.Forms.Button();
            this.btnXe = new System.Windows.Forms.Button();
            this.btnDonVi = new System.Windows.Forms.Button();
            this.btnTuyenXe = new System.Windows.Forms.Button();
            this.plbody = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvTuyenXe = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.plbody.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyenXe)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnDangXuat);
            this.panel1.Controls.Add(this.btnNhanVien);
            this.panel1.Controls.Add(this.btnTaiXe);
            this.panel1.Controls.Add(this.btnXe);
            this.panel1.Controls.Add(this.btnDonVi);
            this.panel1.Controls.Add(this.btnTuyenXe);
            this.panel1.Location = new System.Drawing.Point(34, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 613);
            this.panel1.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.Location = new System.Drawing.Point(3, 487);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(235, 61);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNhanVien.Location = new System.Drawing.Point(6, 420);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(235, 61);
            this.btnNhanVien.TabIndex = 5;
            this.btnNhanVien.Text = "Quản Lý Nhân Viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnTaiXe
            // 
            this.btnTaiXe.FlatAppearance.BorderSize = 0;
            this.btnTaiXe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiXe.Location = new System.Drawing.Point(3, 353);
            this.btnTaiXe.Name = "btnTaiXe";
            this.btnTaiXe.Size = new System.Drawing.Size(235, 61);
            this.btnTaiXe.TabIndex = 4;
            this.btnTaiXe.Text = "Quản Lý Tài Xế";
            this.btnTaiXe.UseVisualStyleBackColor = true;
            this.btnTaiXe.Click += new System.EventHandler(this.btnTaiXe_Click);
            // 
            // btnXe
            // 
            this.btnXe.FlatAppearance.BorderSize = 0;
            this.btnXe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXe.Location = new System.Drawing.Point(3, 286);
            this.btnXe.Name = "btnXe";
            this.btnXe.Size = new System.Drawing.Size(235, 61);
            this.btnXe.TabIndex = 3;
            this.btnXe.Text = "Quản Lý Xe";
            this.btnXe.UseVisualStyleBackColor = true;
            this.btnXe.Click += new System.EventHandler(this.btnXe_Click);
            // 
            // btnDonVi
            // 
            this.btnDonVi.FlatAppearance.BorderSize = 0;
            this.btnDonVi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDonVi.Location = new System.Drawing.Point(3, 219);
            this.btnDonVi.Name = "btnDonVi";
            this.btnDonVi.Size = new System.Drawing.Size(235, 61);
            this.btnDonVi.TabIndex = 2;
            this.btnDonVi.Text = "Quản Lý Đơn Vị";
            this.btnDonVi.UseVisualStyleBackColor = true;
            this.btnDonVi.Click += new System.EventHandler(this.btnDonVi_Click);
            // 
            // btnTuyenXe
            // 
            this.btnTuyenXe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTuyenXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTuyenXe.Location = new System.Drawing.Point(3, 152);
            this.btnTuyenXe.Name = "btnTuyenXe";
            this.btnTuyenXe.Size = new System.Drawing.Size(235, 61);
            this.btnTuyenXe.TabIndex = 1;
            this.btnTuyenXe.Text = "Quản Lý Tuyến Xe";
            this.btnTuyenXe.UseVisualStyleBackColor = true;
            this.btnTuyenXe.Click += new System.EventHandler(this.btnTuyenXe_Click);
            // 
            // plbody
            // 
            this.plbody.Controls.Add(this.btnLamMoi);
            this.plbody.Controls.Add(this.btnXoa);
            this.plbody.Controls.Add(this.btnSua);
            this.plbody.Controls.Add(this.btnThem);
            this.plbody.Controls.Add(this.groupBox1);
            this.plbody.Controls.Add(this.dgvTuyenXe);
            this.plbody.Location = new System.Drawing.Point(303, 75);
            this.plbody.Name = "plbody";
            this.plbody.Size = new System.Drawing.Size(812, 615);
            this.plbody.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLamMoi.Location = new System.Drawing.Point(625, 509);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(141, 58);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.Location = new System.Drawing.Point(417, 509);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(141, 58);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.Location = new System.Drawing.Point(226, 509);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(141, 58);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(41, 509);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(141, 58);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(9, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm Thông Tin Tuyến Xe";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(6, 33);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(308, 33);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // dgvTuyenXe
            // 
            this.dgvTuyenXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTuyenXe.Location = new System.Drawing.Point(9, 152);
            this.dgvTuyenXe.Name = "dgvTuyenXe";
            this.dgvTuyenXe.RowHeadersWidth = 51;
            this.dgvTuyenXe.RowTemplate.Height = 24;
            this.dgvTuyenXe.Size = new System.Drawing.Size(797, 316);
            this.dgvTuyenXe.TabIndex = 0;
            this.dgvTuyenXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTuyenXe_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(34, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1081, 67);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(945, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHẦN MỀM QUẢN LÝ TUYẾN XE BUS TẠI THÀNH PHỐ BÌNH DƯƠNG";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WF_QuanLyXeBus.Properties.Resources.maxresdefault_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(6, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 143);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1143, 714);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.plbody);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tuyến xe BUS - Bình Dương";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.plbody.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyenXe)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDangXuat;
        public System.Windows.Forms.Button btnNhanVien;
        public System.Windows.Forms.Button btnTaiXe;
        public System.Windows.Forms.Button btnXe;
        public System.Windows.Forms.Button btnDonVi;
        public System.Windows.Forms.Button btnTuyenXe;
        private System.Windows.Forms.Panel plbody;
        private System.Windows.Forms.DataGridView dgvTuyenXe;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}