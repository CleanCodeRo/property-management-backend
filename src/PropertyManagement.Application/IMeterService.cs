namespace PropertyManagement.Application
{
	//This interface is used for Bussiness Rule / USE CASE
	public interface IMeterService
	{
		List<Domain.Meter> GetAllMeters();
	}
}
