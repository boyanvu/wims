using System;
using System.Collections.Generic;
using System.Text;

namespace Wims.Core.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}
