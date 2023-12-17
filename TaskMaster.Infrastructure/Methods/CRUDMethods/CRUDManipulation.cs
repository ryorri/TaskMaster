using Microsoft.AspNetCore.Mvc.Rendering;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Infrastructure.DatabaseContext;

namespace TaskMaster.Infrastructure.Methods.CRUDMethods
{
    public class CRUDManipulation
    {
        private readonly TaskMasterDbContext _dbContext;
        private readonly IErrorService _errorService;
        private readonly IWarningService _warningService;

        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;

        public CRUDManipulation(TaskMasterDbContext dbContext, IErrorService errorService, ICategoryService categoryService, IWarningService warningService, IPriorityService priorityService)
        {
            _dbContext = dbContext;
            _warningService = warningService;
            _errorService = errorService;
            _categoryService = categoryService;
            _priorityService = priorityService;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoryToViewbag()
        {
            var catModel = await _categoryService.GetAll();

            IEnumerable<SelectListItem> categories = catModel.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            return categories;
        }


        public async Task<IEnumerable<SelectListItem>> GetPriorityToViewbag()
        {
            var prioModel = await _priorityService.GetAll();

            var priorities = prioModel.ToList().Select(x => new SelectListItem
            {
                Text = x._Priority,
                Value = x.Id.ToString(),
            });

            return (IEnumerable<SelectListItem>)priorities;
        }
    }
}
