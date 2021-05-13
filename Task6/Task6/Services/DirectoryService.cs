using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Services.Abstractions;

namespace Task6.Services
{
    public class DirectoryService : IDirectoryService
    {
        public void CreateDirectory(string path)
        {
           Directory.CreateDirectory(path);
        }

        public bool Exists(string path) => Directory.Exists(path);
    }
}
