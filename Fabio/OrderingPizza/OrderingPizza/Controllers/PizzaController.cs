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
            //PizzaModel pm = _repository.Set(User.Identity.GetUserId());
            PizzaModel pm = new PizzaModel();
            return View(pm);
        }

        public ActionResult Order(long id)
        {
            var vm = _repository.Get(User.Identity.GetUserId(), id);
            var order = new PizzaOrderModel
            {
                PizzaId = id,
                Name = vm.Name
            };
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(PizzaOrderModel model)
        {
            if (!ModelState.IsValid) //|| upload == null)
            {
                return View(model);
            }


            // save to repository
            //  var addId = _repository.Add(User.Identity.GetUserId(), model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddPizzaModel model)
        {
            if (!ModelState.IsValid) //|| upload == null)
            {
                return RedirectToAction("Index");
            }


            // save to repository
            var addId = _repository.Add(User.Identity.GetUserId(), model);

            return RedirectToAction("Order", new { id = addId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTomato(PizzaModel model)
        {
            if (!ModelState.IsValid) //|| upload == null)
            {
                //return RedirectToAction("Index");
            }

            model.tomato.quantity = true;

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMozzarella(PizzaModel model)
        {
            if (!ModelState.IsValid) //|| upload == null)
            {
                //return RedirectToAction("Index");
            }

            model.mozzarella.quantity = true;

            return RedirectToAction("Index", model);

        }
    }
}