using System.ComponentModel.DataAnnotations;

namespace REST_API.Models
{

	/// <summary>
	/// User data model
	/// </summary>
	public class User
	{
		/// <summary>
		/// Id of the user
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// First name of the user
		/// </summary>
		[StringLength(100, MinimumLength = 2)]
		public string? FirstName { get; set; }
		/// <summary>
		/// Last name of the user
		/// </summary>
		[StringLength(100, MinimumLength = 2)]
		public string? LastName { get; set; }
		/// <summary>
		/// Age of the user
		/// </summary>
		[Range(0, 200)]
		public required int Age { get; set; }

		/// <summary>
		/// Create new user from the DTO
		/// </summary>
		/// <param name="dto">Source DTO</param>
		/// <returns>User created from the DTO</returns>
		public static User FromDTO(UserDTO dto)
		{
			return new() { FirstName = dto.FirstName, LastName = dto.LastName, Age = dto.Age, };
		}

	}
}
