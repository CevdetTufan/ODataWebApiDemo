using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataWebApiDemo.Context;
using ODataWebApiDemo.Models;

namespace ODataWebApiDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ODataDemoController (AppDbContext dbContext): ControllerBase
{
	[HttpGet("Categories")]
	[EnableQuery]
	public IQueryable<Category> GetCategories()
	{
		var categories = dbContext.Categories.AsQueryable();
		return categories;
	}
}
