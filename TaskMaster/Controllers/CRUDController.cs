﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Domain.Entities;
using TaskMaster.Infrastructure.Methods.CRUDMethods;

namespace TaskMaster.Controllers
{
    public class CRUDController : Controller
    {
        #region Properities
        private readonly IErrorService _errorService;
        private readonly IWarningService _warningService;

        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly CRUDManipulation _crudManipulation;
        #endregion

        #region Constructor
        public CRUDController(IErrorService errorService, ICategoryService categoryService, IWarningService warningService, IPriorityService priorityService, CRUDManipulation crudManipulation, UserManager<IdentityUser> userManager)
        {
            _warningService = warningService;
            _errorService = errorService;
            _categoryService = categoryService;
            _priorityService = priorityService;
            _crudManipulation = crudManipulation;
            _userManager = userManager;
        }
        #endregion

        #region Creating

        [Authorize(Roles ="User,Moderator,Admin")]
        [HttpGet]
        public async Task<IActionResult> CreateError()
        {
            ViewBag.catModelView = await _crudManipulation.GetCategoryToViewbag();
            ViewBag.prioModelView = await _crudManipulation.GetPriorityToViewbag();
            return View();
        }

        [Authorize(Roles = "User,Moderator,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateError(Domain.Entities.Error error)
        { 
                await _crudManipulation.SetUserIdInTable(error, await _userManager.GetUserAsync(HttpContext.User));
                await _errorService.Create(error);
                return RedirectToAction("Index", "Home");
        }

        

        [HttpGet]
        public async Task<IActionResult> CreateWarning()
        {
            ViewBag.catModelView = await _crudManipulation.GetCategoryToViewbag();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWarning(Domain.Entities.Warning warr)
        {
            await _crudManipulation.SetUserIdInTable(warr, await _userManager.GetUserAsync(HttpContext.User));
            await _warningService.Create(warr);
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Editing

        [Authorize(Roles = "Moderator,Admin")]
        [HttpGet]
        public async Task<IActionResult> EditWarning(int id)
        {
            ViewBag.catModelView = await _crudManipulation.GetCategoryToViewbag();

            var war = await _warningService.GetById(id);
            return View(war);
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWarning(int id, Domain.Entities.Warning warr)
        {
            await _crudManipulation.SetUserIdInTable(warr, await _userManager.GetUserAsync(HttpContext.User));

            await _warningService.Edit(id, warr);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpGet]
        public async Task<IActionResult> EditError(int id)
        {
            ViewBag.catModelView = await _crudManipulation.GetCategoryToViewbag();
            ViewBag.prioModelView = await _crudManipulation.GetPriorityToViewbag();



            var err = await _errorService.GetById(id);
            return View(err);
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditError(int id, Domain.Entities.Error err)
        {
            await _crudManipulation.SetUserIdInTable(err, await _userManager.GetUserAsync(HttpContext.User));

            await _errorService.Edit(id, err);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region RemovingData

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteWarning(int id)
        {
            var war = await _warningService.GetById(id);
            return View(war);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWarning(Domain.Entities.Warning warr)
        {
            await _warningService.Delete(warr);

            return RedirectToAction("Index", "Home");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteError(int id)
        {
            var war = await _errorService.GetById(id);
            return View(war);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteError(Domain.Entities.Error err)
        {
            await _errorService.Delete(err);

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Details

        [Authorize(Roles = "User,Moderator,Admin")]
        [HttpGet]
        public async Task<IActionResult> ErrorDetails(int id)
        {     
            return View(await _errorService.GetById(id));
        }

        [Authorize(Roles = "User,Moderator,Admin")]
        [HttpGet]
        public async Task<IActionResult> WarningDetails(int id)
        {
            return View(await _warningService.GetById(id));
        }
        #endregion

    }
}
