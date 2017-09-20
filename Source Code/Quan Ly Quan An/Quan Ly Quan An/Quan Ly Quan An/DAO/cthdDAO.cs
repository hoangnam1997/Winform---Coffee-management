using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class cthdDAO
    {
        private static cthdDAO instance;

        public static cthdDAO Instance
        {
            get
            {
                if (instance == null) instance = new cthdDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public cthdDAO() { }
        /// <summary>
        /// lấy thông tin hóa đơn theo maba
        /// </summary>
        /// <param name="MABA"></param>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getListItemNonCheckByMABA(string MABA)
        {
            List<ThongTinHoaDonDTO> result = new List<ThongTinHoaDonDTO>();
            string query = "USP_GETnonCheckLISTHOADONBYMABA @maba";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MABA });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new ThongTinHoaDonDTO(i, item));
            }
            return result;
        }
        /// <summary>
        /// lấy thông tin hóa đơn them makd và mahd
        /// </summary>
        /// <param name="makh"></param>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getListItemPreByMAKHandMAHD(string makh, string mahd)
        {
            List<ThongTinHoaDonDTO> result = new List<ThongTinHoaDonDTO>();
            string query = "USP_GETPreLISTHOADONbyMAKHandMaHD @makh , @mahd";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { makh, mahd });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new ThongTinHoaDonDTO(i, item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách đặt trước theo maba
        /// </summary>
        /// <param name="maba"></param>
        /// <returns></returns>
        public List<DateTime> getListDateTimePreByMaBa(string maba)
        {
            List<DateTime> result = new List<DateTime>();
            string query = "USP_GetDateHoaDonPreByMABA @maba";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maba });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add((DateTime)item["THOIGIANBATDAU"]);
            }
            return result;
        }
        /// <summary>
        /// thêm hóa đơn
        /// </summary>
        /// <param name="MAHD"></param>
        /// <param name="NGAYLAP"></param>
        /// <param name="THOIGIANBATDAU"></param>
        /// <param name="TONGTIEN"></param>
        /// <param name="TIENDATHANHTOAN"></param>
        /// <param name="TRANGTHAI"></param>
        /// <param name="MAKH"></param>
        /// <param name="MANV"></param>
        /// <param name="MABA"></param>
        /// <returns></returns>

        public bool insertCTHD(string MAHD, string MAMA, int SOLUONGMA, int TRANGTHAI)
        {
            string query = "dbo.USP_InsertCTHD @MAHD , @MAMA , @SoLuongMA , @TRANGTHAI";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD, MAMA, SOLUONGMA, TRANGTHAI }) > 0;
        }
        /// <summary>
        /// Xáo cthd chưa chế biến kiệp.
        /// </summary>
        /// <param name="MAHD"></param>
        /// <returns></returns>
        public bool xoaCTHDChuaCheBienCTHD(string MAHD)
        {
            string query = "delete CTHD where MAHD='"+MAHD+ "' and TRANGTHAI=-1";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        /// <summary>
        /// cập nhật thong tin hóa đơn
        /// </summary>
        /// <param name="MAHD"></param>
        /// <param name="MAMA"></param>
        /// <param name="TrangThaiold"></param>
        /// <param name="trangthainew"></param>
        /// <returns></returns>
        public bool updateCTHD(string MAHD, string MAMA, int TrangThaiold, int trangthainew)
        {
            string query = "USP_updateCTHDChicken @mahd , @mama , @trangthaiOld , @TrangThai";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD, MAMA, TrangThaiold, trangthainew }) > 0;
        }
        /// <summary>
        /// lấy danh thong tin hóa đơn theo maba
        /// </summary>
        /// <param name="maba"></param>
        /// <returns></returns>
        public DataTable getListPrintBills(string maba)
        {
            string query = "USP_GETBillsNonCheckByMABA @maba";
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExecuteQuery(query, new object[] { maba });
            return data;
        }
        /// <summary>
        /// lấy thông tin hóa đơn them mahd
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public DataTable getListPrintBillsbyMAHD(string mahd)
        {
            string query = "USP_GETBillsByMAHD @mahd";
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExecuteQuery(query, new object[] { mahd });
            return data;
        }
        /// <summary>
        /// lấy tiền đã thanh toán theo mahd
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public float getTienDaThanhToanByHoaDon(string mahd)
        {
            float result = 0;
            string query = "USP_GetTIENDATHANHTOANByMAHD @MAHD";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { mahd });
            foreach (DataRow item in data.Rows)
            {
                result += float.Parse(item["TIENDATHANHTOAN"].ToString());
            }
            return result;
        }
        /// <summary>
        /// cập nhật cthd
        /// </summary>
        /// <param name="mahd"></param>
        /// <param name="mama"></param>
        /// <param name="sl"></param>
        /// <returns></returns>
        public bool updateCTHDbyMAHDandMAMA(string mahd, string mama, int sl)
        {
            string query = "USP_UpdateCTHD @mahd , @mama , @sl , @trangthai";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, mama, sl, -1 }) > 0;
        }
        /// <summary>
        /// xóa cthd
        /// </summary>
        /// <param name="mahd"></param>
        /// <param name="mama"></param>
        /// <returns></returns>
        public bool deleteCTHDbyMAHDandMAMA(string mahd, string mama)
        {
            string query = " USP_deleteCTHD @mahd , @mama";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, mama }) > 0;
        }
        /// <summary>
        /// lấy danh sách món ăn đãn xong
        /// </summary>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getDanhSachMonAnDaXong()
        {
            List<ThongTinHoaDonDTO> result = new List<ThongTinHoaDonDTO>();
            string query = "getListFoodDone";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new ThongTinHoaDonDTO(i, item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách món ăn đang làm
        /// </summary>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getDanhSachMonANDangLam()
        {
            List<ThongTinHoaDonDTO> result = new List<ThongTinHoaDonDTO>();
            string query = "getListFoodCooking";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new ThongTinHoaDonDTO(i, item));
            }
            return result;
        }
        /// <summary>
        /// lấy danh sách món ăn đag đợi
        /// </summary>
        /// <returns></returns>
        public List<ThongTinHoaDonDTO> getDanhSachMonANDangdoi()
        {
            List<ThongTinHoaDonDTO> result = new List<ThongTinHoaDonDTO>();
            string query = "getListFoodWaiting";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add(new ThongTinHoaDonDTO(i, item));
            }
            return result;
        }
    }
}
