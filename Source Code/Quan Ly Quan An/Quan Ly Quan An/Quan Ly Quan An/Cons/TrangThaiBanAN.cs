using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class TrangThaiBanAN
    {
        private string tRANGTHAI;
        private int isTrangThai;
        public TrangThaiBanAN() { }
        public TrangThaiBanAN(int status) {
            this.isTrangThai = status;
            switch(status)
            {
                case -1:
                    TRANGTHAI = "Không thể hoạt động";
                    break;
                case 0:
                    TRANGTHAI = "Trống";
                    break;
                case 1:
                    TRANGTHAI = "Có khách";
                    break;
                case 2:
                    TRANGTHAI = "Đã đặt trước";
                    break;
                default:
                    break;
            }
        }
        public string TRANGTHAI
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

        public int IsTrangThai
        {
            get
            {
                return isTrangThai;
            }

            set
            {
                isTrangThai = value;
            }
        }
        public override String ToString()
        {
            return TRANGTHAI;
        }
    }
}
