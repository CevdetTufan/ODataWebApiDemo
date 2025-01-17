using Microsoft.EntityFrameworkCore;
using ODataWebApiDemo.Models;

namespace ODataWebApiDemo.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options):base(options)
	{

	}

	public DbSet<Category> Categories { get; set; } = default!;
}
