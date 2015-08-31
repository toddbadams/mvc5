using OrderingPizza.Models.Pizza;

namespace OrderingPizza.Entities
{
    public class Pizza
    {
        public long Id { get; set; }
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

        public void AddUser(long id)
        {
            this.Id = id;
        }
    }
}