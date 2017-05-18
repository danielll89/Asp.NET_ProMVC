using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace UrlsAndRouting.Infrastructure
{
    public class UserAgentConstraint : IRouteConstraint
    {
        private string requiredAgent;

        public UserAgentConstraint(string agentParam)
        {
            requiredAgent = agentParam;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.UserAgent != null && httpContext.Request.UserAgent.Contains(requiredAgent);
        }
    }
}