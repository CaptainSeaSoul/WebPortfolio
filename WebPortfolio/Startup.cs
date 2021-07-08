using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebPortfolio.Models;
using Microsoft.AspNetCore.ResponseCompression;
using WebPortfolio.Services;
using System.IO.Compression;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.Extensions.Azure;
using Azure.Security.KeyVault.Secrets;
using AzureSamples.Security.KeyVault.Proxy;
using Azure.Core;
using Azure.Identity;

namespace WebPortfolio
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
            // configure compression
            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            // configure web frameworks
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllers();

            // configure Email
            EmailServerConfiguration config = Configuration.GetSection("EmailServerConfiguration").Get<EmailServerConfiguration>();
            services.AddSingleton<EmailServerConfiguration>(config);

            services.AddTransient<IEmailService, MailKitEmailService>();

            // confugure DB cache
            services.AddEFSecondLevelCache(options =>
            {
                options.UseMemoryCacheProvider().DisableLogging(true).UseCacheKeyPrefix("EF_");
                options.CacheAllQueries(CacheExpirationMode.Sliding, TimeSpan.FromDays(60));
            }
            );

            // confugure DB 
             string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddConfiguredMsSqlDbContext(connection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseResponseCompression();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=1209600");
                }
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapControllers();
            });
        }
    }
}
