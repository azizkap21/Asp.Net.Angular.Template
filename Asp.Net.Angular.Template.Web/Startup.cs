using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Service.ApplicationConfiguration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Asp.Net.Angular.Template.Web
{
  public class Startup
  {
    public Startup(IConfiguration configuration, ILogger<Startup> logger)
    {
      Configuration = configuration;
      Logger = logger;
    }

    public IConfiguration Configuration { get; }
    public ILogger Logger { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;

      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      //In production, the Angular files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "wwwroot/clientApp/dist";
      });

      ConfigureSettings(services);

      AddAuthentication(services);
    }

    private void ConfigureSettings(IServiceCollection services)
    {
      var globalSettingSection = Configuration.GetSection("GlobalSettings");
      services.Configure<GlobalSettings>(globalSettingSection);
    }

    private void AddAuthentication(IServiceCollection services)
    {
      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<Settings>(appSettingsSection);

      var appSettings = appSettingsSection.Get<Settings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
     .AddJwtBearer(x =>
     {
       x.RequireHttpsMetadata = false;
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters
       {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(key),
         ValidateIssuer = false,
         ValidateAudience = false
       };
       x.Events = new JwtBearerEvents
       {
         OnAuthenticationFailed = context =>
         {
           if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
           {
             context.Response.Headers.Add("Token-Expired", "true");
           }
           return Task.CompletedTask;
         }
       };
     });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
      app.UseSpaStaticFiles();
      app.UseCookiePolicy();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
               
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "./";
        if (env.IsDevelopment())
        {
          spa.UseAngularCliServer(npmScript: "start");
        }
      });
    }
  }
}
