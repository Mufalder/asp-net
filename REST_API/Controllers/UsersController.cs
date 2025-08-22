using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using REST_API.DAL;
using REST_API.Data;
using REST_API.Models;
using System.Collections;

namespace REST_API.Controllers
{

	/// <summary>
	/// Controller for the users
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : Controller
	{

		private readonly IUsersRepository usersRepository;

		/// <inheritdoc/>
		public UsersController(IUsersRepository usersRepository)
		{
			this.usersRepository = usersRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> Get()
		{
			try
			{
				IEnumerable<User> users = await usersRepository.GetUsers();

				if (users.Count() == 0)
				{
					return NoContent();
				}

				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
			}
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<User>> Get(int id)
		{
			try
			{
				User user = await usersRepository.GetUserByID(id);

				if (user == null)
					return NotFound();

				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult<User>> Post(UserDTO dto)
		{
			try
			{
				if (dto == null)
					return BadRequest();

				User user = await usersRepository.InsertUser(dto);

				return CreatedAtAction(nameof(User), user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
			}
		}

		[HttpPut]
		[Route("{id:int}")]
		public async Task<ActionResult<User>> Put(int id, UserDTO dto)
		{
			try
			{
				User user = await usersRepository.GetUserByID(id);

				if (user == null)
					return NotFound($"User with ID - {id} not found!");

				await usersRepository.UpdateUser(id, dto);
				user = await usersRepository.GetUserByID(id);
				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
			}
		}

		/// <summary>
		/// Delete the user with ID
		/// </summary>
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				User user = await usersRepository.GetUserByID(id);

				if (user == null)
					return NotFound($"User with ID - {id} not found!");

				await usersRepository.DeleteUser(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
			}
		}
	}
}
