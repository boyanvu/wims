using Wims.Models.Common;
using System;
using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Models
{
    public class Bug : WorkItem, IBug
    {
        private Priority priority;
        private Severity severity;
        private StatusBug statusBug;
        private IMember assignee;


        public Bug(string title, string description, Priority priority, Severity severity, StatusBug statusBug)
            : base(title, description)
        {
            this.Priority = priority;
            this.Severity = severity;
            this.Status = statusBug;
            this.StepsToReproduce = new List<string>();
            this.Assignee = null;
        }


        public IList<string> StepsToReproduce { get; }


        public Priority Priority
        {
            get
            {
                return this.priority;
            }
            set
            {
                this.priority = value;
            }

        }

        public Severity Severity
        {
            get
            {
                return this.severity;
            }
            set
            {
                this.severity = value;
            }
        }

        public StatusBug Status
        {
            get
            {
                return this.statusBug;
            }
            set
            {
                this.statusBug = value;
            }
        }


        public IMember Assignee
        {
            get
            {
                return this.assignee;
            }
            set
            {
                this.assignee = value;
            }
        }
    }
}
