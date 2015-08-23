using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderingPizza.Entities
{
    public class Pizza
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        //public List<Toppings> Toppings { get; set; }
        public virtual ICollection<PizzaTopping> Toppings { get; set; }
    }
}