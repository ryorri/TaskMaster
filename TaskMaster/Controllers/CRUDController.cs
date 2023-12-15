using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services;
using TaskMaster.Application.Services.Interfaces;

namespace TaskMaster.Controllers
{
    public class CRUDController : Controller
    {

        private readonly IErrorService _errorService;
        private readonly IWarningService _warningService;

        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;

        public CRUDController(IErrorService errorService, ICategoryService categoryService, IWarningService warningService, IPriorityService priorityService)
        {
            _warningService = warningService;
            _errorService = errorService;
            _categoryService = categoryService;
            _priorityService = priorityService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateError()
        {
            var catModel = await _categoryService.GetAll();
            var prioModel = await _priorityService.GetAll();


            var categories = catModel.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            var priorities = prioModel.ToList().Select(x => new SelectListItem
            {
                Text = x._Priority,
                Value = x.Id.ToString(),
            });

            ViewBag.catModelView = categories;
            ViewBag.prioModelView = priorities;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateError(Domain.Entities.Error error)
        {
            await _errorService.Create(error);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateWarning()
        {
            var catModel = await _categoryService.GetAll();

            var categories = catModel.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });


            ViewBag.catModelView = categories;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWarning(Domain.Entities.Warning warr)
        {
            await _warningService.Create(warr);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditWarning(int id)
        {
            var catModel = await _categoryService.GetAll();

            var categories = catModel.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });


            ViewBag.catModelView = categories;

            var war = await _warningService.GetById(id);
            return View(war);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWarning(int id, Domain.Entities.Warning warr)
        {
            await _warningService.Edit(id, warr);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditError(int id)
        {
            var catModel = await _categoryService.GetAll();
            var prioModel = await _priorityService.GetAll();


            var categories = catModel.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            var priorities = prioModel.ToList().Select(x => new SelectListItem
            {
                Text = x._Priority,
                Value = x.Id.ToString(),
            });

            ViewBag.catModelView = categories;
            ViewBag.prioModelView = priorities;

            var war = await _errorService.GetById(id);
            return View(war);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditError(int id, Domain.Entities.Error warr)
        {
            await _errorService.Edit(id, warr);

            return RedirectToAction("Index", "Home");
        }





















        // GET: CRUDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUDController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
