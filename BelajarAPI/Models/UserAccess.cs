using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarAPI.Models;

[Table("tb_user_access")]
public class UserAccess
{
	[Key, Column("UserAccessId")]
	public Guid Id { get; set; }
	
	[Required, Column("user_id")]
	public Guid UserId { get; set; }
	
	[Required, Column("username")]
	public string Username { get; set; }
	
	[Required, Column("password")]
	public string Password { get; set; }
	
}