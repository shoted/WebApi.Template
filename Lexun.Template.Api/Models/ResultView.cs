using System.Net;

namespace Lexun.Template.Api.Models
{
    public class ResultView
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode Code { get; set; }
        public dynamic Data { get; set; }
        public string Msg { get; set; }

        public ResultView(HttpStatusCode code, dynamic data, string msg = "")
        {
            if (code == HttpStatusCode.OK)
                IsSuccess = true;
            Data = data;
            Code = code;
            Msg = msg;
        }
    }
}