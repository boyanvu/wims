using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    interface IMemberProvider
    {
        IReadOnlyList<IMember> Members { get; }

        void Add(IMember member);

    }
}
