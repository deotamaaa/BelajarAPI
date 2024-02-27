using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarAPI.Models;

[Table("tb_users")]
public class Users
{
	[Key, Column("id")]
	public Guid UsersId { get; set; }
	
	[Required, Column("first_name")]
	public String FirstName { get; set; }

	[Required, Column("last_name")]
	public String LastName { get; set; }
	
	[Required, Column("email")]
	public String Email { get; set; }
	
	[Required, Column("user_access")]
	public UserAccess UserAccess { get; set; }
}
