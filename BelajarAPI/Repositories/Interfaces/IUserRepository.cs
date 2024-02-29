using BelajarAPI.Models;

namespace BelajarAPI.Repositories.Interfaces;

public interface IUserRepository
{
	public string CreateUser(Users user);
	
	public bool ValidateEmail(string email);
	
	public List<Users?> GetUser();
	
	public Users? GetUserById(Guid id);
	
	public bool UpdateUser(Users user);

	public bool DeleteUser(Guid id);
}