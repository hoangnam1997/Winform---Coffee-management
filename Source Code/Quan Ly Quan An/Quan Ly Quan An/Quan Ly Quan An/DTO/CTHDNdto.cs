using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class CTHDNdto
    {
        private string mAHDN;
        private string mATP;
        private float soLuongThucPham;
        private double thanhTien;
        public CTHDNdto() { }
        public CTHDNdto(string MAHDN, string MATP, float soLuongThucPham,double ThanhTien) {
            this.MAHDN = MAHDN;
            this.MATP = MATP;
            this.SoLuongThucPham = soLuongThucPham;
            this.ThanhTien = ThanhTien;
        }
        public CTHDNdto(DataRow row)
        {
            this.MAHDN = (string)row["MAHDN"];
            this.MATP = (string)row["MATP"];
            this.SoLuongThucPham = float.Parse(row["SoLuongThucPham"].ToString()) ;
            this.ThanhTien = float.Parse(row["ThanhTien"].ToString());
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

        public float SoLuongThucPham
        {
            get
            {
                return soLuongThucPham;
            }

            set
            {
                soLuongThucPham = value;
            }
        }

        public double ThanhTien
        {
            get
            {
                return thanhTien;
            }

            set
            {
                thanhTien = value;
            }
        }
    }
}
