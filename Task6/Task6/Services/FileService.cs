using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Services.Abstractions;

namespace Task6.Services
{
    public class FileService
    {
        public IDisposable CreateStreamForWrite(string path)
        {
            return new StreamWriter(path, true, Encoding.Default);
        }

        public void WriteToStream(IDisposable stream, string text)
        {
            var streamWrite = (StreamWriter)stream;

            streamWrite.WriteLine(text);
        }

        public string ReadAllText(string path) => File.ReadAllText(path);

        public DateTime GetCreationTime(string path) => File.GetCreationTime(path);
    }
}
