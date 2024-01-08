using CycleParking.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICycleParking, CycleParkingService>(); 
builder.Services.AddTransient<IDbService, DbService>();
var app = builder.Build();
var appDataPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data");

// Set DataDirectory dynamically
AppDomain.CurrentDomain.SetData("DataDirectory", appDataPath);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
