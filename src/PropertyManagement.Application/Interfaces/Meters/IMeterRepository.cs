using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Application.Interfaces.Meters
{
    public interface IMeterRepository
    {
        Task<Meter> CreateAsync(Meter meterModel);
        Task<List<Meter>> GetAllAsync();
        Task<Meter?> GetByIdAsync(Guid id);
        Task<Meter> UpdateAsync();
        Task<Meter> DeleteAsync();
    }
}
