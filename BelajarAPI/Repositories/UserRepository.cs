using BelajarAPI.Context;
using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;

namespace BelajarAPI.Repositories;

public class UserRepository : IUserRepository
{
	private readonly DataContexts _contexts;
	public UserRepository(DataContexts contexts)
	{
		_contexts = contexts;
	}


	public Users CreateUser(Users user)
	{
		try
		{
			Guid id = Guid.NewGuid();
			user.UsersId = id;
			_contexts.Users?.Add(user);
			_contexts.SaveChanges();
			return user;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public bool ValidateEmail(string email)
	{
		try
		{
			var validate = _contexts.Users?.AsQueryable().Where(x => x.Email == email).ToList();
			if (validate?.Count > 0)
			{
				return true;
			}
			return false;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public List<Users?> GetUser()
	{
		try
		{
			var result = _contexts.Users?.ToList();
			return result!;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public Users? GetUserById(Guid id)
	{
		try
		{
			return _contexts.Users?.Find(id);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public bool UpdateUser(Users users)
	{
		try
		{
			var user = _contexts.Users?.Find(users.UsersId);
			if (user != null)
			{
				user.FirstName = users.FirstName;
				user.LastName = users.LastName;
				user.Email = users.Email;
				
				_contexts.Update(user);
				_contexts.SaveChanges();
				return true;
			}
			return false;
			
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public bool DeleteUser(Guid id)
	{
		try
		{
			var user = _contexts.Users?.Find(id);
			_contexts.Users?.Remove(user!);
			_contexts.SaveChanges();
			return true;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}
}