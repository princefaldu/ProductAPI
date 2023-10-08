using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context with SQL Server provider
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(option => option.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:5174")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        }));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}");

app.Run();
