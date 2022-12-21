using FaultServiceApi.Models.DataTransferObjects;
using FaultServiceApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaultServiceApi.Controllers
{
    [Route("api/faults")]
    [ApiController]
    public class FaultController : ControllerBase
    {
        private readonly IFaultRepository _repository;

        public FaultController(IFaultRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaultReadDto>>> GetFaults()
        {
            var results = await _repository.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id:guid}", Name ="FaultById")]
        public async Task<IActionResult> GetFault(Guid id)
        {
            var fault = await _repository.GetByIdAsync(id);
            if(fault == null)
                return NotFound();
            return Ok(fault);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFault([FromBody] FaultCreateDto createDto)
        {
            if (createDto is null)
                return BadRequest("FaultCreate Object is null");

            var model = await _repository.CreateFault(createDto);

            return CreatedAtRoute("FaultById", new {id = model.Id}, model);
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateFault(Guid Id, FaultUpdateDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("updateDto object is null");
            
            await _repository.UpdateFault(Id, updateDto);

            return NoContent();
        }
        

        [HttpDelete]
        public async Task<IActionResult> DeleteFault(Guid id)
        {            
            bool isSuccess = await _repository.DeleteFault(id);
            return NoContent();
        }
    }
}
