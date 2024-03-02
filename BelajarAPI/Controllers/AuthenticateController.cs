using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using BelajarAPI.DTO;
using BelajarAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BelajarAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticateController : ControllerBase
{
	private readonly IConfiguration _config;
	private readonly IUserAccessRepository _userAccessRepository;

	public AuthenticateController(IConfiguration config, IUserAccessRepository userAccessRepository)
	{
		_userAccessRepository = userAccessRepository;
		_config = config;
	}

	[HttpPost]
	[Route("login")]
	public ActionResult Login(LoginRequest loginRequest)
	{
		try
		{
			var data = _userAccessRepository.Login(new LoginRequest
			{
				Username = loginRequest.Username,
				Password = loginRequest.Password
			});
			switch (data)
			{
				case "001":
					return BadRequest(new ApiMessage<string>
					{
						StatusCode = (int)HttpStatusCode.BadRequest,
						Status = "Bad Request",
						Message = "Username not found!",
						Data = null
					});
				case "002":
					return BadRequest(new ApiMessage<string>
					{
						StatusCode = (int)HttpStatusCode.BadRequest,
						Status = "Bad Request",
						Message = "Password not valid!",
						Data = null
					});
				default:
					var securityKeys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
					var credentials = new SigningCredentials(securityKeys, SecurityAlgorithms.HmacSha256);
					var secureToken = new JwtSecurityToken(
						_config["JWT:Issuer"],
						null,
						null,
						expires: DateTime.Now.AddMinutes(120),
						signingCredentials: credentials
					);
					var token = new JwtSecurityTokenHandler().WriteToken(secureToken);
					return Ok(new ApiMessage<string>
					{
						StatusCode = (int)HttpStatusCode.OK,
						Status = "Ok",
						Message = "Login Success!",
						Data = token
					});
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
}