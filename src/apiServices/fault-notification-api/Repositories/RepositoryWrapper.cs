using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IFaultRepository> _fault;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _fault = new Lazy<IFaultRepository>(() => new FaultRepository(repositoryContext));
        }

        public IFaultRepository Fault => _fault.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
