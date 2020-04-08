using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogString;

namespace Lexun.Template.Data.Utils
{
    public class WLog
    {
        public static void WriteDebugLog(string log)
        {
#if DEBUG
            CLog.WriteLog(log);
#endif
        }

        public static void WriteDebugLog(string fmt, params object[] par)
        {
            string log = string.Format(fmt, par);
            WriteDebugLog(log);
        }

        public static void WriteErrorLog(string log)
        {
            CLog.WriteLog(log);
        }

        public static void WriteErrorLog(string fmt, params object[] par)
        {
            string log = string.Format(fmt, par);
            WriteErrorLog(log);
        }
    }
}
