using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Application.Objects;

namespace TaskMaster.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ErrorDto, Domain.Entities.Error>();
            CreateMap<Domain.Entities.Error, ErrorDto>();

            CreateMap<WarningDto, Domain.Entities.Warning>();
            CreateMap<Domain.Entities.Warning, WarningDto>();

            CreateMap<CategoryDto, Domain.Entities.Category>();
            CreateMap<Domain.Entities.Category, CategoryDto>();

            CreateMap<PriorityDto, Domain.Entities.Priority>();
            CreateMap<Domain.Entities.Priority, PriorityDto>();
        }

    }
}
