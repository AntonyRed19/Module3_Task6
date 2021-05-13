using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Services;
using Task6.Services.Abstractons;

namespace Task6
{
    public class Starter
    {
        private ILoggerService _loggerService;
        public Starter()
        {
            _loggerService = LocatorService.LoggerService;
        }

        public void Run()
        {
            _loggerService.LogMassage("Eror");
        }
    }
}
