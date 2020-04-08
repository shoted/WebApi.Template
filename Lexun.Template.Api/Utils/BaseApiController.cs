using System.Net;
using System.Web.Http;
using Lexun.Common;
using Lexun.Template.Api.Models;

namespace Lexun.Template.Api.Utils
{
    public class BaseApiController : ApiController
    {
        protected new CUser User => 
            ActionContext.ControllerContext.RouteData.Values.TryGetValue("lx_user", out object user) ? user as CUser : null;

        protected int UserId => User == null ? 0 : User.UserId;

        protected string Lxt => User == null ? "" : User.UserLxt;
    }
}