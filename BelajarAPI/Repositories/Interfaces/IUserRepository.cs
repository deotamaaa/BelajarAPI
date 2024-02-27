using BelajarAPI.Models;

namespace BelajarAPI.Repositories.Interfaces;

public interface IUserRepository
{
	public string CreateUser();
	
	public List<Users?> GetUser();
	
	public Users GetUserById();
	
	public Users UpdateUser();

	public string DeleteUser();
}