using CoffeeShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{

	/// <summary>
	/// Controller for orders
	/// </summary>
	[Route("api/[controller]")]
	public class OrdersController : Controller
	{

		private readonly CoffeeShopContext _context;

		/// <inheritdoc/>
		public OrdersController(CoffeeShopContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get list of all orders that not cancelled or done
		/// </summary>
		/// <param name="filter">Use "all" to get all orders despite the status</param>
		/// <returns>List of all orders</returns>
		[HttpGet]
		[Route("{filter?}")]
		public async Task<ActionResult<IList<Order>>> Get(string filter)
		{
			try
			{
				IList<Order> result;
				if (!string.IsNullOrEmpty(filter) && filter.ToLower() == "all")
					result = await _context.Orders.Include(c => c.User).ThenInclude(v => v.Role).Include(x => x.Status).ToListAsync();
				else
					result = await _context.Orders.Include(c => c.User).ThenInclude(v => v.Role).Include(x => x.Status).Where(x => x.StatusId < OrderStatus.DoneOrder).ToListAsync();

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
		/// Get order with specific ID
		/// </summary>
		/// <param name="id">ID of the order</param>
		/// <returns>Order</returns>
		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<Order>> Get(int id)
		{
			try
			{
				Order result = await _context.Orders.Include(c => c.User).ThenInclude(v => v.Role).Include(x => x.Status).SingleAsync(x => x.Id == id);

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
		/// Add new order
		/// </summary>
		/// <param name="newOrder">New order data</param>
		/// <returns>Action result</returns>
		[HttpPost]
		public async Task<ActionResult> Post(OrderDTO newOrder)
		{
			try
			{
				newOrder.Date = DateTime.Now.ToShortDateString();
				Order order = Order.FromDTO(newOrder, OrderStatus.NewOrder);

				await _context.Orders.AddAsync(order);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		/// <summary>
		/// Change status of the order with specific ID
		/// </summary>
		/// <param name="id">Order ID for update</param>
		/// <param name="status">New status</param>
		/// <returns>Action result</returns>
		[HttpPut]
		[Route("{id:int}/{status:int}")]
		public async Task<ActionResult> ChangeStatus(int id, int status)
		{
			try
			{
				Order result = await _context.Orders.SingleAsync(x => x.Id == id);
				if (result == null)
				{
					return NotFound();
				}
				else
				{
					await _context.Orders.ExecuteUpdateAsync(setters => setters.SetProperty(x => x.StatusId, status));

					await _context.SaveChangesAsync();
					return Ok();
				}
			}
			catch
			{
				return BadRequest();
			}
		}

	}
}
