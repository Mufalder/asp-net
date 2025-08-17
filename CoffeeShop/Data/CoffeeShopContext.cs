using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Data
{
	public class CoffeeShopContext : DbContext
	{

		public DbSet<Item> Items { get; set; }
		public DbSet<OrderStatus> OrderStatues { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }

		private string dbPath;

		public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options)
		{
			dbPath = Path.Join(Environment.CurrentDirectory, "coffeeshop.db");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Data Source={dbPath}");
		}

	}
}
