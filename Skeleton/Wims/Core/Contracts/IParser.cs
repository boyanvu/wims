using Wims.Commands.Contracts;
using System.Collections.Generic;

namespace Wims.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
