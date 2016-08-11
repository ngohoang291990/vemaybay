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
            ViewBag.Airports = objvendors;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CW_Airport model, List<int> lstIdDen)
        {
           
            if (ModelState.IsValid)
            {
                db.Set<CW_Airport>().Add(model);

                if (lstIdDen != null)
                {
                    for (int i = 0; i < lstIdDen.Count; i++)
                    {
                        if (!lstIdDen[i].ToString().Equals(""))
                        {
                            CW_AirportRoute a = new CW_AirportRoute();

                            a.AirportID1 = model.Id;
                            a.AirportID2 = lstIdDen[i];
                            db.Set<CW_AirportRoute>().Add(a);
                            //db.SaveChanges();
                        }
                    }
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<CW_Airport> objvendors = db.Airports;
                ViewBag.Airports = objvendors;
                return View(model);
            }
            
        }

        public ActionResult Edit(int id)
        {
            var air = db.Airports.Find(id);

            //IEnumerable<CW_Airport> objvendors = db.Airports;
            ViewBag.Airports = db.Airports.OrderBy(x => x.Id);
            List<CW_AirportRoute> selectlist = db.AirportRoutes.OrderBy(x => x.AirportID1).ToList();
            if (selectlist.Count > 0)
            {
                ViewBag.SelectListItems = selectlist;
            }

            return View(air);
        }

        [HttpPost]
        public ActionResult Edit(CW_Airport model, List<int> lstIdDen)
        {
            //IEnumerable<CW_Airport> objmenunoselect = db.Airports;
            if (lstIdDen != null)
            {
               
                var lstAir = db.AirportRoutes.Where(x => x.AirportID1 == model.Id);
                if (lstAir.Any())
                {
                    foreach (var str in lstAir)
                    {
                        var catedelte = db.AirportRoutes.Attach(str);
                        db.AirportRoutes.Remove(catedelte);
                       
                    }
                }
                for (int i = 0; i < lstIdDen.Count; i++)
                {
                    if (!lstIdDen[i].ToString().Equals(""))
                    {
                        CW_AirportRoute a = new CW_AirportRoute();

                        a.AirportID1 = model.Id;
                        a.AirportID2 = lstIdDen[i];
                        db.Set<CW_AirportRoute>().Add(a);
                        db.SaveChanges();
                    }
                }
                //foreach (int str in lstIdDen)
                //{

                //    var lst = db.AirportRoutes.SingleOrDefault(x => x.AirportID1 == model.Id && x.AirportID2 == str);
                //    if (lst != null)
                //    {
                //        db.AirportRoutes.Remove(lst);
                //        db.SaveChanges();
                //    }

                //    //IEnumerable<CW_AirportRoute> lstai= from air in db.AirportRoutes
                //    //    where air.AirportID1 == model.Id && air.AirportID2.Equals(str)
                //    //    select air;

                //    //if (lstai != null)
                //    //{
                //    //    addmenucate = new CW_AirportRoute();
                //    //    addmenucate.AirportID1 = model.Id;
                //    //    addmenucate.AirportID2 = str;
                //    //    db.Set<CW_AirportRoute>().Add(addmenucate);
                //    //    db.SaveChanges();
                //    //}

                //    //objmenunoselect = objmenunoselect.Where(x => !x.Id.Equals(str));
                //}
                //menu không được chọn nữa, nhưng đang tồn tại trong bảng CW_AirportRoute thì xóa đi
                //if (lstIdDen != null)
                //{
                //    CW_AirportRoute objMenuCategory = null;
                //    foreach (var item in objmenunoselect)
                //    {
                //        objMenuCategory = db.AirportRoutes.Where(x => x.AirportID1 == model.Id && x.AirportID2.Equals(item.Id)).FirstOrDefault();
                //        if (objMenuCategory != null)
                //        {
                //            db.AirportRoutes.Attach(objMenuCategory);
                //            db.Set<CW_AirportRoute>().Remove(objMenuCategory);
                //        }
                //    }
                //    db.SaveChanges();
                //}
            }
            //else
            //{
            //    IEnumerable<CW_AirportRoute> menucate = (from s in db.AirportRoutes
            //                                             where s.AirportID1 == model.Id
            //                                             select s);
            //    foreach (CW_AirportRoute obj in menucate)
            //    {
            //        db.AirportRoutes.Attach(obj);
            //        db.Set<CW_AirportRoute>().Remove(obj);
            //    }
            //    db.SaveChanges();
            //}

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