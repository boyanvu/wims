using System;
using System.Collections.Generic;
using System.Text;
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
            Severity severity, StatusBug statusBug, IMember assignee);

    }
}
