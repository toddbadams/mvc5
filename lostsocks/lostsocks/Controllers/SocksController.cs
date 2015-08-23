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
            var context = new ApplicationDbContext();
            _repository = new SockRepository(context);
        }
        // GET: Socks
        public ActionResult Index()
        {
            var vm = _repository.Fetch(User.Identity.GetUserId());
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
            if (!ModelState.IsValid || upload == null)
            {
                return View(model);
            }
            _repository.Add(User.Identity.GetUserId(), model, ToByteArray(upload));
            return RedirectToAction("Index");
        }

        // convert the upload to a byte array type
        private static byte[] ToByteArray(HttpPostedFileBase upload)
        {
            if (upload == null) return null;
            using (var target = new MemoryStream())
            {
                upload.InputStream.CopyTo(target);
                var data = target.ToArray();
                return data;
            }
        }

        public ActionResult Delete(long id)
        {
            var vm = _repository.Get(User.Identity.GetUserId(), id);
            if (vm == null) RedirectToAction("Index");
            return View(vm);
        }


        public ActionResult DeleteConfirm(long id)
        {
            _repository.Delete(User.Identity.GetUserId(), id);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(long id)
        {
            var vm = _repository.Get(User.Identity.GetUserId(), id);
            if (vm == null) RedirectToAction("Index");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSockModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { id = model.Id });
            }
            _repository.Update(User.Identity.GetUserId(), model.Id, model.Name, model.Description);
            return RedirectToAction("Index");
        }
    }
}