using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTrungTamTinHoc_DB.Class;   

namespace QuanLyTrungTamTinHoc_DB
{
    public partial class ThemSinhVien : Form
    {
        SqlConnection connect = new Connect().GetData();
        public ThemSinhVien()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.ToString() == "")
            {
                MessageBox.Show("Không được để trống Họ tên", "Chưa Nhập Tên", MessageBoxButtons.OK);
            }
            else if ( txtEmail.Text.ToString() == "")
            {
                MessageBox.Show("Không được để trống Email", "Chưa Nhập Email", MessageBoxButtons.OK);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand command = new SqlCommand("EXEC THEMSINHVIEN @NAME = '" + txtHoTen.Text.ToString() + "', @BIRTHDAY = '" + dateTimeBirthDay.Value.ToString() + "', @EMAIL = '" + txtEmail.Text.ToString() + "', @PHONE = '" + txtPhone.Text.ToString() + "',@ADDRESS = '" + txtAddress.Text.ToString() + "'", connect);
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
                    MessageBox.Show("Email đã dùng để đăng ký cho sinh viên khác!", "Email đã đăng ký!!", MessageBoxButtons.OK);
                    this.Show();
                }
            }    
        }

        private void ThemSinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}
