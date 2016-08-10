using System.Collections.Generic;
using System.Linq;
using Model.EF;
using System.Web.Mvc;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class AirportController : BaseController
    {
        //
        // GET: /Admin/Airport/
        private MVCDbContext db = new MVCDbContext();

        public ActionResult Index()
        {
            var ariport = db.Airports.OrderBy(x => x.SortOrder);
            return View(ariport);
        }
        public ActionResult View(int id)
        {
            var ariport = db.Airports.Find(id);
            return View(ariport);
        }
        public ActionResult Add()
        {
            //nhà sản xuất
            IEnumerable<CW_Airport> objvendors = db.Airports;
            ViewBag.Airports = new SelectList(objvendors, "Id", "AirportName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CW_Airport model)
        {
            db.Set<CW_Airport>().Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var air = db.Airports.Find(id);
            return View(air);
        }

        [HttpPost]
        public ActionResult Edit(CW_Airport model)
        {
            db.Airports.Attach(model);
            db.Entry(model).Property(a => a.AirportName).IsModified = true;
            db.Entry(model).Property(a => a.AirportCode).IsModified = true;
            db.Entry(model).Property(a => a.SortOrder).IsModified = true;
            db.Entry(model).Property(a => a.IsActive).IsModified = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var article = db.Set<CW_Airport>().Find(id);
            if (article != null)
            {
                var catedelte = db.Airports.Attach(article);
                db.Set<CW_Airport>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateIsActive(int id, bool isactive)
        {
            CW_Airport art = db.Airports.Find(id);
            if (art != null)
            {
                db.Set<CW_Airport>().Attach(art);
                if (isactive)
                {
                    art.IsActive = false;
                }
                else
                {
                    art.IsActive = true;
                }

                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateOrder(int id, int order)
        {
            CW_Airport art = db.Airports.Find(id);
            if (art != null)
            {
                db.Set<CW_Airport>().Attach(art);
                art.SortOrder = order;
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
    }
}