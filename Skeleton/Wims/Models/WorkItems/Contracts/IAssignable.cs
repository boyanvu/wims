using Wims.Models.Contracts;

namespace Wims.Models.WorkItems.Contracts
{
    public interface IAssignable
    {
        IMember Assignee { get; set; }
    }
}