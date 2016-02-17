using BusinessLogicLayer;
using DataAccessLayer;
using MaynoothFlorist.WebUI.App_Start;
using MaynoothFlorist.WebUI.AppHelpers;
using MaynoothFlorist.WebUI.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace MaynoothFlorist.WebUI.Controllers
{
    [CustomHandleError]
    [Serializable]
    public class UserController : Controller
    {             
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
           
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(MaynoothFloristUser user, string returnUrl, UserSession session)
        {           
            user.Repository = new MFRepository();

            if (ModelState.IsValid)
            {
                if (user.IsValid(user, user.UserName, user.PassWord))
                {
                    session.Name = user.UserName;
      
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToLocal(returnUrl);
                }

                //ModelState.AddModelError("", "Invalid username or password!");
                this.FlashError("Invalid Credentials: ", "You've entered an invalid username or password.");
            }

            return View(user);
        }


        public ViewResult SessionInfo(UserSession session)
        {
            return View(session);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Item");
        }

    }
}