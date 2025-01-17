using ODataWebApiDemo.Context;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Bogus;
using ODataWebApiDemo.Models;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("ODataWebApiDemoContext"));
});

builder.Services
	.AddControllers()
	.AddOData(opt=>opt.EnableQueryFeatures());

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference();

app.MapGet("seed-data/categories", async (AppDbContext dbContext) =>
{
	Faker faker = new();
	var categories = faker.Commerce.Categories(100)
				.Select(s => new Category
				{
					Name = s
				}).ToList();

	dbContext.AddRange(categories);
	await dbContext.SaveChangesAsync();
	return Results.NoContent();
}).Produces(204).WithTags("SeedCategories");

app.MapControllers();

app.Run();
