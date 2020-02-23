using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Common;

namespace Wims.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        Priority Priority { get; }
        Size Size { get; }
        StatusStory Status { get; }
        IMember Assignee { get; }
    }
}
