using BelajarAPI.DTO;
using BelajarAPI.Models;

namespace BelajarAPI.Repositories.Interfaces;

public interface IUserAccessRepository
{
	public int CreateUserAccess(UserAccess access);

	public string Login(LoginRequest login);

	public string Logout();
}