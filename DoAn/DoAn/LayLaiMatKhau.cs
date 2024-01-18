using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class LayLaiMatKhau : Form
    {
        string user = "";
        string pass = "";
        bool flag = true;
        public LayLaiMatKhau()
        {
            
            InitializeComponent();
        }
        public LayLaiMatKhau(bool flag, string user, string pass)
        {
            this.flag = flag;
            this.pass = pass;
            this.user = user;
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string taiKhoan = textBox2.Text;
            string matKhau = textBox3.Text;
            string xnMatKhau = textBox4.Text;
            Connection db = new Connection(flag, user, pass);
            if (matKhau != xnMatKhau)
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác");
                return;
            }
            if (email.Trim() == "" || taiKhoan.Trim() == "")
            {
                MessageBox.Show("email và tài khoản không được để trống");
            }
            else
            {
                string query = "select * from Users where email='" + email + "'and username='" + taiKhoan + "'";
                string query1 = "update Users set password ='" + matKhau + "'where email='" + email + "'and username='" + taiKhoan + "'";
                string query2 = "ALTER LOGIN " + taiKhoan + " WITH PASSWORD = '" + matKhau + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {   
                    modify.Command(query1);
                    modify.Command(query2);
                    if (MessageBox.Show("Đổi mật khẩu thành công! Bạn có muốn đăng nhập không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.Close();
                        DangNhap dangNhap = new DangNhap();
                        dangNhap.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Email hoặc tài khoản này chưa được đăng kí");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
