using Microsoft.AspNetCore.Mvc;
using CvProject.Models;
using CvProject.Data;
using CvProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CvProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        CvContext db = new CvContext();
        public IActionResult Index()
        {
            var model = new MainVm
            {
                Deneyimler = db.TblDeneyimler.ToList(),
                Hakkinda = db.TblHakkinda.ToList(),
                Egitimler = db.TblEgitimler.ToList(),
                Yetenekler = db.TblYetenekler.ToList(),
                Hobiler = db.TblHobiler.ToList(),
                Sertifikalar = db.TblSertifikalar.ToList(),
                Iletisim = db.TblIletisim.ToList(),
                SosyalMedya = db.TblSosyalMedya.ToList()
            };
            return View(model);
        }
        public PartialViewResult Hakkinda()
        {
            return PartialView();
        }
        public PartialViewResult Deneyim()
        {
            return PartialView();
        }
        public PartialViewResult Egitimler()
        {
            return PartialView();
        }
        public PartialViewResult Hobiler()
        {
            return PartialView();
        }
        public PartialViewResult Yetenekler()
        {
            return PartialView();
        }
        public PartialViewResult Sertifikalar()
        {
            return PartialView();
        }
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        public PartialViewResult SosyalMedya()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Iletisim(TblIletisim iletisim)
        {
            iletisim.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIletisim.Add(iletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
