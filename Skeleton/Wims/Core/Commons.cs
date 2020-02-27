using System;
using System.Linq;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Core
{
    public static class Commons
    {
        public static ITeam currentTeam;
        public static IBoard currentBoard;


        //Returns the current team and board where the program works in
        public static string CurrentPosition()
        {
            var currTeam = currentTeam != null ? currentTeam.Name : "NotSelected";
            var currBoard = currentBoard != null ? currentBoard.Name : "NotSelected";
            var currPos = $" - Team: { currTeam } | Board: {currBoard} - " + Environment.NewLine + "-------------------";
            return currPos;
        }


        //Adds to the work item history
        public static void AddToWIHistory(IWorkItem item)
        {
            item.History.Add($"{item.Title} {item.GetType().Name.ToLower()} created in {Commons.currentBoard.Name}");
        }

        //Adds all item histories in their board history
        public static string AddToBoardHistory(IBoard board)
        {
            var builder = new StringBuilder();
            foreach (var itemHistory in board.WorkItems)
            {
                builder.AppendLine(string.Join(Environment.NewLine, itemHistory.History));
            }
            return builder.ToString().TrimEnd();
        }

        //Adds all boards and members history to their team history
        public static string GetTeamHistory(ITeam team)
        {
            var builder = new StringBuilder();
            foreach (var board in team.Boards)
            {
                builder.AppendLine(string.Join(Environment.NewLine, AddToBoardHistory(board)));
            }
            foreach (var member in team.Members)
            {
                builder.AppendLine(string.Join(Environment.NewLine, member.History));
            }
            return builder.ToString().TrimEnd();
        }


        //Returns the current work item by his title and type
        public static IWorkItem GetWorkItem(string workItemTitle, string workItemType)
        {

            var currBoardItems = Commons.currentBoard.WorkItems;
            var teamWorkItemsOfType = currBoardItems.Where(b => b.GetType().Name == workItemType);

            var workItem = teamWorkItemsOfType.FirstOrDefault(b => b.Title == workItemTitle);
            if (workItem == null)
            {
                throw new ArgumentException
                    ($"There's no work item {workItemTitle} of type {workItemType} in board {Commons.currentBoard.Name}.");
            }

            return workItem;
        }


        //Returns the current team 
        public static ITeam CurrTeamValid()
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


        //Returns the current board
        public static IBoard CurrBoardValid()
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

        //Returns a message after executing the createbugcommand
        public static string CreateBugText()
        {
            var msg = Environment.NewLine + "You can now add comment or steps to reproduce using the following commands:" + Environment.NewLine +
                       "addstepstobug <bugTitle> <firststep> > <secondstep> .... || addcomment <workItemTitle> <memberName> <message>!" + Environment.NewLine +
                       "You can also modify bug with modifybug <bugTitle> <status/severity/priority> <newValue>!";
            return msg;
        }

        //Returns a message after executing the createstorycommand
        public static string CreateStoryText()
        {
            var msg = Environment.NewLine + "You can modify the story using the following commands:" + Environment.NewLine +
                       "modifystory <storyTitle> <status/size/priority> <newValue>!";
            return msg;
        }

        //Returns a message after executing the createfeedbackcommand
        public static string CreateFeedbackText()
        {
            var msg = Environment.NewLine + "You can modify the feedback using the following commands:" + Environment.NewLine +
                       "modifyfeedback <feedbackTitle> <rating/status> <newValue>!";
            return msg;
        }

        //Returns a message after executing the createteamcommand
        public static string CreateTeamText()
        {
            var msg = Environment.NewLine + "You can now create a member or a board in the team using the following commands:" + Environment.NewLine +
                       "createmember <memberName> || createboard <boardName>!";
            return msg;
        }

        //Returns a message after executing the createboardcommand
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