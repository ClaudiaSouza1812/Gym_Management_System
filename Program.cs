using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Services;
using Microsoft.EntityFrameworkCore;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Read the appsettings.json connection string name;
var connectionString = builder.Configuration.GetConnectionString("CA_RS11_P2-2_ClaudiaSouza_ConnectionString");

// Register the EF service;
builder.Services.AddDbContext<CA_RS11_P2_2_ClaudiaSouza_DBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddScoped<IPaymentService, PaymentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var cultureInfo = new CultureInfo("en-GB");
cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRequestLocalization();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();
