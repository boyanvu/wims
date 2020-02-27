using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    public interface IMemberProvider
    {
        IReadOnlyList<IMember> Members { get; }

        void Add(IMember member);

        IMember Find(string name);

    }
}
