using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Logger
{
    public class LogPrint
    {
        private string _RutaLog;
        public LogPrint(string rutaLog)
        {
            _RutaLog = rutaLog;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($"{_RutaLog}IsiBoCoreNegocio.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        public static void Info(string metodo, string mensaje)
        {
            Log.Information($"[{metodo}] [{mensaje}]");
        }
        public static void Error(string metodo, string mensaje)
        {
            Log.Error($"[{metodo}] [{mensaje}]");
        }
        public static void Debug(string metodo, string mensaje)
        {
            Log.Debug($"[{metodo}] [{mensaje}]");
        }
    }
}
