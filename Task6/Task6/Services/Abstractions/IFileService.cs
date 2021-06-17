using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Services.Abstractions
{
    public interface IFileService
    {
        StreamWriter CreateStreamForWrite(string path);

        void WriteToStreamAsync(StreamWriter stream, string text);

        string ReadAllText(string path);

        DateTime GetCreationTime(string path);
    }
}
