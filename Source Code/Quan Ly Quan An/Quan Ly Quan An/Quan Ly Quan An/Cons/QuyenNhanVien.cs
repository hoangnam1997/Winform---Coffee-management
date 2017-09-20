using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.Cons
{
    public class QuyenNhanVien
    {
        public override string ToString()
        {
            return TenQuyen;
        }
        private int quyen;
        private string tenQuyen;
        public QuyenNhanVien(int quyen, string tenQuyen)
        {
            this.Quyen = quyen;
            this.TenQuyen = tenQuyen;
        }
        public int Quyen
        {
            get
            {
                return quyen;
            }

            set
            {
                quyen = value;
            }
        }

        public string TenQuyen
        {
            get
            {
                return tenQuyen;
            }

            set
            {
                tenQuyen = value;
            }
        }
    }
}
