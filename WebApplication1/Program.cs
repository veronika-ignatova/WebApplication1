using Core.Entities;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Service;
using DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesConnection") ?? throw new InvalidOperationException("Connection string 'RazorPagesContext' not found.")));


builder.Services.Configure<AppConf>(builder.Configuration.GetSection("AppConf"));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IDayRepository, DayRepository>();
builder.Services.AddTransient<IDayService, DayService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IImageRepository, ImageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
