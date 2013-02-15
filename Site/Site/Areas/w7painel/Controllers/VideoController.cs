using System.Web.Mvc;
using Site.Areas.w7painel.Helpers;

namespace Site.Areas.w7painel.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /w7painel/Video/

        //Se usar o parametro RedirecionarPara pode 
        //setar pra onde jogar o usuario sem acesso
        [Seguranca(Roles = "video_visualizar", RedirecionarPara = "/Home")]
        public ActionResult Index()
        {
            return View();
        }

        [Seguranca(Roles = "video_alterar")]
        public ActionResult Update()
        {
            return View();
        }

        [Seguranca(Roles = "video_excluir")]
        public ActionResult Excluir()
        {
            return View();
        }

    }
}
