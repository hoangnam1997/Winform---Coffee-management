using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class BangLuongNhanVienDAO
    {
        private static BangLuongNhanVienDAO instance;

        public static BangLuongNhanVienDAO Instance
        {
            get
            {
                if (instance == null) instance = new BangLuongNhanVienDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private BangLuongNhanVienDAO() { }
        /// <summary>
        /// lấy bảng lương nhân viên
        /// </summary>
        /// <param name="dateTuNgay"></param>
        /// <param name="dateDenNgay"></param>
        /// <returns></returns>
        public List<BangLuongTempDTO> getBangLuongtemp( DateTime dateTuNgay, DateTime dateDenNgay)
        {
            List<BangLuongTempDTO> result = new List<BangLuongTempDTO>();
            string query = "USP_getBangLuongTemp @tungay , @denngay";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {dateTuNgay,dateDenNgay });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new BangLuongTempDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy bảng lương nhân vien
        /// </summary>
        /// <param name="dateTuNgay"></param>
        /// <param name="dateDenNgay"></param>
        /// <param name="tennv"></param>
        /// <returns></returns>
        public List<BangLuongTempDTO> getBangLuongtemp(DateTime dateTuNgay, DateTime dateDenNgay,string tennv)
        {
            List<BangLuongTempDTO> result = new List<BangLuongTempDTO>();
            string query = "USP_getBangLuongTempbyTen @tungay , @denngay , @tennv";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { dateTuNgay, dateDenNgay,tennv });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new BangLuongTempDTO(item));
            }
            return result;
        }
        /// <summary>
        /// thêm bảng lương
        /// </summary>
        /// <param name="MABL"></param>
        /// <param name="MANV"></param>
        /// <param name="ThoiGianBatDau"></param>
        /// <param name="ThoiGianKetThuc"></param>
        /// <param name="TongTien"></param>
        /// <param name="ngaylap"></param>
        /// <returns></returns>
        public bool insertBangLuong(string MABL,string MANV,DateTime ThoiGianBatDau,DateTime ThoiGianKetThuc,float TongTien,DateTime ngaylap)
        {
            string query = "USP_insertBangLuong @mabl , @manv , @thoigianbatdau , @thoigianketthuc , @tongtien , @NgayLap";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MABL,MANV,ThoiGianBatDau,ThoiGianKetThuc,TongTien, ngaylap })>0;
        }
        /// <summary>
        /// lấy danh sach bảng lương theo ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable getListBangLuongTuNgayDenNgay(DateTime TuNgay, DateTime DenNgay)
        {
            string query = "USP_getListBangLuongbyThoiGian @TuNgay , @DenNgay";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { TuNgay, DenNgay });
        }
    }
}
