using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class HoaDonDTO
    {
        private string mAHD;
        private DateTime nGAYLAP;
        private DateTime tHOIGIANBATDAU;
        private float tONGTIEN;
        private float tIENDATHANHTOAN;
        private int tRANGTHAI;
        private string mAKH;
        private string mANV;
        private string mABA;
        public HoaDonDTO() { }
        public HoaDonDTO(string MAHD,DateTime NGAYLAP,DateTime THOIGIANBATDAU, float TONGTIEN, float TIENDATHANHTOAN, int TRANGTHAI, string MAKH, string MANV, string MABA) {
            this.MAHD = MAHD;
            this.NGAYLAP = NGAYLAP;
            this.THOIGIANBATDAU = THOIGIANBATDAU;
            this.TONGTIEN = TONGTIEN;
            this.TIENDATHANHTOAN = TIENDATHANHTOAN;
            this.TRANGTHAI = TRANGTHAI;
            this.MAKH = MAKH;
            this.MANV = MANV;
            this.MABA = MABA;
        }
        public HoaDonDTO(DataRow row)
        {
            this.MAHD = (string)row["MAHD"];
            this.NGAYLAP = (DateTime)row["NGAYLAP"];
            this.THOIGIANBATDAU = (DateTime)row["THOIGIANBATDAU"];
            this.TONGTIEN = float.Parse(row["TONGTIEN"].ToString());
            this.TIENDATHANHTOAN = float.Parse(row["TIENDATHANHTOAN"].ToString());
            this.TRANGTHAI = (int)row["TRANGTHAI"];
            this.MAKH = (string)row["MAKH"];
            this.MANV = (string)row["MANV"];
            this.MABA = (string)row["MABA"];
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

        public DateTime NGAYLAP
        {
            get
            {
                return nGAYLAP;
            }

            set
            {
                nGAYLAP = value;
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

        public float TONGTIEN
        {
            get
            {
                return tONGTIEN;
            }

            set
            {
                tONGTIEN = value;
            }
        }

        public float TIENDATHANHTOAN
        {
            get
            {
                return tIENDATHANHTOAN;
            }

            set
            {
                tIENDATHANHTOAN = value;
            }
        }

        public int TRANGTHAI
        {
            get
            {
                return tRANGTHAI;
            }

            set
            {
                tRANGTHAI = value;
            }
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

        public string MANV
        {
            get
            {
                return mANV;
            }

            set
            {
                mANV = value;
            }
        }

        public string MABA
        {
            get
            {
                return mABA;
            }

            set
            {
                mABA = value;
            }
        }
    }
}
