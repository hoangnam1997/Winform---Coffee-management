using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhanVienDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public NhanVienDAO() { }
        /// <summary>
        /// cập nhật pass nhân viên. pass là 1
        /// </summary>
        /// <param name="manv"></param>
        /// <returns></returns>
        public bool resetPass(string manv)
        {
            string query = "USP_resetPass @manv";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv })>0;
        }
        /// <summary>
        /// Them nhan vien
        /// </summary>
        /// <param name="tenNV"></param>
        /// <returns></returns>
        public bool insertNhanVien(string manv,string hoten,DateTime ngaysinh,string diachi ,string sdt, DateTime ngayvl,int phanquyen,float mucluong,string matkhau)
        {
            string query = "USP_insertNhanVien @manv , @hoten , @Datetime , @diachi , @sdt , @NGVAOLAM , @phanquyen , @mucluong , @matkhau";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, hoten, ngaysinh, diachi,sdt, ngayvl, phanquyen, mucluong, matkhau }) > 0;

        }
        /// <summary>
        /// cập nhật thong tin nhân viên
        /// </summary>
        /// <param name="manv"></param>
        /// <param name="hoten"></param>
        /// <param name="ngaysinh"></param>
        /// <param name="diachi"></param>
        /// <param name="sdt"></param>
        /// <param name="ngayvl"></param>
        /// <param name="phanquyen"></param>
        /// <param name="mucluong"></param>
        /// <returns></returns>
        public bool updateNhanVien(string manv, string hoten, DateTime ngaysinh, string diachi, string sdt, DateTime ngayvl, int phanquyen, float mucluong)
        {
            string query = "USP_updateNhanVien @manv , @hoten , @Datetime , @diachi , @sdt , @NGVAOLAM , @phanquyen , @mucluong";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, hoten, ngaysinh, diachi, sdt, ngayvl, phanquyen, mucluong }) > 0;

        }
        /// <summary>
        /// xóa nhân viên
        /// </summary>
        /// <param name="manv"></param>
        /// <returns></returns>
        public bool deleteNhanVien(string manv)
        {
            string query = "USP_deleteNhanVien @manv";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv }) > 0;

        }
        /// <summary>
        /// láy dnah sách nhân viên theo tên nhân viên
        /// </summary>
        /// <param name="tenNV"></param>
        /// <returns></returns>
        public List<NhanVienDTO> getListNhanVien(string tenNV)
        {
            List<NhanVienDTO> result = new List<NhanVienDTO>();
            string query = "USP_getListNhanVienbyTen @TenNV";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenNV });
            foreach (DataRow item in data.Rows)
            {
                result.Add(new NhanVienDTO(item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        public List<NhanVienDTO> getListNhanVien()
        {
            List<NhanVienDTO> result = new List<NhanVienDTO>();
            string query = "USP_getListNhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                result.Add(new NhanVienDTO(item));
            }
            return result;
        }

        /// <summary>
        /// Lấy ra nhân viên khi có manv
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<NhanVienDTO> getAccountByUserName(string userName)
        {
            List<NhanVienDTO> result = new List<NhanVienDTO>();
            string query = "dbo.USP_GETACCOUNTBYUSERNAME @USERNAME";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    result.Add(new NhanVienDTO(item));
                }
            }
            return result;
        }
        /// <summary>
        /// Cập nhật mật khẩu.
        /// </summary>
        /// <param name="manv"></param>
        /// <param name="passNew"></param>
        /// <returns></returns>
        public bool updateAccountPass(string manv, string passNew)
        {
            string query = "dbo.USP_UPDATEPASSBYUSERNAME @MANV , @PASS";
            try
            {
                if (DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, passNew }) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Cập nhật thông tin tài khoản
        /// </summary>
        /// <param name="manv"></param>
        /// <param name="HOTEN"></param>
        /// <param name="DiaChi"></param>
        /// <param name="SDT"></param>
        /// <param name="NGAYSINH"></param>
        /// <returns></returns>
        public bool updateAccountInfomation(string manv, string HOTEN, string DiaChi, string SDT, DateTime NGAYSINH)
        {
            string query = "dbo.USP_UPDATEACCOUNTINFOMATION @MANV , @HOTEN , @DIACHI , @SDT , @NGSINH ";
            try
            {
                if (DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, HOTEN, DiaChi, SDT, NGAYSINH }) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        /// <summary>
        /// lấy pass khi có manv
        /// </summary>
        /// <param name="MANV"></param>
        /// <returns></returns>
        public string getPassByMANV(string MANV)
        {
            string query = "USP_GetPassByMANV @manv";
            return (string)DataProvider.Instance.ExecuteScalar(query, new object[] { MANV });
        }
    }
}
