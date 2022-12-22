using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.Business.Concrete;
using RecycleCoin.Business.Validation.FluentValidation;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Repositories;
using RecycleCoin.Core.Services;
using RecycleCoin.Infrastructure;
using RecycleCoin.Infrastructure.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<RecycleCoinDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<Sale>, SaleValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();

builder.Services.AddAuthentication();


builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddTransient(typeof(ISaleService), typeof(SaleService));
builder.Services.AddTransient(typeof(IProductService), typeof(ProductService));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
