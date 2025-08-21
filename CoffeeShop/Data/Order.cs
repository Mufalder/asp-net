namespace CoffeeShop.Data
{
	public class Order
	{

		public int Id { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public string Date { get; set; }
		public int StatusId { get; set; }
		public OrderStatus Status { get; set; }

		public static Order FromDTO(OrderDTO dto, int statusId)
		{
			Order order = new Order
			{
				UserId = dto.UserId,
				Date = dto.Date,
				StatusId = statusId
			};
			return order;
		}

	}
}
