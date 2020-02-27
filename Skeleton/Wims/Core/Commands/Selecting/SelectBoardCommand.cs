using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;

namespace Wims.Core.Commands
{
    public class SelectBoardCommand : Command
    {
        /// <summary>
        /// Current board is set with this command
        /// </summary>
        /// <param name="commandLine">One parameter - name of the board that should be set as current</param>
        public SelectBoardCommand(IList<string> commandLine)
            : base(commandLine)
        {
        }

        public override string Execute()
        {
            var currTeam = Commons.currentTeam;
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
                return $"There's no any board to select from in team {currTeam.Name}!{Environment.NewLine} " +
                    $"You can create it with command: createboard {boardToSelect}.";
            }
     
            var findBoard = currTeam.Boards.FirstOrDefault(b => b.Name == boardToSelect);

            Commons.currentBoard = findBoard ?? throw new Exception($"{boardToSelect} does not exist in team" +
                    $" {currTeam.Name}.{Environment.NewLine} You can create it with command: createboard {boardToSelect}.");

            return $"Board {boardToSelect} selected";
         
        }
    }
}

