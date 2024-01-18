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
    public partial class Search : Form
    {
        SqlConnection connect = new Connect().GetData();
        DataTable ListKhoaHoc;
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            LoadKhoaHoc();
            cboChucVu.Items.Add("");
            cboChucVu.Items.Add("Giảng Viên");
            cboChucVu.Items.Add("Sinh Viên");
            dateTimeStart.Value = new DateTime(1900, 1, 1);
            dateTimeEnd.Value = new DateTime(2100, 12, 31);
            LoadData();
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
        private void LoadData()
        {
            DataTable DanhSachGiangVien = new DataTable();
            DataTable DanhSachSinhVien = new DataTable();
            SqlDataAdapter dagv = new SqlDataAdapter();
            SqlDataAdapter dasv = new SqlDataAdapter();

            if (cboChucVu.Text == "Giảng Viên")
            {
                dagv = new SqlDataAdapter("EXEC LocDanhSachGiangVien @name = '" + txtHoTen.Text.ToString() + "', @khoahoc = '" + cboKhoaHoc.Text.ToString() + "', @datestart = '" + dateTimeStart.Value.ToString() + "', @dateend = '" + dateTimeEnd.Value.ToString() + "'", connect);
                dagv.Fill(DanhSachGiangVien);
            }
            else if (cboChucVu.Text == "Sinh Viên")
            {
                dasv = new SqlDataAdapter("EXEC LocDanhSachSinhVien @name = '" + txtHoTen.Text.ToString() + "', @khoahoc = '" + cboKhoaHoc.Text.ToString() + "', @datestart = '" + dateTimeStart.Value.ToString() + "', @dateend = '" + dateTimeEnd.Value.ToString() + "'", connect);
                dasv.Fill(DanhSachSinhVien);
            }
            else
            {
                dagv = new SqlDataAdapter("EXEC LocDanhSachGiangVien @name = '" + txtHoTen.Text.ToString() + "', @khoahoc = '" + cboKhoaHoc.Text.ToString() + "', @datestart = '" + dateTimeStart.Value.ToString() + "', @dateend = '" + dateTimeEnd.Value.ToString() + "'", connect);
                dasv = new SqlDataAdapter("EXEC LocDanhSachSinhVien @name = '" + txtHoTen.Text.ToString() + "', @khoahoc = '" + cboKhoaHoc.Text.ToString() + "', @datestart = '" + dateTimeStart.Value.ToString() + "', @dateend = '" + dateTimeEnd.Value.ToString() + "'", connect);
                dagv.Fill(DanhSachGiangVien);
                dasv.Fill(DanhSachSinhVien);
            }
            // Tạo DataTable mới để chứa dữ liệu từ cả hai bảng
            DataTable mergedTable = new DataTable();

            // Gộp các cột từ bảng DanhSachSinhVien vào mergedTable
            foreach (DataColumn column in DanhSachSinhVien.Columns)
            {
                mergedTable.Columns.Add(column.ColumnName);
            }

            // Gộp dữ liệu từ bảng DanhSachSinhVien vào mergedTable
            foreach (DataRow row in DanhSachSinhVien.Rows)
            {
                mergedTable.ImportRow(row);
            }

            // Gộp các cột từ bảng DanhSachGiangVien vào mergedTable
            foreach (DataColumn column in DanhSachGiangVien.Columns)
            {
                if (!mergedTable.Columns.Contains(column.ColumnName))
                {
                    mergedTable.Columns.Add(column.ColumnName);
                }
            }

            // Gộp dữ liệu từ bảng DanhSachGiangVien vào mergedTable
            foreach (DataRow row in DanhSachGiangVien.Rows)
            {
                DataRow newRow = mergedTable.NewRow();

                foreach (DataColumn column in DanhSachGiangVien.Columns)
                {
                    newRow[column.ColumnName] = row[column.ColumnName];
                }

                mergedTable.Rows.Add(newRow);
            }

            // Gán DataTable mới làm nguồn dữ liệu cho DataGridView
            dataGridView.DataSource = mergedTable;

            // Thiết lập tên cột cho DataGridView
            dataGridView.Columns["Họ tên"].HeaderText = "Họ tên";
            dataGridView.Columns["Khoá học"].HeaderText = "Khoá học";
            dataGridView.Columns["Chức vụ"].HeaderText = "Chức vụ";
            dataGridView.Columns["Ngày bắt đầu"].HeaderText = "Ngày bắt đầu";
            dataGridView.Columns["Ngày kết thúc"].HeaderText = "Ngày kết thúc";

            // Tự động tạo các cột dựa trên DataTable
            dataGridView.AutoGenerateColumns = true;
        }
        private void Changed(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
