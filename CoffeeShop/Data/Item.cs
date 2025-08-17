namespace CoffeeShop.Data
{
	public class Item
	{
		
		public int Id { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public string? ImgURL { get; set; }
		public bool MarkDel { get; set; }

	}

}