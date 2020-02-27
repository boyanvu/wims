using System.Collections.Generic;
using System.Linq;
using Wims.Core.Contracts;
using Wims.Models.Contracts;

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

        public IMember Find(string name)
        {
            var member = members.FirstOrDefault(m => m.Name == name);
            return member;
        }
    }
}


