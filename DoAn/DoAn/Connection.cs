using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace DoAn
{
    class Connection
    {
        string user = "";
        string pass = " ";
        bool flag = true;
        public static string chuoiketnoi = "";

        public SqlConnection conn = new SqlConnection();
        public SqlDataAdapter da;

        public Connection(bool flag, string user, string pass)
        {
            this.flag = flag;
            this.pass = pass;
            
            this.user = user;
            if (this.conn == null)
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập");
            }
            else if (flag == true)
            {
                chuoiketnoi = "Data Source =DESKTOP-1SP23K9; Initial Catalog =DB_QuanLyTrungTamTinHoc; Integrated Security = true";
                conn = new SqlConnection(chuoiketnoi);
            }
            else if (flag == false)
            {
                chuoiketnoi = "Data Source =DESKTOP-1SP23K9; Initial Catalog =DB_QuanLyTrungTamTinHoc; User ID ='" + user + "' ; Password = '" + pass + "'";
                conn = new SqlConnection(chuoiketnoi);
            }
        }
 
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(chuoiketnoi);
        }
        public DataSet getDataSet(string sqlquery)
        {
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(sqlquery, conn);
            da.Fill(ds);
            return ds;
        }
    }
}
