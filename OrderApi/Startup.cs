using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OrderApi.DatabaseSettings;
using OrderApi.Middlewares;
using OrderApi.Models.Request;
using OrderApi.Repository;
using OrderApi.Repository.Interfaces;
using OrderApi.Services;
using OrderApi.Services.Interfaces;
using OrderApi.Validators;

namespace OrderApi
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
            services.Configure<OrderDatabaseSettings>(
                Configuration.GetSection(nameof(OrderDatabaseSettings)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<OrderDatabaseSettings>>().Value);
            
            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddSingleton<IOrderServices, CustomerServices>();
            
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<OrderCreateRequestModel>, OrderCreateValidator>();
            services.AddTransient<IValidator<OrderUpdateRequestModel>, OrderUpdateValidator>();
            
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "OrderApi", Version = "v1"}); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderApi v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}