using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class BanAn
    {
        private string mABA;
        private int tRANGTHAI;
        public BanAn() { }
        public BanAn(String maba, int trangthai) {
            this.MABA = maba;
            this.TRANGTHAI = trangthai;
        }
        public BanAn(DataRow row)
        {
            this.MABA = (string)row["MABA"];
            this.TRANGTHAI = (int)row["TRANGTHAI"];
        }
        public override string ToString()
        {
            return MABA;
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
