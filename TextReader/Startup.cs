using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextReader.Data.Database;
using TextReader.Repository.IRepository.Admin;
using TextReader.Repository.IRepository.Common;
using TextReader.Repository.IRepository.User;
using TextReader.Repository.Repository.Admin;
using TextReader.Repository.Repository.Common;
using TextReader.Repository.Repository.User;

namespace TextReader
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllersWithViews();

      // Register your repositories
      string cs = "Server=DESKTOP-JOI1JGN\\SQLEXPRESS;Database=TextReader;Trusted_Connection=True;";
      services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(cs));
      services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<DatabaseContext>()
              .AddDefaultTokenProviders();
      //user
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IImageTextReader, ImageTextReader>();
      services.AddScoped<IPDFTextReader, PDFTextReader>();
      services.AddScoped<IAudioTextReader, AudioTextReader>();
      services.AddScoped<IVideoTextReader, VideoTextReader>();
      services.AddScoped<IGPTRepository, GPTRepository>();
      services.AddScoped<IUserProfileRepository, UserProfileRepository>();

      //Admin
      services.AddScoped<IAccountRepository, AccountRepository>();
      services.AddScoped<IImageTextRepository, ImageTextRepository>();
      services.AddScoped<IPDFTextRepository, PDFTextRepository>();
      services.AddScoped<IAudioTextRepository, AudioTextRepository>();
      services.AddScoped<IVideoTextRepository, VideoTextRepository>();
      services.AddScoped<IUserAccountRepository, UserAccountRepository>();

      //Common
      services.AddScoped<IMemberRepository, MemberRepository>();
      services.AddScoped<IEmailRepository, EmailRepository>();



    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();


      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}");
      });
    }
  }
}
