using System.Web.Mvc;
using Site.Areas.w7painel.Helpers;

namespace Site.Areas.w7painel.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /w7painel/Home/
        [Seguranca]
        public ActionResult Index()
        {
            return View();
        }

        [Seguranca]
        public ActionResult SemAcesso()
        {
            return View();
        }

    }
}
