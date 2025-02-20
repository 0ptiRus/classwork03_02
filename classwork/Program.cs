using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using classwork.Data;
using classwork.Services;
using Microsoft.AspNetCore.Authorization;
using classwork.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<IAuthorizationHandler, IsGameOwnerHandler>();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(
    "IsAuthenticated",
    policybuilder => policybuilder.RequireAuthenticatedUser());

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(
    "CanManageGame",
    policybuilder => policybuilder.AddRequirements(new IsGameOwnerRequirement()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
