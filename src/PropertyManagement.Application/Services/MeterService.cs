using PropertyManagement.Application.Interfaces.Meters;
using PropertyManagement.Domain.Entities;

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

        public Task<List<Meter>> GetAllAsync()
        {
            return _meterRepository.GetAllAsync();
        }
    }
}
