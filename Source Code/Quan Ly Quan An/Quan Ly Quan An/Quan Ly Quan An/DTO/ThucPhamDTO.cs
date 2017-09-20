using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class ThucPhamDTO
    {
        private string mATP;
        private string tENTP;
        private float giaTP;
        private float kHOILUONGTONKHO;
        public ThucPhamDTO() { }
        public ThucPhamDTO(string MATP, string TENTP,float GiaTP,float KHOILUONGTONKHO) {
            this.MATP = MATP;
            this.TENTP = TENTP;
            this.GiaTP = GiaTP;
            this.KHOILUONGTONKHO = KHOILUONGTONKHO;
        }
        public ThucPhamDTO(DataRow row)
        {
            this.MATP = (string)row["MATP"];
            this.TENTP = (string)row["TENTP"];
            this.GiaTP = float.Parse(row["GiaTP"].ToString());
            this.KHOILUONGTONKHO = float.Parse(row["KHOILUONGTONKHO"].ToString());
        }
        public override string ToString()
        {
            return this.TENTP;
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

        public float GiaTP
        {
            get
            {
                return giaTP;
            }

            set
            {
                giaTP = value;
            }
        }

        public float KHOILUONGTONKHO
        {
            get
            {
                return kHOILUONGTONKHO;
            }

            set
            {
                kHOILUONGTONKHO = value;
            }
        }
    }
}
