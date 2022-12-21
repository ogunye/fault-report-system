using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFaultRepository
    {
        Task<IEnumerable<Fault>> GetAllFaultAsync(bool trackChanges);
        Task<Fault> GetFaultByIdAsync(Guid faultId, bool trackChanges);
        void CreateFault(Fault fault);
        void DeleteFault(Fault fault);             
    }
}
