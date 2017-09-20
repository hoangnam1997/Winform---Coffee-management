using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class MonAnDAO
    {
        private static MonAnDAO instance;

        public static MonAnDAO Instance
        {
            get
            {
                if (instance == null) instance = new MonAnDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public MonAnDAO() { }
        /// <summary>
        /// Lấy danh sách món ăn
        /// </summary>
        /// <returns></returns>
        public List<MonAnDTO> getListMonAn()
        {
            List<MonAnDTO> result = new List<MonAnDTO>();
            string query = "USP_getListMonAn";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new MonAnDTO(item));
            }
            return result;
        }
        /// <summary>
        /// kiểm tra món ăn có tồn tại không
        /// </summary>
        /// <param name="mama"></param>
        /// <returns></returns>
        public bool CheckMonAn(string mama)
        {
            string query = "USP_checkMonAn @mama";
            return ((int)DataProvider.Instance.ExecuteScalar(query, new object[] { mama})>0);
        }
        /// <summary>
        /// cập nhật thong tin món ăn
        /// </summary>
        /// <param name="mama"></param>
        /// <param name="tenma"></param>
        /// <param name="gia"></param>
        /// <param name="maloaima"></param>
        /// <returns></returns>
        public bool updateMonAn(string mama,string tenma,float gia,string maloaima)
        {
            string query = "USP_updateMonAn @mama , @tenma , @gia , @maloaima";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mama,tenma,gia,maloaima }) > 0;
        }
        /// <summary>
        /// thêm món ăn
        /// </summary>
        /// <param name="mama"></param>
        /// <param name="tenma"></param>
        /// <param name="gia"></param>
        /// <param name="maloaima"></param>
        /// <returns></returns>
        public bool insertMonAn(string mama, string tenma, float gia, string maloaima)
        {
            string query = "USP_insertMonAn @mama , @tenma , @gia , @maloaima";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mama, tenma, gia, maloaima }) > 0;
        }
        //xoa món ăn
        public bool deleteMonAn(string mama)
        {
            string query = "USP_deleteMonAnByMAMA @mama";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mama })>0;
        }
        /// <summary>
        /// lấy danh sách món ăn theo tên gần đúng.
        /// </summary>
        /// <param name="TenMA"></param>
        /// <returns></returns>
        public List<MonAnDTO> getListMonAnbyTenMA(string TenMA)
        {
            List<MonAnDTO> result = new List<MonAnDTO>();
            string query = "USP_GETLISTMonAnbyNAME @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { TenMA });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new MonAnDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách món ăn theo loại ma
        /// </summary>
        /// <param name="LoaiMA"></param>
        /// <returns></returns>
        public List<MonAnDTO> getListMonAnbyLoaiMonAn(string LoaiMA)
        {
            List<MonAnDTO> result = new List<MonAnDTO>();
            string query = "USP_GETLISTMonAnbyLoaiMonAn @maloaima";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { LoaiMA });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new MonAnDTO(item));
            }
            return result;
        }



        /// <summary>
        /// lấy danh sách món ăn có sl>0
        /// </summary>
        /// <returns></returns>
        public List<MonANvaSLmaDTO> getListFood()
        {
            List<MonANvaSLmaDTO> result = new List<MonANvaSLmaDTO>();
            string query = "USP_GETLISTFOOD";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new MonANvaSLmaDTO(item));
            }
            return result;
        }
        /// <summary>
        /// Lấy danh sách món ăn có sl>0 theo loai món ăn
        /// </summary>
        /// <param name="MALOAI"></param>
        /// <returns></returns>
        public List<MonANvaSLmaDTO> getListFoodByMALOAIMA(string MALOAI)
        {
            List<MonANvaSLmaDTO> result = new List<MonANvaSLmaDTO>();
            string query = "USP_GETLISTFOODBYCATEGORY @maloaima";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { MALOAI });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new MonANvaSLmaDTO(item));
            }
            return result;
        }
        /// <summary>
        /// tim theo ten gan dung danh sách món ăn có sl>0
        /// </summary>
        /// <param name="MALOAI"></param>
        /// <returns></returns>
        public List<MonANvaSLmaDTO> getListFoodByName(string Name)
        {
            List<MonANvaSLmaDTO> result = new List<MonANvaSLmaDTO>();
            string query = "USP_GETLISTFOODBYNAME @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { Name });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new MonANvaSLmaDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy số lượng món ăn theo mama
        /// </summary>
        /// <param name="mama"></param>
        /// <returns></returns>
        public float getCountFoodByMAMA(string mama)
        {
            string query = "USP_getCountByMAMA @mama";
            return (int)DataProvider.Instance.ExecuteScalar(query,new object[] { mama });
        }
    }
}
