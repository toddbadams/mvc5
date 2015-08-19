
namespace OrderingPizza.Entities
{
    public class PizzaTopping
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public PizzaTopping(string Name, decimal Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }

        public PizzaTopping()
        {
            // TODO: Complete member initialization
        }
    }
}