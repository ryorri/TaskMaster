using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

    }
}
