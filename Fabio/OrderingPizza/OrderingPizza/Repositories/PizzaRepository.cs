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

        public PizzaRepository(IApplicationDbContext context)
        {
            _users = context.Users;
            _context = context;
        }



        public long Add(string userId, AddPizzaModel model)
        {
            // get the user
            var u = _users.Single(x => x.Id == userId);

            // create a pizza entity
            var e = new Pizza
            {
                Type = model.Name
                //Toppings = model.Toppings
            };
            u.Pizza.Add(e);
            _context.SaveChanges();
            return e.Id;
        }
        public PizzaModel[] Fetch(string userId)
        {
            var u = _users.Single(x => x.Id == userId);

            return u.Pizza
                .Select(PizzaModel)
                .ToArray();
        }

        private static PizzaModel PizzaModel(Pizza item)
        {
            return new PizzaModel
            {
                Id = item.Id,
                Name = item.Type,
                //Toppings = item.Toppings
                Toppings = null
            };
        }

        public PizzaModel Get(string userId, long id)
        {
            var u = _users.Single(x => x.Id == userId);
            if (u.Pizza.All(x => x.Id != id)) return null;
            var p = u.Pizza.FirstOrDefault(x => x.Id == id);
            return PizzaModel(p);
        }
    }

    public interface IPizzaRepository
    {
        long Add(string userId, AddPizzaModel model);
        PizzaModel[] Fetch(string userId);
        PizzaModel Get(string userId, long id);
    }
}