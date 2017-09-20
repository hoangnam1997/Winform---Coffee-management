using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_An.Cons
{
    public static class StaticClass
    {
        public static int sizeLeave = 30;
        public static int sizeFont = 5;
        public static Color colorNonTable = Color.Black;
        public static Color colorfreeTable = Color.Transparent;
        public static Color colorFullTable = Color.FromArgb(38, 152, 251);
        public static Color colorPreTable = Color.FromArgb(234, 38, 252);
        public static Color colorWord = Color.Black;
        public static Color pnlColorList = Color.White;
        //public static Color fColor = Color.White;
        //public static Color pnlColorMenu = Color.FromArgb(55, 128, 223);
        public static Color pnlColorMenu = Color.FromArgb(121, 161, 225);
        //public static Color pnlColorMenu =Color.White;
        //public static Color pnlColorMenu = Color.Aqua;
        public static Color fColor = Color.FromArgb(208, 209, 211);
        /// <summary>
        /// chuyển sang hệ mã asskII mật khẩu
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string hasPass(string Password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(Password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            hasPass.Reverse();
            return hasPass;
        }
        /// <summary>
        /// Xóa khoản trắng thừa
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string xoakhoangtrang(string a)
        {
            string s = a.Trim();
            while (s.IndexOf("  ") >= 0)
                s = s.Replace("  ", " ");
            return s;
        }
        /// <summary>
        /// Random ký tự Mã
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Random(int length)
        {
            string result = "";
            char c;
            Random ran = new Random();
            for (int i = 0; i < length; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(ran.Next(65, 87)));
                result += c;
            }
            return result;
        }
        
        public static string ConvertToUnsign(string str)
        {
            string[] signs = new string[] {"aAeEoOuUiIdDyY","áàạảãâấầậẩẫăắằặẳẵ","ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ","éèẹẻẽêếềệểễ","ÉÈẸẺẼÊẾỀỆỂỄ","óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ","úùụủũưứừựửữ","ÚÙỤỦŨƯỨỪỰỬỮ","íìịỉĩ","ÍÌỊỈĨ","đ","Đ","ýỳỵỷỹ","ÝỲỴỶỸ"};
            for (int i = 1; i < signs.Length; i++)
            {
                for (int j = 0; j < signs[i].Length; j++)
                {
                    str = str.Replace(signs[i][j], signs[0][i - 1]);
                }
            }
            return str;
        }
    }

}
