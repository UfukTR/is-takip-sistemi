using System.Web.Mvc;

namespace IsTakipSistemi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "İş Takip Sistemi Hakkında";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim Sayfası";
            return View();
        }
    }
}
