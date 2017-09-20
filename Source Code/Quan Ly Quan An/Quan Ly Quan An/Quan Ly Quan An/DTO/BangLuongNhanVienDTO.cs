using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class BangLuongNhanVienDTO
    {
        private string mABL;
        private string mANV;
        private DateTime tHOIGIANBATDAU;
        private DateTime tHoiGIANKETTHUC;
        private float tONGTIENLUONG;
        public BangLuongNhanVienDTO() { }
        public BangLuongNhanVienDTO(string MABL, string MANV, DateTime THOIGIANBATDAU, DateTime THOIGIANKETTHUC)
        {
            this.MABL = MABL;
            this.MANV = MANV;
            this.THOIGIANBATDAU = THOIGIANBATDAU;
            this.tHoiGIANKETTHUC = THOIGIANKETTHUC;
        }
        public BangLuongNhanVienDTO(DataRow row)
        {
            this.MABL = (string)row["MABL"];
            this.MANV = (string)row["MANV"];
            this.THOIGIANBATDAU = (DateTime)row["THOIGIANBATDAU"];
            this.tHoiGIANKETTHUC = (DateTime)row["THOIGIANKETTHUC"];
        }

        public string MABL
        {
            get
            {
                return mABL;
            }

            set
            {
                mABL = value;
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

        public DateTime THoiGIANKETTHUC
        {
            get
            {
                return tHoiGIANKETTHUC;
            }

            set
            {
                tHoiGIANKETTHUC = value;
            }
        }

        public float TONGTIENLUONG
        {
            get
            {
                return tONGTIENLUONG;
            }

            set
            {
                tONGTIENLUONG = value;
            }
        }
    }
}
