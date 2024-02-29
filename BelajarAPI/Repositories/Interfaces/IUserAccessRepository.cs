using BelajarAPI.Models;

namespace BelajarAPI.Repositories.Interfaces;

public interface IUserAccessRepository
{
	public string CreateUser(Users users);

	public string ValidateUsername();
	
	public string ValidatePassword();	
}