using Microsoft.EntityFrameworkCore;

namespace BelajarAPI.Context;

public class DataContexts : DbContext
{
	public DataContexts(DbContextOptions<DataContexts> options) : base(options)
	{
	}
	
	
	
}