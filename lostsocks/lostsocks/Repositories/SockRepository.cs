using System.Data.Entity;
using lostsocks.Database;
using lostsocks.Entities;
using lostsocks.Models.Socks;

namespace lostsocks.Repositories
{
    public class SockRepository : ISockRepository
    {
        private readonly DbSet<Sock> _socks;
        private readonly IApplicationDbContext _context;

        public SockRepository(IApplicationDbContext context)
        {
            _socks = context.Socks;
            _context = context;
        }

        public void Add(AddSockModel model, byte[] image)
        {
            // create a sock entity
            var e = new Sock
            {
                Name = model.Name,
                Description = model.Description,
                Image = image
            };
            _socks.Add(e);
            _context.SaveChanges();
        }
    }

    public interface ISockRepository
    {
        void Add(AddSockModel model, byte[] image);
    }
}