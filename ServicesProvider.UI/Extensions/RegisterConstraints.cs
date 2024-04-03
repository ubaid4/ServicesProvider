using ServicesProvider.UI.Constraint;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterConstraints
    {
        public static void RegisterAppConstraints(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(option =>
            {
                option.ConstraintMap.Add("email", typeof(EmailRouteConstraint));
                option.ConstraintMap.Add("appGuid", typeof(GuidRouteConstraint));
                option.ConstraintMap.Add("url", typeof(UrlRouteConstraint));



            });


        }
    }
}
