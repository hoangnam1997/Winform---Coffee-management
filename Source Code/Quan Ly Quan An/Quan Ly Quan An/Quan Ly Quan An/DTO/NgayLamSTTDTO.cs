using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class NgayLamSTTDTO
    {
        private int sTT;
        private DateTime dayWork;
        public NgayLamSTTDTO() { }
        public NgayLamSTTDTO(int stt, DataRow row)
        {
            this.STT = stt;
            this.DayWork = (DateTime)row["THOIGIAN"];
        }
        public NgayLamSTTDTO(int stt,DateTime a)
        {
            this.DayWork = a;
            this.STT = stt;

        }
        public int STT
        {
            get
            {
                return sTT;
            }

            set
            {
                sTT = value;
            }
        }
        public DateTime DayWork
        {
            get
            {
                return dayWork;
            }

            set
            {
                dayWork = value;
            }
        }


        
    }
}
