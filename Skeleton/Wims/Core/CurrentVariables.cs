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

        public static string CreateBugText()
        {
            var msg = Environment.NewLine + "You can now add comment or steps to reproduce using the following commands:" + Environment.NewLine +
                       "addstepstobug <bugTitle> <firststep> > <secondstep> .... || addcomment <workItemTitle> <memberName> <message>!" + Environment.NewLine +
                       "You can also modify bug with modifybug <bugTitle> <status/severity/priority> <newValue>!";
            return msg;
        }


        public static string CreateStoryText()
        {
            var msg = Environment.NewLine + "You can modify the story using the following commands:" + Environment.NewLine +
                       "modifystory <storyTitle> <status/size/priority> <newValue>!";
            return msg;
        }

        public static string CreateFeedbackText()
        {
            var msg = Environment.NewLine + "You can modify the feedback using the following commands:" + Environment.NewLine +
                       "modifyfeedback <feedbackTitle> <rating/status> <newValue>!";
            return msg;
        }

        public static string CreateTeamText()
        {
            var msg = Environment.NewLine + "You can now create a member or a board in the team using the following commands:" + Environment.NewLine +
                       "createmember <memberName> || createboard <boardName>!";
            return msg;
        }

        public static string CreateBoardText()
        {
            var msg = Environment.NewLine + "You can now create a workitem in the board using the following commands:" + Environment.NewLine +
                       "createbug <bugTitle> <bugDescription> <bugPriority> <bugSeverity>!" + Environment.NewLine +
                       "createstory <storyTitle> <storyDescription> <storyPriority> <storySize>!" + Environment.NewLine +
                       "createfeedback <feedbackTitle> <feedbackDescription> <feedbackRating>";

            return msg;
        }
    }
}