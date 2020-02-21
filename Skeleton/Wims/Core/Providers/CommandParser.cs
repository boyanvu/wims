﻿using Wims.Core.Contracts;
using System;
using System.Linq;
using Wims.Core.Abstracts;
using Wims.Core.Commands;
using Wims.Core.Providers.Wims.Core.Providers;
using Wims.Core.Commands.Modifying;

namespace Wims.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        // Every command gets the same instance of OlympicCommittee
        private static readonly ITeamProvider teamProvider = new TeamProvider();
        private static readonly IBoardProvider boardProvider = new BoardProvider();
        private static readonly IMemberProvider memberProvider = new MemberProvider();
        private static readonly IWorkItemProvider workItemProvider = new WorkItemProvider();

        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0].ToLower();
            var parameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
                "createteam" => new CreateTeamCommand(parameters, teamProvider),
                "createboard" => new CreateBoardCommand(parameters, boardProvider),
                "createmember" => new CreateMemberCommand(parameters, memberProvider),
                "selectteam" => new SelectTeamCommand(parameters, teamProvider),
                "selectboard" => new SelectBoardCommand(parameters),
                "listteams" => new ListTeamsCommand(parameters, teamProvider),
                "listallmembers" => new ListAllMembersCommand(parameters, memberProvider),
                "listallteammembers" => new ListAllTeamMembersCommand(parameters, teamProvider),
                "listallboards" => new ListAllBoardsCommand(parameters, boardProvider),
                "listallteamboards" => new ListAllTeamBoardsCommand(parameters, boardProvider),
                "createbug" => new CreateBugCommand(parameters, workItemProvider),
                "createstory" => new CreateStoryCommand(parameters, workItemProvider),
                "createfeedback" => new CreateFeedbackCommand(parameters, workItemProvider),
                "listallteamitems" => new ListAllTeamItemsCommand(parameters, workItemProvider),
                "modifybug" => new ModifyBugCommand(parameters, workItemProvider),
                "modifystory" => new ModifyStoryCommand(parameters, workItemProvider),
                "modifyfeedback" => new ModifyFeedbackCommand(parameters, workItemProvider),
                "listallitems" => new ListAllItemsCommand(parameters, workItemProvider),
                "listfilterallitems" => new ListFilterAllItemsCommand(parameters, workItemProvider),
                "assign" => new AssignCommand(parameters),
                "unassign" => new UnassignCommand(parameters),
                "viewworkitemhistory" => new ViewWorkItemHistoryCommand(parameters, workItemProvider),
                "viewboardhistory" => new ViewBoardHistoryCommand(parameters, boardProvider),
                "viewmemberhistory" => new ViewMemberHistoryCommand(parameters, memberProvider),
                "viewteamhistory" => new ViewTeamHistoryCommand(parameters, teamProvider),
                "addstepstobug" => new AddStepsToBug(parameters),

                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
