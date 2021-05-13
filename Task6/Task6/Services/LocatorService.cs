using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Services.Abstractions;

namespace Task6.Services
{
    public static class LocatorService
    {
        private static readonly LoggerService _loggerService = new LoggerService();
        public static ILoggerService LoggerService => _loggerService;
        public static IFileService FileService => new FileService();

        public static IDirectoryService DirectoryService => new DirectoryService();
        public static IConfigService ConfigService => new ConfigService();
    }
}
