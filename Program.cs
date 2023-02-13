using LibraryManagementSystem_MileStone_1.DataContext;
using LibraryManagementSystem_MileStone_1.Interfaces;
using LibraryManagementSystem_MileStone_1.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add services to use the connection string for SQLSERVER
builder.Services.AddDbContext<LibraryDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add Service for Dependency Injection
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<IBooks, BookRepository>();
builder.Services.AddScoped<IBorrows, BorrowsRepository>();
builder.Services.AddScoped<IAuthors, AuthorsRepository>();



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
