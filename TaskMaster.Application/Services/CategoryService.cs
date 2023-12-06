using AutoMapper;
using TaskMaster.Application.Objects;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepo _catRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo catRepos, IMapper mapper)
        {
            _catRepo = catRepos;
            _mapper = mapper;
        }

        public async Task Create(Domain.Entities.Category cat)
        {
            await _catRepo.Create(cat);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var cat = await _catRepo.GetAll();
            var dtos = _mapper.Map<IEnumerable<CategoryDto>>(cat);

            return dtos;
        }
    }
}
