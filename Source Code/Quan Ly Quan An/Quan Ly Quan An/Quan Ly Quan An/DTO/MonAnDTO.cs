using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.DTO
{
    public class MonAnDTO
    {
        private string mAMA;
        private string tENMA;
        private float gIA;
        private string mALOAIMA;
        public MonAnDTO() { }
        public MonAnDTO(string mama, string TENMA, float GIA, string MALOAIMA)
        {
            this.MAMA = mama;
            this.TENMA = TENMA;
            this.GIA = GIA;
            this.MALOAIMA = MALOAIMA;
        }
        public MonAnDTO(DataRow row)
        {
            this.MAMA = (string)row["MAMA"];
            this.TENMA = (string)row["TENMA"];
            this.GIA = float.Parse(row["GIA"].ToString());
            this.MALOAIMA = (string)row["MALOAIMA"];
        }


        public string MAMA
        {
            get
            {
                return mAMA;
            }

            set
            {
                mAMA = value;
            }
        }
        public string TENMA
        {
            get
            {
                return tENMA;
            }

            set
            {
                tENMA = value;
            }
        }
        public float GIA
        {
            get
            {
                return gIA;
            }

            set
            {
                gIA = value;
            }
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
    }
}
