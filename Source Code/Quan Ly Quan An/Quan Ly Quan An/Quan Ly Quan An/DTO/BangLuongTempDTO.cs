using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class BangLuongTempDTO
    {
        private string mANV;
        private string tENNV;
        private float tIENLUONG;
        public BangLuongTempDTO() { }
        public BangLuongTempDTO(string MANV,string HOTEN,float TIENLUONG) {
            this.MANV = MANV;
            this.TENNV = HOTEN;
            this.TIENLUONG = TIENLUONG;
        }
        public BangLuongTempDTO(DataRow row)
        {
            this.MANV = (string)row["MANV"];
            this.TENNV = (string)row["HOTEN"];
            this.TIENLUONG = float.Parse(row["TIENLUONG"].ToString());
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

        public string TENNV
        {
            get
            {
                return tENNV;
            }

            set
            {
                tENNV = value;
            }
        }

        public float TIENLUONG
        {
            get
            {
                return tIENLUONG;
            }

            set
            {
                tIENLUONG = value;
            }
        }
    }
}
