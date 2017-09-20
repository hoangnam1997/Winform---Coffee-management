    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class CTTPdao
    {
        private static CTTPdao instance;

        public static CTTPdao Instance
        {
            get
            {
                if (instance == null) instance = new CTTPdao();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private CTTPdao() { }
        /// <summary>
        /// thêm ctp
        /// </summary>
        /// <param name="MATP"></param>
        /// <param name="MANCC"></param>
        /// <returns></returns>
        public bool insertCTTP(string MATP, string MANCC)
        {
            if(CTTPdao.Instance.isTonTaiCTTP(MATP,MANCC))
            {
                fMessageBoxOK.Show("Đã tồn tại!");
                return false;
            }
            string query = "USP_insertCTTP @matp , @mancc";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MATP, MANCC })>0;
        }
        public bool isTonTaiCTTP(string MATP, string MANCC)
        {
            string query="select count(*)from CTTP where MATP='"+MATP+"' and MANCC='"+MANCC+"'";
            return (int)DataProvider.Instance.ExecuteScalar(query)>0;
        }
        /// <summary>
        /// xóa cttp
        /// </summary>
        /// <param name="MATP"></param>
        /// <param name="MANCC"></param>
        /// <returns></returns>
        public bool deleteCTTP(string MATP, string MANCC)
        {
            if (!CTTPdao.Instance.isTonTaiCTTP(MATP, MANCC))
            {
                fMessageBoxOK.Show("Không tồn tại!");
                return false;
            }
            string query = "delete CTTP where MATP='"+MATP+"' and MANCC='"+MANCC+"'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
