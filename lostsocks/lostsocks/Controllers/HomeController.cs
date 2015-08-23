using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lostsocks.Database;
using lostsocks.Repositories;

namespace lostsocks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISockRepository _repository;

        public HomeController()
        {
            var context = new ApplicationDbContext();
            _repository = new SockRepository(context);            
        }

        public ActionResult Index()
        {
            var latest = _repository.FetchLatest(4);
            return View(latest);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}