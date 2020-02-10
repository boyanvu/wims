using System;
using System.Collections.Generic;
using System.Text;
using Agency.Models.Common;

namespace Agency.Models.Contracts
{
    public interface IStory
    {
        Priority Priority { get; }
        Size Size { get; }
        StatusStory Status { get; }
        IMember Assignee { get; }
    }
}
