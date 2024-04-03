using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ServicesProvider.Core.DTOs.Shared;
using System.Runtime.CompilerServices;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterAuthentication
    {
        public static IServiceCollection RegisterAppAuthentication(this IServiceCollection services,WebApplicationBuilder builder)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme= JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearer =>
            {
                bearer.UseSecurityTokenValidators = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration.GetRequiredSection("Jwt")["Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration.GetRequiredSection("Jwt")["Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetRequiredSection("Jwt")["Key"])),
                    //There is an additional delay of 5 minutes in the jwt itself.
                    //If you are setting 1 minute as indicated for expiration, the total will be 6 minutes.
                    //If you set 1 hour the total will be 1 hour and 5 minutes.
                    //to set the exact expiration, which you set in token generation then make following property zero
                    ClockSkew = TimeSpan.Zero

                };

                /*bearer.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {

                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(new BaseResponce() { IsSuccess = false, Message = "Sorry! You are not authorize" });
                    },
                    OnForbidden = async context =>
                    {

                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(new BaseResponce() { IsSuccess = false, Message = "Sorry! You are not authorize" });
                    },
                    OnAuthenticationFailed = async context =>
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(new BaseResponce() { IsSuccess = false, Message = "Sorry! You are not authorize" });
                    }

                };*/


            });
            return services;

        }
    }
}
