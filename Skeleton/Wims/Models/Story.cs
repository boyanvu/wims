using System;
using Wims.Models.Contracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Models.Common
{
    public class Story : WorkItem, IStory, ICommon
    {
        public Story(string title, string description, Priority priority, Size size)
            : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = StatusStory.NotDone;
            this.Assignee = null;
        }
        public Priority Priority { get; set; }

        public Size Size { get; set; }

        public StatusStory Status { get; set; }

        public IMember Assignee { get; set; }

        public override string ToString()
        {
            var assigneeName = this.Assignee == null ? "-" : this.Assignee.Name;

            return $"{this.GetType().Name}:{Environment.NewLine}  " +
                $"Title: {this.Title}{Environment.NewLine}  " +
                $"Description: {this.Description}{Environment.NewLine}  " +
                $"Priority: {this.Priority}{Environment.NewLine}  " +
                $"Size: {this.Size}{Environment.NewLine}  " +
                $"Status: {this.Status}{Environment.NewLine}  " +
                $"Assignee: {assigneeName}{Environment.NewLine}  " +
                $"Comments: {String.Join(" ", this.Comments)}  ";
        }
    }
}