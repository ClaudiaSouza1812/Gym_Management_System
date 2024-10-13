// Import necessary namespaces
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL; // Data Access Layer
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Services; // Service layer implementations
using Microsoft.EntityFrameworkCore; // Entity Framework Core for database operations
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices; // Entity Framework Core for database operations
using Microsoft.Extensions.DependencyInjection; // For dependency injection
using Microsoft.AspNetCore.Localization; // For handling localization
using System.Globalization; // For culture-specific data formatting

// Create a new webapplication builder
// This is the starting point for configuring the application
var builder = WebApplication.CreateBuilder(args);

// Read the appsettings.json connection string name;
// This string contains the database connection details
var connectionString = builder.Configuration.GetConnectionString("CA_RS11_P2-2_ClaudiaSouza_ConnectionString");

// Register the EF service.DbContext with the dependency injection container
// This allows the application to interact with the database
builder.Services.AddDbContext<CA_RS11_P2_2_ClaudiaSouza_DBContext>(options => options.UseSqlServer(connectionString));

// Register the ClientService, ContractService and PaymentService as a scoped service
// Scoped services are created once per client request
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddScoped<IPaymentService, PaymentService>();

// Add MVC services to the dependency injection container
// This enables the use of controllers and views in the application
builder.Services.AddControllersWithViews();

// Set up culture info for localization
// This defines how dates, numbers, and other culture-specific data should be formatted
var cultureInfo = new CultureInfo("en-GB");
cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

// Set the default culture for the application
// This ensures consistent formatting throughout the application
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Build the WebApplication
// This creates the application instance with all the configured services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Use custom error page in non-development environments
    // This provides a user-friendly error page for production use
    app.UseExceptionHandler("/Home/Error");
}

// Enable serving of static files (e.g., CSS, JavaScript, images)
// This allows the application to serve files from the wwwroot folder
app.UseStaticFiles();

// Enable serving of static files (e.g., CSS, JavaScript, images)
// This allows the application to serve files from the wwwroot folder
app.UseRequestLocalization();

// Enable routing
// This sets up URL routing for the application
app.UseRouting();

// Enable authorization
// This allows the application to use authorization policies
app.UseAuthorization();

// Configure the default route for the application
// This defines how URLs map to controllers and actions
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

// Start the application
// This runs the configured web application
app.Run();
