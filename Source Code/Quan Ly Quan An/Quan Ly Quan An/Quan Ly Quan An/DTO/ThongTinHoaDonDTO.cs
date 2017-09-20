using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class ThongTinHoaDonDTO
    {
        private int sTT;
        private string mAMA;
        private string tENMA;
        private float gIA;
        private int soLuongMA;
        private float tHANHTIEN;
        private string mABA;
        private DateTime dataCome;
        private string mAHD;
        public ThongTinHoaDonDTO() { }
        public ThongTinHoaDonDTO(int stt,string MAMA, string tenma, float gia, int soluongMA,string maba,DateTime dateCome,string MAHD)
        {
            this.MAMA = MAMA;
            this.STT = stt;
            this.TENMA = tenma;
            this.GIA = gia;
            this.SoLuongMA = soluongMA;
            this.THANHTIEN = soluongMA* gia;
            this.MABA = maba;
            this.DataCome = dateCome;
            this.MAHD = MAHD;
        }
        public ThongTinHoaDonDTO(int STT, DataRow row)
        {
            this.STT = STT;
            this.MAMA = (string)row["MAMA"];
            this.TENMA = (string)row["TENMA"];
            this.GIA = float.Parse(row["GIA"].ToString());
            this.SoLuongMA = (int)row["SoLuongMA"];
            this.THANHTIEN = GIA*SoLuongMA;
            this.MABA = (string)row["MABA"];
            this.DataCome = (DateTime)row["THOIGIANBATDAU"];
            this.MAHD = (string)row["MAHD"];
        }

        public int STT
        {
            get
            {
                return sTT;
            }

            set
            {
                sTT = value;
            }
        }

        public string TENMA
        {
            get
            {
                return tENMA;
            }

            set
            {
                tENMA = value;
            }
        }

        public float GIA
        {
            get
            {
                return gIA;
            }

            set
            {
                gIA = value;
            }
        }

        public int SoLuongMA
        {
            get
            {
                return soLuongMA;
            }

            set
            {
                soLuongMA = value;
            }
        }

        public float THANHTIEN
        {
            get
            {
                return tHANHTIEN;
            }

            set
            {
                tHANHTIEN = value;
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

        public DateTime DataCome
        {
            get
            {
                return dataCome;
            }

            set
            {
                dataCome = value;
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
