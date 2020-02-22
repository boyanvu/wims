using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Models.WorkItems.Contracts
{
    public interface ICommon
    {
        IMember Assignee { get; set; }

        Priority Priority { get; }
    }
}