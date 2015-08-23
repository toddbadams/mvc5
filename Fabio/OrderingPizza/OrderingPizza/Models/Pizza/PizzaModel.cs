using System.Collections.Generic;

namespace OrderingPizza.Models.Pizza
{
    public class PizzaModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Toppings> Toppings { get; set; }
    }

    public class Toppings
    {
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}