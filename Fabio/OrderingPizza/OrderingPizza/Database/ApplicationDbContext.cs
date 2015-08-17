using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrderingPizza.Entities;

namespace OrderingPizza.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}