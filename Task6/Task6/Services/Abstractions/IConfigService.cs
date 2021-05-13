using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Config;

namespace Task6.Services.Abstractions
{
    public interface IConfigService
    {
        LoggerConfig LoggerConfig { get; }
    }
}
