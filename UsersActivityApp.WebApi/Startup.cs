using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UsersActivityApp.Business.Abstract;
using UsersActivityApp.Business.Concrete;
using UsersActivityApp.DataAccess.Abstract;
using UsersActivityApp.DataAccess.Concrete.Ef;

namespace UsersActivityApp.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //Enable CORS
      services.AddCors(c =>
      {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      });

      services.AddControllers();
      services.AddDbContext<UsersActivityDbContext>(x =>
        x.UseNpgsql(Configuration.GetConnectionString("UsersActivityDbContext")));

      services.AddTransient<IUserActivityRepository, UserActivityEfRepository>();
      services.AddTransient<IUserActivityService, UserActivityService>();
      services.AddTransient<IMetricsCalculationService, MetricsCalculationService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      //Enable CORS
      app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
