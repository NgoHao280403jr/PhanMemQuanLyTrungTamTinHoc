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
using System.Collections;

namespace Doan_THHQTCSDL_MT
{
	public partial class Form1 : Form
	{
		SqlConnection connsql = new SqlConnection("Data Source=DESKTOP-1SP23K9;Initial Catalog=DB_QuanLyTrungTamTinHoc;Integrated Security=True");
		public Form1()
		{
			InitializeComponent();
		}

		private void button_student_Click(object sender, EventArgs e)
		{
			connsql.Open();

			DataSet data = new DataSet();

			string query = "SELECT * FROM Students";

			using (SqlCommand cmd = new SqlCommand(query, connsql))
			{
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(data);
			}

			dataGridView_thongke.DataSource = data.Tables[0];

			comboBox_filter.Items.Clear();
			comboBox_filter.Items.Add("student_name + date_of_birth");
			comboBox_filter.Items.Add("student_name + phone");

			connsql.Close();
		}

		private void button_instructor_Click(object sender, EventArgs e)
		{
			connsql.Open();

			DataSet data = new DataSet();

			string query = "SELECT * FROM Instructors";

			using (SqlCommand cmd = new SqlCommand(query, connsql))
			{
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(data);
			}

			dataGridView_thongke.DataSource = data.Tables[0];

			comboBox_filter.Items.Clear();
			comboBox_filter.Items.Add("instructor_name + specialization");
			comboBox_filter.Items.Add("instructor_name + phone");

			connsql.Close();
		}

		private void button_enrollment_Click(object sender, EventArgs e)
		{
			connsql.Open();

			DataSet data = new DataSet();

			string query = "SELECT * FROM Enrollments";

			using (SqlCommand cmd = new SqlCommand(query, connsql))
			{
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(data);
			}

			dataGridView_thongke.DataSource = data.Tables[0];

			comboBox_filter.Items.Clear();
			comboBox_filter.Items.Add("student_name + course_name + enrollment_date");
			

			connsql.Close();
		}

		private void button_course_Click(object sender, EventArgs e)
		{
			connsql.Open();

			DataSet data = new DataSet();

			string query = "SELECT * FROM Courses";

			using (SqlCommand cmd = new SqlCommand(query, connsql))
			{
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(data);
			}

			dataGridView_thongke.DataSource = data.Tables[0];

			comboBox_filter.Items.Clear();
			comboBox_filter.Items.Add("course_name + start_date + end_date");
			comboBox_filter.Items.Add("course_name + instructor_name");

			connsql.Close();
		}

		private void button_fee_Click(object sender, EventArgs e)
		{
			connsql.Open();

			DataSet data = new DataSet();

			string query = "SELECT * FROM Fees";

			using (SqlCommand cmd = new SqlCommand(query, connsql))
			{
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(data);
			}

			dataGridView_thongke.DataSource = data.Tables[0];

			comboBox_filter.Items.Clear();
			comboBox_filter.Items.Add("course_name + fee_amount + currency + fee_date");
			

			connsql.Close();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			var result = MessageBox.Show("Bạn có chắc muốn thoát chương trình không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		private void comboBox_filter_SelectedIndexChanged(object sender, EventArgs e)
		{
			connsql.Open();
			DataSet data = new DataSet();

			string selectedItem = comboBox_filter.SelectedItem.ToString();

			if (selectedItem.Equals("student_name + date_of_birth"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT student_name, date_of_birth FROM Students", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
			else if (selectedItem.Equals("student_name + phone"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT student_name, phone FROM Students", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
			else if (selectedItem.Equals("instructor_name + specialization"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT instructor_name, specialization FROM Instructors", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
			else if (selectedItem.Equals("instructor_name + phone"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT instructor_name, phone FROM Instructors", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
			else if (selectedItem.Equals("student_name + course_name + enrollment_date"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT s.student_name, c.course_name, e.enrollment_date " +
					"FROM Students s " +
					"INNER JOIN Enrollments e ON s.student_id = e.student_id " +
					"INNER JOIN Courses c ON c.course_id = e.course_id", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
			else if (selectedItem.Equals("course_name + start_date + end_date"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT course_name, start_date, end_date FROM Courses", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
			else if (selectedItem.Equals("course_name + instructor_name"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT c.course_name, i.instructor_name " +
					"FROM Courses c INNER JOIN Instructors i " +
					"ON c.instructor_id = i.instructor_id", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
			else if (selectedItem.Equals("course_name + fee_amount + currency + fee_date"))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT c.course_name, f.fee_amount, f.currency, f.fee_date  " +
					"FROM Courses c INNER JOIN Fees f " +
					"ON c.course_id = f.course_id", connsql))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(data);
				}

				dataGridView_thongke.DataSource = data.Tables[0];
				connsql.Close();
			}
		}
	}
}
