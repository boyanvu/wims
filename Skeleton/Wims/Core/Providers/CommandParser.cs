using Wims.Core.Contracts;
using System;
using System.Linq;
using Wims.Core.Abstracts;
using Wims.Core.Commands;
using Wims.Core.Providers.Wims.Core.Providers;

namespace Wims.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        // Every command gets the same instance of OlympicCommittee
        private static readonly ITeamProvider teamProvider = new TeamProvider();
        private static readonly IBoardProvider boardProvider = new BoardProvider();
        private static readonly IMemberProvider memberProvider = new MemberProvider();

        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0];
            var parameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
                "createteam" => new CreateTeamCommand(parameters, teamProvider),
                "createboard" => new CreateBoardCommand(parameters, boardProvider),
                "createmember" => new CreateMemberCommand(parameters, memberProvider),
                "selectteam" => new SelectTeamCommand(parameters, teamProvider),
                "listteams" => new ListTeamsCommand(parameters, teamProvider),
                "listallmembers" => new ListAllMembersCommand(parameters, memberProvider),
                "listteammembers" => new ListAllTeamMembersCommand(parameters, teamProvider),

                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
