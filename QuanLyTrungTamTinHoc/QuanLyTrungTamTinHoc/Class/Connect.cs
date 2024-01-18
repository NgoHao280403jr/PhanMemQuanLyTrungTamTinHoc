using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyTrungTamTinHoc_DB.Class
{
    internal class Connect
    {
        SqlConnection connect;
        public Connect()
        {
            connect = new SqlConnection("Data Source=DESKTOP-1SP23K9;Initial Catalog=DB_QuanLyTrungTamTinHoc;Integrated Security=True");
        }
        public SqlConnection GetData()
        {
            return connect;
        }
    }
}
