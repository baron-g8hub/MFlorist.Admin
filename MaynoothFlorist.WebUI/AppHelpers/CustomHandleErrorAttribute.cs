using DataAccessLayer;
using MaynoothFlorist.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaynoothFlorist.WebUI.App_Start
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist)
    /// Date    : February 16, 2016 
    /// 
    /// Custom error handler for all the controllers   
    /// </summary>
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        //private readonly ILog _logger;

        public CustomHandleErrorAttribute()
        {
            //_logger = LogManager.GetLogger("MyLogger");
        }

        /// <summary>
        /// The OnException() method receives the filterContext parameter that gives more information about the exception. 
        /// Inside, you check the ExceptionHandled property to see whether the exception has been handled already by 
        /// some other part of the controller or not. If this property returns false you go ahead and grab the controller 
        /// and action name that caused the exception. Notice how RouteData.Values is used to retrieve the controller name 
        /// and the action name. To get the actual Exception that was thrown you use the Exception property.
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else
            {
                //var controllerName = (string)filterContext.RouteData.Values["controller"];
                //var actionName = (string)filterContext.RouteData.Values["action"];
                //var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName); 

                //var error = new ErrorInfo
                //{
                //    ErrorMessage = filterContext.Exception.Message,
                //    LogDateTime = DateTime.Now,
                //    Repository = new MFRepository()
                //};

                //if (filterContext.Exception.InnerException != null)
                //{
                //    error.ErrorMessage = filterContext.Exception.InnerException.Message;

                //    if (filterContext.Exception.InnerException.InnerException != null)
                //        error.ErrorMessage = filterContext.Exception.InnerException.InnerException.Message;
                //}


                if (filterContext.HttpContext.Session != null)
                {
                    var userSession = ((UserSession)filterContext.HttpContext.Session["MFloristUser"]);
                    //error.DataAreaID = userSession.DataAreaID;
                    //error.UserID = userSession.UserName;
                    //error.StatusCode = "N";
                }

                //var model = error;

                //filterContext.Result = new ViewResult
                //{
                //    ViewName = View,
                //    MasterName = Master,
                //    //ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                //   // ViewData = new ViewDataDictionary<ErrorInfo>(model),
                //    TempData = filterContext.Controller.TempData
                //};

                //error.LogError();
            }

            // log the error using log4net.
            //_logger.Error(filterContext.Exception.Message, filterContext.Exception);


            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}