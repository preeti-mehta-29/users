using Microsoft.EntityFrameworkCore;
using UserService.DBContext;
using UserService.Repository;
namespace UserService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<UserContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("UserDB")));
           // services.AddScoped<DbContext, UserContext>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            //app.UseCookiePolicy();
           // app.UseStaticFiles();
            //app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
