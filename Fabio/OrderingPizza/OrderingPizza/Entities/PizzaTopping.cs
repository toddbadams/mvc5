using System.ComponentModel.DataAnnotations;
namespace OrderingPizza.Entities
{
    public class PizzaTopping
    {
        [Key]
        public string Name { get; set; }
        public decimal Cost { get; set; }

    }
}