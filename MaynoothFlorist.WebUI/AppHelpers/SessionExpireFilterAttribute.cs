using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MaynoothFlorist.WebUI.AppHelpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    string sessionCookie = context.Request.Headers["Cookie"];

                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        FormsAuthentication.SignOut();

                        if (!string.IsNullOrEmpty(context.Request.RawUrl))
                        {
                            var redirectTo = string.Format("~/User/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));
                            filterContext.Result = new RedirectResult(redirectTo);
                            return;
                        }

                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}