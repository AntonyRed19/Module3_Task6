using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Services.Abstractions
{
    public interface ILoggerService
    {
        public delegate void CheckBackUp();
        public event CheckBackUp BackUpHandler;
        void LogMassage(string message);
        void DoBackUp();
    }
}
