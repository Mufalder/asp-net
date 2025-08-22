using System.ComponentModel.DataAnnotations;

namespace REST_API.Models
{

	/// <summary>
	/// DTO for User model
	/// </summary>
	public class UserDTO
	{
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

	}
}
