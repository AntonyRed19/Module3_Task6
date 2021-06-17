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
        private int _currentLog;
        private static object locker = new object();
        public LoggerService()
        {
            var config = LocatorService.ConfigService;
            _loggerConfig = config.LoggerConfig;

            _fileService = LocatorService.FileService;
            _directoryService = LocatorService.DirectoryService;
            _currentLog = 0;
            Init();
        }

        public event ILoggerService.CheckBackUp BackUpHandler;

        public void LogMassage(string message)
        {
            var log = $"{DateTime.UtcNow}:{message}";
            _fileService.WriteToStreamAsync(_fileStreamWrite, log);
            _currentLog++;
        }

        public void DoBackUp()
        {
            lock (locker)
            {
                var backup = _loggerConfig.BackUp;
                if (_currentLog == backup)
                {
                    _currentLog = 0;
                    Invoke();
                }
            }
        }

        private void Init()
        {
            var dirPath = _loggerConfig.DirectoryPath;
            var backupPath = _loggerConfig.BackUpPath;

            _directoryService.CreateDirectory(dirPath);
            _directoryService.CreateDirectory(backupPath);

            var fileName = $"{DateTime.UtcNow.ToString(_loggerConfig.NameFormat)}";
            var filePath = $"{dirPath}{fileName}{_loggerConfig.ExtensionFile}";

            _fileStreamWrite = _fileService.CreateStreamForWrite(filePath);
        }

        private void Invoke()
        {
            if (BackUpHandler != null)
            {
                BackUpHandler();
            }
        }
    }
}
