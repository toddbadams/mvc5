
using System.ComponentModel;
namespace OrderingPizza.Models.Pizza
{
    public class PizzaModel
    {
        public string Id { get; set; }
        public long PizzaModelID { get; set; }
        public Tomato tomato { get; set; }
        public Mozzarella mozzarella { get; set; }

        public PizzaModel(long pmId, string userId)
        {
            this.PizzaModelID = pmId;
            tomato = new Tomato();
            mozzarella = new Mozzarella();
            this.Id = userId;
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