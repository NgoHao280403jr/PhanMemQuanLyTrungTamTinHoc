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
    public partial class DangNhap : Form
    {
       
        
        public DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabel_QuenPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LayLaiMatKhau layLaiMatKhau = new LayLaiMatKhau();
            layLaiMatKhau.Show();
            this.Visible = false;
        }

        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKi dangKi = new DangKi();
            dangKi.Show();
            this.Visible = false;
        }
      
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Modify modify = new Modify();
        private void button_DangNhap_Click_1(object sender, EventArgs e)
        {
            //SqlDataAdapter da = new SqlDataAdapter("select * from TaiKhoan where TaiKhoan =N'" + textBox1.Text + "' and MatKhau =N'" + textBox2.Text + "'", Connection.strConnection);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            string tenTK = textBox1.Text;
            string matKhau = textBox2.Text;
            bool flag = false;
            if (tenTK.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản");
            }
            else if (matKhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else
            {

                if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0)
                {
                    flag = true;
 
                }
                if (flag == true)
                {
                    Connection db = new Connection(flag, tenTK, matKhau);
                    Home home = new Home(flag, tenTK, matKhau);
                    this.Hide();
                    home.ShowDialog();
                    
                }
                if (flag == false)
                {
                    Connection db = new Connection(flag, tenTK, matKhau);
                    Home home = new Home(flag, tenTK, matKhau);
                    this.Hide();
                    home.ShowDialog();
                   
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng");
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                e.Handled = true;
                string tenTK = textBox1.Text;
                string matKhau = textBox2.Text;
                bool flag = false;
                if (tenTK.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản");
                }
                else if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu");
                }
                else
                {

                    if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0)
                    {
                        flag = true;

                    }
                    if (flag == true)
                    {
                        Connection db = new Connection(flag, tenTK, matKhau);
                        Home home = new Home(flag, tenTK, matKhau);
                        this.Hide();
                        home.ShowDialog();

                    }
                    if (flag == false)
                    {
                        Connection db = new Connection(flag, tenTK, matKhau);
                        Home home = new Home(flag, tenTK, matKhau);
                        this.Hide();
                        home.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng");
                    }
                }
            }    
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox2.Focus();
            }    
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }


        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }
    }
}
