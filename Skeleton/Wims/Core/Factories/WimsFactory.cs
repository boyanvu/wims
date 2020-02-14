using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models;
using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Core.Factories
{
    public class WimsFactory : IWimsFactory
    {
      
        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public Bug CreateBug(string title, string description, Priority priority, Severity severity, StatusBug statusBug, IMember assignee)
        {
            var bugPriority = (Priority)Enum.Parse(typeof(Priority), priority.ToString());
            var bugSeverity = (Severity)Enum.Parse(typeof(Severity), severity.ToString());
            var bugStatus = (StatusBug)Enum.Parse(typeof(StatusBug), statusBug.ToString());

            return new Bug(title, description, bugPriority, bugSeverity, bugStatus, assignee);
        }

        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
