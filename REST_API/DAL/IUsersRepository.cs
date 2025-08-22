using REST_API.Models;

namespace REST_API.DAL
{
	/// <summary>
	/// Repository interface for Users
	/// </summary>
	public interface IUsersRepository : IDisposable
	{
		/// <summary>
		/// Get all users
		/// </summary>
		public Task<IEnumerable<User>> GetUsers();
		/// <summary>
		/// Get user by ID
		/// </summary>
		public Task<User> GetUserByID(int id);
		/// <summary>
		/// Insert new user
		/// </summary>
		public Task<User> InsertUser(UserDTO user);
		/// <summary>
		/// Update user with ID
		/// </summary>
		public Task UpdateUser(int id, UserDTO user);
		/// <summary>
		/// Delete user by ID
		/// </summary>
		/// <param name="id"></param>
		public Task DeleteUser(int id);

	}
}
