using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class HoaDonNhapDAO
    {
        private static HoaDonNhapDAO instance;

        public static HoaDonNhapDAO Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonNhapDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private HoaDonNhapDAO() { }
        /// <summary>
        /// thêm hóa đơn nhập
        /// </summary>
        /// <param name="MAHD"></param>
        /// <param name="NGAYLAP"></param>
        /// <param name="TONGTIEN"></param>
        /// <param name="TrangThai"></param>
        /// <returns></returns>
        public bool insertHoaDonNhap(string MAHD, DateTime NGAYLAP, float TONGTIEN, int TrangThai)
        {
            string query = "USP_insertHoaDonNhap @mahd , @ngaylap , @tongtien , @trangThai";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD, NGAYLAP, TONGTIEN, TrangThai }) > 0;

        }
        /// <summary>
        /// cập nhật hóa đơn
        /// </summary>
        /// <param name="MAHD"></param>
        /// <returns></returns>
        public bool updateHoaDonNhap(string MAHD)
        {
            string query = "USP_updateHoaDonNhapbyMAHD @mahd";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD }) > 0;
        }
        /// <summary>
        /// Xóa hóa đơn
        /// </summary>
        /// <param name="MAHD"></param>
        /// <returns></returns>
        public bool deleteHoaDonNhap(string MAHD)
        {
            string query = "delete HOADONNHAP where mahdn='"+MAHD+"'";
            if (CTHDNdao.Instance.deleteCTHDN(MAHD))
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD }) > 0;
            return false;
        }
        /// <summary>
        /// lấy danh sách hóa đơn theo mahd,tìm kiếm gần đúng
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public List<HoaDonNhapDTO> getListHoaDonNhapbyMAHD(string mahd)
        {
            List<HoaDonNhapDTO> result = new List<HoaDonNhapDTO>();
            string query = "USP_getListHoaDonNhapbyMAHD @mahd";
            DataTable date = DataProvider.Instance.ExecuteQuery(query, new object[] { mahd });
            foreach (DataRow item in date.Rows)
            {
                result.Add(new HoaDonNhapDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách chưa nhập thep mahd. tìm kiếm gần đúng
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public List<HoaDonNhapDTO> getListHoaDonNhapChuaNhapbyMAHD(string mahd)
        {
            List<HoaDonNhapDTO> result = new List<HoaDonNhapDTO>();
            string query = "USP_getListHoaDonNhapChuaXacNhanbyMAHD @mahd";
            DataTable date = DataProvider.Instance.ExecuteQuery(query, new object[] { mahd });
            foreach (DataRow item in date.Rows)
            {
                result.Add(new HoaDonNhapDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy dah sách hóa đơn từ ngày đến ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable getListHoaDonNhapTuNgayDenNgay(DateTime TuNgay, DateTime DenNgay)
        {
            string query = "USP_getListHoaDonNHapbyThoiGian @TuNgay , @DenNgay";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { TuNgay, DenNgay });
        }
    }
}
