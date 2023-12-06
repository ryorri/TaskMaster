using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Domain.Interfaces
{
    public interface IPriorityRepo
    {
        Task Create(Domain.Entities.Priority prio);
        Task<IEnumerable<Domain.Entities.Priority>> GetAll();
    }
}
