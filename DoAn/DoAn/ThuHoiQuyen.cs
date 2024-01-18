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

namespace DoAn
{
    public partial class ThuHoiQuyen : Form
    {
        string user = "admin";
        string value = "";
        string pass = "";
        bool flag = true;
        public ThuHoiQuyen()
        {
            InitializeComponent();
        }
        public ThuHoiQuyen(bool flag, string value, string pass)
        {

            this.flag = flag;
            this.pass = pass;
            this.value = value;
            InitializeComponent();
        }
        void LoadcbBox()
        {
            try
            {
                Connection db = new Connection(flag, user, pass);
                string sqlquery = "select * from Permissions";
                DataSet dt = db.getDataSet(sqlquery);
                comboBox1.DataSource = dt.Tables[0];
                comboBox1.DisplayMember = "permission_name";
                comboBox1.ValueMember = "permission_id";
            }
           
            catch (SqlException ex)
            {
                this.Close();
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
        private void ThuHoiQuyen_Load(object sender, EventArgs e)
        {
            LoadcbBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 3)
            {

                // Thực thi thủ tục để cấp quyền Update cho người dùng đã chọn
                using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("RevokeUpdatePermission", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@TenNguoiDung", value);

                        // Thực thi thủ tục
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã thu hồi quyền Update cho người dùng " + value);
            }
            else if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
            {
                using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("RevokeSELECTPermission", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@TenNguoiDung", value);

                        // Thực thi thủ tục
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Đã thu hồi quyền Select cho người dùng " + value);
            }
            else if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
            {
                using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("RevokeINSERTPermission", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@TenNguoiDung", value);

                        // Thực thi thủ tục
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Đã thu hồi quyền Insertcho người dùng " + value);
            }
            else if (Convert.ToInt32(comboBox1.SelectedValue) == 4)
            {
                using (SqlConnection connection = new SqlConnection(Connection.chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("RevokeDELETEPermission", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@TenNguoiDung", value);

                        // Thực thi thủ tục
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Đã thu hồi quyền Delete cho người dùng " + value);
            }
            
            else
            {
                MessageBox.Show("Vui lòng chọn quyền trước khi thêm!!");
            }
        }
    }
}
