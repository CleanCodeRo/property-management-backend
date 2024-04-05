using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Application.Interfaces.Meters
{
    public interface IMeterRepository
    {
        Task<Meter> CreateAsync();
        Task<List<Meter>> GetAllAsync();
        Task<Meter> UpdateAsync();
        Task<Meter> DeleteAsync();
    }
}
