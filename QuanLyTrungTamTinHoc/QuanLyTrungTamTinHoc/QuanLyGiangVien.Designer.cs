namespace QuanLyTrungTamTinHoc_DB
{
    partial class QuanLyGiangVien
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
            this.groupBoxGiangVien = new System.Windows.Forms.GroupBox();
            this.dataGridViewGiangVien = new System.Windows.Forms.DataGridView();
            this.cboChuyenMon = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGiangVien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBoxGiangVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGiangVien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxGiangVien
            // 
            this.groupBoxGiangVien.Controls.Add(this.dataGridViewGiangVien);
            this.groupBoxGiangVien.Location = new System.Drawing.Point(25, 117);
            this.groupBoxGiangVien.Name = "groupBoxGiangVien";
            this.groupBoxGiangVien.Size = new System.Drawing.Size(738, 310);
            this.groupBoxGiangVien.TabIndex = 10;
            this.groupBoxGiangVien.TabStop = false;
            this.groupBoxGiangVien.Text = "Giảng Viên";
            // 
            // dataGridViewGiangVien
            // 
            this.dataGridViewGiangVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGiangVien.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewGiangVien.Name = "dataGridViewGiangVien";
            this.dataGridViewGiangVien.RowHeadersWidth = 51;
            this.dataGridViewGiangVien.RowTemplate.Height = 24;
            this.dataGridViewGiangVien.Size = new System.Drawing.Size(726, 283);
            this.dataGridViewGiangVien.TabIndex = 0;
            // 
            // cboChuyenMon
            // 
            this.cboChuyenMon.FormattingEnabled = true;
            this.cboChuyenMon.Location = new System.Drawing.Point(131, 40);
            this.cboChuyenMon.Name = "cboChuyenMon";
            this.cboChuyenMon.Size = new System.Drawing.Size(293, 24);
            this.cboChuyenMon.TabIndex = 17;
            this.cboChuyenMon.TextChanged += new System.EventHandler(this.Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Chuyên Môn:";
            // 
            // txtGiangVien
            // 
            this.txtGiangVien.Location = new System.Drawing.Point(131, 12);
            this.txtGiangVien.Name = "txtGiangVien";
            this.txtGiangVien.Size = new System.Drawing.Size(293, 22);
            this.txtGiangVien.TabIndex = 15;
            this.txtGiangVien.TextChanged += new System.EventHandler(this.Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tên Giảng Viên:";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(621, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(124, 47);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(621, 65);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(124, 46);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(495, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 99);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // QuanLyGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboChuyenMon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGiangVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxGiangVien);
            this.Name = "QuanLyGiangVien";
            this.Text = "QuanLyGiangVien";
            this.Load += new System.EventHandler(this.QuanLyGiangVien_Load);
            this.groupBoxGiangVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGiangVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGiangVien;
        private System.Windows.Forms.DataGridView dataGridViewGiangVien;
        private System.Windows.Forms.ComboBox cboChuyenMon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGiangVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
    }
}