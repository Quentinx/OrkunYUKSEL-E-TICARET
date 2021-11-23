using System.Web.Mvc;

namespace OrkunProje.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                  "Olta-sil",
                  "Admin/olta-sil/{id}",
                  new { action = "Sil", controller = "Olta", id = UrlParameter.Optional }
              );
            context.MapRoute(
                "OltaEkle",
                "Admin/olta-ekle/{id}",
                new { action = "Ekle", controller = "Olta", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "OltaListesi",
                "Admin/olta-listesi",
                new { action = "Index", controller = "Olta" }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}