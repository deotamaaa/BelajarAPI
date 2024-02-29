using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;

namespace BelajarAPI.Repositories;

public class UserAccessRepository : IUserAccessRepository
{
	public string CreateUser(Users users)
	{
		try
		{


		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
		throw new NotImplementedException();
	}

	public string ValidateUsername()
	{
		throw new NotImplementedException();
	}

	public string ValidatePassword()
	{
		throw new NotImplementedException();
	}
}