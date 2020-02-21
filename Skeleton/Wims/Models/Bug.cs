﻿using Wims.Models.Common;
using System;
using System.Collections.Generic;
using Wims.Models.Contracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Models
{
    public class Bug : WorkItem, IBug, IAssignable
    {
        private Priority priority;
        private Severity severity;
        private StatusBug statusBug;
        private IMember assignee;


        public Bug(string title, string description, Priority priority, Severity severity)
            : base(title, description)
        {
            this.Priority = priority;
            this.Severity = severity;
            this.Status = StatusBug.Active;
            this.StepsToReproduce = new List<string>();
            this.Assignee = null;
        }


        public IList<string> StepsToReproduce { get; set; }


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

        public override string Print()
        {
            var assigneeName = this.Assignee == null ? "-" : this.Assignee.Name;
            var stepsToReprod = string.Join(">", this.StepsToReproduce);

            return $"{this.GetType().Name}:{Environment.NewLine}  " +
                $"Title: {this.Title}{Environment.NewLine}  " +
                $"Description: {this.Description}{Environment.NewLine}  " +
                $"Steps to reproduce: {stepsToReprod}{Environment.NewLine}  " +
                $"Priority: {this.Priority}{Environment.NewLine}  " +
                $"Severity: {this.Severity}{Environment.NewLine}  " +
                $"Status: {this.Status}{Environment.NewLine}  " +
                $"Assignee: {assigneeName} ";
        }
    }
}
