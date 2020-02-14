using System.Collections.Generic;
using Wims.Models.Contracts;


namespace Wims.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        // TODO Modify
        IList<ITeam> Teams { get; }

        IList<IMember> Members { get; }

        IList<IBoard> Boards { get; }

        IList<IWorkItem> Workitems { get; }

    }
}
