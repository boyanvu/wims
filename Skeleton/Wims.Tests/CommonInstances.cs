using System.Collections.Generic;
using System.Linq;
using Wims.Core;
using Wims.Core.Contracts;
using Wims.Models;
using Wims.Models.Contracts;

namespace Wims.Tests.Commands.Test
{
    public static class CommonInstances
    {

        public const string fakeMemberName = "TestMemberName";
        public const string fakeWiTitle = "WorkItemTitle";
        public static void CreateTestInstances()
        {
            Commons.currentTeam = new Team("TeamName");
            Commons.currentBoard = new Board("BoardName");
            Commons.currentTeam.Boards.Add(Commons.currentBoard);
        }
    }

    public class FakeWorkItemProvider : IWorkItemProvider
    {
        private readonly List<IWorkItem> workItems = new List<IWorkItem>();
        public IReadOnlyList<IWorkItem> WorkItems => workItems;

        public void Add(IWorkItem item)
        {
            workItems.Add(item);
        }

        public IWorkItem Find(string title)
        {
            var wi = workItems.FirstOrDefault(m => m.Title == title);
            return wi;
        }
    }

    public class FakeMemberProvider : IMemberProvider
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

    public class FakeBoardProvider : IBoardProvider
    {
        private readonly List<IBoard> boards = new List<IBoard>();

        public IReadOnlyList<IBoard> Boards
        {
            get
            {
                return this.boards;
            }
        }

        public void Add(IBoard board)
        {
            boards.Add(board);
        }

        public IBoard Find(string name)
        {
            var board = boards.FirstOrDefault(b => b.Name == name);
            return board;
        }
    }

    public class FakeTeamProvider : ITeamProvider
    {
        private List<ITeam> teams => new List<ITeam>();

        public IReadOnlyList<ITeam> Teams => teams;

        public void Add(ITeam team)
        {
            teams.Add(team);
        }

        public ITeam Find(string name)
        {
            var team = teams.FirstOrDefault(t => t.Name == name);
            return team;
        }
    }
}