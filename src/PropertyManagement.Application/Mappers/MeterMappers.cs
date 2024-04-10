using PropertyManagement.Application.DTOs.Meters;
using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Application.Mappers
{
	public static class MeterMappers
	{
		public static MeterDTO ToMeterDTO(this Meter meterModel)
		{
			return new MeterDTO
			{
				Id = meterModel.Id
			};
		}

		public static Meter ToMeterFromCreateDTO(this CreateMeterRequestDTO meterDTO)
		{
			return new Meter();
		}
	}
}
