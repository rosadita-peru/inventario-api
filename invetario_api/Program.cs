using invetario_api.database;
using invetario_api.Filters;
using invetario_api.Modules.categories;
using invetario_api.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ApiFilter>();
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<Database>(opt =>
{
    opt.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.InvalidModelStateResponseFactory = ctx =>
    {
        var errors = ctx.ModelState.Where(e => e.Value!.Errors.Count > 0).ToDictionary(
                e => e.Key,
                e => e.Value!.Errors.Select(x => x.ErrorMessage)
        );

        var res = ResponseApi<object>.ErrorModel(errors);

        return new BadRequestObjectResult(res);
    };
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
