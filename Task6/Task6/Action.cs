using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Services;
using Task6.Services.Abstractions;

namespace Task6
{
    public class Action
    {
        private readonly ILoggerService _logger;
        public Action()
        {
            _logger = LocatorService.LoggerService;
        }

        public void ShowLog(int num)
        {
            _logger.LogMassage($"{num} - Hello there");
        }

        public void ShowLog2(int num)
        {
            _logger.LogMassage($"{num} - General Kenobi");
        }
    }
}
