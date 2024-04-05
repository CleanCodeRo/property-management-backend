using PropertyManagement.Application.DTOs.Meters;
using PropertyManagement.Application.Interfaces.Meters;
using PropertyManagement.Application.Mappers;

namespace PropertyManagement.Application.Services
{
    //Implement Bussiness Rule / USE CASES
    public class MeterService : IMeterService
    {
        private readonly IMeterRepository _meterRepository;

        public MeterService(IMeterRepository meterRepository)
        {
            _meterRepository = meterRepository;
        }

        public async Task<List<MeterDTO>> GetAllAsync()
        {
            var meters = await _meterRepository.GetAllAsync();
            var metersToDTO = meters.Select(m => m.ToMeterDTO()).ToList();
			return metersToDTO;
        }
    }
}
