﻿using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Models;

namespace Wims.Core.Commands
{
    public class ListFilterAllItemsCommand : Command
    {
        public ListFilterAllItemsCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
            base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var allItems = this.WorkItemProvider.WorkItems;


            if (allItems.Count == 0)
            {
                throw new ArgumentException("No workitems added!");

            }

            var filterItems = this.CommandParameters[0];
            var bugs = allItems.Where(b => b.GetType().Name == "Bug");
            var stories = allItems.Where(b => b.GetType().Name == "Story");
            var feedbacks = allItems.Where(b => b.GetType().Name == "Feedback");

            if (this.CommandParameters[0] == "bug")
            {
                foreach (var bug in bugs)
                {
                    builder.AppendLine(bug.Print());
                }
            }
            if (this.CommandParameters[0] == "stories")
            {
                foreach (var story in stories)
                {
                    builder.AppendLine(story.Print());
                }
            }
            if (this.CommandParameters[0] == "feedback")
            {
                foreach (var feedback in feedbacks)
                {
                    builder.AppendLine(feedback.Print());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}