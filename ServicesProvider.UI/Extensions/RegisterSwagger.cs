using Microsoft.OpenApi.Models;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterSwagger
    {
        public static IServiceCollection RegisterAppSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                
                c.IncludeXmlComments("SwaggerComments.xml");
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Services Provider (" + configuration.GetSection("ENV").Value?.ToString() + ")", Version = "v1" }); ; ;

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.\n Don't forget to put Bearer Keyword before token and put token after space like Bearer {token}",
                    

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
            return services;
        }

    }
}
