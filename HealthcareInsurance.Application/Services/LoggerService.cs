using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareInsurance.Application.Services
{
    //Logger Service using Singleton Pattern
    public class LoggerService
    {
        private static LoggerService? _instance;
        private static readonly object _lock = new();

        private LoggerService() { }

        public static LoggerService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new LoggerService();
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            ArgumentNullException.ThrowIfNull(message);
            // Implement logging functionality
        }
    }
}
