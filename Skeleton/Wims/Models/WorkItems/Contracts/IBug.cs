using System.Collections.Generic;
using Wims.Models.Common;

namespace Wims.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        IList<string> StepsToReproduce { get; }
        Priority Priority { get; }
        Severity Severity { get; }
        StatusBug Status { get; }
        IMember Assignee { get; }
    }
}
