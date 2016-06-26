using System.Web.Mvc;
using Vanke.WX.Weixin.App_Extension;


namespace Vanke.WX.Weixin.Controllers
{
    [WeixinAuthorize]
    public class WeixinController : Controller
    {
        public ActionResult ItemBorrow()
        {
            return View();
        }

        public ActionResult ItemBorrowHistories()
        {
            return View();
        }

        public ActionResult SurroundingServices()
        {
            return View();
        }

        public ActionResult DesignatedDrivers()
        {
            return View();
        }

        public ActionResult DinnerRegister()
        {
            return View();
        }

        public ActionResult DinnerRegisterHistories()
        {
            return View();
        }

        public ActionResult ExternalPersonnelDiningRegister()
        {
            return View();
        }

        public ActionResult ExternalPersonnelDiningRegisterHistories()
        {
            return View();
        }

        public ActionResult Idleassets()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
}
