
using Shared.DataTransferObject;
namespace Service.Contracts
{
    public interface IFaultService
    {
        Task<IEnumerable<FaultForReadDto>> GetFaultsForReadAsync(bool trackChanges);
        Task<FaultForReadDto> GetFaultsByIdAsync(Guid Id, bool trackChanges);
        Task<FaultForReadDto> FaultForCreationAsync(FaultForCreationDto fault);
        Task DeleteFaultAsync(Guid Id, bool trackChanges);
        Task UpdateFaultAsync(Guid Id, FaultForUpdateDto faultForUpdate, bool trackChanges);
    }
}
