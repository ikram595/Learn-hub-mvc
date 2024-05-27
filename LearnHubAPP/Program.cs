using LearnHubAPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LearnHubDbContext>(
options => options.UseSqlServer(
builder.Configuration.GetConnectionString("LearnHubConnection")
));
//add Identity service
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() //add roles
    .AddEntityFrameworkStores<LearnHubDbContext>();
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
//////
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//identity routing
app.MapRazorPages();
//add roles 
using (var scope = app.Services.CreateScope())
{
    var roleManager =
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Formateur", "Apprenant" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }



    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    //compte admin
    string email = "admin2@admin.com";
    string password = "Admin@admin123";
    //creation du compte admin si utilisateur "Admin" not found
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.UserName = email;
        user.Email = email;
        await userManager.CreateAsync(user, password);
        //cet utilisateur a le role "Admin"
        await userManager.AddToRoleAsync(user, "Admin");



    }



}

app.Run();
