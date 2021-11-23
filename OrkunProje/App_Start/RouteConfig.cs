using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OrkunProje
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "sepetSil",
                url: "sepete-sil/{id}",
                defaults: new { controller = "Sepet", action = "Sil", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "sepeteEkle",
                url: "sepete-ekle/{id}",
                defaults: new { controller = "Sepet", action = "Ekle", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OltaDetayi",
                url: "urun-detay/{ilanNo}",
                defaults: new { controller = "Urun", action = "Detay", ilanNo = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "kayit",
                url: "kayit",
                defaults: new { controller = "Kullanici", action = "Kayit" }
            );

            routes.MapRoute(
                name: "Hata",
                url: "hata",
                defaults: new { controller = "Error", action = "Index" }
            );

            routes.MapRoute(
                name: "Cikis",
                url: "out",
                defaults: new { controller = "Login", action = "Cikis" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "UyelikAktivasyon",
                url: "aktivasyon/{guidId}",
                defaults: new { controller = "Kullanici", action = "UyelikAktivasyonu", guidId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
