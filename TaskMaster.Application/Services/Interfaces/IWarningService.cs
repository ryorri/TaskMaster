﻿using TaskMaster.Application.Objects;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.Services.Interfaces
{
    public interface IWarningService
    {
        Task Create(Warning warr);

        Task<IEnumerable<WarningDto>> GetAll();
    }
}