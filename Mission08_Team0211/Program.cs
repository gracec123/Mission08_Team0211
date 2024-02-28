using Microsoft.EntityFrameworkCore;
using Mission08_Team0211.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<TaskContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:TaskConnection"]);

});


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

app.MapControllerRoute(
    name: "default",
    pattern: "{action}/{id?}", 
    defaults: new { controller = "Home", action = "Index" }  // Set default controller and action
);

app.Run();
