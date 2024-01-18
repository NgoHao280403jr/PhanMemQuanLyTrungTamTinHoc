using QuanLyTrungTamTinHoc_DB.Class;
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

namespace QuanLyTrungTamTinHoc_DB
{
    public partial class QuanLyGiangVien : Form
    {
        SqlConnection connect = new Connect().GetData();
        public QuanLyGiangVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DangKyGiangVienMoi infoForm = new DangKyGiangVienMoi();
            infoForm.ShowDialog();
            this.Hide();
            cboChuyenMon.Items.Clear();
            LoadChuyenMon();
            Load_Data();
            this.Show();
        }

        private void QuanLyGiangVien_Load(object sender, EventArgs e)
        {
            LoadChuyenMon();
            Load_Data();
        }
        private void LoadChuyenMon()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            SqlCommand command = new SqlCommand("EXEC GETCHUYENMONGIANGVIEN", connect);
            SqlDataReader reader = command.ExecuteReader();
            HashSet<string> chuyenMonSet = new HashSet<string>();
            while (reader.Read())
            {
                string chuyenMon = reader.GetString(0);
                string[] chuyenMonArray = chuyenMon.Split(',');

                foreach (string monHoc in chuyenMonArray)
                {
                    string trimmedMonHoc = monHoc.Trim(); // Xóa khoảng trắng thừa

                    if (!string.IsNullOrEmpty(trimmedMonHoc))
                    {
                        chuyenMonSet.Add(trimmedMonHoc);
                    }
                }
            }
            cboChuyenMon.Items.Add("");
            foreach (string monHoc in chuyenMonSet)
            {
                cboChuyenMon.Items.Add(monHoc);
            }
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
            cboChuyenMon.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Load_Data()
        {
            DataTable DanhSachGiangVien = new DataTable();
            SqlDataAdapter dagv = new SqlDataAdapter();
            dagv = new SqlDataAdapter("EXEC GETGIANGVIENDATA @name = '" + txtGiangVien.Text + "', @chuyenmon = '" + cboChuyenMon.Text + "'", connect);
            dagv.Fill(DanhSachGiangVien);
            dataGridViewGiangVien.DataSource = DanhSachGiangVien;
            // Thiết lập tên cột cho DataGridView
            dataGridViewGiangVien.Columns["Họ tên"].HeaderText = "Họ tên";
            dataGridViewGiangVien.Columns["Chuyên môn"].HeaderText = "Chuyên môn";
            dataGridViewGiangVien.Columns["Email"].HeaderText = "Email";
            dataGridViewGiangVien.Columns["Phone"].HeaderText = "Phone";

            // Tự động tạo các cột dựa trên DataTable
            dataGridViewGiangVien.AutoGenerateColumns = true;
        }

        private void Changed(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewGiangVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn những giảng viên muốn đuổi!!", "Chưa xác định giảng viên cần đuổi!!", MessageBoxButtons.OK);
            }
            else
            {
                DataGridViewRow selectedRow = dataGridViewGiangVien.SelectedRows[0];
                string hoTen = selectedRow.Cells["Họ tên"].Value.ToString();
                string chuyenMon = selectedRow.Cells["Chuyên môn"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string phone = selectedRow.Cells["Phone"].Value.ToString();
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("SELECT instructor_id FROM Instructors  WHERE instructor_name = '" + hoTen + "' AND specialization = '" + chuyenMon + "' AND email = '" + email + "' AND phone = '" + phone + "'", connect);

                // Thực thi lệnh SQL
                object id = command.ExecuteScalar();
                SqlCommand check = new SqlCommand("SELECT start_date FROM Courses, Instructors WHERE Instructors.instructor_id = Courses.instructor_id AND  Instructors.instructor_id = " + (int)id, connect);
                SqlDataReader reader = check.ExecuteReader();
                List<DateTime> checkTime = new List<DateTime>();
                while (reader.Read())
                {
                    DateTime startDate = reader.GetDateTime(0);
                    checkTime.Add(startDate);
                }
                bool hople = true;
                foreach (DateTime item in checkTime)
                {
                    if (item <= DateTime.Now)
                    {
                        hople = false;
                        break;
                    }
                }
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
                if (hople == false)
                {
                    MessageBox.Show("Giảng vien co lop hoc da dien ra.", "Lớp học đã diễn ra.", MessageBoxButtons.OK);
                }
                else
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    SqlCommand delete = new SqlCommand("EXEC XATHAIGIANGVIEN @id = " + (int)id, connect);

                    // Thực thi lệnh SQL
                    delete.ExecuteNonQuery();
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            Load_Data();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewGiangVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khoá học muốn chỉnh sửa !!", "Chưa xác định khoá học cần chỉnh sửa !!", MessageBoxButtons.OK);
            }
            else if (dataGridViewGiangVien.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridViewGiangVien.SelectedRows[0];
                string hoTen = selectedRow.Cells["Họ tên"].Value.ToString();
                string chuyenMon = selectedRow.Cells["Chuyên môn"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string phone = selectedRow.Cells["Phone"].Value.ToString();
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("SELECT instructor_id FROM Instructors  WHERE instructor_name = '" + hoTen + "' AND specialization = '" + chuyenMon + "' AND email = '" + email + "' AND phone = '" + phone + "'", connect);

                // Thực thi lệnh SQL
                object id = command.ExecuteScalar();
                SuaThongTinGiangVien FormEdit = new SuaThongTinGiangVien();
                FormEdit.id = (int)id;
                FormEdit.hoTen = hoTen;
                FormEdit.email = email;
                FormEdit.phone = phone;
                FormEdit.chuyenMon = chuyenMon;
                FormEdit.ShowDialog();
                this.Hide();
                Load_Data();
                this.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 khoá học muốn sửa!!", "Chưa xác định khoá học cần sửa thông tin!!", MessageBoxButtons.OK);
            }
        }
    }
}
