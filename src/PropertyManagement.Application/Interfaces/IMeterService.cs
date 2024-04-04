using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Application.Interfaces
{
    //This interface is used for Bussiness Rule / USE CASE
    public interface IMeterService
    {
		Task<List<Meter>> GetAllAsync();
    }
}
