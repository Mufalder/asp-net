using Microsoft.EntityFrameworkCore;
using REST_API.Models;

namespace REST_API.Data
{
	/// <summary>
	/// Context for the Users database
	/// </summary>
	public class UsersContext : DbContext
	{
		/// <summary>
		/// Users table
		/// </summary>
		public DbSet<User> Users { get; set; }
		/// <inheritdoc/>
		public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

	}
}
