using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Application.Interfaces.Meters
{
    //This interface is used for Bussiness Rule / USE CASE
    public interface IMeterService
    {
        Task<List<Meter>> GetAllAsync();
    }
}
