using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Lexun.Common;
using Lexun.Template.Api.Models;
using Lexun.Template.Api.Utils;

namespace Lexun.Template.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        /// <summary>
        /// 获取当前登录的用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<ResultView> Get()
        {
            return await Task.FromResult(new ResultView(HttpStatusCode.OK, new { User }, "获取成功"));
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  ResultView Get(int id)
        {
            throw new Exception("异常了");
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <returns></returns>
        public ResultView Post(int userid, string lxt)
        {
            return new ResultView(HttpStatusCode.OK, new { userid, lxt }, "添加成功");
        }
    }
}