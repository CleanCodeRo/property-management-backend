using PropertyManagement.Application.DTOs.Meters;

namespace PropertyManagement.Application.Interfaces.Meters
{
    //This interface is used for Bussiness Rule / USE CASE
    public interface IMeterService
    {
        Task<List<MeterDTO>> GetAllAsync();
    }
}
