using Microsoft.AspNet.Identity;
using OrderingPizza.Models;
using OrderingPizza.Models.Pizza;
using OrderingPizza.Repositories;
using System.Web.Mvc;

namespace OrderingPizza.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _repository;

        public PizzaController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            _repository = new PizzaRepository(context);
        }

        // GET: Pizza
        public ActionResult Index()
        {
            //PizzaModel[] pm = _repository.Fetch(User.Identity.GetUserId());
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddPizzaModel model)
        {
            if (!ModelState.IsValid) //|| upload == null)
            {
                return View(model);
            }


            // save to repository
            _repository.Add(User.Identity.GetUserId(), model);

            return RedirectToAction("Add");
        }
    }
}