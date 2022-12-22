using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;

namespace DataManager.Controllers
{
    [Route("api/faults")]
    [ApiController]
    public class FaultsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public FaultsController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetFaults()
        {
            var faults = await _service.FaultService.GetFaultsForReadAsync(trackChanges: false);
            
            return Ok(faults);
        }

        [HttpGet("{id:Guid}", Name = "FaultByID")]
        public async Task<IActionResult> GetFault(Guid id)
        {
            var fault = await _service.FaultService.GetFaultsByIdAsync(id, trackChanges: false);
            return Ok(fault);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFault([FromBody] FaultForCreationDto faultForCreation)
        {
            if (faultForCreation is null)
                return BadRequest("FaultForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdEntity = await _service.FaultService.FaultForCreationAsync(faultForCreation);

            return CreatedAtRoute("FaultByID", new {id=createdEntity.Id}, createdEntity);
        }
    }
}
