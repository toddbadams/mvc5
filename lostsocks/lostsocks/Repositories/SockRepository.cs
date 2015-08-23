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
        private readonly IDbSet<Sock> _socks;
        private readonly IApplicationDbContext _context;

        public SockRepository(IApplicationDbContext context)
        {
            _users = context.Users;
            _socks = context.Socks;
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
                    ImageSrc = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image))
                });
            }

            return socks.ToArray();
        }

        public SockModel[] FetchLatest(int quantity)
        {
            var entities = _socks.Take(quantity).ToList();
            var socks = new List<SockModel>();
            foreach (var item in entities)
            {
                socks.Add(new SockModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImageSrc = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image))
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
                ImageSrc = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(sock.Image))
            };
        }

        public void Update(string userId, long sockId, string name, string description)
        {
            var u = _users.Single(x => x.Id == userId);
            var exists = u.Socks.Any(x => x.Id == sockId);
            if (!exists) return;
            var sock = u.Socks.First(x => x.Id == sockId);
            sock.Description = description;
            sock.Name = name;
            _context.SaveChanges();
        }
    }

    public interface ISockRepository
    {
        void Add(string userId, AddSockModel model, byte[] image);

        SockModel[] Fetch(string userId);

        SockModel Get(string userId, long sockId);

        void Delete(string userId, long sockId);

        void Update(string userId, long sockId, string name, string description);

        SockModel[] FetchLatest(int quantity);
    }
}