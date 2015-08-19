using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Web;
using System.Web.Mvc;
using lostsocks.Database;
using lostsocks.Models.Socks;
using lostsocks.Repositories;
using Microsoft.AspNet.Identity;

namespace lostsocks.Controllers
{
    public class SocksController : Controller
    {
        private readonly ISockRepository _repository;

        public SocksController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            _repository = new SockRepository(context);
        }
        // GET: Socks
        public ActionResult Index()
        {
            SockModel[] vm = _repository.Fetch(User.Identity.GetUserId());
            return View(vm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddSockModel model, HttpPostedFileBase upload)
        {
            if (!ModelState.IsValid) //|| upload == null)
            {
                return View(model);
            }

            // convert the upload to a byte array type
            byte[] data = null;
            if (upload != null)
            {
                MemoryStream target = new MemoryStream();
                upload.InputStream.CopyTo(target);
                data = target.ToArray();
            }

            // save to repository
            _repository.Add(User.Identity.GetUserId(), model, data);

            return RedirectToAction("Index");
        }
    }
}