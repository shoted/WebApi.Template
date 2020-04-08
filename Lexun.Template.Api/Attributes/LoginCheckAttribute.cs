using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using Lexun.Common;
using Lexun.Template.Api.Models;
using Lexun.Template.Data.Utils;
using Newtonsoft.Json;

namespace Lexun.Template.Api.Attributes
{
    public class LoginCheckAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        protected CUser User;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (User == null && !UCommon.IsDevelopment)
            {
                string lxtByQueryString = CCheckIdentity.GetLxtByQueryString();
                string lxtByCookie = CCheckIdentity.GetLxtByCookie();
                User = LoadUserInfo(lxtByQueryString, lxtByCookie);
            }
            var dic = actionContext.ControllerContext.RouteData.Values;
            if (User != null && !dic.ContainsKey("lx_user"))
            {
                dic.Add("lx_user", User);
            }
            //处理未登录的情况
            var controllerName = dic["controller"].ToString();
            var requestMethod = actionContext.Request.Method.Method;
            if (IsDoNotNeedLoginController(controllerName, requestMethod)) return;
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new ResultView(HttpStatusCode.Unauthorized, null, "请先登录")))
            };
        }

        /// <summary>
        /// 加载用户信息
        /// </summary>
        /// <param name="lxtQs"></param>
        /// <param name="lxtCookie"></param>
        /// <returns></returns>
        private CUser LoadUserInfo(string lxtQs, string lxtCookie)
        {
            bool isLogin = CCheckIdentity.LoginByLxt(lxtQs, lxtCookie, CCommon.IsSpider(CUser.GetUserUA()), out var userid, out var lxt, out _);
            return isLogin ? new CUser(userid, lxt) : new CUser(0, "");
        }

        private bool IsDoNotNeedLoginController(string controllerName, string requestMethod)
        {
            return true;
        }
    }
}