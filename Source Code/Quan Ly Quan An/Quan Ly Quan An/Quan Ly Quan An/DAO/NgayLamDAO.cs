using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class NgayLamDAO
    {
        private static NgayLamDAO instance;

        public static NgayLamDAO Instance
        {
            get
            {
                if (instance == null) instance = new NgayLamDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public NgayLamDAO() { }
        /// <summary>
        /// lấy danh sách ngày là chưa tính lương của nhân viên
        /// </summary>
        /// <param name="manv"></param>
        /// <returns></returns>
        public List<NgayLamSTTDTO> getDanhSachNgayChuaTinhLuongMANV(string manv)
        {
            List<NgayLamSTTDTO> result = new List<NgayLamSTTDTO>();
            string query = "USP_GETDAYWORKNONCHECKBYUSERNAME @MANV";
            DataTable data=DataProvider.Instance.ExecuteQuery(query, new object[] { manv });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new NgayLamSTTDTO(i,item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách ngày chưa tính lương của nhân viên. có time
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="manv"></param>
        /// <returns></returns>
        public List<NgayLamSTTDTO> getDanhSachNgayChuaTinhLuongMANV(DateTime tuNgay, DateTime denNgay,string manv)
        {
            List<NgayLamSTTDTO> result = new List<NgayLamSTTDTO>();
            string query = "USP_listNgayLamChuaTinhLuong @tuNgay , @denNgay , @MANV";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {tuNgay,denNgay, manv });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new NgayLamSTTDTO(i, item));
            }
            return result;
        }
        /// <summary>
        /// cập nhật ngày làm
        /// </summary>
        /// <param name="manv"></param>
        /// <param name="ngBatDau"></param>
        /// <param name="ngKetThuc"></param>
        /// <returns></returns>
        public bool updateNgayLam(string manv, DateTime ngBatDau, DateTime ngKetThuc)
        {
            string query = "UpdateCTNL @manv , @ngayBatDau , @ngayKetThuc";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, ngBatDau, ngKetThuc })>0;
        }
        /// <summary>
        /// lấy dánh sách đã tính lương của nhân viên
        /// </summary>
        /// <param name="manv"></param>
        /// <returns></returns>
        public List<NgayLamSTTDTO> getDanhSachNgayDaTinhLuongMANV(string manv)
        {
            List<NgayLamSTTDTO> result = new List<NgayLamSTTDTO>();
            string query = "USP_GETDAYWORKCHECKBYUSERNAME @MANV";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { manv });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new NgayLamSTTDTO(i, item));
            }
            return result;
        }
        /// <summary>
        /// kiểm tra ngày làm có tồn tại chưa
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool isTonTaiNgayLam(DateTime date)
        {
            string query = "USP_isNgayLam @ngaylam";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { date }) > 0;
        }
        /// <summary>
        /// thêm ngày làm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool InsertNgayLam(DateTime date)
        {
            string query = "USP_insertNgayLam @ngaylam";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { date }) > 0;
        }

    }
}
