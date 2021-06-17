using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task6.Services.Abstractions;

namespace Task6.Services
{
    public class FileService : IFileService
    {
        private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);
        private static int _count = 0;
        private int _idFileService;
        public FileService()
        {
            _idFileService = _count;
            _count++;
        }

        public StreamWriter CreateStreamForWrite(string path)
        {
            return new StreamWriter(path, false, Encoding.Default);
        }

        public async void WriteToStreamAsync(StreamWriter stream, string text)
        {
            await _semaphoreSlim.WaitAsync();
            var streamWrite = (StreamWriter)stream;

            await streamWrite.WriteLineAsync($"{_idFileService} {text}");
            streamWrite.Flush();
            Console.WriteLine(text);
            _semaphoreSlim.Release();
        }

        public string ReadAllText(string path) => File.ReadAllText(path);

        public DateTime GetCreationTime(string path) => File.GetCreationTime(path);
    }
}
