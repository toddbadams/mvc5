using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderingPizza.Entities
{
    public class Pizza
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        //public IEnumerable<string> Type { get; set; }
        //public List<Toppings> Toppings { get; set; }
        public virtual ICollection<PizzaTopping> Toppings { get; set; }

        public double GetPrice(string type)
        {
            return 1.0;
        }
    }
}