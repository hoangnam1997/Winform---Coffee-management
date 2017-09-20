using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.Cons
{
    public class StatusPreBills
    {
        private int sTatus;
        private string nameStatus;
        public StatusPreBills(int trangthai, string tentrangthai)
        {
            this.STatus = trangthai;
            this.NameStatus = tentrangthai;
        }
        public override string ToString()
        {
            return NameStatus;
        }
        public int STatus
        {
            get
            {
                return sTatus;
            }

            set
            {
                sTatus = value;
            }
        }

        public string NameStatus
        {
            get
            {
                return nameStatus;
            }

            set
            {
                nameStatus = value;
            }
        }
    }
}
