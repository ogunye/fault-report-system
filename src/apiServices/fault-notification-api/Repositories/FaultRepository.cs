using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FaultRepository : RepositroyBase<Fault>, IFaultRepository
    {
        public FaultRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFault(Fault fault)
        {
            fault.DateCreated = DateTime.Now.Date;
            fault.DateTimeReported = DateTime.Now;
            fault.ConfirmFaultStatus = "Reported";
            Create(fault);           
        }

        public void DeleteFault(Fault fault) => Delete(fault);

        public async Task<IEnumerable<Fault>> GetAllFaultAsync(bool trackChanges) => 
            await GetAll(trackChanges)
            .OrderByDescending(c => c.Id)
            .ToListAsync();

        public async Task<Fault> GetFaultByIdAsync(Guid faultId, bool trackChanges) => await FindByCondition(c => c.Id.Equals(faultId), trackChanges)
                .SingleOrDefaultAsync();
    }
}
