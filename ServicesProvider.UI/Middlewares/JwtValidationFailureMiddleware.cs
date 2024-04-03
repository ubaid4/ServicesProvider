
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using ServicesProvider.Core.DTOs.Accounts;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Threading.Tasks;

namespace ServicesProvider.UI.Middlewares
{
    public class JwtValidationFailureMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtValidationFailureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            if(context.Request.Headers.TryGetValue("Authorization", out var token))
            {

            await _next(context);
                if (context.Response.StatusCode == 401)
                {
                    //check if token expired on not authorized
                    if (context.Response.Headers.ContainsKey("WWW-Authenticate") && context.Response.Headers["WWW-Authenticate"].ToString().Contains("token expired"))
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(new TokenFailureDTO() { IsSuccess = false,   IsTokenExipred=true, IsTokenNotAuthorized=false, IsTokenNotProvided=false, Message = "Sorry! Your token has been expired" });

                    }
                    else
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(new TokenFailureDTO() { IsSuccess = false, IsTokenExipred=false, IsTokenNotAuthorized= true,IsTokenNotProvided=false ,Message = "Sorry! You are not authorized" });
                    }
                }
                else if(context.Response.StatusCode == 403)
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(new TokenFailureDTO() { IsSuccess = false, IsTokenExipred = false, IsTokenNotAuthorized = true, IsTokenNotProvided = false, Message = "Sorry! You are not authorized" });

                }

            }
            else
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new TokenFailureDTO() { IsSuccess = false, IsTokenExipred = false, IsTokenNotAuthorized = false, IsTokenNotProvided = true, Message = "Sorry! you need a valid access token to proceed the request" });
            }
        }
    }

    public static class JwtValidationFailureMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtValidationFailure(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtValidationFailureMiddleware>();
        }
    }

}
