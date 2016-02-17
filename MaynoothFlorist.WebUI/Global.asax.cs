using MaynoothFlorist.WebUI.AppHelpers;
using MaynoothFlorist.WebUI.Binders;
using MaynoothFlorist.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MaynoothFlorist.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Project wide Dependency Injection
            DependencyResolver.SetResolver(new NinjectDependencyResolver());

            ModelBinders.Binders.Add(typeof(UserSession), new UserSessionBinder());
        }

        /// <summary>
        /// The Application_Error event is raised whenever there is any unhandled exception in the application
        /// that was not handled by the CustomHandleErrorAttribute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var httpContext = ((MvcApplication)sender).Context;
            //var currentController = " ";
            //var currentAction = " ";
            //var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            //if (currentRouteData != null)
            //{
            //    if (currentRouteData.Values["controller"] != null && !string.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
            //    {
            //        currentController = currentRouteData.Values["controller"].ToString();
            //    }

            //    if (currentRouteData.Values["action"] != null && !string.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
            //    {
            //        currentAction = currentRouteData.Values["action"].ToString();
            //    }
            //}


            var ex = Server.GetLastError();
            //var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;

                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;

                    case 401: // Unauthorized
                        action = "AccessDenied";
                        break;

                    case 403: // Forbidden
                        action = "AccessDenied";
                        break;
                }
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500; // InternalServerError
            httpContext.Response.TrySkipIisCustomErrors = true;

            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            //controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction); 

            if (httpContext.Response.StatusCode == 500)
            {
                //var error = new ErrorInfo
                //{
                //    ErrorMessage = ex.Message,
                //    LogDateTime = DateTime.Now,
                //    Repository = new FGTRepository()
                //};

                //if (ex.InnerException != null)
                //{
                //    error.ErrorMessage = ex.InnerException.Message;

                //    if (ex.InnerException.InnerException != null)
                //        error.ErrorMessage = ex.InnerException.InnerException.Message;
                //}


                if (httpContext.Session != null)
                {
                    var userSession = ((UserSession)httpContext.Session["MFloristUser"]);
                    //error.DataAreaID = userSession.DataAreaID;
                    //error.UserID = userSession.UserName;
                    //error.StatusCode = "N";
                }

                //controller.ViewData.Model = error;
                //error.LogError();
            }
            else
            {
                //controller.ViewData.Model = new ErrorInfo();
            }

            //((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }
    }
}