﻿using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    public interface ITeamProvider
    {
        IReadOnlyList<ITeam> Teams { get; }

        void Add(ITeam team);
    }
}