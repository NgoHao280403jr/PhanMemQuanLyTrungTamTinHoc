namespace Doan_THHQTCSDL_MT
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
			this.dataGridView_thongke = new System.Windows.Forms.DataGridView();
			this.label = new System.Windows.Forms.Label();
			this.button_student = new System.Windows.Forms.Button();
			this.button_instructor = new System.Windows.Forms.Button();
			this.button_enrollment = new System.Windows.Forms.Button();
			this.button_course = new System.Windows.Forms.Button();
			this.button_fee = new System.Windows.Forms.Button();
			this.comboBox_filter = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_thongke)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView_thongke
			// 
			this.dataGridView_thongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_thongke.Location = new System.Drawing.Point(454, 214);
			this.dataGridView_thongke.Name = "dataGridView_thongke";
			this.dataGridView_thongke.RowHeadersWidth = 51;
			this.dataGridView_thongke.RowTemplate.Height = 24;
			this.dataGridView_thongke.Size = new System.Drawing.Size(577, 314);
			this.dataGridView_thongke.TabIndex = 0;
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label.Location = new System.Drawing.Point(426, 30);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(245, 51);
			this.label.TabIndex = 1;
			this.label.Text = "THỐNG KÊ";
			// 
			// button_student
			// 
			this.button_student.Location = new System.Drawing.Point(57, 126);
			this.button_student.Name = "button_student";
			this.button_student.Size = new System.Drawing.Size(158, 63);
			this.button_student.TabIndex = 2;
			this.button_student.Text = "Student";
			this.button_student.UseVisualStyleBackColor = true;
			this.button_student.Click += new System.EventHandler(this.button_student_Click);
			// 
			// button_instructor
			// 
			this.button_instructor.Location = new System.Drawing.Point(261, 126);
			this.button_instructor.Name = "button_instructor";
			this.button_instructor.Size = new System.Drawing.Size(158, 63);
			this.button_instructor.TabIndex = 3;
			this.button_instructor.Text = "Instructor";
			this.button_instructor.UseVisualStyleBackColor = true;
			this.button_instructor.Click += new System.EventHandler(this.button_instructor_Click);
			// 
			// button_enrollment
			// 
			this.button_enrollment.Location = new System.Drawing.Point(465, 126);
			this.button_enrollment.Name = "button_enrollment";
			this.button_enrollment.Size = new System.Drawing.Size(158, 63);
			this.button_enrollment.TabIndex = 4;
			this.button_enrollment.Text = "Enrollment";
			this.button_enrollment.UseVisualStyleBackColor = true;
			this.button_enrollment.Click += new System.EventHandler(this.button_enrollment_Click);
			// 
			// button_course
			// 
			this.button_course.Location = new System.Drawing.Point(669, 126);
			this.button_course.Name = "button_course";
			this.button_course.Size = new System.Drawing.Size(158, 63);
			this.button_course.TabIndex = 5;
			this.button_course.Text = "Course";
			this.button_course.UseVisualStyleBackColor = true;
			this.button_course.Click += new System.EventHandler(this.button_course_Click);
			// 
			// button_fee
			// 
			this.button_fee.Location = new System.Drawing.Point(873, 126);
			this.button_fee.Name = "button_fee";
			this.button_fee.Size = new System.Drawing.Size(158, 63);
			this.button_fee.TabIndex = 6;
			this.button_fee.Text = "Fee";
			this.button_fee.UseVisualStyleBackColor = true;
			this.button_fee.Click += new System.EventHandler(this.button_fee_Click);
			// 
			// comboBox_filter
			// 
			this.comboBox_filter.FormattingEnabled = true;
			this.comboBox_filter.Location = new System.Drawing.Point(57, 242);
			this.comboBox_filter.Name = "comboBox_filter";
			this.comboBox_filter.Size = new System.Drawing.Size(362, 24);
			this.comboBox_filter.TabIndex = 7;
			this.comboBox_filter.SelectedIndexChanged += new System.EventHandler(this.comboBox_filter_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1068, 553);
			this.Controls.Add(this.comboBox_filter);
			this.Controls.Add(this.button_fee);
			this.Controls.Add(this.button_course);
			this.Controls.Add(this.button_enrollment);
			this.Controls.Add(this.button_instructor);
			this.Controls.Add(this.button_student);
			this.Controls.Add(this.label);
			this.Controls.Add(this.dataGridView_thongke);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_thongke)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView_thongke;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button button_student;
		private System.Windows.Forms.Button button_instructor;
		private System.Windows.Forms.Button button_enrollment;
		private System.Windows.Forms.Button button_course;
		private System.Windows.Forms.Button button_fee;
		private System.Windows.Forms.ComboBox comboBox_filter;
	}
}

