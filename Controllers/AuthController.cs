using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkyBlueBlue.Models;
using Microsoft.AspNetCore.Http;

namespace SkyBlueBlue.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if(!ModelState.IsValid)
            {
                
                return View(loginModel);
            }
            var user=await userManager.FindByNameAsync(loginModel.userName);
            if(user!=null)
            {
                var result = await signInManager.PasswordSignInAsync(user,loginModel.password,false,false);
                if(result.Succeeded)
                {
                    HttpContext.Session.SetString("Avatar", user.avatar);
                    return RedirectToAction("Index","Home",new {user.avatar});
                }
            }
            ModelState.AddModelError("","账号/密码不正确");
            return View(loginModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
           if(ModelState.IsValid)
            {
                var user =new ApplicationUser{
                    UserName=registerModel.userName,
                    avatar=registerModel.avatar
                };
                var result=await userManager.CreateAsync(user,registerModel.password);
                var result2=await userManager.AddToRoleAsync(user,"Student");
                if(result.Succeeded&&result2.Succeeded)
                {
                    // HttpContext.Session.SetString("Avatar", user.avatar);
                    // return RedirectToAction("Index","Home",new {user.avatar});
                    return RedirectToAction("Login");
                }
            }
            return View(registerModel);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}