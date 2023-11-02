using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiLibrary.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppApiLibraryDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppApiLibraryDBContext") ?? throw new InvalidOperationException("Connection string 'AppApiLibraryDBContext' not found.")));

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
});
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=books1}/{action=Index}/{id?}");
app.Run();
