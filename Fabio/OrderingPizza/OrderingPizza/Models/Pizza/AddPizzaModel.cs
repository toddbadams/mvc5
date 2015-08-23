using OrderingPizza.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderingPizza.Models.Pizza
{
    public class AddPizzaModel
    {
        [Required]
        public string Name { get; set; }
        public ICollection<PizzaTopping> Toppings { get; set; }
    }
}