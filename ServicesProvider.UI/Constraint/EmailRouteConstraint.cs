﻿using ServicesProvider.Core.DTOs.Shared;
using System.Text.RegularExpressions;

namespace ServicesProvider.UI.Constraint
{
    public  class EmailRouteConstraint :IRouteConstraint
    {

        private readonly Regex EmailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*\.[a-z]{2,})$");
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object routeValue))
            {
                string parameterValueString = Convert.ToString(routeValue, System.Globalization.CultureInfo.InvariantCulture);

                if (!string.IsNullOrEmpty(parameterValueString))
                {

                    if (EmailRegex.IsMatch(parameterValueString))
                    {
                        return true;
                    }
                    else
                    {
                        httpContext.Response.StatusCode = 400; // Bad Request
                        httpContext.Response.ContentType = "application/json";
                        httpContext.Response.WriteAsJsonAsync(new BaseResponce() { IsSuccess = false, Message = "Failed to process the request.", Errors = new List<string>() { "Invalid Email Format" } });
                        return false;
                    }
                }
            }

            return false;

        }
    }
}
