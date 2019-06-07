using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyBlueBlue.Models;

namespace SkyBlueBlue.Controllers
{
    // [Authorize(Roles = "Administrators")]
    // [Authorize(Policy="仅限管理员")]
    // [Authorize]
    [Authorize(Roles = "Administrators")]
    public class RoleController:Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddViewModel roleAddViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(roleAddViewModel);
            }
            var role = new IdentityRole
            {
                Name = roleAddViewModel.RoleName
            };
            var result = await roleManager.CreateAsync(role);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach(var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty,item.Description);
            }
            return View(roleAddViewModel);
        }

        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role == null)
            {
                return RedirectToAction("Index");
            }
            var roleEditViewModel = new RoleEditViewModel
            {
                Id = id,
                RoleName = role.Name,
                Users = new List<string>()
            };

            var users = await userManager.Users.ToListAsync();
            foreach(var item in users)
            {
                if(await userManager.IsInRoleAsync(item, role.Name))
                {
                    roleEditViewModel.Users.Add(item.UserName);
                }
            }
            return View(roleEditViewModel);

        }


        [HttpPost]
        public async Task<IActionResult> EditRole (RoleEditViewModel roleEditViewModel)
        {
            var role =await roleManager.FindByIdAsync(roleEditViewModel.Id);
            if(role != null)
            {
                role.Name = roleEditViewModel.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty,"更新角色时出错");
                return View(roleEditViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role =await roleManager.FindByIdAsync(id);
            if(role != null)
            {
                var result = await roleManager.DeleteAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                    ModelState.AddModelError(string.Empty,"删除用户时发生错误");
            }
            else
            {
                ModelState.AddModelError(string.Empty,"用户找不到");
            }
            return View("Index",await roleManager.Roles.ToArrayAsync());
        }
        [HttpGet]
        public async Task<IActionResult> AddUserToRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return RedirectToAction("Index");
            }

            var vm = new UserRoleViewModel
            {
                RoleId = role.Id
            };

            var users = await userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                if (!await userManager.IsInRoleAsync(user, role.Name))
                {
                    vm.Users.Add(user);
                }
            }

            return View(vm);

        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            if(user != null && role != null)
            {
                var result = await userManager.AddToRoleAsync(user,role.Name);
                if(result.Succeeded)
                {
                    return RedirectToAction("EditRole",new{id=role.Id});
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,item.Description);
                }
                return View(userRoleViewModel);
            }
            ModelState.AddModelError(string.Empty,"用户或角色未找到");
            return View(userRoleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserToRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return RedirectToAction("Index");
            }

            var vm = new UserRoleViewModel
            {
                RoleId = role.Id
            };

            var users = await userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    vm.Users.Add(user);
                }
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            if(user != null && role != null)
            {
                
                var result = await userManager.RemoveFromRoleAsync(user,role.Name);
                if(result.Succeeded)
                {
                    return RedirectToAction("EditRole",new{id=role.Id});
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,item.Description);
                }
                return View(userRoleViewModel);
            }
            ModelState.AddModelError(string.Empty,"用户或角色未找到");
            return View(userRoleViewModel);
        }

        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> CheckRoleExist([Bind("RoleName")]string RoleName)
        {
            var role = await roleManager.FindByNameAsync(RoleName);
            if(role != null)
            {
                return Json("角色已经存在了");
            }
            return Json(true);
        }
    }
}