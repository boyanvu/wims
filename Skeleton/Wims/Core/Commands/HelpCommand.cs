using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;

namespace Wims.Core.Commands
{
    class HelpCommand : Command
    {
        public HelpCommand(IList<string> commandLine)
            : base(commandLine)
        {
        }
        public override string Execute()
        {
            return Help.helpCommands;
        }
    }
}