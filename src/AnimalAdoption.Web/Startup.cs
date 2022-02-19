using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AnimalAdoption.BusinessLogic;
using AnimalAdoption.BusinessLogic.Helpers;
using AnimalAdoption.BusinessLogic.Services.Email;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Extensions;
using AnimalAdoption.Web.Services.Account;
using AnimalAdoption.Web.Services.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AnimalAdoption.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.AddHealthChecks();

            services.AddDbContext<AnimalAdoptionDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AnimalAdoptionConnectionString"));
            });

            services.AddRazorPages()
                .AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    option.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                });

            services.AddAuthentication();
            services.AddIdentityService();
            services.AddJwtToken(Configuration);

            services.AddCors(option =>
            {
                option.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddAutoMapper(x => x.AddProfile(new AutoMapperHelper()));

            DiConfig.Configure(services);
            SendEmailConfig.Configure(services, Configuration);
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnimalAdoption.Web", Version = "v1" });
            });

            services.AddExceptionMiddleware();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimalAdoption.Web v1"));
            }

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
