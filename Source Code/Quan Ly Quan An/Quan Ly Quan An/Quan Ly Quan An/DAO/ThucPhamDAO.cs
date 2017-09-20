using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class ThucPhamDAO
    {
        private static ThucPhamDAO instance;

        public static ThucPhamDAO Instance
        {
            get
            {
                if (instance == null) instance = new ThucPhamDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ThucPhamDAO() { }
        /// <summary>
        /// xóa thực phẩm với matp
        /// </summary>
        /// <param name="MATP"></param>
        /// <returns></returns>
        public bool deleteThucPham(string MATP)
        {
            string query = "USP_deleteThucPham @matp";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MATP }) > 0;
        }
        /// <summary>
        /// lấy danh sách thực phẩm theo tên
        /// </summary>
        /// <param name="tenTP"></param>
        /// <returns></returns>
        public List<ThucPhamDTO> getListThucPhambtTenTP(string tenTP)
        {
            List<ThucPhamDTO> result = new List<ThucPhamDTO>();
            string query = "USP_getListThucPhambyName @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenTP });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new ThucPhamDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách tát cả thực phẩm
        /// </summary>
        /// <returns></returns>
        public List<ThucPhamDTO> getListThucPham()
        {
            List<ThucPhamDTO> result = new List<ThucPhamDTO>();
            string query = "USP_getListThucPham";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new ThucPhamDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách tát cả thực phẩm
        /// </summary>
        /// <returns></returns>
        public List<ThucPhamDTO> getListThucPham(string MANCC)
        {
            List<ThucPhamDTO> result = new List<ThucPhamDTO>();
            string query = "DECLARE @mucnhap FLOAT = 0; SELECT @mucnhap = MUCNHAP FROM dbo.ThamSo; SELECT* FROM dbo.THUCPHAM JOIN dbo.CTTP ON  CTTP.MATP = THUCPHAM.MATP WHERE KHOILUONGTONKHO > @mucnhap and  MANCC = '" + MANCC + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new ThucPhamDTO(item));
            }
            return result;
        }
        
        /// <summary>
        /// lấy danh sách tất cả thực phẩm trên mức nhập
        /// </summary>
        /// <returns></returns>
        public List<ThucPhamDTO> getListThucPhamTrenMucNhap()
        {
            List<ThucPhamDTO> result = new List<ThucPhamDTO>();
            string query = "USP_getListThucPhamTrenMuc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new ThucPhamDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy thực phảm theo matp
        /// </summary>
        /// <param name="MATP"></param>
        /// <returns></returns>
        public ThucPhamDTO getThucPhambyMATP(string MATP)
        {
            ThucPhamDTO result = null;
            string query = "getThucPhambyMATP @matp";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {MATP});
            foreach (DataRow item in data.Rows)
            {
                result=new ThucPhamDTO(item);
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách thực phẩm dưới mức nhập
        /// </summary>
        /// <returns></returns>
        public List<ThucPhamDTO> getListThucPhamDuoiMucNhap()
        {
            List<ThucPhamDTO> result = new List<ThucPhamDTO>();
            string query = "USP_getListThucPhamDuoiMuc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new ThucPhamDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách thực phẩm dưới mức nhập
        /// </summary>
        /// <returns></returns>
        public List<ThucPhamDTO> getListThucPhamDuoiMucNhap(string MANCC)
        {
            List<ThucPhamDTO> result = new List<ThucPhamDTO>();
            string query = "DECLARE @mucnhap FLOAT = 0; SELECT @mucnhap = MUCNHAP FROM dbo.ThamSo; SELECT* FROM dbo.THUCPHAM JOIN dbo.CTTP ON  CTTP.MATP = THUCPHAM.MATP WHERE KHOILUONGTONKHO <= @mucnhap and  MANCC = '"+MANCC+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new ThucPhamDTO(item));
            }
            return result;
        }
        /// <summary>
        /// kiểm tra thực phẩm đã tồn tại chưa
        /// </summary>
        /// <param name="MATP"></param>
        /// <returns></returns>
        public bool checkMATP(string MATP)
        {
            string query = "USP_CheckThucPham @matp ";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { MATP }) > 0;
        }
        /// <summary>
        /// thêm thực phẩm
        /// </summary>
        /// <param name="MATP"></param>
        /// <param name="tentp"></param>
        /// <param name="gia"></param>
        /// <param name="khoiluong"></param>
        /// <returns></returns>
        public bool insertThucPham(string MATP, string tentp, float gia, float khoiluong)
        {
            string query = "USP_insertThucPham @matp , @tentp , @giatp , @khoiluongtonkho";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MATP, tentp, gia, khoiluong }) > 0;
        }
        /// <summary>
        /// cập nhật thông tin thực phẩm
        /// </summary>
        /// <param name="MATP"></param>
        /// <param name="tentp"></param>
        /// <param name="gia"></param>
        /// <param name="khoiluong"></param>
        /// <returns></returns>
        public bool updateThucPham(string MATP, string tentp, float gia, float khoiluong)
        {
            string query = "USP_updateThucPham @matp , @tentp , @giatp , @khoiluongtonkho";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MATP, tentp, gia, khoiluong }) > 0;
        }

    }
}
