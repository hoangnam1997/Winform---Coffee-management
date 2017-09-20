using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class HoaDonNhapDTO
    {
        private string mAHDN;
        private DateTime nGAYLAP;
        private double tONGTIEN;
        private int tRANGTHAI;
        public HoaDonNhapDTO() { }
        public HoaDonNhapDTO(string MAHDN,DateTime NGAYLAP, double TONGTIEN, int TRANGTHAI) {
            this.MAHDN = MAHDN;
            this.NGAYLAP = NGAYLAP;
            this.TONGTIEN = TONGTIEN;
            this.TRANGTHAI = TRANGTHAI;
        }
        public HoaDonNhapDTO(DataRow row) {
            this.MAHDN = (string)row["MAHDN"];
            this.NGAYLAP = (DateTime)row["NGAYLAP"];
            this.TONGTIEN = float.Parse(row["TONGTIEN"].ToString());
            this.TRANGTHAI = (int)row["TRANGTHAI"];
        }
        public string MAHDN
        {
            get
            {
                return mAHDN;
            }

            set
            {
                mAHDN = value;
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

        public double TONGTIEN
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
    }
}
