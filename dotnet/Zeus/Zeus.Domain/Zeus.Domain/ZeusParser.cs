using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Zeus.Domain
{
    public static class ZeusParser
    {
        private static Regex _Regex = new Regex("^[0-9]"); 
        public static IEnumerable<IZeusCommand> ParseUrl(string url)
        {
            if(!string.IsNullOrEmpty(url))
            {
                //get the area after the querystring
                int qs=url.LastIndexOf("?");
                if(qs!=-1)
                {
                    url = url.Substring(qs+1);
                    if (!string.IsNullOrEmpty(url))
                    {
                        var tokens = url.Split('&');
                        if (tokens != null && tokens.Length > 0)
                        {
                            return GetCommands(tokens);
                        }
                    }
                }
            }
                return null;
        }

        private static IZeusCommand[] GetCommands(string[] tokens)
        {
            Dictionary<string,IZeusCommand> commands = new Dictionary<string,IZeusCommand>();
            int i=0, length=tokens.Length;
            for (; i<length;i+=1)
            {
                //get current token
                var t=tokens[i].Split('=');
                //split it at the = sign
                var left=t[0];
                var right=t[1];

                //if this is not a command argument
                if (!_Regex.IsMatch(left))
                {
                    //make a new command for each one
                    var ids = right.Split(',');
                    foreach (var id in ids)
                    {
                        commands.Add(id, new GenericZeusCommand(left));
                    }
                }
                else
                {
                    var pieces = left.Split('_');
                    commands[pieces[0]].Push(pieces[1],right);
                }
            }
            return commands.Values.ToArray();
        }

    }
}
