using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null) instance = new KhachHangDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public KhachHangDAO() { }
        /// <summary>
        /// Lấy danh sách khách hàng theo mã hóa đơn
        /// </summary>
        /// <param name="MAHD"></param>
        /// <returns></returns>
        public KhachHangHoaDonDTO getKhachHangHoaDonByMAHD(string MAHD)
        {
            KhachHangHoaDonDTO result =null;
            string query = "USP_getKHACHHANGHOADONbyMAHD @MAHD";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { MAHD });
            foreach (DataRow item in data.Rows)
            {
                result = new KhachHangHoaDonDTO(item);
            }
            return result;
        }
        /// <summary>
        /// Lấy tất cả danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public List<KhachHangDTO> getListKhachHang()
        {
            List<KhachHangDTO> result = new List<KhachHangDTO>() ;
            string query = "USP_getListKhachHang";
            DataTable data=DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new KhachHangDTO(item));
            }
            return result;
        }
        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="makh"></param>
        /// <param name="tenkh"></param>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public bool insertKhachHang(string makh, string tenkh, string sdt)
        {
            string query = "USP_insertKhachHang @makh , @tenkh , @sdt";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { makh, tenkh, sdt }) > 0;
        }
        /// <summary>
        /// Câph nhật thông tin khách hàng
        /// </summary>
        /// <param name="makh"></param>
        /// <param name="tenkh"></param>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public bool updateKhachHang(string makh, string tenkh, string sdt)
        {
            string query = "USP_updateKhachHang @makh , @tenkh , @sdt";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { makh, tenkh, sdt }) > 0;
        }
        /// <summary>
        /// Xóa khách hàng với makh
        /// </summary>
        /// <param name="makh"></param>
        /// <returns></returns>
        public bool deleteKhachHang(string makh)
        {
            string query = "USP_deleteKhachHang @makh";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { makh }) > 0;
        }
        /// <summary>
        /// Lấy danh sách khách hàng theo tên và 
        /// </summary>
        /// <param name="ten"></param>
        /// <returns></returns>
        public List<KhachHangDTO> getListKhachHangByTen(string ten)
        {
            List<KhachHangDTO> result = new List<KhachHangDTO>();
            string query = "USP_getListKhachHangbyTen @ten";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { ten});
            foreach (DataRow item in data.Rows)
            {
                result.Add(new KhachHangDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy thông tin khách hàng theo sdt
        /// </summary>
        /// <param name="SDT"></param>
        /// <returns></returns>
        public KhachHangDTO getKhachHangBySDTN(string SDT)
        {
            KhachHangDTO result = null;
            string query = "SELECT *FROM dbo.KHACHHANG WHERE SODIENTHOAI = '"+ SDT+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result=(new KhachHangDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy số lượng kh theo makh
        /// </summary>
        /// <param name="MAKH"></param>
        /// <returns></returns>
        public int getSoLuongKhachHang(string MAKH)
        {
            int result = 0;
            string query = "getSoLuongKHbyMAKH @makh";
            result = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { MAKH });
            return result;
        }
    }
}
