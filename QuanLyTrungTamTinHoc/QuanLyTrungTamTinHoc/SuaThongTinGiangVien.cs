using QuanLyTrungTamTinHoc_DB.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyTrungTamTinHoc_DB
{
    public partial class SuaThongTinGiangVien : Form
    {

        SqlConnection connect = new Connect().GetData();
        public int id { get; set; }
        public string hoTen { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string chuyenMon { get; set; }
        public SuaThongTinGiangVien()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Không được để trống Họ tên", "Chưa Nhập Tên", MessageBoxButtons.OK);
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Không được để trống Email", "Chưa Nhập Email", MessageBoxButtons.OK);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("EXEC SUATHONGTINGIANGVIEN @id = '" + id + "', @name = '" + txtHoTen.Text + "', @chuyenmon = '" + txtChuyenMon.Text + "', @email = '" + txtEmail.Text + "', @phone = '" + txtPhone.Text + "'", connect);
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
                    MessageBox.Show("Email đã dùng để đăng ký cho giảng viên khác!", "Email đã đăng ký!!", MessageBoxButtons.OK);
                    this.Show();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thoát và lưu dữ liệu cũ !!", "Back", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void SuaThongTinGiangVien_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = hoTen;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtChuyenMon.Text = chuyenMon;
        }
    }
}
