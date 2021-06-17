using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task6.Config;
using Task6.Services;
using Task6.Services.Abstractions;

namespace Task6
{
    public class Starter
    {
        private readonly ILoggerService _logger;
        private readonly Action _action;
        private readonly LoggerConfig _loggerConfig;

        public Starter()
        {
            _action = new Action();
            _logger = LocatorService.LoggerService;
            var config = LocatorService.ConfigService;
            _loggerConfig = config.LoggerConfig;
        }

        public void Run(bool isCanDoBackUp, int num)
        {
            if (isCanDoBackUp)
            {
                _logger.BackUpHandler += BackUp;
            }

            for (var i = 0; i < 50; i++)
            {
                _action.ShowLog(num);
                _logger.DoBackUp();
            }

            for (var i = 0; i < 50; i++)
            {
                _action.ShowLog2(num);
                _logger.DoBackUp();
            }
        }

        private void BackUp()
        {
            var dirPath = _loggerConfig.DirectoryPath;
            var backUpPath = _loggerConfig.BackUpPath;

            var fileName = $"{DateTime.UtcNow.ToString(_loggerConfig.NameFormat)}";
            var filePath = $"{backUpPath}{fileName}{_loggerConfig.ExtensionFile}";

            var fileList = Directory.GetFiles(dirPath);
            var fromDir = fileList[fileList.Length - 1];

            if (!File.Exists(filePath))
            {
                File.Copy(fromDir, filePath);
                Thread.Sleep(1000);
            }
        }
    }
}
