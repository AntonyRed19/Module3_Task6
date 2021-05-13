using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Config;
using Task6.Services.Abstractions;

namespace Task6.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly LoggerConfig _loggerConfig;
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;
        private StreamWriter _fileStreamWrite;

        public LoggerService()
        {
            var config = LocatorService.ConfigService;
            _loggerConfig = config.LoggerConfig;
            _fileService = LocatorService.FileService;
            _directoryService = LocatorService.DirectoryService;
        }

        public void LogMassage(string message)
        {
            var log = $"{DateTime.UtcNow}:{message}";
            Console.WriteLine(log);
        }

        public void DoBackUp()
        {
            throw new NotImplementedException();
        }
    }
}
