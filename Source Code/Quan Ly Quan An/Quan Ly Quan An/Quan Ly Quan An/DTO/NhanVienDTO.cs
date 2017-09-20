using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class NhanVienDTO
    {
        private string mANV;
        private string hOTEN;
        private DateTime nGAYSINH;
        private string diaChi;
        private string sDT;
        private DateTime nGVAOLAM;
        private int pHANQUYEN;
        private float mUCLUONG;
        private string mATKhau;
        public NhanVienDTO() { }
        public NhanVienDTO(string manv, string hoten, DateTime ngaysinh, string diachi, string sdt, DateTime ngayvl, int phanquyen, float mucluong, string matkhau)
        {
            this.MANV = manv;
            this.HOTEN = hoten;
            this.NGAYSINH = ngaysinh;
            this.DiaChi = diachi;
            this.SDT = sdt;
            this.NGVAOLAM = ngayvl;
            this.PHANQUYEN = phanquyen;
            this.MUCLUONG = mucluong;
            this.MATKhau = matkhau;
        }
        public NhanVienDTO(DataRow row)
        {
            this.MANV = (string)row["MANV"];
            this.HOTEN = (string)row["HOTEN"];
            this.NGAYSINH = (DateTime)row["NGAYSINH"];
            this.DiaChi = (string)row["DIACHI"];
            this.SDT = (string)row["SDT"]; ;
            this.NGVAOLAM = (DateTime)row["NGVAOLAM"];
            this.PHANQUYEN = (int)row["PHANQUYEN"];
            this.MUCLUONG = float.Parse(row["MUCLUONG"].ToString());
            this.MATKhau = (string)row["MATKHAU"];
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

        public string HOTEN
        {
            get
            {
                return hOTEN;
            }

            set
            {
                hOTEN = value;
            }
        }

        public DateTime NGAYSINH
        {
            get
            {
                return nGAYSINH;
            }

            set
            {
                nGAYSINH = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string SDT
        {
            get
            {
                return sDT;
            }

            set
            {
                sDT = value;
            }
        }

        public DateTime NGVAOLAM
        {
            get
            {
                return nGVAOLAM;
            }

            set
            {
                nGVAOLAM = value;
            }
        }

        public int PHANQUYEN
        {
            get
            {
                return pHANQUYEN;
            }

            set
            {
                pHANQUYEN = value;
            }
        }

        public float MUCLUONG
        {
            get
            {
                return mUCLUONG;
            }

            set
            {
                mUCLUONG = value;
            }
        }

        public string MATKhau
        {
            get
            {
                return mATKhau;
            }

            set
            {
                mATKhau = value;
            }
        }
    }
}
