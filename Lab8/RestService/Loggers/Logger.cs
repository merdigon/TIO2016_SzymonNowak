using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService.Loggers
{
    public class Logger
    {
        private static readonly ILog log =
           log4net.LogManager.GetLogger(typeof(Logger));

        public void LogInfo(string message)
        {
            if (log != null)
                log.Info(message);
        }
    }
}