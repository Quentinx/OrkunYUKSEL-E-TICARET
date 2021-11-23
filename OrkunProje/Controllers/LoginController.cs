using BL.Session;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Controllers
{
    public class LoginController : Repository<Kullanici>
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Kullanici model)
        {
            Kullanici kullanici = GetById(k => k.KullaniciAdi == model.KullaniciAdi && k.Sifre == model.Sifre);
            if (kullanici != null)
            {
                if (kullanici.Aktiflik)
                {
                    SessionKontrol.Kontrol = kullanici;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Mesaj = "Lütfen üyeliğinizi aktifleştiriniz.";
            }
            else
                ViewBag.Mesaj = "Lütfen kullanıcı adı ve şifrenizi doğru giriniz.";
            return View();
        }

        public ActionResult Cikis()
        {
            SessionKontrol.Kontrol = null;
            return RedirectToAction("Index", "Home");
        }
    }
}