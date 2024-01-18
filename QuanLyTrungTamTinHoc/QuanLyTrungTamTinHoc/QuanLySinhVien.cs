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
    public partial class QuanLySinhVien : Form
    {
        SqlConnection connect = new Connect().GetData();
        public QuanLySinhVien()
        {
            InitializeComponent();
        }
        private void LoadKhoaHoc()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            DataTable KhoaHocs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXEC LayDanhSachKhoaHoc", connect);
            da.Fill(KhoaHocs);
            DataRow emptyRow = KhoaHocs.NewRow();
            KhoaHocs.Rows.InsertAt(emptyRow, 0);
            cboKhoaHoc.DataSource = KhoaHocs;
            cboKhoaHoc.DisplayMember = "course_name";
            cboKhoaHoc.ValueMember = "course_id";
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }
        private void QuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadKhoaHoc();
            Load_Data();
        }
        private void Changed(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void Load_Data()
        {
            DataTable DanhSachSinhVien = new DataTable();
            SqlDataAdapter dasv = new SqlDataAdapter();
            dasv = new SqlDataAdapter("EXEC DANHSACHSINHVIEN @name = '" + txtHoTen.Text.ToString() + "', @khoahoc = '" + cboKhoaHoc.Text.ToString() + "'", connect);
            dasv.Fill(DanhSachSinhVien);
            dataGridView.DataSource = DanhSachSinhVien;
            // Thiết lập tên cột cho DataGridView
            dataGridView.Columns["Họ tên"].HeaderText = "Họ tên";
            dataGridView.Columns["Birthday"].HeaderText = "Birthday";
            dataGridView.Columns["Email"].HeaderText = "Email";
            dataGridView.Columns["Sđt"].HeaderText = "Sđt";
            dataGridView.Columns["Địa chỉ"].HeaderText = "Địa chỉ";

            // Tự động tạo các cột dựa trên DataTable
            dataGridView.AutoGenerateColumns = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn sửa!!", "Chưa xác định sinh viên cần sửa thông tin!!", MessageBoxButtons.OK);
            }
            else if(dataGridView.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string hoTen = selectedRow.Cells["Họ tên"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string phone = selectedRow.Cells["Sđt"].Value.ToString();
                string address = selectedRow.Cells["Địa chỉ"].Value.ToString();
                DateTime birthday = DateTime.Parse( selectedRow.Cells["Birthday"].Value.ToString() );
                SuaThongTinSinhVien FormSuaThongTin = new SuaThongTinSinhVien();
                FormSuaThongTin.hoTen = hoTen;
                FormSuaThongTin.email = email;
                FormSuaThongTin.phone = phone;
                FormSuaThongTin.address = address;
                FormSuaThongTin.birthDay = birthday;
                FormSuaThongTin.ShowDialog();
                this.Hide();
                Load_Data();
                this.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 sinh viên muốn sửa!!", "Chưa xác định sinh viên cần sửa thông tin!!", MessageBoxButtons.OK);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Mở Form "Info"
            ThemSinhVien infoForm = new ThemSinhVien();
            infoForm.ShowDialog();
            this.Hide();
            Load_Data();
            this.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //bug select data
            if (dataGridView.SelectedRows.Count==0)
            {
                MessageBox.Show("Vui lòng chọn những sinh viên muốn đuổi!!", "Chưa xác định sinh viên cần đuổi!!", MessageBoxButtons.OK);
            }
            else
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string hoTen = selectedRow.Cells["Họ tên"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("EXEC DUOIHOC @NAME = '" + hoTen + "', @EMAIL = '" + email + "'", connect);

                // Thực thi lệnh SQL
                command.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }    
            Load_Data();
        }
    }
}