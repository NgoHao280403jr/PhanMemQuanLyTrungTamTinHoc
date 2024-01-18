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
namespace DoAn
{
    public partial class TrangChu : Form
    {
        string user = "";
        string pass = "";
        bool flag = false;
        public TrangChu()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public TrangChu(bool flag, string user, string pass)
        {

            this.flag = flag;
            this.pass = pass;
            this.user = user;
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadData()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                {
                    string query = "select course_id,course_name,Courses.description,start_date,end_date,Instructors.instructor_name from Courses,Instructors where Courses.instructor_id = Instructors.instructor_id ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (SqlException ex)
            {
                this.Close();
                // Xử lý các ngoại lệ liên quan đến SQL Server
                MessageBox.Show($"Lỗi SQL Server: {ex.Message}");
            }
            catch (Exception ex)
            {
                this.Close();
                // Xử lý các ngoại lệ khác
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            User.Text = user;
            LoadData();
        }

        private void button_ThongkeUser_Click(object sender, EventArgs e)
        {
            Doan_THHQTCSDL_MT.Form1 form1 = new Doan_THHQTCSDL_MT.Form1();
            form1.ShowDialog();
        }

        private void button_QLSVPass_Click(object sender, EventArgs e)
        {
            QuanLyTrungTamTinHoc_DB.QuanLySinhVien quanLySinhVien = new QuanLyTrungTamTinHoc_DB.QuanLySinhVien();
            quanLySinhVien.ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            QuanLyTrungTamTinHoc_DB.Search search = new QuanLyTrungTamTinHoc_DB.Search();
            search.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            QuanLyTrungTamTinHoc_DB.QuanLyGiangVien quanLyGiangVien = new QuanLyTrungTamTinHoc_DB.QuanLyGiangVien();
            quanLyGiangVien.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            QuanLyTrungTamTinHoc_DB.QuanLyKhoaHoc quanLyKhoaHoc = new QuanLyTrungTamTinHoc_DB.QuanLyKhoaHoc();
            quanLyKhoaHoc.ShowDialog();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Enroll_HH.Form1 form1 = new Enroll_HH.Form1();
            form1.ShowDialog();
        }
    }
}
