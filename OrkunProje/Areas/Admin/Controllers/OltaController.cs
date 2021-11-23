using BL.Business;
using DAL.Entities;
using DAL.Repository;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Areas.Admin.Controllers
{
    public class OltaController : Repository<Olta>
    {
        public ActionResult Index()
        {
            return View(GetList());
        }

        public ActionResult Ekle(int? id)
        {
            ViewBag.Olta = GetList<Olta>();
            if (id.HasValue)
            {
                Olta guncellencekolta = GetById(k => k.Id == id);
                VMOlta_OltaOzellik vmNesnesi = new VMOlta_OltaOzellik
                {
                    Olta = guncellencekolta,
                    OltaOzellik = guncellencekolta.Ozellikler.Count > 0 ? guncellencekolta.Ozellikler.First() : null
                };
                return View(vmNesnesi);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(VMOlta_OltaOzellik model, int? id)
        {
            if (id == 0)
            {
                int sayi = RastgeleTekilSayi.Uret();
                model.Olta.İlanNo = sayi;
                Add(model.Olta);
                Olta eklenenurun = GetLastItem();
                model.OltaOzellik.Id = eklenenurun.Id;
                Add<OltaOzellik>(model.OltaOzellik);
            }
            else
            {
                Olta guncellenecekolta = GetById(k => k.Id == id);
                guncellenecekolta.Baslik = model.Olta.Baslik;
                guncellenecekolta.Fiyat = model.Olta.Fiyat;
                guncellenecekolta.Misina = model.Olta.Misina;


                if (guncellenecekolta.Ozellikler.Count > 0)
                {
                    OltaOzellik ozellik = guncellenecekolta.Ozellikler.First();
                    ozellik.YapimYili = model.OltaOzellik.YapimYili;

                }

                Save();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            Olta silinicekOlta = GetById(k => k.Id == id);
            Remove(silinicekOlta);
            return RedirectToAction("Index");
        }
    }
}