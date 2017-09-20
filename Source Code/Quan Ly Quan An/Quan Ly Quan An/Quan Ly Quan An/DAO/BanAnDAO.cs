using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class BanAnDAO
    {
        private static BanAnDAO instance;

        public static BanAnDAO Instance
        {
            get
            {
                if (instance == null) instance = new BanAnDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public BanAnDAO() { }
        /// <summary>
        /// lấy danh sách bàng ăn
        /// </summary>
        /// <returns></returns>
        public List<BanAn> getListTable()
        {
            List<BanAn> result = new List<BanAn>();
            string query = "USP_GETLISTTABLE";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new BanAn(item));
            }
            return result;
        }
        /// <summary>
        /// lay ban an theo maba
        /// </summary>
        /// <returns></returns>
        public List<BanAn> getTableMABA(string MABA)
        {
            List<BanAn> result = new List<BanAn>();
            string query = "select *from BANAN where MABA='"+ MABA + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new BanAn(item));
            }
            return result;
        }
        /// <summary>
        /// thêm bàn ăn
        /// </summary>
        /// <param name="MABA"></param>
        /// <param name="TRANGTHAI"></param>
        /// <returns></returns>
        public bool InsertTable(string MABA, int TRANGTHAI)
        {
            string query = "USP_INSERTTABLE @MABA , @TRANGTHAI";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MABA, TRANGTHAI }) > 0;
        }
        /// <summary>
        /// cập nhật bàn ăn
        /// </summary>
        /// <param name="MABA"></param>
        /// <param name="TRANGTHAI"></param>
        /// <returns></returns>
        public bool UpdateTable(string MABA, int TRANGTHAI)
        {
            string query = "USP_UPDATETABLE @MABA , @TRANGTHAI";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MABA, TRANGTHAI }) > 0;
        }
        /// <summary>
        /// xóa bàn ăn
        /// </summary>
        /// <param name="maba"></param>
        /// <returns></returns>
        public bool deleteTable(string maba)
        {
            string query = "USP_DELETETABLE @maba";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { maba}) > 0;
        }
    }
}
