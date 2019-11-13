using AuthenticationPortal.AwsExtension;
using AuthenticationPortal.Contracts;
using AuthenticationPortal.MongoDBStore;
using AuthenticationPortal.Services;
using Autofac;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthenticationPortal.Web
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
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.Configure<AwsCognitoCredentials>(Configuration.GetSection("id"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IValidator<SignInRequest>, SignInRequestValidator>();
            services.AddSingleton<IValidator<TokenAuthenticationRequest>, TokenAuthenticationRequestValidator>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //configure auto fac here
            builder.RegisterType<AwsCognito>().As<IUserAuthenticationAdapter>();
            builder.RegisterType<AWSCognitoAuth>().As<ITokenAuthenticatorAdapter>();
            builder.RegisterType<UserAuthenticationService>().As<IUserAuthenticationService>();
            builder.RegisterType<TokenAuthenticationService>().As<ITokenAuthenticationService>();
            builder.RegisterType<MongoUserStore>().As<IUserStore>();
            builder.RegisterType<UserDetailsService>().As<IUserDetailsService>();
        }
    }
}
