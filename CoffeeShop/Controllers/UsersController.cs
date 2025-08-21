using CoffeeShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{

	/// <summary>
	/// Controller for the users
	/// </summary>
	[Route("api/[controller]")]
	public class UsersController : Controller
	{

		private readonly CoffeeShopContext _context;

		/// <inheritdoc/>
		public UsersController(CoffeeShopContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get list of all users
		/// </summary>
		/// <returns>List of all users</returns>
		[HttpGet]
		public async Task<ActionResult<IList<User>>> Get()
		{
			try
			{
				IList<User> result = await _context.Users.Include(c => c.Role).ToListAsync();

				if (result.Count == 0)
				{
					return NoContent();
				}

				return Ok(result);
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Get user with specific ID
		/// </summary>
		/// <param name="id">ID of the user</param>
		/// <returns>Item</returns>
		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<User>> Get(int id)
		{
			try
			{
				User result = await _context.Users.Include(c => c.Role).SingleAsync(x => x.Id == id);

				if (result == null)
				{
					return NotFound();
				}

				return Ok(result);
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Add new user
		/// </summary>
		/// <param name="newUser">New user data</param>
		/// <returns>Action result</returns>
		[HttpPost]
		public async Task<ActionResult> Post(UserDTO newUser)
		{
			User user = Data.User.FromDTO(newUser);

			try
			{
				await _context.Users.AddAsync(user);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		/// <summary>
		/// Update user or add new user if user with ID doesnt exists
		/// </summary>
		/// <param name="user">User data</param>
		/// <param name="id">User ID for update</param>
		/// <returns>Action result</returns>
		[HttpPut]
		[Route("{id:int}")]
		public async Task<ActionResult> Put(UserDTO user, int id)
		{
			try
			{
				User result = await _context.Users.SingleAsync(x => x.Id == id);
				if (result == null)
				{
					User newUser = Data.User.FromDTO(user);

					await _context.Users.AddAsync(newUser);
					await _context.SaveChangesAsync();
					return Created();
				}
				else
				{
					result.Name = user.Name;
					result.RoleId = user.RoleId;

					await _context.SaveChangesAsync();
					return Ok();
				}
			}
			catch
			{
				return BadRequest();
			}
		}

		/// <summary>
		/// Delete user with specific ID
		/// </summary>
		/// <param name="id">User ID</param>
		/// <returns>Action result</returns>
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				User result = await _context.Users.SingleAsync(x => x.Id == id);
				if (result == null)
				{
					return NotFound();
				}
				else
				{
					_context.Users.Remove(result);
					await _context.SaveChangesAsync();
					return NoContent();
				}
			}
			catch
			{
				return BadRequest();
			}
		}

	}
}
