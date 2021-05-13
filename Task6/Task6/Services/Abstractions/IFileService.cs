using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Services.Abstractions
{
    public interface IFileService
    {
        IDisposable CreateStreamForWrite(string path);

        void WriteToStream(IDisposable stream, string text);

        string ReadAllText(string path);

        DateTime GetCreationTime(string path);
    }
}
