using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PizzaBurgerHouse.Extensions
{
    public static class ConfigureExtensions
    {
        public static  void CorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
  
        public static void SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
           x.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza Burger House", Version = "v1" }));
        }



        public static void FluentValidationConfiguration(this IServiceCollection services)
        {
            //services.AddMvc()
            //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()
            //.RunDefaultMvcValidationAfterFluentValidationExecutes = false);

            services.AddMvc()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            
        }

     

    }
}
