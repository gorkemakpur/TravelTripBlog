using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_Trip_Blog_Website.Models.Siniflar;
namespace Travel_Trip_Blog_Website.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();
            return View();
        }

        public ActionResult BlogSil(int id)
        {
            var sDeger = c.Blogs.Find(id);
            c.Blogs.Remove(sDeger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var gDeger = c.Blogs.Find(id);
            return View("BlogGetir",gDeger);
        }


        public ActionResult BlogGuncelle(Blog b)
        {
            var gbDeger = c.Blogs.Find(b.ID);
            gbDeger.Baslik = b.Baslik;
            gbDeger.BlogResmi = b.BlogResmi;
            gbDeger.Tarih=b.Tarih;
            gbDeger.Aciklama= b.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);

        }

        public ActionResult YorumSil(int id)
        {
            var sDeger=c.Yorumlars.Find(id);
            c.Yorumlars.Remove(sDeger);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var deger = c.Yorumlars.Find(id);
            return View("YorumGetir", deger);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var gDeger = c.Yorumlars.Find(y.ID);
            gDeger.Mail = y.Mail;
            gDeger.Yorum=y.Yorum;
            gDeger.KullaniciAdi = y.KullaniciAdi;
            gDeger.Mail = y.Mail;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }

    }
}