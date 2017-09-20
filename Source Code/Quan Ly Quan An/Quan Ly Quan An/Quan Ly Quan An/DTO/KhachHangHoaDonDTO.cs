using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class KhachHangHoaDonDTO
    {
        private string mAKH;
        private string tENKH;
        private string sODIENTHOAI;
        private DateTime tHOIGIANBATDAU;
        private string mAHD;
        //private 
        public override string ToString()
        {
            return TENKH;
        }
        public KhachHangHoaDonDTO() { }
        public KhachHangHoaDonDTO(string MAKH, string TENKH, string SODIENTHOAI,DateTime THOIGIANBATDAU,string MAHD)
        {
            this.MAKH = MAKH;
            this.TENKH = TENKH;
            this.SODIENTHOAI = SODIENTHOAI;
            this.THOIGIANBATDAU = THOIGIANBATDAU;
            this.MAHD = MAHD;
        }
        public KhachHangHoaDonDTO(DataRow row)
        {
            this.MAKH = (string)row["MAKH"];
            this.TENKH = (string)row["TENKH"];
            this.SODIENTHOAI = (string)row["SODIENTHOAI"];
            this.THOIGIANBATDAU = (DateTime)row["THOIGIANBATDAU"];
            this.MAHD = (string)row["MAHD"];
        }

        public string MAKH
        {
            get
            {
                return mAKH;
            }

            set
            {
                mAKH = value;
            }
        }

        public string TENKH
        {
            get
            {
                return tENKH;
            }

            set
            {
                tENKH = value;
            }
        }

        public string SODIENTHOAI
        {
            get
            {
                return sODIENTHOAI;
            }

            set
            {
                sODIENTHOAI = value;
            }
        }

        public DateTime THOIGIANBATDAU
        {
            get
            {
                return tHOIGIANBATDAU;
            }

            set
            {
                tHOIGIANBATDAU = value;
            }
        }

        public string MAHD
        {
            get
            {
                return mAHD;
            }

            set
            {
                mAHD = value;
            }
        }
    }
}
