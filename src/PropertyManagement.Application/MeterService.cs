using PropertyManagement.Domain;

namespace PropertyManagement.Application
{
	//Implement Bussiness Rule / USE CASES
	public class MeterService : IMeterService
	{
		private readonly IMeterRepository _meterRepository;

		public MeterService(IMeterRepository meterRepository)
		{
			_meterRepository = meterRepository;
		}

		public List<Meter> GetAllMeters()
		{
			return _meterRepository.GetAllMeters();
		}
	}
}
