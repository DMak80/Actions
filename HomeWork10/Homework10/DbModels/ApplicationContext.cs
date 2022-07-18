using Microsoft.EntityFrameworkCore;

namespace Homework10.DbModels;

public class ApplicationContext: DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
	}
}