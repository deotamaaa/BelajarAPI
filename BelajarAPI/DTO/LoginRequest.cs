using System.Text.Json.Serialization;

namespace BelajarAPI.DTO;

public class LoginRequest
{
	[JsonPropertyName("username")]
	public string Username { get; set; }

	[JsonPropertyName("password")]
	public string Password { get; set; }
}