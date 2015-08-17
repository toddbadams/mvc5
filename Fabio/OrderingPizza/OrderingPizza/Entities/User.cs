using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrderingPizza.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
       // public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string StreetNumber { get; set; }
        public string AddressLine { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}