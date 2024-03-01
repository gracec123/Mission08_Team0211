using Microsoft.EntityFrameworkCore;
using Mission08_Team0211.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext for TaskContext
builder.Services.AddDbContext<TaskContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:TaskConnection"]);

});

// Add scoped service for ITaskRepo with EFTaskRepo implementation
builder.Services.AddScoped<ITaskRepo, EFTaskRepo>();

var app = builder.Build();

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


// Map default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{action}/{id?}", 
    defaults: new { controller = "Home", action = "Index" }  // Set default controller and action
);

app.Run();
