using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class DataProvider
    {
        public string connectSTR = @"Data Source=.;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectSTR))//tu giai phong khi loi xay ra.
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);


                    if (parameter != null)
                    {
                        string[] ListData = query.Split(' ');
                        int i = 0;
                        foreach (string item in ListData)
                        {
                            if (item.Contains('@'))
                            {
                                SqlParameter unitsParam=command.Parameters.AddWithValue(item, parameter[i]);
                                if (parameter[i] == null)
                                {
                                    unitsParam.Value = DBNull.Value;
                                }
                                i++;
                            }
                        }
                    }

                    // lay du lieu ra

                    SqlDataAdapter adapter = new SqlDataAdapter(command);//trung gian thuc hien lay du lieu

                    adapter.Fill(data);



                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                fMessageBoxOK.Show("Lỗi " + ex.Message);
            }
            return data;

        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {

            int data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectSTR))//tu giai phong khi loi xay ra.
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);


                    if (parameter != null)
                    {
                        string[] ListData = query.Split(' ');
                        int i = 0;
                        foreach (string item in ListData)
                        {
                            if (item.Contains('@'))
                            {

                                SqlParameter unitsParam = command.Parameters.AddWithValue(item, parameter[i]);
                                if (parameter[i] == null)
                                {
                                    unitsParam.Value = DBNull.Value;
                                }
                                i++;
                            }
                        }
                    }
                    data = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                fMessageBoxOK.Show("Lỗi sever!");
            }
            return data;

        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectSTR))//tu giai phong khi loi xay ra.
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);


                    if (parameter != null)
                    {
                        string[] ListData = query.Split(' ');
                        int i = 0;
                        foreach (string item in ListData)
                        {
                            if (item.Contains('@'))
                            {
                                SqlParameter unitsParam = command.Parameters.AddWithValue(item, parameter[i]);
                                if (parameter[i] == null)
                                {
                                    unitsParam.Value = DBNull.Value;
                                }
                                i++;
                            }
                        }
                    }
                    data = command.ExecuteScalar();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                fMessageBoxOK.Show("Lỗi " + ex.Message);
            }
            return data;

        }
    }
}
