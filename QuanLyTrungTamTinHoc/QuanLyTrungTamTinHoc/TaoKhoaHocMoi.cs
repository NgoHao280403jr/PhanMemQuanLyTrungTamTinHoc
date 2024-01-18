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
    public partial class TaoKhoaHocMoi : Form
    {
        SqlConnection connect = new Connect().GetData();
        public TaoKhoaHocMoi()
        {
            InitializeComponent();
        }

        private void TaoKhoaHocMoi_Load(object sender, EventArgs e)
        {
            LoadChuyenMonCoSan();//Nếu không có tự gõ vào
            cboGiangVien.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimeStart.MinDate = DateTime.Today.AddDays(1);
            dateTimeEnd.MinDate = dateTimeStart.Value.AddDays(1);
            dateTimeStart.MaxDate = dateTimeEnd.Value.AddDays(-1);
        }
        private void LoadChuyenMonCoSan()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            DataTable ChuyenMons = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT description FROM Courses", connect);
            da.Fill(ChuyenMons);
            DataRow emptyRow = ChuyenMons.NewRow();
            ChuyenMons.Rows.InsertAt(emptyRow, 0);
            cboChuyenMon.DataSource = ChuyenMons;
            cboChuyenMon.DisplayMember = "description";
            cboChuyenMon.ValueMember = "description";
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }

        private void cboChuyenMon_TextChanged(object sender, EventArgs e)
        {
            LoadGiangVienPhuHop();
        }
        private void LoadGiangVienPhuHop()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            DataTable GiangViens = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT * FROM Instructors WHERE specialization LIKE '%"+cboChuyenMon.Text+"%'", connect);
            da.Fill(GiangViens);
            DataRow emptyRow = GiangViens.NewRow();
            GiangViens.Rows.InsertAt(emptyRow, 0);
            cboGiangVien.DataSource = GiangViens;
            cboGiangVien.DisplayMember = "instructor_name";
            cboGiangVien.ValueMember = "instructor_id";
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtKhoaHoc.Text=="")
            {
                MessageBox.Show("Vui lòng không để trống tên Khoá học", "Chưa có tên khoá học.", MessageBoxButtons.OK);
            }
            else if (dateTimeStart.Value <= DateTime.Today)
            {
                MessageBox.Show("Không được tạo lớp học với thời gian trong quá khứ.", "Vi phạm quy tắc thời gian.", MessageBoxButtons.OK);
            }
            else if(dateTimeEnd.Value < dateTimeStart.Value.AddDays(1))
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu ít nhất 1 ngày.", "Vi phạm quy tắc thời gian.", MessageBoxButtons.OK);
            }
            else if (dateTimeStart.Value > dateTimeEnd.Value.AddDays(-1))
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc ít nhất 1 ngày.", "Vi phạm quy tắc thời gian.", MessageBoxButtons.OK);
            }
            else if (cboChuyenMon.Text=="")
            {
                MessageBox.Show("Vui lòng chọn chuyên môn đào tạo khoá học", "Chưa có chuyên môn khoá học.", MessageBoxButtons.OK);
            }
            else if (cboGiangVien.Text=="")
            {
                MessageBox.Show("Vui lòng phân công giảng viên hướng dẫn cho khoá học", "Khoá học chưa có giảng viên.", MessageBoxButtons.OK);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("EXEC AddCourse @name = '"+txtKhoaHoc.Text+"', @chuyenmon ='"+cboChuyenMon.Text+"', @start = '"+dateTimeStart.Value.ToString()+"', @end = '"+dateTimeEnd.Value.ToString()+"', @giangvien ='"+(int)cboGiangVien.SelectedValue+"'", connect);
                // try catch bug dup data
                // Thực thi lệnh SQL
                try
                {
                    command.ExecuteNonQuery();
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Khoá học này đã tồn tại!", "Trùng khoá học!!", MessageBoxButtons.OK);
                    this.Show();
                }
            }
        }
    }
}
