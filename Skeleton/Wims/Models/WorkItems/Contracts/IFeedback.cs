using Wims.Models.Common;

namespace Wims.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        int Rating { get; }
        StatusFeedback Status { get; }
    }
}
