using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Domain.Interfaces
{
    public interface IWarrningRepo
    {
        Task Create(Domain.Entities.Warning warr);
        Task<IEnumerable<Domain.Entities.Warning>> GetAll();
    }
}
