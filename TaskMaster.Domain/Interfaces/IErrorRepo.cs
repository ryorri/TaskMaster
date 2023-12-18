using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Domain.Interfaces
{
    public interface IErrorRepo
    {
        Task Create(Domain.Entities.Error error);
        Task<Error> Edit(int id, Domain.Entities.Error error);
        Task Delete(Domain.Entities.Error error);
        Task<IEnumerable<Domain.Entities.Error>> GetAll();
        Task<Domain.Entities.Error> GetById(int id);
    }
}
