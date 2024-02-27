using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BelajarAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController 
{
	private readonly IUserRepository _userRepository;
	public UsersController(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	[HttpGet]
	[Route("get-user")]
	public List<Users> GetUser()
	{
		try
		{
			var result = _userRepository.GetUser();
			return result;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
	
	
}