using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyBlueBlue.Models;
using SkyBlueBlue.Date;

namespace SkyBlueBlue.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UserController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager=userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        [IgnoreAntiforgeryToken]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> AddUser(UserCreateViewModel userCreateViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userCreateViewModel);
            }
            var user = new ApplicationUser
            {
                UserName = userCreateViewModel.UserName,
            };

            var result = await _userManager.CreateAsync(user,userCreateViewModel.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Index",await _userManager.Users.ToListAsync());
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,item.Description);
                }
                return View(userCreateViewModel);
            }
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var result = await _userManager.DeleteAsync(user);
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
            return View("Index",await _userManager.Users.ToArrayAsync());
        }


        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var claims= await _userManager.GetClaimsAsync(user);
                var theUser = new UserUpdateViewModel{
                    Id=user.Id,
                    UserName=user.UserName,
                    Claims=claims.Select(x => x.Value).ToList()
                };
                return View("UpdateUser",theUser);
            }
            else
            {
                ModelState.AddModelError(string.Empty,"用户找不到");
            }
            
            return View("Index",await _userManager.Users.ToArrayAsync());
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel userUpdateViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userUpdateViewModel);
            }
            var user =await _userManager.FindByIdAsync(userUpdateViewModel.Id);
            if(user != null)
            {
                user.UserName=userUpdateViewModel.UserName;

                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,item.Description);
                    }
                    return View(userUpdateViewModel);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ManagerClaims(string id)
        {
            var user = await _userManager.Users.Where(x => x.Id == id)
                .Include(x => x.Claims).SingleOrDefaultAsync();
            if(user==null)
            {
                return RedirectToAction("Index");
            }
            var list = ClaimTypes.AllClaimTypeList.Except(user.Claims.Select(x => x.ClaimType)).ToList();
            var vm = new ManagerClaimsViewModel
            {
                UserId =id,
                AllClaims=list 
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ManagerClaims(ManagerClaimsViewModel vm)
        {
            var user = await _userManager.FindByIdAsync(vm.UserId);
            if(user==null)
            {
                return RedirectToAction("Index");
            }

            var claim = new IdentityUserClaim<string>
            {
                ClaimType=vm.ClaimId,
                ClaimValue=vm.ClaimId
            };
            user.Claims.Add(claim);
            var result =await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("UpdateUser",new{id=vm.UserId});
            }
            ModelState.AddModelError(string.Empty,"编辑用户Claims时发生错误");
            return View(vm);
        }
    }
}