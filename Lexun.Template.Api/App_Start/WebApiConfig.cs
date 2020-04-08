using System.Net.Http.Formatting;
using System.Web.Http;
using Lexun.Template.Api.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.Formatters.Clear();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(), //小写命名法。
                DateFormatString = "yyyy-MM-dd HH:mm:ss",//解决json时间带T的问题
                Formatting = Newtonsoft.Json.Formatting.Indented,//解决json格式化缩进问题
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore//解决json序列化时的循环引用问题
            };

            config.Filters.Add(new LoginCheckAttribute());
            config.Filters.Add(new GlobalExceptionAttribute());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
