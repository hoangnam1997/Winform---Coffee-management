using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class ctnlDAO
    {
        private static ctnlDAO instance;

        public static ctnlDAO Instance
        {
            get
            {
                if (instance == null) instance = new ctnlDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public ctnlDAO() { }
        /// <summary>
        /// thêm chi tiết nguyên liệu
        /// </summary>
        /// <param name="manv"></param>
        /// <param name="NgayLam"></param>
        /// <returns></returns>
        public bool insertCTNL(string manv,DateTime NgayLam)
        {
            string query= "USP_insertCTNL @manv , @NgayLam";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, NgayLam }) > 0;
        }
        /// <summary>
        /// kiêm tra tòn tại ctnl
        /// </summary>
        /// <param name="manv"></param>
        /// <param name="NgayLam"></param>
        /// <returns></returns>
        public bool isCTNL(string manv, DateTime NgayLam)
        {
            string query = "USP_isCTNL @manv , @NgayLam";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { manv, NgayLam }) > 0;
        }
    }
}
