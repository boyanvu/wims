using System.Collections.Generic;

namespace Wims.Models.Contracts
{
    public interface IBoard
    {
        string Name { get; }
        IList<IWorkItem> WorkItems { get; }
        IList<string> History { get; }

      
    }
}
