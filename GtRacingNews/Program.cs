using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

ConnectionString ConnectionString = new ConnectionString();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SqlDBContext>(options =>
    options.UseSqlServer(ConnectionString.SqlConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SqlDBContext>();
builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        
    });

////////////////// MONGO MONGO MONGO //////////////////
builder.Services.Configure<MongoSetUp>(
    builder.Configuration.GetSection("MongoSettings"));
////////////////// MONGO MONGO MONGO //////////////////


builder.Services.AddScoped<MongoDbContext, MongoDbContext>();
//builder.Services.AddScoped<IHasher, Hasher>();
//builder.Services.AddScoped<IEngine, Engine>();
////builder.Services.AddScoped<IBindService, BindService>();
////builder.Services.AddScoped<IAddService, AddService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IValidator, Validator>();
builder.Services.AddScoped<ISeederService, Seeder>();
//builder.Services.AddScoped<IDeleteService, DeleteService>();
////builder.Services.AddScoped<IReturnAll, ReturnAll>();
builder.Services.AddScoped<ISqlRepoisitory, SqlRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();