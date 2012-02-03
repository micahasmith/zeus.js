using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Domain
{
    public interface IZeusCommandHandler
    {
        void Handle(IZeusCommand command);
    }
}
