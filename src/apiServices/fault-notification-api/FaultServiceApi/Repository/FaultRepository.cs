using AutoMapper;
using FaultServiceApi.Data;
using FaultServiceApi.Models;
using FaultServiceApi.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace FaultServiceApi.Repository
{
    public class FaultRepository : IFaultRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public FaultRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FaultReadDto> CreateFault(FaultCreateDto createDto)
        {
            Fault fault = _mapper.Map<FaultCreateDto, Fault>(createDto);
            fault.DateCreated = DateTime.Now;
            fault.DateTimeReported = DateTime.Now;
            fault.ConfirmFaultStatus = "Reported";
             _context.Faults.Add(fault);
            await _context.SaveChangesAsync();
            return _mapper.Map<Fault, FaultReadDto>(fault);
        }

        public async Task<bool> DeleteFault(Guid id)
        {
            var getFault = await _context.Faults.FirstOrDefaultAsync(x => x.Id == id);
            if (getFault == null)   
                return false;

            _context.Faults.Remove(getFault);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<FaultReadDto>> GetAllAsync()
        {
            var faults = await _context.Faults.ToListAsync();
            var resultToDto = _mapper.Map<IEnumerable<FaultReadDto>>(faults);
            return resultToDto;
        }

        public async Task<FaultReadDto> GetByIdAsync(Guid id)
        {
            var fault = await _context.Faults.FirstOrDefaultAsync(x => x.Id == id);
            var resultToDto = _mapper.Map<FaultReadDto>(fault);
            return resultToDto;
        }

        public async Task UpdateFault(Guid Id,  FaultUpdateDto updateDto)
        {
            var faultEntity = await _context.Faults.FindAsync(Id);
            if (faultEntity == null)
                throw new Exception();

            faultEntity.ConfirmFaultStatus = updateDto.ConfirmFaultStatus;
            faultEntity.DateTimeConfirmStatus = updateDto.DateTimeConfirmStatus = DateTime.Now;
            _mapper.Map(updateDto, faultEntity);

            await _context.SaveChangesAsync();           
        }
    }
}
