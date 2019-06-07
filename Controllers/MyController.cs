using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkyBlueBlue.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using SkyBlueBlue.Services;

namespace SkyBlueBlue.Controllers
{
    [Authorize]
    public class MyController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SuccessManager successManager;

        public MyController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SuccessManager successManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.successManager = successManager;
        }
        public async Task<IActionResult> Index()
        {
            var a = User.Identity.Name;
            var my = await userManager.FindByNameAsync(User.Identity.Name);
            return View(
                new MyInfoModel
                {
                    id = my.Id,
                    userName = my.UserName,
                    roles = await userManager.GetRolesAsync(my),
                    avatar = my.avatar,
                    email = my.Email
                }
            );
        }

        public async Task<IActionResult> CheckHistory()
        {
            var successList= await successManager.FindSuccessByUserNameAsync(User.Identity.Name);
            ViewBag.SuccessList = successList;
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var my = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (my != null)
            {
                var result =  await userManager.ChangePasswordAsync(my,model.oldPassword,model.newPassword);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty,"原密码错误");
                return View(model);
            }
            
            return View(model);
        }
    }
}