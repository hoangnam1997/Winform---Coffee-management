using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class QuanAnDTO
    {
        private float imPort;
        private float prePersen;
        public QuanAnDTO() { }
        public QuanAnDTO(float discount,float inport, float prepersen) {
            this.ImPort = inport;
            this.PrePersen = prepersen;
        }
        public QuanAnDTO(DataRow row)
        {
            this.ImPort = float.Parse(row["MUCNHAP"].ToString());
            this.PrePersen = float.Parse(row["PHANTRAMTRATRUOC"].ToString());
        }

        public float ImPort
        {
            get
            {
                return imPort;
            }

            set
            {
                imPort = value;
            }
        }

        public float PrePersen
        {
            get
            {
                return prePersen;
            }

            set
            {
                prePersen = value;
            }
        }
    }
}
