using Microsoft.EntityFrameworkCore;
using Rc_serviceV2.Models;
using Microsoft.AspNetCore.Identity;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<Rc_serviceV2.Models.Rc_serviceV2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion")));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<Rc_serviceV2.Models.Rc_serviceV2Context>();


        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();


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
        app.UseAuthentication(); ;

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();


        app.Run();
    }
}