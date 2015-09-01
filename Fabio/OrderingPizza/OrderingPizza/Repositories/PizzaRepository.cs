using OrderingPizza.Entities;
using OrderingPizza.Models;
using OrderingPizza.Models.Pizza;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OrderingPizza.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IDbSet<ApplicationUser> _users;
        private readonly IApplicationDbContext _context;
        private List<PizzaModel> _pm { get; set; }

        public PizzaRepository(IApplicationDbContext context)
        {
            _users = context.Users;
            _context = context;
            _pm = new List<PizzaModel>();
        }

        //public long Add(string userId, AddPizzaModel model)
        //{
        //    // get the user
        //    var u = _users.Single(x => x.Id == userId);

        //    Pizza e = new Pizza(model.tomato, model.mozzarella);

        //    // create a pizza entity
        //    //var e = new Pizza()
        //    //{
        //    //    tomato = model.tomato,
        //    //    mozzarella = model.mozzarella
        //    //    //Type = model.Name
        //    //    //Toppings = model.Toppings
        //    //};

        //    u.Pizza.Add(e);
        //    _context.SaveChanges();
        //    return e.Id;
        //    //return 0;
        //}

        //public long AddPizzaModel(string userId, long PizzaModelId)
        //{
        //    // get the user
        //    var u = _users.Single(x => x.Id == userId);

        //    Pizza e = new Pizza(model.tomato, model.mozzarella);

        //    // create a pizza entity
        //    //var e = new Pizza()
        //    //{
        //    //    tomato = model.tomato,
        //    //    mozzarella = model.mozzarella
        //    //    //Type = model.Name
        //    //    //Toppings = model.Toppings
        //    //};

        //    u.Pizza.Add(e);
        //    _context.SaveChanges();
        //    //return e.Id;
        //    return 0;
        //}



        //public PizzaModel Fetch(string userId)
        //{
        //    var u = _users.Single(x => x.Id == userId);

        //    //Convert.ToInt64(u.Id);

        //    Pizza newItem = new Pizza(Convert.ToInt64(u.Id));

        //    return PizzaModel(newItem);
        //    //return u.Pizza
        //    //    .Select(PizzaModel)
        //    //    .ToArray();
        //}


        //private static PizzaModel PizzaModel(Pizza item)
        //{
        //    return new PizzaModel
        //    {
        //        //Id = item.Id,
        //        //Name = item.Type,
        //        mozzarella = new Mozzarella(),
        //        tomato = new Tomato()
        //    };
        //}

        //public PizzaModel Get(string userId, long id)
        //{
        //    var u = _users.Single(x => x.Id == userId);
        //    if (u.Pizza.All(x => x.Id != id)) return null;
        //    var p = u.Pizza.FirstOrDefault(x => x.Id == id);
        //    return PizzaModel(p);
        //}

        public PizzaModel CreatePizzaModel(string userId)
        {
            var u = _users.Single(x => x.Id == userId);
            //??
            PizzaModel pm = new PizzaModel(1, userId);
            _pm.Add(pm);
            return pm;
        }

        public PizzaModel GetPizzaModel(string userId, long PizzaModelId)
        {
            var u = _users.Single(x => x.Id == userId);
            PizzaModel pm = _pm.FirstOrDefault(x => x.PizzaModelID == PizzaModelId);
            return pm;
        }

        public void AddTomato(long PizzaModelId)
        {
            PizzaModel pm = _pm.FirstOrDefault(x => x.PizzaModelID == PizzaModelId);
            pm.tomato.quantity = true;
        }

        public void AddMozzarella(long PizzaModelId)
        {
            PizzaModel pm = _pm.FirstOrDefault(x => x.PizzaModelID == PizzaModelId);
            pm.mozzarella.quantity = true;
        }

        public void AddPizza(string userId, long PizzaModelId)
        {
            var u = _users.Single(x => x.Id == userId);
            PizzaModel pm = GetPizzaModel(userId, PizzaModelId);
            Pizza p = new Pizza()
            {
                OrderId = PizzaModelId,
                tomato = pm.tomato,
                mozzarella = pm.mozzarella
            };
            u.Pizza.Add(p);
        }
    }

    public interface IPizzaRepository
    {
        //long Add(string userId, AddPizzaModel model);
        //long AddPizzaModel(string userId, long PizzaModelId);
        //PizzaModel[] Fetch(string userId);
        //PizzaModel Fetch(string userId);
        //PizzaModel Get(string userId, long id);
        PizzaModel GetPizzaModel(string userId, long PizzaModelId);
        PizzaModel CreatePizzaModel(string userId);
        void AddTomato(long PizzaModelId);
        void AddMozzarella(long PizzaModelId);
        void AddPizza(string userId, long PizzaModelId);
    }
}