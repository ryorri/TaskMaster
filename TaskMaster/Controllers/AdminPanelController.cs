using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TaskMaster.Infrastructure.DatabaseContext;
using TaskMaster.Infrastructure.Methods.AdminPanelMethods;

namespace TaskMaster.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly TaskMasterDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CRUDManipulation _userManipulator;

        public AdminPanelController(TaskMasterDbContext dbContext, UserManager<IdentityUser> userManager, CRUDManipulation userManipulator) 
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
        public async Task<IActionResult> ChangeRole()
        {
            ViewBag.usersList = _userManipulator.GetUserList();
            ViewBag.roleList = _userManipulator.GetRoleList();

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userId, string newRole)
        {

            var userName = _userManipulator.GetUserName(userId);

            var roles = _userManipulator.GetUserRole(userName);

            await _userManager.RemoveFromRoleAsync(await userName, (await roles.ConfigureAwait(false))[0]);
            await _userManager.AddToRoleAsync(await userName, newRole);


            return RedirectToAction("ChangeRole");
        }
    }
}
