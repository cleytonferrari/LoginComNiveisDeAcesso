using System;
using System.Web;
using System.Web.Mvc;

namespace Site.Areas.w7painel.Helpers
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class Seguranca : AuthorizeAttribute
    {
        // Seta um action default para redirecionar
        private string redirecionarPara = "~/w7painel/Home/SemAcesso";

        public string RedirecionarPara
        {
            get { return redirecionarPara; }
            set { redirecionarPara = value; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }


            //if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    // TODO: fix the URL building:
            //    // 1- Use some class to build URLs just in case LoginUrl actually has some query already.
            //    // 2- When leaving Result as a HttpUnauthorizedResult, ASP.Net actually does some nice automatic stuff, like adding a ReturnURL, when hardcodding the URL here, that is lost.
            //    String url = System.Web.Security.FormsAuthentication.LoginUrl + "?X-Requested-With=XMLHttpRequest";
            //    filterContext.Result = new RedirectResult(url);
            //}

            if (AuthorizeCore(filterContext.HttpContext))
            {
                var cachePolicy = filterContext.HttpContext.Response.Cache;
                cachePolicy.SetProxyMaxAge(new TimeSpan(0));

                cachePolicy.AddValidationCallback(CacheValidateHandler, null);
            }

            // Adiciona um pagina Não Autorizada
            else if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (RedirecionarPara != null)
                    filterContext.Result = new RedirectResult(RedirecionarPara);
                else
                    // Pagina de Login
                    HandleUnauthorizedRequest(filterContext);
            }
            else
                HandleUnauthorizedRequest(filterContext);
            
        }

        protected void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
        }
    }
}