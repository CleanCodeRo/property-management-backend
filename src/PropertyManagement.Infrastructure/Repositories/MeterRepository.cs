using Microsoft.EntityFrameworkCore;
using PropertyManagement.Application.Interfaces;
using PropertyManagement.Domain.Entities;
using PropertyManagement.Infrastructure.Data;

namespace PropertyManagement.Infrastructure.Repositories
{
    public class MeterRepository : IMeterRepository
    {
		private readonly ApplicationDbContext _context;

		public MeterRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public Task<Meter> CreateAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Meter> DeleteAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<Meter>> GetAllAsync()
		{
			return _context.Meters.ToListAsync();
		}

		public Task<Meter> UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
