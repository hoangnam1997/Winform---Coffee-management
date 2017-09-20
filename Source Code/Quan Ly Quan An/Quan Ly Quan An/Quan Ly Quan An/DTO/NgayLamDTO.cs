using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class NgayLamDTO
    {
        private DateTime tHOIGIAN;
        public NgayLamDTO() { }
        public NgayLamDTO(DataRow row)
        {
            this.THOIGIAN = (DateTime)row["THOIGIAN"];
        }
        public NgayLamDTO (DateTime a)
        {
            this.THOIGIAN = a;

        }
        public DateTime THOIGIAN
        {
            get
            {
                return tHOIGIAN;
            }

            set
            {
                tHOIGIAN = value;
            }
        }
    }
}
