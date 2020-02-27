﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Core.Abstracts;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Models.Contracts;

namespace Wims.Core.Commands
{
    public class AddCommentCommand : Command
    {
        public AddCommentCommand(IList<string> commandLine, IMemberProvider memberProvider)
            : base(commandLine)
        {
            this.MemberProvider = memberProvider;
        }


        public IMemberProvider MemberProvider { get; }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 3)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var workItemTitle = this.CommandParameters[0];
            var memberName = this.CommandParameters[1];
            var message = this.CommandParameters[2];
            var currBoardItems = CurrentVariables.currentBoard.WorkItems;


            if (currBoardItems.Count == 0)
            {
                throw new ArgumentException("No items in this board!");
            }

            var findMember = CurrentVariables.currentTeam.Members.FirstOrDefault(m => m.Name == memberName) ??
                throw new ArgumentException($"Member with name {memberName} does not exist in team {CurrentVariables.currentTeam.Name}.");

            var findItem = currBoardItems.FirstOrDefault(i => i.Title == workItemTitle) ??
                throw new ArgumentException($"Work item with title {workItemTitle} does not exist in board {CurrentVariables.currentBoard.Name}.");

            var newComment = this.Factory.CreateComment(findMember.Name, message);

            findItem.AddComment(newComment);


            return newComment.ToString().TrimEnd(); ;
        }
    }
}
