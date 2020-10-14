using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LandingPageTemplate.Client.Helpers;
using Blazor.FileReader;
using LandingPageTemplate.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using LandingPageTemplate.Client.Auth;
using NewsProject.Client.Auth;

namespace LandingPageTemplate.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IBlockRepository, BlockRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISocialLinkRepository, SocialLinkRepository>();
            builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

            builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<JWTAuthenticationStateProvider>();

            builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

            builder.Services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

            builder.Services.AddScoped<TokenRenewer>();

            await builder.Build().RunAsync();
        }
    }
}
