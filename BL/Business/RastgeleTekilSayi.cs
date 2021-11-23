using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;


namespace BL.Business
{
    static public class RastgeleTekilSayi
    {
        public static int Uret()
        {
            VTOrkunProje db = new VTOrkunProje();

            Random rst = new Random();
            int sayi = 0;
            while (true)
            {
                sayi = rst.Next(999999, 9999999);
                Olta varMi = db.Oltas.FirstOrDefault(k => k.İlanNo == sayi);
                if (varMi == null)
                    break;
            }
            return sayi;
        }
    }
}