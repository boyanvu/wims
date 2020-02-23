using System;
using System.Linq;
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

        public static IWorkItem GetWorkItem(string workItemTitle, string workItemType)
        {

            var currBoardItems = CurrentVariables.currentBoard.WorkItems;
            var teamWorkItemsOfType = currBoardItems.Where(b => b.GetType().Name == workItemType);

            var workItem = teamWorkItemsOfType.FirstOrDefault(b => b.Title == workItemTitle);
            if (workItem == null)
            {
                throw new ArgumentException
                    ($"There's no work item {workItemTitle} of type {workItemType} in board {CurrentVariables.currentBoard.Name}.");
            }

            return workItem;
        }

        public static ITeam currTeamValid()
        {
            if (currentTeam == null)
            {
                var msg = $"No team currently selected." + Environment.NewLine +
                          $"You can use one of following commands:" + Environment.NewLine +
                          $"createteam <teamname>, selectteam <teamname>, listteams";
                throw new Exception(msg);
            }
            return currentTeam;
        }

        public static IBoard currBoardValid()
        {
            if (currentBoard == null)
            {
                var msg = $"No board currently selected." + Environment.NewLine +
                          $"You can use one of the following commands:" + Environment.NewLine +
                          $"createboard <boardname>, selectboard <boardname>, listallboards";
                throw new Exception(msg);
            }
            return currentBoard;
        }
    }
}