
using Wims.Core.Contracts;
using Wims.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wims.Core.Abstracts;
using Wims.Core.Commands;

namespace Wims.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        // Every command gets the same instance of OlympicCommittee
        private static readonly ITeamProvider teamProvider = new TeamProvider();
        private static readonly IBoardProvider boardProvider = new BoardProvider();

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
                //"listolympians" => new ListOlympiansCommand(parameters, olympicCommittee),

                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
