using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    public interface IMemberProvider
    {
        IReadOnlyList<IMember> Members { get; }

        void Add(IMember member);

    }
}
