using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Net.Http;
using System.Web.ModelBinding;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
namespace WebApi
{
    public static class WebApiConfig
    {
        //public class CustomJsonFormtter : JsonMediaTypeFormatter {

        //    public CustomJsonFormtter() 
        //    {
        //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html")); 
        //    }

        //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        //    {
        //        base.SetDefaultContentHeaders(type, headers, mediaType);
        //        headers.ContentType=new MediaTypeHeaderValue("application/json")
        //    }
        //}

        public static void Register(HttpConfiguration config)
        {

            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
           
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.Add(new CustomJsonFormtter());
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting=Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
           // config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            //config.Formatters.Remove(config.Formatters.XmlFormatter);// Retrun only Json Data
            //config.Formatters.Remove(config.Formatters.JsonFormatter);// Retrun only XML Data
        }
    }
}
