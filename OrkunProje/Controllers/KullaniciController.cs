using BL.Mail;
using DAL.Context;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Controllers
{
    public class KullaniciController : Repository<Kullanici>
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kayit()
        {
            ViewBag.Kullanicilar = GetList<Kullanici>();
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(Kullanici model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            model.Aktiflik = false;
            model.GuidId = Guid.NewGuid(); 
            model.KullaniciTip = DAL.Enums.KullaniciTip.Normal;
            Kullanici kullaniciVarmi = GetById(k => k.EMail == model.EMail || k.KullaniciAdi == model.KullaniciAdi);
            if (kullaniciVarmi != null)
            {
                ViewBag.Durum = -1;
                return View();
            }
            bool sonuc = Add(model);
            if (sonuc)
                ViewBag.Durum = 1;
            
            StringBuilder builder = new StringBuilder();
            builder.Append($"Hoşgeldiniz sayın {model.Adi} {model.Soyadi};<br>");
            builder.Append("Sistemi kullanabilmek için oturumunuzu onaylamanız gerekmektedir.<br>");
            builder.Append("Oturumunuzu onaylayabilmek için lütfen aşağıdaki linke tıklayınız.<br>");
            builder.Append($"<a href='http://localhost:59929/aktivasyon/{model.GuidId}'>Üyeliği Aktif Etmek İçin Tıklayınız...</a>");


            MailGonderici.Gonder(model.EMail, builder.ToString(), "Üyelik Aktivasyonu");

            return View();
        }

        public ActionResult UyelikAktivasyonu(string guidId)
        {
            Kullanici kullanici = GetById(k => k.GuidId.ToString() == guidId);
            if (kullanici != null)
            {
                if (!kullanici.Aktiflik)
                {
                    kullanici.Aktiflik = true;
                    Save();
                    ViewBag.Mesaj = "Üyeliğiniz aktifleştirilmiştir.";
                }
                else
                    @ViewBag.Mesaj = "Üyeliğiniz zaten aktifleştirilmiştir.<br> Bu link geçersizdir!";
            }

            return View();
        }
    }
}