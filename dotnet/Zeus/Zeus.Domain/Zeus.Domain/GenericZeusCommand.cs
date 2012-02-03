using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Domain
{
    public class GenericZeusCommand:IZeusCommand
    {
        private readonly string _Name;
        public string Name
        {
            get{return _Name;}
        }

        private Dictionary<string, string> _Arguments;
        public Dictionary<string, string> Arguments
        {
            get { return _Arguments; }
        }

        public GenericZeusCommand(string name, Dictionary<string,string> args)
        {
            _Arguments=args;
            _Name = name;
        }
        public GenericZeusCommand(string name)
        {
            _Arguments = new Dictionary<string, string>();
            _Name = name;
        }
        public void Push(string argName, string argVal)
        {
            _Arguments.Add(argName, argVal);
        }
    }
}
