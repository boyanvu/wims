using System.Collections.Generic;
using Wims.Core.Contracts;
using Wims.Core.Factories;

namespace Wims.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command(IList<string> commandLine)
        {
            this.Factory = new WimsFactory();
            this.CommandParameters = new List<string>(commandLine);
        }

        protected IList<string> CommandParameters { get; }

        protected IWimsFactory Factory { get; }

        public abstract string Execute();
    }
}
