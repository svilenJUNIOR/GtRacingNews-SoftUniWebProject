using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
builder.Services.AddDbContext<SqlDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));
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
builder.Services.AddScoped<IHasher, Hasher>();
builder.Services.AddScoped<IEngine, Engine>();
builder.Services.AddScoped<IBindService, BindService>();
builder.Services.AddScoped<IAddService, AddService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IValidator, Validator>();
builder.Services.AddScoped<IDeleteService, DeleteService>();
builder.Services.AddScoped<IReturnAll, ReturnAll>();
builder.Services.AddScoped<ISqlSeeder, SqlSeeder>();
builder.Services.AddScoped<ISqlRepository, SqlRepository>();
builder.Services.AddScoped<IMongoRepository, MongoRepository>();
builder.Services.AddScoped<IMongoSeeder, MongoSeeder>();
builder.Services.AddScoped<IProfileService, ProfileService>();

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