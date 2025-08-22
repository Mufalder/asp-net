using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Models;

namespace REST_API.DAL
{
	public class UsersRepository : IUsersRepository
	{

		private bool disposed;
		private UsersContext context;

		public UsersRepository(UsersContext context)
		{
			this.context = context;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed && disposing)
				context.Dispose();

			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			return await context.Users.ToListAsync();
		}

		public async Task<User> GetUserByID(int id)
		{
			return await context.Users.SingleAsync(x => x.Id == id);
		}

		public async Task<User> InsertUser(UserDTO user)
		{
			User result = (await context.Users.AddAsync(User.FromDTO(user))).Entity;
			await context.SaveChangesAsync();
			return result;
		}

		public async Task UpdateUser(int id, UserDTO user)
		{
			await context.Users.Where(x => x.Id == id).ExecuteUpdateAsync(s => s.SetProperty(u => u.FirstName, user.FirstName).SetProperty(u => u.LastName, user.LastName).SetProperty(u => u.Age, user.Age));
			await context.SaveChangesAsync();
		}

		public async Task DeleteUser(int id)
		{
			await context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
			await context.SaveChangesAsync();
		}
	}
}
