using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DTO.Util;
using System.Web;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Logger
            string logLevel = System.Configuration.ConfigurationManager.AppSettings["LogLevel"];
            string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
            Logger.logPath = HttpContext.Current.Server.MapPath(logPath);
            if (logLevel.ToUpper().Equals("DEBUG"))
            {
                Logger.logLevel = Logger.DEBUG;
            }
            else if (logLevel.ToUpper().Equals("INFO"))
            {
                Logger.logLevel = Logger.INFO;
            }
            else if (logLevel.ToUpper().Equals("ERROR"))
            {
                Logger.logLevel = Logger.ERROR;
            }
        }
    }
}
