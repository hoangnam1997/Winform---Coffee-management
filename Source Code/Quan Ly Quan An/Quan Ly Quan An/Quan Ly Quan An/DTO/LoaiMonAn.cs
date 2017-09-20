using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class LoaiMonAn
    {
        private string mALOAIMA;
        private string tENLOAIMA;
        public override string ToString()
        {
            return TENLOAIMA;
        }
        public LoaiMonAn() { }
        public LoaiMonAn(string MALOAIMA, string TENLOAIMA)
        {
            this.MALOAIMA = MALOAIMA;
            this.TENLOAIMA = TENLOAIMA;
        }
        public LoaiMonAn(DataRow row)
        {
            this.MALOAIMA = (string)row["MALOAIMA"];
            this.TENLOAIMA = (string)row["TENLOAIMA"];
        }
        public string MALOAIMA
        {
            get
            {
                return mALOAIMA;
            }

            set
            {
                mALOAIMA = value;
            }
        }

        public string TENLOAIMA
        {
            get
            {
                return tENLOAIMA;
            }

            set
            {
                tENLOAIMA = value;
            }
        }
    }
}
