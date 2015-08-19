//using OrderingPizza.Entities;
//using OrderingPizza.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace OrderingPizza.Controllers
//{
//    public class PizzaController : Controller
//    {
//        // GET: Pizza
//        public ActionResult Index()
//        {
//            return View();
//        }


//        //
//        // POST: /Order/OrderPizza
//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<ActionResult> OrderPizza(PizzaViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                List<PizzaTopping> pizzaToppings = new List<PizzaTopping>();
//                foreach (var item in model.Toppings)
//                {
//                    pizzaToppings.Add(new PizzaTopping { Name = item.Name, Cost = item.Cost });
//                }
//                var pizza = new Pizza { Type = model.Type, Cost = model.Cost, Toppings = pizzaToppings.ToArray() };
//            }
//            return View(model);
//        }
//    }
//}