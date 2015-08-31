using System.ComponentModel.DataAnnotations;

namespace OrderingPizza.Models.Pizza
{
    public class AddPizzaModel
    {
        //public lon MyProperty { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Tomato tomato { get; set; }
        [Required]
        public Mozzarella mozzarella { get; set; }
    }

    //public class AddToppings
    //{
    //    public ICollection<PizzaTopping> Toppings { get; set; }
    //}
}