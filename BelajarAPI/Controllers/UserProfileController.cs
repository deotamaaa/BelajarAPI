using System.Net;
using BelajarAPI.DTO;
using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BelajarAPI.Controllers;

[Route("api/user-profile")]
[ApiController]
public class UserProfileController : ControllerBase
{
	private readonly IUserAccessRepository _userAccessRepository;
	private readonly IUserRepository _userRepository;
	public UserProfileController(IUserAccessRepository userAccessRepository, IUserRepository userRepository)
	{
		_userAccessRepository = userAccessRepository;
		_userRepository = userRepository;
	}
	
	[HttpPost]
	[Route("register")]
	public ActionResult Register([FromBody] RegisterRequest request)
	{
		try
		{
			var validateEmail = _userRepository.ValidateEmail(request.Email);
			if (validateEmail)
			{
				return BadRequest(new ApiMessage<UserAccess>()
				{
					StatusCode = (int)HttpStatusCode.BadRequest,
					Status = "Bad Request",
					Message = "Email already exist!",
					Data = null
				});
			}
			var userData = _userRepository.CreateUser(new Users
			{
				Email = request.Email,
				FirstName = request.firstName,
				LastName = request.lastName,
			});
			var access = _userAccessRepository.CreateUserAccess(new UserAccess
			{
				UserId = userData.UsersId,
				Username = request.Username,
				Password = request.Password
			});
			return Ok(new ApiMessage<UserAccess>()
			{
				StatusCode = (int)HttpStatusCode.OK,
				Status = "Ok",
				Message = "User access Created Successfully!",
				Data = null
			});
			
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}	
	}
}