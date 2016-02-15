using MaynoothFlorist.WebUI.AppHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using MaynoothFlorist.WebUI.ViewModels;

namespace MaynoothFlorist.WebUI.Controllers
{
    [CustomHandleError]
    [Serializable]
    public class UserController : Controller
    {
        private readonly MaynoothFloristUser _mfuser = new MaynoothFloristUser();

        public UserController(IRepository repository)
        {
            _mfuser.Repository = repository;
        }

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
            if (ModelState.IsValid)
            {
                session.UserName = user.Username;

                if (user.IsValid(user, user.Username, user.Password))
                {
                    return null;
                }

                this.FlashError("Invalid Credentials: ", "You've entered an invalid username or password.");
            }

            


            return View(user);
        }























        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Login", "Home");
        }

    }
}