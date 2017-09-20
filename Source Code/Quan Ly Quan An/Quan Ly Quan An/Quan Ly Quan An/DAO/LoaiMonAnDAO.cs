using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class LoaiMonAnDAO
    {
        private static LoaiMonAnDAO instance;

        public static LoaiMonAnDAO Instance
        {
            get
            {
                if (instance == null) instance = new LoaiMonAnDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public LoaiMonAnDAO() { }
        /// <summary>
        /// thêm loại món ăn
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool insertCategory(string ma, string name)
        {
            string query = "USP_INSERTLOAIMONAN @MALOAI , @TENLOAI ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ma, name })>0;
        }
        /// <summary>
        /// lấy danh sách loại món ăn
        /// </summary>
        /// <returns></returns>
        public List<LoaiMonAnDTO> getListCategory()
        {
            List<LoaiMonAnDTO> result = new List<LoaiMonAnDTO>();
            string query = "USP_GETLISTLOAIMONAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new LoaiMonAnDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách loại món ăn
        /// </summary>
        /// <returns></returns>
        public List<LoaiMonAn> getListCategoryClassCategoryName()
        {
            List<LoaiMonAn> result = new List<LoaiMonAn>();
            string query = "USP_GETLISTLOAIMONAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new LoaiMonAn(item));
            }
            return result;
        }
        /// <summary>
        /// Xóa loại món ăn
        /// </summary>
        /// <param name="maloaima"></param>
        /// <returns></returns>
        public bool deleteCategory(string maloaima)
        {
            string query = "USP_DELETELOAIMONAN @MALOAI";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { maloaima}) > 0;
        }
        /// <summary>
        /// cập nhật thông tin loại món ăn
        /// </summary>
        /// <param name="maloaima"></param>
        /// <param name="ten"></param>
        /// <returns></returns>
        public bool updateCategory(string maloaima,string ten)
        {
            string query = "USP_UPDATELOAIMONAN @MALOAI , @TEN";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { maloaima, ten }) > 0;
        }
        /// <summary>
        /// lấy danh sách loại món ăn theo mama
        /// </summary>
        /// <param name="MAMA"></param>
        /// <returns></returns>
        public LoaiMonAnDTO getLoaiMAbyMAMA(string MAMA)
        {
            LoaiMonAnDTO result=null;
            string query = "USP_getLoaiMAbyMAMA @mama";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MAMA });
            foreach (DataRow item in data.Rows)
            {
                result = new LoaiMonAnDTO(item);
            }
            return result;
        }
    }
}
