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

		public async Task<MeterDTO> CreateAsync(CreateMeterRequestDTO meterDTO)
		{
			var meterModel = meterDTO.ToMeterFromCreateDTO();

			await _meterRepository.CreateAsync(meterModel);

			return meterModel.ToMeterDTO();
		}

		public async Task<List<MeterDTO>> GetAllAsync()
        {
            var meters = await _meterRepository.GetAllAsync();
            var metersToDTO = meters.Select(m => m.ToMeterDTO()).ToList();
			return metersToDTO;
        }

		public async Task<MeterDTO?> GetByIdAsync(Guid id)
		{
			var existingMeter = await _meterRepository.GetByIdAsync(id);
			return existingMeter != null ? existingMeter.ToMeterDTO() : null;
		}

		public Task<MeterDTO> UpdateAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<MeterDTO?> DeleteAsync(Guid id)
		{
			var existingMeter = await _meterRepository.DeleteAsync(id);
			return existingMeter != null ? existingMeter.ToMeterDTO() : null;
		}
	}
}
