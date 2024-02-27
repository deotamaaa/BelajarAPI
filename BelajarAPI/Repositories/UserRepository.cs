using BelajarAPI.Context;
using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;

namespace BelajarAPI.Repositories;

public class UserRepository : IUserRepository
{
	private DataContexts _contexts;
	public UserRepository(DataContexts contexts)
	{
		_contexts = contexts;
	}
	
	public string CreateUser()
	{
		
		throw new NotImplementedException();
	}

	public List<Users?> GetUser()
	{
		try
		{
			var result = _contexts.Users?.ToList();
			return result;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public Users GetUserById()
	{
		throw new NotImplementedException();
	}

	public Users UpdateUser()
	{
		throw new NotImplementedException();
	}

	public string DeleteUser()
	{
		throw new NotImplementedException();
	}
}