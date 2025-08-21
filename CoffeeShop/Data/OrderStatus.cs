namespace CoffeeShop.Data
{
	public class OrderStatus
	{

		public int Id { get; set; }
		public required string Name { get; set; }

		public const int NewOrder = 1;
		public const int WorkingOrder = 2;
		public const int DoneOrder = 3;
		public const int CancelledOrder = 4;

	}
}
