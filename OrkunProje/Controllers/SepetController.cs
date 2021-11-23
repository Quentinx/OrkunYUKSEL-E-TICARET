using BL.Session;
using DAL.Entities;
using DAL.Repository;
using OrkunProje.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Controllers
{
    [Oturum]
    public class SepetController : Repository<Sepet>
    {
        public SepetController()
        {
        }

        public ActionResult Index()
        {
            var sepetler = GetWhere<Sepet>(s => s.KullaniciId == SessionKontrol.Kontrol.Id);
            return View(sepetler);
        }

        public ActionResult Ekle(int id)
        {
            Sepet sepet = new Sepet();
            sepet.Adet = 1;
            sepet.OltaId = id;
            sepet.KullaniciId = SessionKontrol.Kontrol.Id;

            Sepet sepettekiUrun = GetById(s => s.KullaniciId == SessionKontrol.Kontrol.Id && s.OltaId == id);
            if (sepettekiUrun != null)
            {
                sepettekiUrun.Adet++;
                Save();
            }
            else
            {

                
                Add(sepet);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            Sepet sepet = GetById(s => s.Id == id);
            Remove(sepet);
            return RedirectToAction("Index");
        }
    }
}