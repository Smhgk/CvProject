using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class IletisimController : Controller
    {
        IletisimRepository _repo = new IletisimRepository();
        public IActionResult Index()
        {
            var iletisim = _repo.List();
            return View(iletisim);
        }
    }
}
