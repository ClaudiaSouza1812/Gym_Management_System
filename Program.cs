using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Read the appsettings.json connection string name;
var connectionString = builder.Configuration.GetConnectionString("CA_RS11_P2-2_ClaudiaSouza_ConnectionString");

// Register the EF service;
builder.Services.AddDbContext<CA_RS11_P2_2_ClaudiaSouza_DBContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "The field is required.");
});

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
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();
