using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Web;
using System.Web.Mvc;
using lostsocks.Database;
using lostsocks.Models.Socks;
using lostsocks.Repositories;

namespace lostsocks.Controllers
{
    public class SocksController : Controller
    {
        private readonly ISockRepository _repository;

        public SocksController()
        {
            var context = new ApplicationDbContext();
            _repository = new SockRepository(context);
        }
        // GET: Socks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddSockModel model)
        {
            if (!ModelState.IsValid) //|| upload == null)
            {
                return View(model);
            }

            //// convert the upload to a byte array type
            //MemoryStream target = new MemoryStream();
            //upload.InputStream.CopyTo(target);
            //byte[] data = target.ToArray();

            // save to repository
            _repository.Add(model, null);

            return RedirectToAction("Index");
        }
    }
}