using System;
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

        public override string Print()
        {
            return $"{this.GetType().Name}:{Environment.NewLine}  " +
                $"Title: {this.Title}{Environment.NewLine}  " +
                $"Description: {this.Description}{Environment.NewLine}  " +
                $"Priority: {this.Priority}{Environment.NewLine}  " +
                $"Size: {this.Size}{Environment.NewLine}  " +
                $"Status: {this.Status}{Environment.NewLine}  ";
        }
    }
}