using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Data
{
	public class CoffeeShopContext : DbContext
	{

		public DbSet<Item> Items { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<OrderItem> OrdersItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }

		public CoffeeShopContext(DbContextOptions options) : base(options) { }

	}
}
