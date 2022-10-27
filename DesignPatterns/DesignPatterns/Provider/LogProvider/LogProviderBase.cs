using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal abstract class LogProviderBase: ProviderBase
    {
        public abstract void WriteLog(LogType logType, string message);
    }
    
    internal enum LogType
    {
        None,
        Verbose,
        Information,
        Warning,
        Error,
        Fatal,
    }
}
