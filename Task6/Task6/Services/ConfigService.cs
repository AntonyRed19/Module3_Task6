using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Config;
using Task6.Services.Abstractions;
using Newtonsoft.Json;

namespace Task6.Services
{
    public class ConfigService : IConfigService
    {
        private readonly string _filePath = "config.json";
        private readonly LoggerConfig _loggerConfig;
        private readonly IFileService _fileService;

        public ConfigService()
        {
            _fileService = LocatorService.FileService;

            var config = GetConfig();
            _loggerConfig = config.LoggerConfig;
        }

        public LoggerConfig LoggerConfig => _loggerConfig;

        private GeneralConfig GetConfig()
        {
            var json = _fileService.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<GeneralConfig>(json);
        }
    }
}
