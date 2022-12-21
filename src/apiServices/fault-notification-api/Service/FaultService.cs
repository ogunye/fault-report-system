using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Service
{
    internal sealed class FaultService : IFaultService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FaultService(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task DeleteFaultAsync(Guid Id, bool trackChanges)
        {
            var fault = await _repository.Fault.GetFaultByIdAsync(Id, trackChanges);
            //if (fault is null)
            //    throw new FaultNotFoundException(Id);
            _repository.Fault.DeleteFault(fault);
            await _repository.SaveAsync();
        }

        public async Task<FaultForReadDto> FaultForCreationAsync(FaultForCreationDto fault)
        {
            var faultEntity = _mapper.Map<Fault>(fault);
            
            _repository.Fault.CreateFault(faultEntity);
            await _repository.SaveAsync();

            var faultToReturn = _mapper.Map<FaultForReadDto>(faultEntity);
            return faultToReturn;
        }

        public async Task<FaultForReadDto> GetFaultsByIdAsync(Guid Id, bool trackChanges)
        {
            var fault = await _repository.Fault.GetFaultByIdAsync(Id, trackChanges);
            //if (fault is null)
            //    throw new FaultNotFoundException(Id);
            var faultDto = _mapper.Map<FaultForReadDto>(fault);
            return faultDto;
        }

        public async Task<IEnumerable<FaultForReadDto>> GetFaultsForReadAsync(bool trackChanges)
        {
            var faults = await _repository.Fault.GetAllFaultAsync(trackChanges);

            var faultsDto = _mapper.Map<IEnumerable<FaultForReadDto>>(faults);

            return faultsDto;
        }

        public async Task UpdateFaultAsync(Guid Id, FaultForUpdateDto faultForUpdate, bool trackChanges)
        {
            var faultEntity = await _repository.Fault.GetFaultByIdAsync(Id, trackChanges);
            //if (fault is null)
            //    throw new FaultNotFoundException(Id);

            faultEntity.ConfirmFaultStatus = faultForUpdate.ConfirmFaultStatus;
            faultEntity.DateTimeConfirmStatus = DateTime.Now;

            _mapper.Map(faultForUpdate, faultEntity);
            await _repository.SaveAsync();
        }
    }
}
