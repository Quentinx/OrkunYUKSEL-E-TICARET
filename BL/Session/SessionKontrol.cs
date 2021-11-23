using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL.Session
{
    public class SessionKontrol
    {
        static public Kullanici Kontrol
        {
            get
            {
                return HttpContext.Current.Session["oturum"] as Kullanici;
            }
            set
            {
                if (HttpContext.Current.Session["oturum"] != null)
                {
                    HttpContext.Current.Session["oturum"] = value;
                }
                else
                {
                    HttpContext.Current.Session.Add("oturum", value);
                }
            }
        }
    }
}
