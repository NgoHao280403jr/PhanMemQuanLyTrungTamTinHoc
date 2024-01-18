namespace QuanLyTrungTamTinHoc_DB
{
    partial class QuanLyKhoaHoc
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboStart = new System.Windows.Forms.ComboBox();
            this.cboEnd = new System.Windows.Forms.ComboBox();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKhoaHoc = new System.Windows.Forms.TextBox();
            this.groupBoxKhoaHoc = new System.Windows.Forms.GroupBox();
            this.dataGridViewKhoaHoc = new System.Windows.Forms.DataGridView();
            this.txtGiangVien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboChuyenMon = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBoxKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhoaHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Khoá Học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bắt đầu:";
            // 
            // cboStart
            // 
            this.cboStart.FormattingEnabled = true;
            this.cboStart.Location = new System.Drawing.Point(114, 34);
            this.cboStart.Name = "cboStart";
            this.cboStart.Size = new System.Drawing.Size(66, 24);
            this.cboStart.TabIndex = 2;
            this.cboStart.TextChanged += new System.EventHandler(this.Changed);
            // 
            // cboEnd
            // 
            this.cboEnd.FormattingEnabled = true;
            this.cboEnd.Location = new System.Drawing.Point(114, 64);
            this.cboEnd.Name = "cboEnd";
            this.cboEnd.Size = new System.Drawing.Size(66, 24);
            this.cboEnd.TabIndex = 3;
            this.cboEnd.TextChanged += new System.EventHandler(this.Changed);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(186, 36);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(276, 22);
            this.dateTimeStart.TabIndex = 4;
            this.dateTimeStart.ValueChanged += new System.EventHandler(this.Changed);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(186, 66);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(276, 22);
            this.dateTimeEnd.TabIndex = 5;
            this.dateTimeEnd.ValueChanged += new System.EventHandler(this.Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kết thúc";
            // 
            // txtKhoaHoc
            // 
            this.txtKhoaHoc.Location = new System.Drawing.Point(114, 6);
            this.txtKhoaHoc.Name = "txtKhoaHoc";
            this.txtKhoaHoc.Size = new System.Drawing.Size(348, 22);
            this.txtKhoaHoc.TabIndex = 7;
            this.txtKhoaHoc.TextChanged += new System.EventHandler(this.Changed);
            // 
            // groupBoxKhoaHoc
            // 
            this.groupBoxKhoaHoc.Controls.Add(this.dataGridViewKhoaHoc);
            this.groupBoxKhoaHoc.Location = new System.Drawing.Point(15, 94);
            this.groupBoxKhoaHoc.Name = "groupBoxKhoaHoc";
            this.groupBoxKhoaHoc.Size = new System.Drawing.Size(865, 310);
            this.groupBoxKhoaHoc.TabIndex = 8;
            this.groupBoxKhoaHoc.TabStop = false;
            this.groupBoxKhoaHoc.Text = "Khoá Học";
            // 
            // dataGridViewKhoaHoc
            // 
            this.dataGridViewKhoaHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhoaHoc.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewKhoaHoc.Name = "dataGridViewKhoaHoc";
            this.dataGridViewKhoaHoc.RowHeadersWidth = 51;
            this.dataGridViewKhoaHoc.RowTemplate.Height = 24;
            this.dataGridViewKhoaHoc.Size = new System.Drawing.Size(853, 283);
            this.dataGridViewKhoaHoc.TabIndex = 0;
            // 
            // txtGiangVien
            // 
            this.txtGiangVien.Location = new System.Drawing.Point(587, 3);
            this.txtGiangVien.Name = "txtGiangVien";
            this.txtGiangVien.Size = new System.Drawing.Size(293, 22);
            this.txtGiangVien.TabIndex = 11;
            this.txtGiangVien.TextChanged += new System.EventHandler(this.Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tên Giảng Viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Chuyên Môn:";
            // 
            // cboChuyenMon
            // 
            this.cboChuyenMon.FormattingEnabled = true;
            this.cboChuyenMon.Location = new System.Drawing.Point(587, 31);
            this.cboChuyenMon.Name = "cboChuyenMon";
            this.cboChuyenMon.Size = new System.Drawing.Size(293, 24);
            this.cboChuyenMon.TabIndex = 13;
            this.cboChuyenMon.TextChanged += new System.EventHandler(this.Changed);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(21, 428);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(208, 61);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Tạo khoá học mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(348, 428);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(208, 61);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Sửa khoá học";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(671, 428);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(209, 61);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Huỷ khoá học";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // QuanLyKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 516);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboChuyenMon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGiangVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxKhoaHoc);
            this.Controls.Add(this.txtKhoaHoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.cboEnd);
            this.Controls.Add(this.cboStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyKhoaHoc";
            this.Text = "Quản Lý Khoá Học";
            this.Load += new System.EventHandler(this.QuanLyKhoaHoc_Load);
            this.groupBoxKhoaHoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhoaHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStart;
        private System.Windows.Forms.ComboBox cboEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKhoaHoc;
        private System.Windows.Forms.GroupBox groupBoxKhoaHoc;
        private System.Windows.Forms.DataGridView dataGridViewKhoaHoc;
        private System.Windows.Forms.TextBox txtGiangVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboChuyenMon;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}