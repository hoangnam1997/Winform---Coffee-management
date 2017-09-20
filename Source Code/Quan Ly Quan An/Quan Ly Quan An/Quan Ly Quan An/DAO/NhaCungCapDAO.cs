using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhaCungCapDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public NhaCungCapDAO() { }
        /// <summary>
        /// lấy danh sách nhà cung cấp. tât cả
        /// </summary>
        /// <returns></returns>
        public List<NhaCungCapDTO> getListNhaCungCap()
        {
            List<NhaCungCapDTO> result = new List<NhaCungCapDTO>();
            string query = "USP_getListNhaCungCap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new NhaCungCapDTO(item));
            }
            return result;
        }
        //lấy dnah sahc nha cung cấp theo matp
        public List<NhaCungCapDTO> getListNhaCungCapbyMATP(string matp)
        {
            List<NhaCungCapDTO> result = new List<NhaCungCapDTO>();
            string query = "USP_getListNhaCungCapbyMATP @matp";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { matp });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new NhaCungCapDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lây danh sach nha cung cấp theo mancc
        /// </summary>
        /// <param name="manhacc"></param>
        /// <returns></returns>
        public List<NhaCungCapDTO> getListNhaCungCapbyNhaccganDung(string manhacc)
        {
            List<NhaCungCapDTO> result = new List<NhaCungCapDTO>();
            string query = "USP_getListNhaCungCapbyMAnccganDung @mancc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { manhacc });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new NhaCungCapDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lây danh sach nha cung cấp theo mahdn
        /// </summary>
        /// <param name="manhacc"></param>
        /// <returns></returns>
        public string getNhaCungCapbyMAHDN(string mahdn)
        {
            string result = null;
            string query = "SELECT DISTINCT MANCC FROM dbo.HOADONNHAP JOIN dbo.CTHDN ON CTHDN.MAHDN = HOADONNHAP.MAHDN JOIN dbo.THUCPHAM ON THUCPHAM.MATP = CTHDN.MATP JOIN dbo.CTTP ON CTTP.MATP = THUCPHAM.MATP WHERE HOADONNHAP.MAHDN = '"+mahdn+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result = item["MANCC"].ToString() ;
            }
            return result;
        }
        
        /// <summary>
        /// cập nhật thông tin nha cung cấp
        /// </summary>
        /// <param name="mancc"></param>
        /// <param name="sotaikhoan"></param>
        /// <param name="diachi"></param>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public bool updateNhacc(string mancc, string sotaikhoan, string diachi, string sdt)
        {
            string query = "updateNhaCC @MANCC , @sotaikhoan , @Diachi , @sdt";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mancc, sotaikhoan, diachi, sdt }) > 0;
        }
        /// <summary>
        /// thêm nhà cung cấp
        /// </summary>
        /// <param name="mancc"></param>
        /// <param name="sotaikhoan"></param>
        /// <param name="diachi"></param>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public bool insertNHACC(string mancc, string sotaikhoan, string diachi, string sdt)
        {
            string query = "insertNCC @MANCC , @sotaikhoan , @Diachi , @sdt";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mancc, sotaikhoan, diachi, sdt }) > 0;
        }
        /// <summary>
        /// lấy số long nha cug cấp
        /// </summary>
        /// <param name="mancc"></param>
        /// <returns></returns>
        public int getSoLuongNCC(string mancc)
        {
            int result = 0;
            string query = "getSoLuongNCCbyMANCC @mancc";
            result = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { mancc });
            return result;
        }
        /// <summary>
        /// xóa
        /// </summary>
        /// <param name="mancc"></param>
        /// <returns></returns>
        public bool deleteNCC(string mancc)
        {
            string query = "deleteNCC @mancc";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mancc }) > 0;
        }
    }
}
