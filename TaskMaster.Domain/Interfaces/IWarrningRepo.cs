using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Domain.Interfaces
{
    public interface IWarrningRepo
    {
        Task Create(Domain.Entities.Warning warr);
        Task<Warning> Edit(int id, Domain.Entities.Warning warr);
        Task Delete(Domain.Entities.Warning warr);
        Task<Domain.Entities.Warning> GetById(int id);
        Task<IEnumerable<Domain.Entities.Warning>> GetAll();
    }
}
