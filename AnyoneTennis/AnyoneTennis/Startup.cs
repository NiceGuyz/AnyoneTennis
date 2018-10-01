using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyoneTennis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



[assembly: OwinStartupAttribute(typeof(AnyoneTennis.Startup))]
namespace AnyoneTennis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //  var connection = @"Server=(ehsesql1prd.cdu.edu.au)\mssqllocaldb;Database=tennis;Trusted_Connection=True;ConnectRetryCount=0";
            var connection = @"Server=ehsesql1prd.cdu.edu.au;Database=tennis;User Id=test;Password=easypassword";
            services.AddDbContext<tennisContext>(options => options.UseSqlServer(connection));
        }

    }
}
