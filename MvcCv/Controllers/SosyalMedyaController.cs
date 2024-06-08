using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya> ();
        public ActionResult Index()
        {
            var medya = repo.List();
            return View(medya);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
          
            return View();
        }
        [HttpPost]  
        public ActionResult Ekle(TblSosyalMedya s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var sayfa = repo.Find(x=>x.ID == id);
            return View(sayfa);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            var sayfa = repo.Find(x => x.ID == p.ID);
            sayfa.Ad = p.Ad;
            sayfa.Durum = true;
            sayfa.Link = p.Link;
            sayfa.ikon = p.ikon;
            repo.TUpdate(sayfa);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var medya = repo.Find(x=>x.ID==id);
            medya.Durum = false;
            repo.TUpdate(medya);
            return RedirectToAction("Index");
        }
    }
}