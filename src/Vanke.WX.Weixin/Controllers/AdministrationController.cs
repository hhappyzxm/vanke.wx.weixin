using System.Web.Mvc;

namespace Vanke.WX.Weixin.Controllers
{
    [AllowAnonymous]
    public class AdministrationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}