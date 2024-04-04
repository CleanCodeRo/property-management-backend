using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Application.Interfaces;

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

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var meters = await _meterService.GetAllAsync();
			return Ok(meters);
		}
	}
}
