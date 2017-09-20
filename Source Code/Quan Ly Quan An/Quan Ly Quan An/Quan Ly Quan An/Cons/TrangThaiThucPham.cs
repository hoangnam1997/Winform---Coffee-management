using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.Cons
{
    /// <summary>
    /// 0: còn trên mức quy định
    /// 1: dưới mức quy định
    /// </summary>
    public class TrangThaiThucPham
    {
        
        private int trangThai;
        private string tenTrangThai;
        public override string ToString()
        {
            return TenTrangThai;
        }
        public TrangThaiThucPham(int ma, string ten)
        {
            this.TrangThai = ma;
            this.TenTrangThai = ten;
        }
        public int TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }

        public string TenTrangThai
        {
            get
            {
                return tenTrangThai;
            }

            set
            {
                tenTrangThai = value;
            }
        }
    }
}
