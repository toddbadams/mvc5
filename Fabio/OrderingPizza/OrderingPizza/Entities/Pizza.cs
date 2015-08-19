
namespace OrderingPizza.Entities
{
    public class Pizza
    {
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public PizzaTopping[] Toppings { get; set; }

        public Pizza(string type)
        {
            this.Type = type;
            this.Cost = 0;
            this.Toppings = null;
        }

        public Pizza()
        {
            // TODO: Complete member initialization
        }
    }
}