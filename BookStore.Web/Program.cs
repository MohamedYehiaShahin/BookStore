using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.Repositories.Implementations;
using BookStore.Repositories.Interfaces;
using BookStore.Utilities.Mapper;
using BookStore.ViewModels;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlServer());
//Register abstract Dependenies 
builder.Services.AddMvc();
builder.Services.AddScoped<IBookStoreRepository<AuthorViewModel,Author>, AuthorRepository>();
builder.Services.AddScoped<IBookStoreRepository<BookViewModel,Book>, BookRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
// Register AutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));


// Register Dbcontext
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqServerCon"));
//});

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
    pattern: "{controller=Author}/{action=Index}/{id?}");

app.Run();
