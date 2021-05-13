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
            Init();
        }

        public event Action BackUp;
        public void LogMassage(string message)
        {
            var log = $"{DateTime.UtcNow}:{message}";
            _fileService.WriteToStream(_fileStreamWrite, log);
            Console.WriteLine(log);
        }

        public void DoBackUp()
        {
        }

        private void Init()
        {
            var dirPath = _loggerConfig.DirectoryPath;
            var backUpPath = _loggerConfig.BackUpPath;

            _directoryService.CreateDirectory(dirPath);
            _directoryService.CreateDirectory(backUpPath);

            var fileName = $"{DateTime.UtcNow.ToString(_loggerConfig.NameFormat)}";
            var filePath = $"{dirPath}{fileName}{_loggerConfig.ExtensionFile}";

            _fileStreamWrite = (StreamWriter)_fileService.CreateStreamForWrite(filePath);
        }
    }
}
