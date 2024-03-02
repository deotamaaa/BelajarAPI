using System.Text.Json.Serialization;

namespace BelajarAPI.DTO;

public class RegisterRequest
{
	[JsonPropertyName("firstName")]
	public string firstName { get; set; }
	
	[JsonPropertyName("lastName")] 
	public string lastName { get; set; }

	[JsonPropertyName("email")]
	public string Email { get; set; }
	
	[JsonPropertyName("username")] 
	public string Username { get; set; }

	[JsonPropertyName("password")]
	public string Password { get; set; }
}