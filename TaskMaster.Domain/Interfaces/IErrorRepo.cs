using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Domain.Interfaces
{
    public interface IErrorRepo
    {
        Task Create(Domain.Entities.Error error);
        Task<IEnumerable<Domain.Entities.Error>> GetAll();
    }
}
