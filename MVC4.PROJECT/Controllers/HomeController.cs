using Model.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC4.PROJECT.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var lang = Session["culture"].ToString();
            //int cateid = int.Parse(COMMOM.Interface.ISetting.GetSettingValue("SettingDefaultPage" + lang));
            //var cateobj = db.CW_Category.Find(cateid);
            //if (!cateobj.CategoryCode.Equals("trang-chu") && !cateobj.CategoryCode.Equals("home"))
            //{
            //    return Redirect(COMMOM.Interface.Helper.RenderURL(cateobj.TypeCode, cateobj.ID, cateobj.CategoryCode, cateobj.Link));
            //}
            //ViewBag.CateID = 1;

            return View();
        }

        // Adv ---------------------------------------------

        [ChildActionOnly]
        public PartialViewResult _AdvSlider()
        {
            var lang = Session["culture"].ToString();
            var advs = db.CW_Adv.Where(m => m.Position == 1 && m.LanguageCode.Equals(lang) && m.IsActive).OrderBy(m => m.Order);
            return PartialView(advs);
        }

        // Menu --------------------------------------------
        [ChildActionOnly]
        public PartialViewResult _MenuMain()
        {
            var lang = Session["culture"].ToString();

            IEnumerable<CW_Category> categories = from cate in db.CW_Category
                                                  join cate_menu in db.CW_Menu_Category
                                                  on cate.ID equals cate_menu.CategoryID
                                                  where cate_menu.MenuCode.Equals("menu-top") && cate.ParentID == null && cate.LanguageCode.Equals(lang) && cate.IsActive
                                                  orderby cate_menu.SortOrder
                                                  select cate;
            return PartialView(categories);
        }

        [ChildActionOnly]
        public PartialViewResult _MenuFooter()
        {
            var lang = Session["culture"].ToString();

            IEnumerable<CW_Category> categories = from cate in db.CW_Category
                                                  join cate_menu in db.CW_Menu_Category
                                                  on cate.ID equals cate_menu.CategoryID
                                                  where cate_menu.MenuCode.Equals("menu-bottom") && cate.ParentID == null && cate.LanguageCode.Equals(lang) && cate.IsActive
                                                  orderby cate_menu.SortOrder
                                                  select cate;
            return PartialView(categories);
        }

        // Data --------------------------------------------
        private MVCDbContext db = new MVCDbContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}