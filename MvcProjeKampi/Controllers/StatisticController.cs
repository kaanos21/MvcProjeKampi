using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using DataAccesLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.toplamkategori = db.Categories.Count();
            ViewBag.yazılımkategori = db.Headings.Count(h => h.Category.CategoryName == "Yazılım");
            ViewBag.aharfgeçensayı = db.Writers.Count(x => x.WriterName.Contains("a"));
            var xx = db.Categories.Select(c => new
            {
                KategoriAdi = c.CategoryName,
                basliksayı = c.Headings.Count(h=>h.CategoryID==c.CategoryID)

            }).OrderByDescending(k => k.basliksayı).FirstOrDefault();
            ViewBag.enfazlakategori = xx.KategoriAdi;
            int b = db.Categories.Count(x => x.CategoryStatus == false);
            int ll = db.Categories.Count(x => x.CategoryStatus == true);
            int truefalse = ll - b;
            ViewBag.truefalsefark = truefalse.ToString();
            return View();
        }
    }
}