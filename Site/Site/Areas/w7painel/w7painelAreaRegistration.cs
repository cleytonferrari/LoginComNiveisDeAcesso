using System.Web.Mvc;

namespace Site.Areas.w7painel
{
    public class w7painelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "w7painel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "w7painel_default",
                "w7painel/{controller}/{action}/{id}",
                new {controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
