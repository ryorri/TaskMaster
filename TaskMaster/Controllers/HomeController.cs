using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using NuGet.Packaging;
using System.Dynamic;
using System.Runtime.InteropServices;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services;
using TaskMaster.Domain.Interfaces;
using TaskMaster.Infrastructure.DatabaseContext;
using TaskMaster.Models;

namespace TaskMaster.Controllers
{
    public class HomeController : Controller
    {

        private readonly IErrorService _errorService;
        private readonly IWarningService _warningService;

        private readonly ICategoryService _categoryService;

        public HomeController(IErrorService errorService, ICategoryService categoryService, IWarningService warningService)
        {
            _warningService = warningService;
            _errorService = errorService;
            _categoryService = categoryService;
        }


        // GET: HomeController1
        public async Task<IActionResult> Index()
        {

            var errorModel = await _errorService.GetAll();
            var warningModel = await _warningService.GetAll();

            var model = new Tuple<IEnumerable<ErrorDto>, IEnumerable<WarningDto>>(errorModel, warningModel);

            return View(model);
        }
         
        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<IActionResult> CreateError()
        {
            var cat = await _categoryService.GetAll();
            if (cat != null)
            {
                ViewBag.data = cat;
            }
            return View("../CreatingViews/CreateError");
        }
        public async Task<IActionResult> Vieww()
        {
            var cat = await _categoryService.GetAll();

            return View(cat);
        }
        [HttpPost]
        public async Task<ActionResult> CreateError(Domain.Entities.Error error)
        {
            await _errorService.Create(error);
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
