using Microsoft.EntityFrameworkCore;
using RecycleCoin.Business.Concrete;
using RecycleCoin.Core.Repositories;
using RecycleCoin.Core.Services;
using RecycleCoin.Infrastructure;
using RecycleCoin.Infrastructure.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<RecycleCoinDbContext>(options =>
options.UseSqlServer("name=ConnectionStrings:DbConnection"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddTransient(typeof(ISaleService), typeof(SaleService));

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

app.MapControllers();

app.Run();
