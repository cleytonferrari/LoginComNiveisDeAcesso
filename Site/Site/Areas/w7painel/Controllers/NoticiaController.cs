using System.Web.Mvc;
using Site.Areas.w7painel.Helpers;

namespace Site.Areas.w7painel.Controllers
{
    public class NoticiaController : Controller
    {
        //
        // GET: /w7painel/Noticia/

        [Seguranca(Roles = "noticia_visualizar")]
        public ActionResult Index()
        {
            return View();
        }

        [Seguranca(Roles = "noticia_alterar")]
        public ActionResult Update()
        {
            return View();
        }

        [Seguranca(Roles = "noticia_excluir")]
        public ActionResult Excluir()
        {
            return View();
        }

    }
}
