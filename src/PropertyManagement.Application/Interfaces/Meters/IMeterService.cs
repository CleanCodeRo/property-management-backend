using PropertyManagement.Application.DTOs.Meters;

namespace PropertyManagement.Application.Interfaces.Meters
{
    //This interface is used for Bussiness Rule / USE CASE
    public interface IMeterService
    {
        Task<MeterDTO> CreateAsync(CreateMeterRequestDTO meterDTO);
        Task<List<MeterDTO>> GetAllAsync();
        Task<MeterDTO> GetByIdAsync(Guid id);
        Task<MeterDTO> UpdateAsync();
        Task<MeterDTO> DeleteAsync();
	}
}
