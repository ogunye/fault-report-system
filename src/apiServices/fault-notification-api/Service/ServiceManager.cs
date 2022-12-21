using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IFaultService> _faultService;

        public ServiceManager(IRepositoryWrapper repositoryWrapper, ILoggerManager logger, IMapper mapper)
        {
            _faultService = new Lazy<IFaultService>(() =>
            new FaultService(repositoryWrapper, logger, mapper));
        }
        public IFaultService FaultService => _faultService.Value;
    }
}
