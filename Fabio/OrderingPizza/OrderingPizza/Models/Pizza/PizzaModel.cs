
using System.ComponentModel;
namespace OrderingPizza.Models.Pizza
{
    public class PizzaModel
    {
        public long Id { get; set; }
        public Tomato tomato { get; set; }
        public Mozzarella mozzarella { get; set; }

        public PizzaModel()
        {
            tomato = new Tomato();
            mozzarella = new Mozzarella();
        }
    }

    public class Tomato
    {
        [DisplayName("Tomato")]
        public string name { get; private set; }
        public bool quantity { get; set; }
        public double cost = 1;

    }

    public class Mozzarella
    {
        [DisplayName("Mozzarella")]
        public string name { get; private set; }
        public bool quantity { get; set; }
        public double cost = 2;

    }
}