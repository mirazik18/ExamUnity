using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using d2tv.Models;
 

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using LoginModel = d2tv.Models.LoginModel;

namespace d2tv.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private D2Context d2Context;
        private readonly UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(D2Context d2Context, UserManager<User> manager, RoleManager<IdentityRole> role, SignInManager<User> signIn)
        {
            signInManager = signIn;
            roleManager = role;
            userManager = manager;
            this.d2Context = d2Context;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            //var role=new IdentityRole();
            //role.Name = "user";

            //roleManager.CreateAsync(role);
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               
                User user = userManager.Users.FirstOrDefault(u => u.UserName == model.Username);

            
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password) == true)
                {
                    //await signInManager.SignInAsync(user, false);
                    await Authenticate(model.Username); // аутентификация
                    bool a = HttpContext.User.Identity.IsAuthenticated;
                    return RedirectToAction("GetNews", "Home");

                }
                else
                {
                   
                    return RedirectToAction("Register", "Account");
                }

               
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
  
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Username, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                   // await signInManager.SignInAsync(user, false);
                    await Authenticate(model.Username); // аутентификация

                    return RedirectToAction("GetNews", "Home");
                }
                else {
                    return View(model);
                }
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}