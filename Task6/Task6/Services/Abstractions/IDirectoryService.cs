using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Services.Abstractions
{
    public interface IDirectoryService
    {
        bool Exists(string path);

        void CreateDirectory(string path);
    }
}
