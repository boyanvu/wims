using Wims.Models;
using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Core.Factories
{
    public interface IWimsFactory
    {
        ITeam CreateTeam(string name);

        IMember CreateMember(string name);

        IBoard CreateBoard(string name);

        Bug CreateBug(string title, string description, Priority priority,
            Severity severity);

        Story CreateStory(string title, string description, Priority priority,
            Size size, StatusStory status);

        Feedback CreateFeedback(string title, string description, int rating);


        Comment CreateComment(string author, string message);
    }
}
