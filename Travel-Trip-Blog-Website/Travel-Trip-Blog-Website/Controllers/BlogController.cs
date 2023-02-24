using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_Trip_Blog_Website.Models.Siniflar;



namespace Travel_Trip_Blog_Website.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogYorum by = new BlogYorum();
        Context c = new Context();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            by.Deger2 = c.Yorumlars.OrderByDescending(x=>x.ID).Take(3).ToList();
            return View(by);
        }

        
        public ActionResult BlogDetay(int id)
        {
            //var blogBul = c.Blogs.Where(x=>x.ID==id).ToList();

            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.idDegeri = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}