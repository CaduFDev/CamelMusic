using CamelDev.Musicas.DAO.Entity.Context;
using CamelDev.Musicas.Web.Identity;
using CamelDev.Musicas.Web.ViewModels.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CamelDev.Musicas.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser
                {
                    UserName = viewModel.Email.ToString(),
                    Email = viewModel.Email.ToString()                    
                };
                IdentityResult result = userManager.Create(identityUser, viewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.Add("Error_identity",ModelState.Values.First());
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(viewModel.Email, viewModel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Error_identity", "Usuario e/ou senha incorretos.");
                    return View(viewModel);
                }
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent = false,
                    
                },identity);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
        
        [Authorize]
        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}