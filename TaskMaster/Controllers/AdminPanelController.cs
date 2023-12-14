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
        private readonly UsersManipulation _userManipulator;

        public AdminPanelController(TaskMasterDbContext dbContext, UserManager<IdentityUser> userManager, UsersManipulation userManipulator) 
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
            var users = await _dbContext.Users.ToListAsync();

            var userList = users.ToList().Select(x => new SelectListItem
            {
                Text = x.UserName,
                Value = x.Id.ToString(),
            });

            var roles = await _dbContext.Roles.ToListAsync();

            var roleList = roles.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name,
            });



            ViewBag.usersList = userList;
            ViewBag.roleList = roleList;

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userId, string newRole)
        {

            var userName = _userManipulator.GetUserName(userId);

            IList<string> roles = await _userManager.GetRolesAsync(await userName);


            await _userManager.RemoveFromRoleAsync(await userName, roles[0]);
            await _userManager.AddToRoleAsync(await userName, newRole);


            return View();
        }
    }
}
