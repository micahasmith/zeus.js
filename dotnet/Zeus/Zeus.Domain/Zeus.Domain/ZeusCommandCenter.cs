using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Domain
{
    public class ZeusCommandCenter
    {
        private IZeusCommandHandler[] _Handlers;
        private int _HandlersLength = 0;
        public ZeusCommandCenter(IEnumerable<IZeusCommandHandler> handlers)
        {
            _Handlers = handlers.ToArray();
            _HandlersLength = _Handlers.Count();
        }

        public void Handle(IZeusCommand command)
        {
            for (int i = 0; i < _HandlersLength; i += 1)
            {
                _Handlers[i].Handle(command);
            }
        }
    }
}
