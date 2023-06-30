using Microsoft.EntityFrameworkCore;
using TeamManager.Application.Services;
using TeamManager.Application.Services.Contracts;
using TeamManager.DataAccess.EF;
using TeamManager.DataAccess.Repositories;
using TeamManager.DataAccess.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<TeamManagerDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("EldoradoTeamManager"),
        opts =>
        {
            // To check the version execute this query:
            // SELECT version();
            opts.SetPostgresVersion(new Version(15, 3));
        });
});


builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();



var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
