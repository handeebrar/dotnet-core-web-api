using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiDemo.CustomMiddlewares;
using WebApiDemo.DataAccess;
using WebApiDemo.Formatter;

namespace WebApiDemo
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
            services.AddScoped<IProductDal, EfProductDal>(); //IProductDal ihtiyacı olduğu zaman o nesneyi efproductdal'da oluşturup döndür
            services.AddMvc(options=> 
            {
                options.OutputFormatters.Add(new VCardOutputFormatter());
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<AuthenticationMiddleware>();

            //routing yapılandırması için fakat bu artık kullanılmıyor
            app.UseMvc(config =>
            {
                //config.MapRoute("DefaultRoute", "api/{controller}/{action}");
            });
        }
    }
}
