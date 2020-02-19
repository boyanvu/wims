using System;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Core
{
    public static class CurrentVariables
    {
        public static ITeam currentTeam;
        public static IBoard currentBoard;
        public static string CurrentPosition()
        {
            var currTeam = currentTeam != null ? currentTeam.Name : "NotSelected";
            var currBoard = currentBoard != null ? currentBoard.Name : "NotSelected";
            var currPos = $" - Team: { currTeam } | Board: {currBoard} - " + Environment.NewLine + "-------------------";
            return currPos;
        }


        public static void AddToWIHistory(IWorkItem item)
        {
            item.History.Add($"{item.Title} {item.GetType().Name.ToLower()} created in {CurrentVariables.currentBoard.Name}");
        }


        public static void AddToBoardHistory(IBoard board, IWorkItem item)
        {
            foreach (var itemHistory in item.History)
            {
                board.History.Add(itemHistory);
            }
        }

        public static string GetTeamHistory(ITeam team)
        {
            var builder = new StringBuilder();
            foreach (var board in team.Boards)
            {
                builder.AppendLine(string.Join(Environment.NewLine, board.History));
            }
            foreach (var member in team.Members)
            {
                builder.AppendLine(string.Join(Environment.NewLine, member.History));
            }
            return builder.ToString().TrimEnd();
        }
    }
}