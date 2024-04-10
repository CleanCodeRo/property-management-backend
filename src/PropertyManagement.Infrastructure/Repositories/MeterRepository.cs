﻿using Microsoft.EntityFrameworkCore;
using PropertyManagement.Application.Interfaces.Meters;
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

		public async Task<Meter> CreateAsync(Meter meterModel)
		{
			await _context.Meters.AddAsync(meterModel);
			await _context.SaveChangesAsync();
			return meterModel;
		}

		public async Task<List<Meter>> GetAllAsync()
		{
			return await _context.Meters.ToListAsync();
		}

		public async Task<Meter?> GetByIdAsync(Guid id)
		{
			return await _context.Meters
					.FirstOrDefaultAsync(meter => meter.Id == id);
		}

		public Task<Meter> UpdateAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<Meter?> DeleteAsync(Guid id)
		{
			var existingMeter = await _context.Meters
					.FirstOrDefaultAsync(meter => meter.Id == id);

			if (existingMeter == null)
			{
				return null;
			}

			_context.Meters.Remove(existingMeter);
			await _context.SaveChangesAsync();

			return existingMeter;
		}
	}
}
