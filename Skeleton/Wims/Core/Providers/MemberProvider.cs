using System;
using System.Collections.Generic;
using System.Text;

namespace Wims.Core.Providers
{
    using global::Wims.Core.Contracts;
    using global::Wims.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    namespace Wims.Core.Providers
    {
        public class MemberProvider : IMemberProvider
        {
            private readonly List<IMember> members = new List<IMember>();

            public IReadOnlyList<IMember> Members
            {
                get
                {
                    return this.members;
                }
            }

            public void Add(IMember member)
            {
                members.Add(member);
            }
        }
    }

}
