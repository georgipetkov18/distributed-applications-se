using InvestmentManagerApi.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InvestmentManagerApi.Shared.Attributes
{
    public class AppAuthorizeAttribute : TypeFilterAttribute
    {
        public AppAuthorizeAttribute() : base(typeof(AppAuthorizeFilter))
        {
        }
    }


    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class AppAuthorizeFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (SessionManager.Token == null)
            {
                filterContext.Result = new RedirectResult("/login");
                return;
            }
        }
    }
}
