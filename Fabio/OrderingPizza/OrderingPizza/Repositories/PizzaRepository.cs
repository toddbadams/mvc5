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



        public void Add(string userId, AddPizzaModel model)
        {
            // get the user
            var u = _users.Single(x => x.Id == userId);

            // create a pizza entity
            var e = new Pizza
            {
                Type = model.Name,
                Toppings = model.Toppings
            };
            u.Pizza.Add(e);
            _context.SaveChanges();
        }
        public PizzaModel[] Fetch(string userId)
        {
            var u = _users.Single(x => x.Id == userId);

            var pizza = new List<PizzaModel>();
            foreach (var item in u.Pizza)
            {
                pizza.Add(new PizzaModel
                {
                    Id = item.Id,
                    Name = item.Type,
                    //Toppings = item.Toppings
                    Toppings = null
                });
            }

            return pizza.ToArray();
        }
    }

    public interface IPizzaRepository
    {
        void Add(string userId, AddPizzaModel model);
        PizzaModel[] Fetch(string userId);
    }
}