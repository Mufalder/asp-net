namespace CoffeeShop.Data
{
	public class Item
	{
		
		public int Id { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public string? ImgURL { get; set; }

		public static Item FromDTO(ItemDTO dto)
		{
			return new Item
			{
				Name = dto.Name,
				Price = dto.Price,
				ImgURL = dto.ImgURL
			};
		}

	}

}