using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GTNewsDbContext>(options =>
    options.UseSqlServer("Server=.;Database=GTNews;Integrated Security=true;"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GTNewsDbContext>();
builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        
    });

builder.Services.AddScoped<IChampionshipService, ChampionshipService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IGuard, Guard>();
builder.Services.AddScoped<IHasher, Hasher>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IRaceService, RaceService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IValidator, Validator>();

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