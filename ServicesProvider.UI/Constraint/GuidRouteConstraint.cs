
using ServicesProvider.Core.DTOs.Shared;
using System.Text.RegularExpressions;

namespace ServicesProvider.UI.Constraint
{
    public class GuidRouteConstraint : IRouteConstraint
    {
        private readonly Regex _guidRegex = new Regex(@"(?i)\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b");
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object routeValue))
            {
                string parameterValueString = Convert.ToString(routeValue, System.Globalization.CultureInfo.InvariantCulture);

                if (!string.IsNullOrEmpty(parameterValueString))
                {

                    if(_guidRegex.IsMatch(parameterValueString))
                    {
                        return true;
                    }
                    else
                    {
                        httpContext.Response.StatusCode = 400; // Bad Request
                        httpContext.Response.ContentType = "application/json";
                        httpContext.Response.WriteAsJsonAsync(new BaseResponce() { IsSuccess = false, Message = "Failed to process the request.", Errors = new List<string>() { "Invalid Guid Format" } }) ;
                        return false;
                    }
                }
            }

            return false;

        }
    }
}
