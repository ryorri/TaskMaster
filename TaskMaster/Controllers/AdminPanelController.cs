using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using TaskMaster.Infrastructure.DatabaseContext;
using TaskMaster.Infrastructure.Methods.AdminPanelMethods;

namespace TaskMaster.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly TaskMasterDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserManipulation _userManipulator;

        public AdminPanelController(TaskMasterDbContext dbContext, UserManager<IdentityUser> userManager, UserManipulation userManipulator) 
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _userManipulator = userManipulator;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeRole()
        {
            ViewBag.usersList = _userManipulator.GetUserList();
            ViewBag.roleList = _userManipulator.GetRoleList();

            return PartialView("_ChangeRole");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userId, string newRole)
        {

            var userName = _userManipulator.GetUser(userId);

            var roles = _userManipulator.GetUserRole(userName);

            await _userManager.RemoveFromRoleAsync(await userName, (await roles.ConfigureAwait(false))[0]);
            await _userManager.AddToRoleAsync(await userName, newRole);

            return RedirectToAction("Index");

        }

        public IActionResult RemoveUser()
        {
            ViewBag.usersList = _userManipulator.GetUserList();

            return PartialView("_RemoveUser");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUser(string userId)
        {
            await _userManipulator.RemoveUser(await _userManipulator.GetUser(userId));
            
            return RedirectToAction("Index");
        }
    }
}
