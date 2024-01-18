namespace Enroll_HH
{
    partial class Form1
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
            this.btn_ShowEnrolledCourses = new System.Windows.Forms.Button();
            this.btn_ShowNonEnrolledCourses = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.dgv_Students = new System.Windows.Forms.DataGridView();
            this.dgv_Courses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Courses)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ShowEnrolledCourses
            // 
            this.btn_ShowEnrolledCourses.Location = new System.Drawing.Point(589, 12);
            this.btn_ShowEnrolledCourses.Name = "btn_ShowEnrolledCourses";
            this.btn_ShowEnrolledCourses.Size = new System.Drawing.Size(199, 52);
            this.btn_ShowEnrolledCourses.TabIndex = 0;
            this.btn_ShowEnrolledCourses.Text = "Hiện thị đã đăng ký";
            this.btn_ShowEnrolledCourses.UseVisualStyleBackColor = true;
            this.btn_ShowEnrolledCourses.Click += new System.EventHandler(this.btn_ShowEnrolledCourses_Click);
            // 
            // btn_ShowNonEnrolledCourses
            // 
            this.btn_ShowNonEnrolledCourses.Location = new System.Drawing.Point(384, 12);
            this.btn_ShowNonEnrolledCourses.Name = "btn_ShowNonEnrolledCourses";
            this.btn_ShowNonEnrolledCourses.Size = new System.Drawing.Size(199, 52);
            this.btn_ShowNonEnrolledCourses.TabIndex = 1;
            this.btn_ShowNonEnrolledCourses.Text = "Hiện thị chưa đăng ký";
            this.btn_ShowNonEnrolledCourses.UseVisualStyleBackColor = true;
            this.btn_ShowNonEnrolledCourses.Click += new System.EventHandler(this.btn_ShowNonEnrolledCourses_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(12, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(78, 52);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(278, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(78, 52);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // dgv_Students
            // 
            this.dgv_Students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Students.Location = new System.Drawing.Point(12, 103);
            this.dgv_Students.Name = "dgv_Students";
            this.dgv_Students.RowHeadersWidth = 51;
            this.dgv_Students.RowTemplate.Height = 24;
            this.dgv_Students.Size = new System.Drawing.Size(360, 335);
            this.dgv_Students.TabIndex = 4;
            this.dgv_Students.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Students_CellClick);
            // 
            // dgv_Courses
            // 
            this.dgv_Courses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Courses.Location = new System.Drawing.Point(428, 103);
            this.dgv_Courses.Name = "dgv_Courses";
            this.dgv_Courses.RowHeadersWidth = 51;
            this.dgv_Courses.RowTemplate.Height = 24;
            this.dgv_Courses.Size = new System.Drawing.Size(360, 335);
            this.dgv_Courses.TabIndex = 5;
            this.dgv_Courses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Courses_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Courses);
            this.Controls.Add(this.dgv_Students);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_ShowNonEnrolledCourses);
            this.Controls.Add(this.btn_ShowEnrolledCourses);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Courses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ShowEnrolledCourses;
        private System.Windows.Forms.Button btn_ShowNonEnrolledCourses;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.DataGridView dgv_Students;
        private System.Windows.Forms.DataGridView dgv_Courses;
    }
}

