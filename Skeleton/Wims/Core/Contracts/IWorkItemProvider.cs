﻿using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    public interface IWorkItemProvider
    {
        IReadOnlyList<IWorkItem> WorkItems { get; }

        void Add(IWorkItem item);

    }
}