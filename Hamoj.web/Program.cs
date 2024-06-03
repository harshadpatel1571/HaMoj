using Hamoj.DB.Context;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<HamojDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection")));

// Service Registration
builder.Services.AddScoped<ICatagoryService, CatagoryService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDropDownBindService, DropDownBindService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Index"; // Set the login path
        options.LogoutPath = "/Account/Logout";
        options.Cookie.Name = "HaaMoj";
    });

// Add session services
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".HaaMoj.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add response compression services
builder.Services.AddResponseCompression();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseStaticFiles();

app.UseRouting();

// Add session middleware
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// Enable response compression middleware
app.UseResponseCompression();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
