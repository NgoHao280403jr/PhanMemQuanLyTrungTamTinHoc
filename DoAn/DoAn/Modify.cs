﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DoAn
{
    class Modify
    {
        public Modify()
        {
        }
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public List<TaiKhoan>TaiKhoans(string query)//check tài khoản
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query,sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while(dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(1),dataReader.GetString(2)));

                }    
                sqlConnection.Close();
            }    
            return taiKhoans;
        }
        public void Command( string query)
        {
            using (SqlConnection sqlConnection=Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();//thực thi câu truy vấn
                sqlConnection.Close();
            }    
        }
    }
}
