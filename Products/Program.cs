using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Products.Configurations;
using Products.Data;
using Products.Data.Configuration;
using Products.Data.Models;
using Products.Interfaces;
using Products.Repositories;

var builder = WebApplication.CreateBuilder(args);


var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductsContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
    });
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ProductsContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>  
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}");

app.Run();
