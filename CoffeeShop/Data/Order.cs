namespace CoffeeShop.Data
{
	public class Order
	{

		public int Id { get; set; }
		public Item Item { get; set; }
		public User User { get; set; }
		public string Date { get; set; }
		public int Quantity { get; set; }
		public OrderStatus Status { get; set; }

	}
}
