using System;
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
    }
}