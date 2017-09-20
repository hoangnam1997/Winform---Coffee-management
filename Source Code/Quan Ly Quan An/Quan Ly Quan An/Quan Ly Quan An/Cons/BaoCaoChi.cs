using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.Cons
{
    public class BaoCaoChi
    {
        private int baoCao;
        private string tenBaoCao;
        public BaoCaoChi(int baocao,string ten)
        {
            this.BaoCao = baocao;
            this.TenBaoCao = ten;
        }
        public int BaoCao
        {
            get
            {
                return baoCao;
            }

            set
            {
                baoCao = value;
            }
        }
        public override string ToString()
        {
            return TenBaoCao;
        }
        public string TenBaoCao
        {
            get
            {
                return tenBaoCao;
            }

            set
            {
                tenBaoCao = value;
            }
        }
    }
}
