using System.Net;
using BelajarAPI.DTO;
using BelajarAPI.Helper;
using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BelajarAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IUserRepository _userRepository;

	public UsersController(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	[HttpPost]
	[Route("create-user")]
	public string CreateUser([FromBody] Users user)
	{
		try
		{
			var validateEmail = _userRepository.ValidateEmail(user.Email);
			if (!validateEmail)
			{
				var result = _userRepository.CreateUser(user);
				return "Success";
			}

			return "Failed";
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	[Authorize]
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

	[HttpPost]
	[Route("get-user-by-id")]
	public ActionResult GetUserById([FromBody] Guid id)
	{
		try
		{
			
			var data = _userRepository.GetUserById(id);
			if (data == null)
			{
				return NotFound(new ApiMessage<Users>
				{
					StatusCode = (int)HttpStatusCode.NotFound,
					Status = "Not Found",
					Message = "User not found!",
					Data = null
				});
			}
			else
			{
				return Ok(new ApiMessage<Users>
				{
					StatusCode = (int)HttpStatusCode.OK,
					Status = "Ok",
					Message = "User has been found!",
					Data = data
				});
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	[HttpPatch]
	[Route("update-user")]
	public ActionResult UpdateUser([FromBody] Users user)
	{
		try
		{
			var data = _userRepository.UpdateUser(user);
			if (data)
			{
				return Ok(new ApiMessage<Users>
				{
					StatusCode = (int)HttpStatusCode.OK,
					Status = "Ok",
					Message = "User has been updated!",
					Data = user
				});
			}
			else
			{
				return NotFound(new ApiMessage<Users>
				{
					StatusCode = (int)HttpStatusCode.NotFound,
					Status = "Not Found",
					Message = "User not found!",
					Data = null
				});
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	[HttpDelete]
	[Route("delete-user/{id}")]
	public ActionResult DeleteUser(Guid id)
	{
		try
		{
			var data = _userRepository.DeleteUser(id);
			if (data)
			{
				return Ok(new ApiMessage<Users>
				{
					StatusCode = (int)HttpStatusCode.OK,
					Status = "Ok",
					Message = "User has been deleted!",
					Data = null
				});
			}

			return NotFound(new ApiMessage<Users>
			{
				StatusCode = (int)HttpStatusCode.NotFound,
				Status = "Not Found",
				Message = "User not found!",
				Data = null
			});
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
	
}