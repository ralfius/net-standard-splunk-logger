using System;
using System.Collections.Generic;
using System.Text;

namespace SplunkLogger.Writer
{
    public interface ILogService
    {
        void WriteInformation(string message);
    }
}
