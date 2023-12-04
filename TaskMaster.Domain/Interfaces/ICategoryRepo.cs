using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Domain.Interfaces
{
    public interface ICategoryRepo
    {
        Task Create(Domain.Entities.Category cat);
        Task<IEnumerable<Domain.Entities.Category>> GetAll();
    }
}
