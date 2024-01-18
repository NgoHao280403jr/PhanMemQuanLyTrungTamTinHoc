using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTrungTamTinHoc_DB.Class;

namespace QuanLyTrungTamTinHoc_DB
{
    public partial class QuanLyKhoaHoc : Form
    {
        SqlConnection connect = new Connect().GetData();
        public QuanLyKhoaHoc()
        {
            InitializeComponent();
        }

        private void QuanLyKhoaHoc_Load(object sender, EventArgs e)
        {
            cboStart.Items.Add("Sau");
            cboStart.Items.Add("Trước");
            cboStart.SelectedIndex = 0;
            cboEnd.Items.Add("Trước");
            cboEnd.Items.Add("Sau");
            cboEnd.SelectedIndex = 0;
            dateTimeStart.Value = new DateTime(1900, 1, 1);
            dateTimeEnd.Value = new DateTime(2100, 12, 31);
            LoadChuyenMonGiangVien();
            Load_Data();
        }
        private void LoadChuyenMonGiangVien()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            DataTable GiangViens = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DBO.GETCHUYENMON()", connect);
            da.Fill(GiangViens);
            DataRow emptyRow = GiangViens.NewRow();
            GiangViens.Rows.InsertAt(emptyRow, 0);
            cboChuyenMon.DataSource = GiangViens;
            cboChuyenMon.DisplayMember = "Chuyên Môn";
            cboChuyenMon.ValueMember = "Chuyên Môn";
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }
        private void Load_Data()
        {
            //Khoá học
            DataTable KhoaHocs = new DataTable();
            SqlDataAdapter getKhoaHoc = new SqlDataAdapter();
            getKhoaHoc = new SqlDataAdapter("SELECT * FROM dbo.GETKHOAHOC('"+cboChuyenMon.Text+"', '"+txtGiangVien.Text+"', '"+txtKhoaHoc.Text+"', '"+dateTimeStart.Value.ToString()+"', N'"+cboStart.Text+"', '"+dateTimeEnd.Value.ToString()+"', N'"+cboEnd.Text+"')", connect);
            getKhoaHoc.Fill(KhoaHocs);
            dataGridViewKhoaHoc.DataSource = KhoaHocs;
            dataGridViewKhoaHoc.Columns["Tên khoá học"].HeaderText = "Tên khoá học";
            dataGridViewKhoaHoc.Columns["Chuyên môn"].HeaderText = "Chuyên môn";
            dataGridViewKhoaHoc.Columns["Ngày bắt đầu"].HeaderText = "Ngày bắt đầu";
            dataGridViewKhoaHoc.Columns["Ngày kết thúc"].HeaderText = "Ngày kết thúc";
            dataGridViewKhoaHoc.Columns["Giảng viên"].HeaderText = "Giảng viên";
            dataGridViewKhoaHoc.AutoGenerateColumns = true;

            //Giảng Viên
            //DataTable GiangViens = new DataTable();
            //SqlDataAdapter getGiangVien = new SqlDataAdapter("", connect);
            //getGiangVien.Fill(GiangViens);

           
        }

        private void Changed(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TaoKhoaHocMoi From = new TaoKhoaHocMoi();
            From.ShowDialog();
            this.Hide();
            Load_Data();
            this.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataGridViewKhoaHoc.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoá học muốn huỷ !!", "Chưa xác định khoá học cần huỷ !!", MessageBoxButtons.OK);
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridViewKhoaHoc.SelectedRows[0];
                    if (DateTime.Today >= (DateTime)selectedRow.Cells["Ngày bắt đầu"].Value)
                    {
                        MessageBox.Show("Lớp học đã diễn ra.", "Lớp học đã diễn ra.", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string tenKhoaHoc = selectedRow.Cells["Tên khoá học"].Value.ToString();
                        string chuyenMon = selectedRow.Cells["Chuyên môn"].Value.ToString();
                        string ngayBatDau = selectedRow.Cells["Ngày bắt đầu"].Value.ToString();
                        string ngayKetThuc = selectedRow.Cells["Ngày kết thúc"].Value.ToString();
                        string giangVien = selectedRow.Cells["Giảng viên"].Value.ToString();
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                        }
                        SqlCommand command = new SqlCommand("SELECT course_id FROM Courses,Instructors  WHERE course_name = '" + tenKhoaHoc + "' AND description = '" + chuyenMon + "' AND start_date = '" + ngayBatDau + "' AND end_date = '" + ngayKetThuc + "' AND Courses.instructor_id = Instructors.instructor_id AND instructor_name = '" + giangVien + "'", connect);

                        // Thực thi lệnh SQL
                        object id = command.ExecuteScalar();
                        SqlCommand deleteCmd = new SqlCommand("EXEC DeleteCourse @id = " + id, connect);
                        deleteCmd.ExecuteNonQuery();
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                    }
                }
            }
            else if (result == DialogResult.No) { } 
            Load_Data();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewKhoaHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khoá học muốn chỉnh sửa !!", "Chưa xác định khoá học cần chỉnh sửa !!", MessageBoxButtons.OK);
            }
            else if (dataGridViewKhoaHoc.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridViewKhoaHoc.SelectedRows[0];
                if (DateTime.Today >= (DateTime)selectedRow.Cells["Ngày bắt đầu"].Value)
                {
                    MessageBox.Show("Lớp học đã diễn ra.", "Lớp học đã diễn ra.", MessageBoxButtons.OK);
                }
                else
                {
                    string tenKhoaHoc = selectedRow.Cells["Tên khoá học"].Value.ToString();
                    string chuyenMon = selectedRow.Cells["Chuyên môn"].Value.ToString();
                    DateTime ngayBatDau = (DateTime)selectedRow.Cells["Ngày bắt đầu"].Value;
                    DateTime ngayKetThuc = (DateTime)selectedRow.Cells["Ngày kết thúc"].Value;
                    string giangVien = selectedRow.Cells["Giảng viên"].Value.ToString();
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    SqlCommand command = new SqlCommand("SELECT course_id FROM Courses,Instructors  WHERE course_name = '" + tenKhoaHoc + "' AND description = '" + chuyenMon + "' AND start_date = '" + ngayBatDau.ToString() + "' AND end_date = '" + ngayKetThuc.ToString() + "' AND Courses.instructor_id = Instructors.instructor_id AND instructor_name = '" + giangVien + "'", connect);

                    // Thực thi lệnh SQL
                    object id = command.ExecuteScalar();
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                    SuaThongTinKhoaHoc FormEdit = new SuaThongTinKhoaHoc();
                    FormEdit.id = (int)id;
                    FormEdit.tenKhoaHoc = tenKhoaHoc;
                    FormEdit.chuyenMon = chuyenMon;
                    FormEdit.ngayBatDau = ngayBatDau;
                    FormEdit.ngayKetThuc = ngayKetThuc;
                    FormEdit.giangVien = giangVien;
                    FormEdit.ShowDialog();
                    this.Hide();
                    Load_Data();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 khoá học muốn sửa!!", "Chưa xác định khoá học cần sửa thông tin!!", MessageBoxButtons.OK);
            }
        }
    }
}
