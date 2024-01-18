using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Enroll_HH
{
    public partial class Form1 : Form
    {
        string selectedCourseId = "", selectedStudentId = "";
        SqlConnection sql = new SqlConnection("Data Source = DESKTOP-1SP23K9; Initial Catalog = DB_QuanLyTrungTamTinHoc; Integrated Security = True;");
        public Form1()
        {
            InitializeComponent();
            LoadStudents();
            btn_Add.Enabled = btn_Delete.Enabled = btn_ShowEnrolledCourses.Enabled = btn_ShowNonEnrolledCourses.Enabled = false;
        }

        private void LoadStudents()
        {
            DataTable dt = new DataTable();
            string select = "SELECT student_id, student_name FROM Students";
            SqlCommand cmd = new SqlCommand(select, sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv_Students.DataSource = dt;
            dgv_Students.AllowUserToAddRows = false;
            dgv_Students.ReadOnly = true;
        }

        private void LoadNonEnrolledCourses()
        {
            dgv_Courses.DataSource = null;
            DataTable dt = new DataTable();
            string select = "SELECT * FROM dbo.GetNonEnrolledCourses(@student_id)";
            SqlCommand cmd = new SqlCommand(select, sql);

            cmd.Parameters.AddWithValue("@student_id",selectedStudentId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv_Courses.DataSource = dt;
            dgv_Courses.AllowUserToAddRows = false;
            dgv_Courses.ReadOnly = true;
        }

        private void LoadEnrolledCourses()
        {
            dgv_Courses.DataSource = null;
            DataTable dt = new DataTable();
            string select = "SELECT * FROM dbo.GetEnrolledCourses(@student_id)";
            SqlCommand cmd = new SqlCommand(select, sql);
            cmd.Parameters.AddWithValue("@student_id", selectedStudentId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv_Courses.DataSource = dt;
            dgv_Courses.AllowUserToAddRows = false;
            dgv_Courses.ReadOnly = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
                btn_Add.Enabled = false;
            string select = "EXEC InsertEnrollments @student_id, @course_id";
            SqlCommand cmd = new SqlCommand(select, sql);
            cmd.Parameters.AddWithValue("@student_id", selectedStudentId);
            cmd.Parameters.AddWithValue("@course_id", selectedCourseId);
            cmd.ExecuteNonQuery();
                LoadNonEnrolledCourses();
                if (sql.State == ConnectionState.Open)
                {
                    sql.Close();
                }
            } catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btn_ShowNonEnrolledCourses_Click(object sender, EventArgs e)
        {
            LoadNonEnrolledCourses();
        }

        private void btn_ShowEnrolledCourses_Click(object sender, EventArgs e)
        {
            LoadEnrolledCourses();
        }

        private void dgv_Courses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Courses.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[0];
                if (cell != null)
                {
                    selectedCourseId = cell.Value.ToString();
                    btn_Add.Enabled = btn_Delete.Enabled = true;
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if(sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
            btn_Add.Enabled = false;
            string select = "EXEC DeleteEnrollments @student_id, @course_id";
            SqlCommand cmd = new SqlCommand(select, sql);
            cmd.Parameters.AddWithValue("@student_id", selectedStudentId);
            cmd.Parameters.AddWithValue("@course_id", selectedCourseId);
            cmd.ExecuteNonQuery();
                LoadEnrolledCourses();
                if (sql.State == ConnectionState.Open)
                {
                    sql.Close();
                }
            } catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dgv_Students_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Students.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[0];
                if (cell != null)
                {
                    selectedStudentId = cell.Value.ToString();
                    btn_ShowEnrolledCourses.Enabled = btn_ShowNonEnrolledCourses.Enabled = true;
                }
            }
        }
    }
}
