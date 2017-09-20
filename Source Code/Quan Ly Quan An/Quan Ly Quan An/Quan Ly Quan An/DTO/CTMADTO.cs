using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class CTMADTO
    {
        private string mAMA;
        private string mATP;
        private string tENTP;
        private float khoiLuongTP;
        public CTMADTO() { }
        public CTMADTO(string tentp,float khoiluongtp,string MATP,string MAMA) {
            this.TENTP = tentp;
            this.KhoiLuongTP = khoiluongtp;
            this.MATP = MATP;
            this.MAMA = MAMA;
        }
        public CTMADTO(DataRow row)
        {
            this.TENTP = (string)row["TENTP"];
            this.KhoiLuongTP = float.Parse(row["KhoiLuongTP"].ToString());
            this.MATP = (string)row["MATP"];
            this.MAMA = (string)row["MAMA"];
        }

        public string TENTP
        {
            get
            {
                return tENTP;
            }

            set
            {
                tENTP = value;
            }
        }

        public float KhoiLuongTP
        {
            get
            {
                return khoiLuongTP;
            }

            set
            {
                khoiLuongTP = value;
            }
        }

        public string MATP
        {
            get
            {
                return mATP;
            }

            set
            {
                mATP = value;
            }
        }

        public string MAMA
        {
            get
            {
                return mAMA;
            }

            set
            {
                mAMA = value;
            }
        }
    }
}
