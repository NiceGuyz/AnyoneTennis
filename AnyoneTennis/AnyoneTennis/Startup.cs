using Microsoft.Owin;
using Owin;
<<<<<<< HEAD
<<<<<<< HEAD
using AnyoneTennis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
=======
>>>>>>> parent of e3d5e6e... added models, initial migration
=======
>>>>>>> parent of e3d5e6e... added models, initial migration

[assembly: OwinStartupAttribute(typeof(AnyoneTennis.Startup))]
namespace AnyoneTennis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
<<<<<<< HEAD
<<<<<<< HEAD

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
       
            var connection = @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<tennisContext>(options => options.UseSqlServer(connection));
        }
=======
>>>>>>> parent of e3d5e6e... added models, initial migration
=======
>>>>>>> parent of e3d5e6e... added models, initial migration
    }
}
