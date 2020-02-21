﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class SelectBoardCommand : Command
    {
        public SelectBoardCommand(IList<string> commandLine)
            : base(commandLine)
        {
        }

        public override string Execute()
        {
            var currTeam = CurrentVariables.currentTeam;
            if (currTeam == null)
            {
                var msg = $"You have to select/create team before board selection." + Environment.NewLine +
                          $"You can you use one of these commands:" + Environment.NewLine +
                          $"createteam <teamname>, selectteam <teamname>, listteams";
                throw new Exception(msg);
            }

            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var boardToSelect = this.CommandParameters[0];

            if (currTeam.Boards.Count == 0)
            {
                return $"There's no any board to select from in team {currTeam.Name}!{Environment.NewLine} You can create it with command: createboard {boardToSelect}.";
            }

            foreach (var board in currTeam.Boards) //TODO Linq
            {
                if (board.Name == boardToSelect)
                {
                    CurrentVariables.currentBoard = board;
                    return $"Board {boardToSelect} selected";
                }
            }

            return $"{boardToSelect} does not exists in team {currTeam.Name}.{Environment.NewLine} You can create it with command: createboard {boardToSelect}.";
        }
    }
}
