using Microsoft.AspNet.Identity.EntityFramework;
using OrderingPizza.Entities;
using System.Data.Entity;

namespace OrderingPizza.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           // System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public interface IApplicationDbContext
    {
        IDbSet<ApplicationUser> Users { get; }

        int SaveChanges();

    }
}