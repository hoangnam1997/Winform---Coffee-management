using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class NhaCungCapDTO
    {
        private string mANCC;
        private string sOTAIKHOAN;
        private string dIACHI;
        private string sDT;
        public NhaCungCapDTO() { }
        public NhaCungCapDTO(string MANCC,string SOTAIKHOAN,string DIACHI,string SDT) {
            this.MANCC = MANCC;
            this.SOTAIKHOAN = SOTAIKHOAN;
            this.DIACHI = DIACHI;
            this.SDT = SDT;
        }
        public NhaCungCapDTO(DataRow row)
        {
            this.MANCC = (string)row["MANCC"];
            this.SOTAIKHOAN = (string)row["SOTAIKHOAN"];
            this.DIACHI = (string)row["DIACHI"];
            this.SDT = (string)row["SDT"];
        }
        public override string ToString()
        {
            return this.MANCC;
        }
        public string MANCC
        {
            get
            {
                return mANCC;
            }

            set
            {
                mANCC = value;
            }
        }

        public string SOTAIKHOAN
        {
            get
            {
                return sOTAIKHOAN;
            }

            set
            {
                sOTAIKHOAN = value;
            }
        }

        public string DIACHI
        {
            get
            {
                return dIACHI;
            }

            set
            {
                dIACHI = value;
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
    }
}
