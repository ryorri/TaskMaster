using Microsoft.AspNetCore.Mvc;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services.Interfaces;

namespace TaskMaster.Controllers
{
    public class HomeController : Controller
    {

        private readonly IErrorService _errorService;
        private readonly IWarningService _warningService;

        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;

        public HomeController(IErrorService errorService, ICategoryService categoryService, IWarningService warningService, IPriorityService priorityService)
        {
            _warningService = warningService;
            _errorService = errorService;
            _categoryService = categoryService;
            _priorityService = priorityService;
        }

        public async Task<IActionResult> Index()
        {

            var errorModel = await _errorService.GetAll();
            var warningModel = await _warningService.GetAll();

            var model = new Tuple<IEnumerable<ErrorDto>, IEnumerable<WarningDto>>(errorModel, warningModel);

            return View(model);
        }



    }
}
