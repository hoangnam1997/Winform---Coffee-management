using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class ThongTinMonAnBingdingDAO
    {
        private string connectSTR = DataProvider.Instance.connectSTR;
        
        private static ThongTinMonAnBingdingDAO instance;

        public static ThongTinMonAnBingdingDAO Instance
        {
            get
            {
                if (instance == null) instance = new ThongTinMonAnBingdingDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public ThongTinMonAnBingdingDAO() { }
        private event EventHandler _Change;
        public event EventHandler Change
        {
            add { _Change += value; }
            remove { _Change -= value; }
        }
        private event EventHandler _ChangeWaiting;
        public event EventHandler ChangeWaiting
        {
            add { _ChangeWaiting += value; }
            remove { _ChangeWaiting -= value; }
        }
        private event EventHandler _ChangeCooking;
        public event EventHandler ChangeCooking
        {
            add { _ChangeCooking += value; }
            remove { _ChangeCooking -= value; }
        }
        /// <summary>
        /// lấy đanh sách đã làm xong
        /// </summary>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getListItemCheckDone()
        {
            System.Data.SqlClient.SqlDependency.Start(connectSTR);
            string query = "getListFoodDone";
            List<ThongTinHoaDonDTO> result =new List<ThongTinHoaDonDTO>();
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(connectSTR))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Notification = null;

                    SqlDependency de = new SqlDependency(cmd);
                    de.OnChange += new OnChangeEventHandler(de_OnChange);

                    dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                    int i = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        i++;
                        result.Add(new ThongTinHoaDonDTO(i,item));
                    }
                    return result;
                }

            }
            catch (Exception e)
            {
                return result;
            }
        }
        /// <summary>
        /// lấy danh sách đnag đợi
        /// </summary>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getListItemWaiting()
        {
            System.Data.SqlClient.SqlDependency.Start(connectSTR);
            string query = "getListFoodWaiting";
            List<ThongTinHoaDonDTO> result = new List<ThongTinHoaDonDTO>();
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(connectSTR))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Notification = null;

                    SqlDependency de = new SqlDependency(cmd);
                    de.OnChange += new OnChangeEventHandler(de_OnChangeWaiting);

                    dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                    int i = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        i++;
                        result.Add(new ThongTinHoaDonDTO(i, item));
                    }
                    return result;
                }

            }
            catch (Exception e)
            {
                return result;
            }
        }
        /// <summary>
        /// lấy danh sách đang nấu
        /// </summary>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getListItemCooking()
        {
            System.Data.SqlClient.SqlDependency.Start(connectSTR);
            string query = "getListFoodCooking";
            List<ThongTinHoaDonDTO> result = new List<ThongTinHoaDonDTO>();
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(connectSTR))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Notification = null;

                    SqlDependency de = new SqlDependency(cmd);
                    de.OnChange += new OnChangeEventHandler(de_OnChangeCooking);

                    dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                    int i = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        i++;
                        result.Add(new ThongTinHoaDonDTO(i, item));
                    }
                    return result;
                }

            }
            catch (Exception e)
            {
                return result;
            }
        }

        private void de_OnChangeCooking(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= de_OnChangeCooking;
            if (_ChangeCooking != null)
            {
                _ChangeCooking(this, new EventArgs());
            }
        }

        private void de_OnChangeWaiting(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= de_OnChangeWaiting;
            if (_ChangeWaiting != null)
            {
                _ChangeWaiting(this, new EventArgs());
            }
        }

        private void de_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= de_OnChange;
            if (_Change != null)
            {
                _Change(this, new EventArgs());
            }
        }
    }
}
