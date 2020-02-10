using System;
using System.Collections.Generic;
using System.Text;
using Agency.Models.Common;

namespace Agency.Models.Contracts
{
    interface IBug
    {
        IList<string> StepsToReproduce { get; }
        Priority Priority { get; }
        Severity Severity { get; }
        StatusBug Status { get; }
        IMember Assignee { get; }
    }
}
