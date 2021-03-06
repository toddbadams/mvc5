﻿using OrderingPizza.Models.Pizza;
using System.ComponentModel.DataAnnotations;

namespace OrderingPizza.Entities
{
    public class Pizza
    {
        // ??
        [Key]
        public long OrderId { get; set; }
        public Tomato tomato { get; set; }
        public Mozzarella mozzarella { get; set; }

        public Pizza()
        {
            tomato = new Tomato();
            mozzarella = new Mozzarella();
        }

        public Pizza(Tomato tomato, Mozzarella mozzarella)
        {
            this.tomato = tomato;
            this.mozzarella = mozzarella;
        }
    }
}