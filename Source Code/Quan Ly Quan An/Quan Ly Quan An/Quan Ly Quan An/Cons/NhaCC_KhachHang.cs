using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.Cons
{
    public class NhaCC_KhachHang
    {
        /// <summary>
        /// i : 0 nhà cc
        /// 1: khách hàng
        /// </summary>
        private int i;
        private string ten;
        public override string ToString()
        {
            return Ten;
        }
        public NhaCC_KhachHang(int i, string ten)
        {
            this.I = i;
            this.Ten = ten;
        }
        public int I
        {
            get
            {
                return i;
            }

            set
            {
                i = value;
            }
        }

        public string Ten
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }
    }
}
