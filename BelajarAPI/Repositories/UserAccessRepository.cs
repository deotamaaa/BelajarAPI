using BelajarAPI.Context;
using BelajarAPI.DTO;
using BelajarAPI.Helper;
using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;

namespace BelajarAPI.Repositories;

public class UserAccessRepository : IUserAccessRepository
{
	private readonly DataContexts _contexts;

	public UserAccessRepository(DataContexts contexts)
	{
		_contexts = contexts;
	}

	public int CreateUserAccess(UserAccess access)
	{
		try
		{
			var id = Guid.NewGuid();
			var encryptUsername = EncryptionHelper.Encrypt(access.Username, "123");
			var encryptPassword = EncryptionHelper.Encrypt(access.Password, "123");
			var userAccess = new UserAccess()
			{
				Id = id,
				UserId = access.UserId,
				Username = encryptUsername,
				Password = encryptPassword
			};
			_contexts.UserAccess?.Add(userAccess);
			var result = _contexts.SaveChanges();
			return result;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception();
		}
	}

	public string Login(LoginRequest login)
	{
		try
		{
			var result = _contexts.UserAccess?.FirstOrDefault(x =>
				x.Username.Equals(login.Username));
			if (result != null)
			{
				var password = EncryptionHelper.Decrypt(result.Password, "123");
				if (login.Password != password)
				{
					return "002";
				}
				return "003";
			}
			return "001";
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public string Logout()
	{
		throw new NotImplementedException();
	}
}