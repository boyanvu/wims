using Wims.Models.Common;
using Wims.Models.Contracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Core.Factories
{
    public interface IWimsFactory
    {
        ITeam CreateTeam(string name);

        IMember CreateMember(string name);

        IBoard CreateBoard(string name);

        IBug CreateBug(string title, string description, Priority priority,
            Severity severity);

        IStory CreateStory(string title, string description, Priority priority,
            Size size);

        IFeedback CreateFeedback(string title, string description, int rating);


        IComment CreateComment(string author, string message);
    }
}
