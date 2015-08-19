using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using lostsocks.Database;
using lostsocks.Entities;
using lostsocks.Models.Socks;

namespace lostsocks.Repositories
{
    public class SockRepository : ISockRepository
    {
        private readonly IDbSet<ApplicationUser> _users;
        private readonly IApplicationDbContext _context;

        public SockRepository(IApplicationDbContext context)
        {
            _users = context.Users;
            _context = context;
        }

        public void Add(string userId, AddSockModel model, byte[] image)
        {
            // get the user
            var u = _users.Single(x => x.Id == userId);

            // create a sock entity
            var e = new Sock
            {
                Name = model.Name,
                Description = model.Description,
                Image = image,
                DateOfBirth = DateTime.Now
            };
            u.Socks.Add(e);
            _context.SaveChanges();
        }

        public SockModel[] Fetch(string userId)
        {
            var u = _users.Single(x => x.Id == userId);

            var socks = new List<SockModel>();
            foreach (var item in u.Socks)
            {
                socks.Add(new SockModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image
                });
            }

            return socks.ToArray();
        }
    }

    public interface ISockRepository
    {
        void Add(string userId, AddSockModel model, byte[] image);
        SockModel[] Fetch(string userId);
    }
}