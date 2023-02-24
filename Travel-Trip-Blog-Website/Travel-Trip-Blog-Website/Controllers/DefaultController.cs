using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_Trip_Blog_Website.Models.Siniflar;
namespace Travel_Trip_Blog_Website.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            var degerler = c.Blogs.Take(5).ToList();
            return View(degerler);
        }

        public PartialViewResult Partial()
        {
            var degerler = c.Blogs.OrderByDescending(x=>x.ID).Skip(1).Take(2).ToList();
            return PartialView(degerler);
        }
        //partial içinde partial kullanımı için partial2 oluşturuldu
        public PartialViewResult Partial2()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(1).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial3()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial4()
        {
            var degerler = c.Blogs.Take(3).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial5()
        {
            var degerler = c.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            return PartialView(degerler);
        }
    }
}