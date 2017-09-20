using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class ctmaDAO
    {
        private static ctmaDAO instance;

        public static ctmaDAO Instance
        {
            get
            {
                if (instance == null) instance = new ctmaDAO();
                return instance;
            }

           private set
            {
                instance = value;
            }
        }
        private ctmaDAO() { }
        /// <summary>
        /// thêm
        /// </summary>
        /// <param name="mama"></param>
        /// <param name="matp"></param>
        /// <param name="khoiluongTP"></param>
        /// <returns></returns>
        public bool insertCTMA(string mama, string matp,float khoiluongTP)
        {
            string query = "USP_insertCTMAbyMAMA @mama , @matp , @khoiLuong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mama ,matp,khoiluongTP}) > 0;
        }
        /// <summary>
        /// xoá ctma theo mama
        /// </summary>
        /// <param name="mama"></param>
        /// <returns></returns>
        public bool deleteCTMAbyMAMA(string mama)
        {
            string query = "USP_deleteCTMDbyMAMA @mama";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mama })>0;
        }
        /// <summary>
        /// láy danh sách món ăn theo mama, tìm kiếm gần đúng
        /// </summary>
        /// <param name="MAMA"></param>
        /// <returns></returns>
        public List<CTMADTO> getListCTMAbyMAMA(string MAMA)
        {
            List<CTMADTO> result = new List<CTMADTO>();
            string query = "USP_getCTMAbyMAMA @mama";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MAMA });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new CTMADTO(item));
            }
            return result;
        }

    }
}
