using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda h)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = h.Ad;
            t.Soyad = h.Soyad;
            t.Adres = h.Adres;
            t.Mail = h.Mail;
            t.Telefon = h.Telefon;
            t.Aciklama = h.Aciklama;
            t.Görsel = h.Görsel;

            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}