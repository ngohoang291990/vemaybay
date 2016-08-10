using System;
using System.Linq;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class NationalController : BaseController
    {
        //
        // GET: /Admin/National/
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            var na = db.Nationalities.OrderBy(x => x.SortOrder);
            return View(na);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CW_Nationality model)
        {
            model.FilterName = COMMOM.Filter.FilterChar(model.NationalityName);
            db.Set<CW_Nationality>().Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var nation = db.Nationalities.Find(id);
            return View(nation);
        }
        [HttpPost]
        public ActionResult Edit(CW_Nationality model)
        {
            model.FilterName = COMMOM.Filter.FilterChar(model.NationalityName);
            db.Nationalities.Attach(model);
            db.Entry(model).Property(a => a.NationalityName).IsModified = true;
            db.Entry(model).Property(a => a.Description).IsModified = true;
            db.Entry(model).Property(a => a.NationalityCode).IsModified = true;
            db.Entry(model).Property(a => a.Fee).IsModified = true;
            db.Entry(model).Property(a => a.Tips).IsModified = true;
            db.Entry(model).Property(a => a.TimeZoo).IsModified = true;
            db.Entry(model).Property(a => a.SortOrder).IsModified = true;
            db.Entry(model).Property(a => a.Requirement).IsModified = true;
            db.Entry(model).Property(a => a.IsActive).IsModified = true;
            db.Entry(model).Property(a => a.Icon).IsModified = true;
            db.Entry(model).Property(a => a.FilterName).IsModified = true;
            db.Entry(model).Property(a => a.Embassy).IsModified = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var article = db.Set<CW_Nationality>().Find(id);
            if (article != null)
            {
                var catedelte = db.Nationalities.Attach(article);
                db.Set<CW_Nationality>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateIsActive(int id, bool isactive)
        {
            CW_Nationality art = db.Nationalities.Find(id);
            if (art != null)
            {
                db.Set<CW_Nationality>().Attach(art);
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
            CW_Nationality art = db.Nationalities.Find(id);
            if (art != null)
            {
                db.Set<CW_Nationality>().Attach(art);
                art.SortOrder = order;
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
    }
}