using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarAuthShop.Areas.Identity;
using CarAuthShop.Data;
using MudBlazor.Services;
using CarAuthShop.Services.Infrastructure;
using CarAuthShop.Services;
using CarAuthShop.Data.DatabaseObjects;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
});


//Service registration
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IRoleManagerService, RoleManagerService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<ISelectedCarService, SelectedCarService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<UserDo>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<UserDo>>();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();

builder.Services.Configure<IdentityOptions>(options =>
{
    //Password settings
    options.Password.RequireNonAlphanumeric = false;

    //Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

