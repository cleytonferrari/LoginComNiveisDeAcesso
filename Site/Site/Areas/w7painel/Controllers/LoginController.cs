using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Site.Areas.w7painel.Helpers;

namespace Site.Areas.w7painel.Controllers
{
    public class LoginController : Controller
    {
        public SiteMembershipProvider MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null)
                MembershipService = new SiteMembershipProvider();

            base.Initialize(requestContext);
        }

        //
        // GET: /w7painel/Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModelo model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.Login, model.Pass))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.Relembrar);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Usuário e Senha Invalidos!");
            }
            return View(model);
        }

    }
}
