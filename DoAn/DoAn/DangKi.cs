using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace DoAn
{
    public partial class DangKi : Form
    {
        string user = "";
        string pass = "";
        bool flag = true;
        public DangKi()
        {
            InitializeComponent();
        }
        public DangKi(bool flag, string user, string pass)
        {
            this.flag = flag;
            this.pass = pass;
            this.user = user;
            InitializeComponent();
        }
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac,"^[a-zA-z0-9]{6,24}$");
        }
        public bool checkEmail(string em)
        {
            return Regex.IsMatch(em,@"^[a-zA-z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        Modify modify = new Modify();
       

        
        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void button_DangNhap_Click_1(object sender, EventArgs e)
        {
            string tenTK = textBox1.Text;
            string matKhau = textBox2.Text;
            string xnMatKhau = textBox3.Text;
            string email = textBox4.Text;
            string vaiTro = "2";
            string role = "Nhom_QLDL";
            Connection db = new Connection(flag, user, pass);
            if (!checkAccount(tenTK))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài từ 6 đến 24 kí tự,với kí tụ chữ hoa chữ thường và số");
                return;
            }
            if (!checkAccount(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài từ 6 đến 24 kí tự,với kí tụ chữ hoa chữ thường và số");
                return;
            }
            if (matKhau != xnMatKhau)
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác");
                return;
            }
            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng Email");
                return;
            }
            if (modify.TaiKhoans("Select*from Users where email='" + email + "'").Count != 0)
            {
                MessageBox.Show("Email này đã được đăng kí");
                return;
            }
            string query;
            try
            {
                query = "Insert into Users values('" + tenTK + "','" + matKhau + "','" + email + "'," + vaiTro + ")";
                using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                {
                    connection.Open();
                    using (SqlCommand loginCommand = new SqlCommand("sp_addlogin", connection))
                    {
                        loginCommand.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số của thủ tục sp_addlogin
                        loginCommand.Parameters.AddWithValue("@loginame", tenTK);
                        loginCommand.Parameters.AddWithValue("@passwd", matKhau);

                        // Thực thi thủ tục lưu trữ
                        loginCommand.ExecuteNonQuery();
                    }

                    // Tạo user
                    using (SqlCommand userCommand = new SqlCommand("sp_adduser", connection))
                    {
                        userCommand.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số của thủ tục sp_adduser
                        userCommand.Parameters.AddWithValue("@loginame", tenTK);
                        userCommand.Parameters.AddWithValue("@name_in_db", tenTK);

                        // Thực thi thủ tục lưu trữ
                        userCommand.ExecuteNonQuery();
                    }
                    using (SqlCommand addMemberCommand = new SqlCommand("sp_addrolemember", connection))
                    {
                        addMemberCommand.CommandType = CommandType.StoredProcedure;
                        addMemberCommand.Parameters.AddWithValue("@rolename", role);
                        addMemberCommand.Parameters.AddWithValue("@membername", tenTK);
                        addMemberCommand.ExecuteNonQuery();
                    }
                }
                modify.Command(query);
                if (MessageBox.Show("Đăng kí thành công! Bạn có muốn đăng nhập không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                    DangNhap dangNhap = new DangNhap();
                    dangNhap.ShowDialog();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled=true;
                string tenTK = textBox1.Text;
                string matKhau = textBox2.Text;
                string xnMatKhau = textBox3.Text;
                string email = textBox4.Text;
                string vaiTro = "2";
                Connection db = new Connection(flag, user, pass);
                if (!checkAccount(tenTK))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản dài từ 6 đến 24 kí tự,với kí tụ chữ hoa chữ thường và số");
                    return;
                }
                if (!checkAccount(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu dài từ 6 đến 24 kí tự,với kí tụ chữ hoa chữ thường và số");
                    return;
                }
                if (matKhau != xnMatKhau)
                {
                    MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác");
                    return;
                }
                if (!checkEmail(email))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng Email");
                    return;
                }
                if (modify.TaiKhoans("Select*from Users where email='" + email + "'").Count != 0)
                {
                    MessageBox.Show("Email này đã được đăng kí");
                    return;
                }
                string query;
                try
                {
                    query = "Insert into Users values('" + tenTK + "','" + matKhau + "','" + email + "'," + vaiTro + ")";
                    using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                    {
                        connection.Open();
                        using (SqlCommand loginCommand = new SqlCommand("sp_addlogin", connection))
                        {
                            loginCommand.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số của thủ tục sp_addlogin
                            loginCommand.Parameters.AddWithValue("@loginame", tenTK);
                            loginCommand.Parameters.AddWithValue("@passwd", matKhau);

                            // Thực thi thủ tục lưu trữ
                            loginCommand.ExecuteNonQuery();
                        }

                        // Tạo user
                        using (SqlCommand userCommand = new SqlCommand("sp_adduser", connection))
                        {
                            userCommand.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số của thủ tục sp_adduser
                            userCommand.Parameters.AddWithValue("@loginame", tenTK);
                            userCommand.Parameters.AddWithValue("@name_in_db", tenTK);

                            // Thực thi thủ tục lưu trữ
                            userCommand.ExecuteNonQuery();
                        }
                    }
                    modify.Command(query);
                    if (MessageBox.Show("Đăng kí thành công! Bạn có muốn đăng nhập không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.Close();
                        DangNhap dangNhap = new DangNhap();
                        dangNhap.ShowDialog();
                    }
                }
                catch
                {
                    MessageBox.Show("Tên tài khoản này đã được đăng kí");
                }
            }    
        }
    }
}
