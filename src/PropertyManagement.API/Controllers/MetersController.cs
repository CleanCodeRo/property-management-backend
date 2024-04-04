using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Application;

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
		public ActionResult<IList<Domain.Meter>> Get()
		{
			return Ok(_meterService.GetAllMeters());
		}
	}
}
