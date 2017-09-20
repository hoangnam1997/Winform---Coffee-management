using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class KhachHangDTO
    {
        private string mAKH;
        private string tENKH;
        private string sODIENTHOAI;
        public override string ToString()
        {
            return TENKH;
        }
        public KhachHangDTO() { }
        public KhachHangDTO(string MAKH,string TENKH,string SODIENTHOAI)
        {
            this.MAKH = MAKH;
            this.TENKH = TENKH;
            this.SODIENTHOAI = SODIENTHOAI;
        }
        public KhachHangDTO(DataRow row)
        {
            this.MAKH = (string)row["MAKH"];
            this.TENKH = (string)row["TENKH"];
            this.SODIENTHOAI = (string)row["SODIENTHOAI"];
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
    }
}
