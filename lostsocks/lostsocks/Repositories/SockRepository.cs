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

        public void Delete(string userId, long sockId)
        {
            // get the user
            var u = _users.Single(x => x.Id == userId);

            var exists = u.Socks.Any(x => x.Id == sockId);

            if (!exists) return;

            var sock = u.Socks.First(x => x.Id == sockId);
            u.Socks.Remove(sock);
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
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image
                });
            }

            return socks.ToArray();
        }

        public SockModel Get(string userId, long sockId)
        {
            var u = _users.Single(x => x.Id == userId);
            var exists = u.Socks.Any(x => x.Id == sockId);

            if (!exists) return null;

            var sock = u.Socks.First(x => x.Id == sockId);

            return new SockModel
            {
                Id = sock.Id,
                Name = sock.Name,
                Description = sock.Description,
                Image = sock.Image
            };
        }
    }

    public interface ISockRepository
    {
        void Add(string userId, AddSockModel model, byte[] image);
        SockModel[] Fetch(string userId);

        SockModel Get(string userId, long sockId);

        void Delete(string userId, long sockId);
    }
}