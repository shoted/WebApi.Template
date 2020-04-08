using Lexun.Common;
using Lexun.Template.Api.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Lexun.Template.Api.Attributes
{
    public class GlobalExceptionAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            CLog.WriteLog(actionExecutedContext.Exception.Message + actionExecutedContext.Exception.StackTrace);
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new ResultView(HttpStatusCode.InternalServerError, null, actionExecutedContext.Exception.Message)))
            };
        }
    }
}