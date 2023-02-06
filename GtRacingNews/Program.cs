using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.Services.Championship;
using GtRacingNews.Services.Comment;
using GtRacingNews.Services.Driver;
using GtRacingNews.Services.News;
using GtRacingNews.Services.Others;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.Services.Profile;
using GtRacingNews.Services.Race;
using GtRacingNews.Services.Team;
using GtRacingNews.Services.User;
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

builder.Services.AddScoped<IHasher, Hasher>();
builder.Services.AddScoped<IValidator, Validator>();
builder.Services.AddScoped<IGuard, Guard>();
builder.Services.AddScoped<ISqlSeeder, SqlSeeder>();
builder.Services.AddScoped<IDeleteService, DeleteService>();
builder.Services.AddScoped<ISqlRepository, SqlRepository>();

builder.Services.AddScoped<IChampionshipService, ChampionshipService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IRaceService, RaceService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IUserService, UserService>();

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