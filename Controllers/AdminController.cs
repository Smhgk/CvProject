using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository _repo = new AdminRepository();
        public IActionResult Index()
        {
            var adminList = _repo.List();
            return View(adminList);
        }

        public IActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult  AdminEkle(TblAdmin entity)
        {
            _repo.TAdd(entity);
            return RedirectToAction("Index");
        }

        public IActionResult AdminGetir(int id)
        {
            var admin = _repo.TFind(x=> x.Id == id);
            return View(admin);
        }

        [HttpPost]
        public IActionResult AdminGetir(TblAdmin entity)
        {
            var admin = _repo.TFind(x => x.Id == entity.Id);
            admin.KullaniciAdi = entity.KullaniciAdi;
            admin.Sifre = entity.Sifre;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }

        public IActionResult AdminSil(int id)
        {
            var admin = _repo.TFind(x => x.Id == id);
            _repo.TDelete(admin);
            return RedirectToAction("Index");
        }
    }
}
