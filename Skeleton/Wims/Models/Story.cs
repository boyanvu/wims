using Wims.Models.Contracts;

namespace Wims.Models.Common
{
    public class Story : WorkItem, IStory
    {
        public Story(string title, string description, Priority priority, Size size, StatusStory status)
            : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
            this.Assignee = null;
        }
        public Priority Priority { get; }

        public Size Size { get; }

        public StatusStory Status { get; }

        public IMember Assignee { get; }
    }
}