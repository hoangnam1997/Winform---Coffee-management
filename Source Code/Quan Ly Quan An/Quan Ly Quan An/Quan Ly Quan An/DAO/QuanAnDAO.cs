using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class QuanAnDAO
    {
        private static QuanAnDAO instance;

        public static QuanAnDAO Instance
        {
            get
            {
                if (instance == null) instance = new QuanAnDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private QuanAnDAO() { }
        /// <summary>
        /// lấy tham số
        /// </summary>
        /// <returns></returns>

        public QuanAnDTO getListQuanAn()
        {
            QuanAnDTO result = null;
            string query = "USP_getListQuanAn";
            DataTable data=DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result=new QuanAnDTO(item);

            }
            return result;
        }
        /// <summary>
        /// thêm tham số
        /// </summary>
        /// <returns></returns>
        public bool insertDefaultValueQuanAn()
        {
            string query = "insertDefaultQuanAn";
            return DataProvider.Instance.ExecuteNonQuery(query)>0;
        }
        /// <summary>
        /// update tham số
        /// </summary>
        /// <param name="prepersen"></param>
        /// <param name="import"></param>
        /// <returns></returns>
        public bool UpdateValue(float prepersen, float import)
        {
            string query = "USP_AlterQuanAn  @import , @prePersen ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { import, prepersen }) > 0;
        }
    }
}
