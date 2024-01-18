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
    public partial class DangKyGiangVienMoi : Form
    {
        SqlConnection connect = new Connect().GetData();
        public DangKyGiangVienMoi()
        {
            InitializeComponent();
        }

        private void DangKyGiangVienMoi_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.ToString() == "")
            {
                MessageBox.Show("Không được để trống Họ tên", "Chưa Nhập Tên", MessageBoxButtons.OK);
            }
            else if (txtEmail.Text.ToString() == "")
            {
                MessageBox.Show("Không được để trống Email", "Chưa Nhập Email", MessageBoxButtons.OK);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("EXEC ADDGIANGVIEN @name = '" + txtHoTen.Text + "', @chuyenmon = '" + txtChuyenMon.Text + "', @email = '" + txtEmail.Text + "', @phone = '" + txtPhone.Text + "'", connect);
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
                    MessageBox.Show("Email đã dùng để đăng ký cho giảng viên khác!", "Email đã đăng ký!!", MessageBoxButtons.OK);
                    this.Show();
                }
            }
        }
    }
}
