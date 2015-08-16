using System.Data.Entity;
using lostsocks.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace lostsocks.Database
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    // http://www.entityframeworktutorial.net/EntityFramework4.3/dbcontext-vs-objectcontext.aspx
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Sock> Socks { get; set; }
    }

    public interface IApplicationDbContext
    {
        DbSet<Sock> Socks { get; }

        int SaveChanges();
    }
}