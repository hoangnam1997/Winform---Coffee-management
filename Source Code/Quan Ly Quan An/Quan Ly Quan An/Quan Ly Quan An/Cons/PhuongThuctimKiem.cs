using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.Cons
{
    /// <summary>
    /// 0: theo tên món ăn
    /// 1: theo loại món ăn
    /// </summary>
    public class PhuongThuctimKiem
    {
        private int loai;
        private string tenLoai;
        public PhuongThuctimKiem(int loai,string tenloai)
        {
            this.Loai = loai;
            this.TenLoai = tenloai;
        }
        public override string ToString()
        {
            return TenLoai;
        }
        public int Loai
        {
            get
            {
                return loai;
            }

            set
            {
                loai = value;
            }
        }

        public string TenLoai
        {
            get
            {
                return tenLoai;
            }

            set
            {
                tenLoai = value;
            }
        }
    }
}
