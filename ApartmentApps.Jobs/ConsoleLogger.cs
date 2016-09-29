using System;
using ApartmentApps.Api.Modules;

namespace ApartmentApps.Jobs
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string str, params object[] args)
        {
            Console.WriteLine(str,args);
        }

        public void Warning(string str, params object[] args)
        {
            Console.WriteLine(str, args);
        }

        public void Info(string str, params object[] args)
        {
            Console.WriteLine(str, args);
        }
    }
}