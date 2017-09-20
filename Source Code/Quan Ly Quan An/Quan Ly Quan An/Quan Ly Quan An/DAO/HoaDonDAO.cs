
using Quan_Ly_Quan_An.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private HoaDonDAO() { }
        /// <summary>
        /// lay danh sach HD chua thanh toan tu MABA khi tới quán
        /// </summary>
        public List<String> GETHOADONNonCheckByMABA(string maba)
        {
            List<string> result = new List<string>();
            string query = "USP_GETHOADONNonCheckByMABA @MABA";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maba });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add((string)item["MAHD"]);
            }
            return result;

        }

        /// <summary>
        /// lấy hóa đơn đặt trước
        /// </summary>
        /// <param name="maba"></param>
        /// <returns></returns>
        public List<String> GETHOADONPreByMABA(string maba)
        {
            List<string> result = new List<string>();
            string query = "USP_GETHOADONPreByMABA @MABA";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maba });
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                i++;
                result.Add((string)item["MAHD"]);
            }
            return result;

        }
        /// <summary>
        /// check out hóa đơn
        /// </summary>
        /// <param name="maba"></param>
        /// <returns></returns>
        public bool UpdateHoaDonCheckOut(string MAHD)
        {
            string query = "USP_UPDATEHOADONCheckOut @mahd";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD }) > 0;
        }
        /// <summary>
        /// Lấy danh hóa đơn khi có MAHD
        /// </summary>
        /// <param name="MAHD"></param>
        /// <returns></returns>
        public HoaDonDTO getHoaDonbyMaHD(string MAHD)
        {
            HoaDonDTO result = null;
            string query = "USP_getHOADONbyMAHD @mahd";
            DataTable data=DataProvider.Instance.ExecuteQuery(query, new object[] { MAHD });
            foreach (DataRow item in data.Rows)
            {
                result = new HoaDonDTO(item);
            }
            return result;
        }
        /// <summary>
        /// lấy thông tin hóa đơn theo thời gian
        /// </summary>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <returns></returns>
        public DataTable getHoaDonbyThoiGian(DateTime tungay, DateTime denngay)
        {
            string query = "USP_getListHoaDonbyThoiGian @tungay , @denngay";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { tungay, denngay });
        }
        
        /// <summary>
        /// thay đổi thời gian đến
        /// </summary>
        /// <param name="mahd"></param>
        /// <param name="ThoiGiaDen"></param>
        /// <returns></returns>
        public bool updateTHOIGIANDEN(string mahd,DateTime ThoiGiaDen)
        {
            string query = "USP_updateThoiGianDenHOADONbyMAHD @mahd , @ThoiGiaDen";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, ThoiGiaDen })>0;
        }
        /// <summary>
        /// Thêm hóa đơn
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
        public bool insertHoaDon(string MAHD, DateTime NGAYLAP, DateTime THOIGIANBATDAU, float TONGTIEN, float TIENDATHANHTOAN, int TRANGTHAI, string MAKH, string MANV, string MABA)
        {
            string query = "dbo.USP_INSERTHOADON @MAHD , @NGAYLAP , @THOIGIANBATDAU , @TONGTIEN , @TIENTHANHTOAN  , @TRANGTHAI , @MAKH , @MANV , @MABA";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD, NGAYLAP, THOIGIANBATDAU, TONGTIEN, TIENDATHANHTOAN, TRANGTHAI, MAKH, MANV, MABA }) > 0;
        }
        /// <summary>
        /// Xóa hóa đơn
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public bool deletePreHoaDon(string @mahd)
        {
            string query = "USP_deleteHoaDonPre @MAHD";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd}) > 0;
        }
        /// <summary>
        /// Khách hàng đã đến
        /// </summary>
        /// <param name="mahd"></param>
        /// <returns></returns>
        public bool checkCome(string @mahd)
        {
            string query = "USP_checkHoaDonPre @MAHD";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd }) > 0;
        }
        /// <summary>
        /// thực hiện thanh toán
        /// </summary>
        /// <param name="MAHD"></param>
        /// <returns></returns>
        public bool checkOutHoaDonPre(string MAHD)
        {
            string query = "USP_checkOUTHOaDonPre @mahd";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MAHD }) > 0;
        }
        /// <summary>
        /// láy danh sách hóa đơn theo mama vs thời gian
        /// </summary>
        /// <param name="mama"></param>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <returns></returns>
        public DataTable gethoaDonbyMAMAvaThoiGian(string mama, DateTime tungay, DateTime denngay)
        {
            string query = "USP_GetThongKeTheoTenMonAn @tenma , @thoigianbatdau , @thoigianketthuc";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { mama, tungay, denngay });
        }
        /// <summary>
        /// láy danh sách hóa đơn theo loại
        /// </summary>
        /// <param name="maloai"></param>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <returns></returns>
        public DataTable gethoaDonbyLoaiMAvaThoiGian(string maloai, DateTime tungay, DateTime denngay)
        {
            string query = "USP_GetThongKeTheoLoaiMonAn @tenma , @thoigianbatdau , @thoigianketthuc";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maloai, tungay, denngay });
        }
        /// <summary>
        /// thong kê chi tiết theo tên
        /// </summary>
        /// <param name="tenma"></param>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <returns></returns>
        public DataTable USP_getThongKeTheoTenchiTiet(string tenma,DateTime tungay, DateTime denngay)
        {
            string query = "USP_getThongKeTheoTenchiTiet @tenma , @tuNgay , @denngay";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { tenma,tungay, denngay });
        }
        /// <summary>
        /// thống kê chi tiết theo lọai
        /// </summary>
        /// <param name="tenma"></param>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <returns></returns>
        public DataTable USP_getThongKeTheoLoaichiTiet(string tenma, DateTime tungay, DateTime denngay)
        {
            string query = "USP_GetThongKeChiTietTheoLoaiMonAn @tenma , @tuNgay , @denngay";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { tenma, tungay, denngay });
        }
    }
}
