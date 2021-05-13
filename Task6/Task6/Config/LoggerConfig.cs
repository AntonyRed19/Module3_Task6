using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Config
{
    public class LoggerConfig
    {
        public string DirectoryPath { get; set; }
        public string BackUpPath { get; set; }
        public string ExtensionFile { get; set; }
        public string NameFormat { get; set; }
        public int BackUp { get; set; }
    }
}
