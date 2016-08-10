using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class AirportRouteController : BaseController
    {
        //
        // GET: /Admin/AirportRoute/
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index(int id)
        {
            var air = db.AirportRoutes.Find(id);
            return View(air);
        }

    }
}
