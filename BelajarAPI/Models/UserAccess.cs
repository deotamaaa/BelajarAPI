using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarAPI.Models;

[Table("tb_user_access")]
public class UserAccess
{
	[Key, Column("UserAccessId")]
	public Guid Id { get; set; }
	
	[Required, Column("user_id")]
	public String UserId { get; set; }
	
	[Required, Column("username")]
	public String Username { get; set; }
	
	[Required, Column("password")]
	public String Password { get; set; }
	
}