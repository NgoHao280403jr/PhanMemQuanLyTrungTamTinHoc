using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DoAn
{
    public partial class Home : Form
    {
        string user = "";
        string pass = "";
        bool flag = false;
        public Home()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public Home(bool flag, string user, string pass)
        {

            this.flag = flag;
            this.pass = pass;
            this.user = user;
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Home_Load(object sender, EventArgs e)
        {
            button_XoaUser.Enabled = false;
            label1.Text = user;
            LoadUserData();
        }
        private void LoadUserData()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                {
                    string query = "SELECT Users.user_id, Users.username,Users.password, Users.email, Roles.role_name FROM Users JOIN Roles ON Users.role_id = Roles.role_id; ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (SqlException ex)
            {
                this.Close();
                TrangChu trangChu = new TrangChu(flag,user,pass);
                trangChu.Show();
            }
            catch (Exception ex)
            {
                this.Close();
                // Xử lý các ngoại lệ khác
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
            }
           
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name != "password")
            {
                
                MessageBox.Show("Chỉ có thể sửa mật khẩu user!");

                
                dataGridView1.CancelEdit();

          
                return;
            }

           
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string Tk = Convert.ToString(selectedRow.Cells["username"].Value);
            string Mk = Convert.ToString(selectedRow.Cells["password"].Value);
            string Gm = Convert.ToString(selectedRow.Cells["email"].Value);
            

            using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
            {
                try
                {
                    connection.Open();
                    string query1 = "ALTER LOGIN "+Tk+" WITH PASSWORD = '"+Mk+"'";
                    SqlCommand logincommand = new SqlCommand(query1, connection);
                    logincommand.ExecuteNonQuery();
                    // Update only the "username" column in the database
                    string query = "UPDATE Users SET password = @password WHERE username = @username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", Tk);
                    command.Parameters.AddWithValue("@password", Mk);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin user thành công!");
                        // Optionally, you can reload the data from the database and refresh the DataGridView
                        LoadUserData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin user!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật mật khẩu user: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        string value = "";
        string columnValue = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button_XoaUser.Enabled = true;
            Connection db = new Connection(flag, user, pass);
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            value = selectedRow.Cells["username"].Value.ToString();
            string sqlquery = "select user_id from Users where username='" + value + "'";
            DataSet dt = db.getDataSet(sqlquery);
            if (dt != null && dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
            {
                columnValue = dt.Tables[0].Rows[0]["user_id"].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_XoaUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa user này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string Tk = Convert.ToString(selectedRow.Cells["username"].Value);

                    using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                    {
                        try
                        {
                            connection.Open();
                            string query1 = "drop login "+Tk+"";
                            SqlCommand logincommand = new SqlCommand(query1, connection);                                             
                            logincommand.ExecuteNonQuery();
                            string query = "DELETE FROM Users WHERE username = @username";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@username", Tk);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa user thành công!");
                                LoadUserData();
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa user!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa user: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một user để xóa!");
            }
        }

        private void button_SuaPass_Click(object sender, EventArgs e)
        {

        }

        private void thêmQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemQuyen themQuyen = new ThemQuyen(flag,value,pass);
            themQuyen.ShowDialog();
        }

        private void thuHồiQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThuHoiQuyen thuHoiQuyen = new ThuHoiQuyen(flag, value, pass);
            thuHoiQuyen.ShowDialog();
        }

        
    }
}
