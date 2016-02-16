using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using System.Web.Security;
using MaynoothFlorist.WebUI.ViewModels;
using System.Collections;

namespace MaynoothFlorist.WebUI.Controllers
{
    public class UserController : Controller
    {

        private readonly MaynoothFloristUser _mfUser = new MaynoothFloristUser();

        public int PageSize = 10;

        public UserController(IRepository repository)
        {
            _mfUser.Repository = repository;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            // itemList = _mfUser.GetUsers();

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(MaynoothFloristUser user, string returnUrl, UserSession session)
        {
            var userList = _mfUser.GetUsers();
            
            if (ModelState.IsValid)
            {
                if (user.IsValid(user, user.UserName, user.PassWord, userList))
                {
                    //session.Name = user.Username;
                    //session.LocationID = user.Mfgnumber;

                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToLocal(returnUrl);
                }

                //ModelState.AddModelError("", "Invalid username or password!");
                //this.FlashError("Invalid Credentials: ", "You've entered an invalid username or password.");
            }

            return View(user);
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