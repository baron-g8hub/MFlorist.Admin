using MaynoothFlorist.WebUI.ViewModels;
using System;
using System.Web.Mvc;

namespace MaynoothFlorist.WebUI.Binders
{
    [Serializable]
    public class UserSessionBinder : IModelBinder
    {
        private const string _sessionKey = "MFloristUser";

        /// <summary>
        /// Model binders can create C# types from any information that is available in the request.
        /// This is one of the central features of the MVC Framework
        /// </summary>
        /// <param name="controllerContext">
        /// provides access to all of the information that the controller has, which includes
        /// details of the request from the client
        /// 
        /// The ControllerContext class has the HttpContext property, which in turn has
        /// </param>
        /// <param name="bindingContext">
        /// gives you information about the model object you are being asked to build and tools
        /// for making it easier
        /// </param>
        /// <returns></returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get the User from the session
            UserSession user = (UserSession)controllerContext.HttpContext.Session[_sessionKey];

            //create the user if there wasn't one in the session data
            if (user == null)
            {
                user = new UserSession();
                controllerContext.HttpContext.Session[_sessionKey] = user;
            }

            return user;
        }
    }
}