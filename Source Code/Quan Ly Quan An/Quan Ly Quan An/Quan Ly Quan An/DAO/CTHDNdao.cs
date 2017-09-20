using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class CTHDNdao
    {
        private static CTHDNdao instance;

        public static CTHDNdao Instance
        {
            get
            {
                if (instance == null) instance = new CTHDNdao();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private CTHDNdao() { }
        /// <summary>
        /// them cthdn
        /// </summary>
        /// <param name="mahd"></param>
        /// <param name="matp"></param>
        /// <param name="soluong"></param>
        /// <returns></returns>
        public bool insertCTHDN(string mahd,string matp,float soluong)
        {
            string query = "USP_insertCTHDN @mahd , @matp , @soluong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, matp, soluong }) > 0;
        }
        /// <summary>
        /// lấy danh sach cthdn theo mahdn
        /// </summary>
        /// <param name="mahdn"></param>
        /// <returns></returns>
        public DataTable getListCTHDNbyMAHD(string mahdn)
        {
            string query = "USP_getListCTHDN @mahdn";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { mahdn });
        }
        /// <summary>
        /// xóa cthdn
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public bool deleteCTHDN(string mahd)
        {
            string query = "delete CTHDN where mahdn='"+mahd+"'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
