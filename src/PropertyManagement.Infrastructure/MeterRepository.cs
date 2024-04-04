using PropertyManagement.Application;
using PropertyManagement.Domain;

namespace PropertyManagement.Infrastructure
{
	public class MeterRepository : IMeterRepository
	{
		public static List<Meter> meters = new List<Meter>()
		{
		   new Meter{  Id = Guid.NewGuid() },
		   new Meter{  Id = Guid.NewGuid() },
		   new Meter{  Id = Guid.NewGuid() }
		};

		public List<Meter> GetAllMeters()
		{
			return meters;
		}
	}
}
