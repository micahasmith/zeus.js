using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Domain
{
    public interface IZeusCommand
    {
        string Name { get; }
        Dictionary<string, string> Arguments { get; }
        void Push(string argName, string argVal);
    }
}
