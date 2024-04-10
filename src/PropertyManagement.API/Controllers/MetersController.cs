using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Application.DTOs.Meters;
using PropertyManagement.Application.Interfaces.Meters;

namespace PropertyManagement.API.Controllers
{
    [Route("api/meters")]
	public class MetersController : ApiControllerBase
	{
		private readonly IMeterService _meterService;

		public MetersController(IMeterService meterService)
		{
			_meterService = meterService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateMeterRequestDTO meterDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var meterModelDTO = await _meterService.CreateAsync(meterDTO);

			return CreatedAtAction(nameof(GetById), new { id = meterModelDTO.Id }, meterModelDTO);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetAll()
		{
			var meters = await _meterService.GetAllAsync();
			return Ok(meters);
		}


		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingMeter = await _meterService.GetByIdAsync(id);

			if (existingMeter == null)
			{
				return NotFound("The meter does not exist.");
			}

			return Ok(existingMeter);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingMeter = await _meterService.DeleteAsync(id);

			if (existingMeter == null)
			{
				return NotFound("The meter does not exist.");
			}

			return NoContent();
		}
	}
}
