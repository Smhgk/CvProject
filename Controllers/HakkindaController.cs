using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class HakkindaController : Controller
    {
        HakkindaRepository _repo = new HakkindaRepository();
        public IActionResult Index()
        {
            var hakkinda = _repo.List();
            return View(hakkinda);
        }

        [HttpPost]
        public IActionResult Index(TblHakkinda p)
        {
            var hakkında = _repo.TFind(x => x.Id == p.Id);
            hakkında.Ad = p.Ad;
            hakkında.Soyad = p.Soyad;
            hakkında.Adres = p.Adres;
            hakkında.Telefon = p.Telefon;
            hakkında.Mail = p.Mail;
            hakkında.Aciklama = p.Aciklama;
            hakkında.Image = p.Image;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }
    }
}
