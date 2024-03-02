using BelajarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BelajarAPI.Context;

public class DataContexts : DbContext
{
	public DataContexts(DbContextOptions<DataContexts> options) : base(options)
	{
	}

	public DbSet<Issue>? Issues { get; set; }
	public DbSet<Users>? Users { get; set; }
	public DbSet<UserAccess>? UserAccess { get; set; }
	
}