using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using AzureSamples.Security.KeyVault.Proxy;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.KeyVault;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

namespace WebPortfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Production)
                    {
                        var keyVaultEndpoint = Environment.GetEnvironmentVariable("VaultUri");
                        var AppRegistrationTenantId = Environment.GetEnvironmentVariable("AppRegistrationTenantId");
                        var AppRegistrationAppId = Environment.GetEnvironmentVariable("AppRegistrationAppId");
                        var AppRegistrationAppSecret = Environment.GetEnvironmentVariable("AppRegistrationAppSecret");
    
                        // key vault cache
                        SecretClientOptions options = new SecretClientOptions();
                        options.AddPolicy(new KeyVaultProxy(TimeSpan.FromDays(90)), HttpPipelinePosition.PerCall);

                        SecretClient client = new SecretClient(
                            new Uri(keyVaultEndpoint),
                            new ClientSecretCredential(AppRegistrationTenantId, AppRegistrationAppId, AppRegistrationAppSecret),
                            options);

                        config.AddAzureKeyVault(client, new KeyVaultSecretManager());
                        }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
