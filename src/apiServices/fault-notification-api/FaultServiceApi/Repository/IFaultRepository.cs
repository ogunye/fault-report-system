using FaultServiceApi.Models.DataTransferObjects;

namespace FaultServiceApi.Repository
{
    public interface IFaultRepository
    {
        Task<IEnumerable<FaultReadDto>> GetAllAsync();
        Task<FaultReadDto> GetByIdAsync(Guid id);
        Task<FaultReadDto> CreateFault(FaultCreateDto createDto);
        Task UpdateFault(Guid Id, FaultUpdateDto updateDto);
        Task<bool> DeleteFault(Guid id);
    }
}
