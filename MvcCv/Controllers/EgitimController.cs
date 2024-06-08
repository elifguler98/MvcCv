using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEğitimlerim> repo = new GenericRepository<TblEğitimlerim> ();
   
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEğitimlerim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }

            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEğitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            var e = repo.Find(x => x.ID == t.ID);
           e.Baslik = t.Baslik;
            e.AltBaslik1 = t.AltBaslik1;
            e.AltBaslik2 = t.AltBaslik2;
            e.GNO=t.GNO;
            e.Tarih=t.Tarih;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}