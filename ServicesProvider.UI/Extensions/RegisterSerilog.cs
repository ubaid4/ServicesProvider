using Serilog;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterSerilog
    {
        public static WebApplicationBuilder RegisterAppSerilog(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((HostBuilderContext context,IServiceProvider services,LoggerConfiguration logger) =>
            {
                logger
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services);

            });
            return builder;
        }
    }
}
