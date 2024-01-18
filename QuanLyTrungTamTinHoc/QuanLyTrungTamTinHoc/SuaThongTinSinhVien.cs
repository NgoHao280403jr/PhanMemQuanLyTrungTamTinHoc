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
    public partial class SuaThongTinSinhVien : Form
    {
        SqlConnection connect = new Connect().GetData();
        public string hoTen { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime birthDay { get; set; }

        public SuaThongTinSinhVien()
        {
            InitializeComponent();
        }

        private void SuaThongTinSinhVien_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = hoTen;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;
            dateTimeBirthDay.Value = birthDay;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Không được để trống Họ tên", "Chưa Nhập Tên", MessageBoxButtons.OK);
            }
            else if(txtEmail.Text == "")
            {
                MessageBox.Show("Không được để trống Email", "Chưa Nhập Email", MessageBoxButtons.OK);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("EXEC SUATHONGTINSINHVIEN @emailGetId = '" + email + "', @name = '" + txtHoTen.Text + "',@birthday = '" + dateTimeBirthDay.Value.ToString() + "', @email ='" + txtEmail.Text + "', @phone = '" + txtPhone.Text + "', @address ='" + txtAddress.Text + "'",connect);
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
                    MessageBox.Show("Email đã dùng để đăng ký cho sinh viên khác!", "Email đã đăng ký!!", MessageBoxButtons.OK);
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
    }
}
