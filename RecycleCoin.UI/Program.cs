

using Microsoft.EntityFrameworkCore;
using RecycleCoin.Core;
using RecycleCoin.Infrastructure;
using RecycleCoin.Infrastructure.Concrete;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
