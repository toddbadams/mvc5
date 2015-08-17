using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderingPizza.Models
{
    public class AddingPizzaModel
    {
        [Required]
        public long TypeId { get; set; }

        public PizzaTopping[] Toppings { get; set; }
    }

    public class PizzaTopping
    {
        public string Name { get; set; }
    }


    public class PizzaViewModel
    {
        [Required]
        public string Type { get; set; }

        public decimal Cost { get; set; }

        public PizzaToppingViewModel[] Toppings { get; set; }
    }

    public class PizzaToppingViewModel
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}