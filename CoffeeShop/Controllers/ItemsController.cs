using CoffeeShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{

	[Route("api/[controller]")]
	public class ItemsController : Controller
	{

		private readonly CoffeeShopContext _context;

		public ItemsController(CoffeeShopContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IList<Item>>> Get()
		{
			try
			{
				IList<Item> result = await _context.Items.ToListAsync();
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<Item>> Get(int id)
		{
			try
			{
				Item result = await _context.Items.FirstAsync(x => x.Id == id);
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult> Post(ItemDTO newItem)
		{
			Item item = new Item
			{
				Name = newItem.Name,
				Price = newItem.Price,
				ImgURL = newItem.ImgURL
			};

			try
			{
				await _context.Items.AddAsync(item);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut]
		public async Task<ActionResult> Put(ItemDTO item)
		{

		}
	}
}
