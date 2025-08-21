using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Data
{
	public class User
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public int RoleId { get; set; }
		public Role Role { get; set; }

		public static User FromDTO(UserDTO dto)
		{
			User user = new()
			{
				Name = dto.Name,
				RoleId = dto.RoleId
			};
			return user;
		}

	}
}
