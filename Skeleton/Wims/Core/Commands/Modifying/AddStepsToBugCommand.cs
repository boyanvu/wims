using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Models;

namespace Wims.Core.Commands.Modifying
{
    public class AddStepsToBugCommand : Command
    {
        public AddStepsToBugCommand(IList<string> commandLine)
            : base(commandLine)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count! < 2)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }
            var titleOfBug = this.CommandParameters[0];
            var toBeSet = string.Join(" ", this.CommandParameters.Skip(1)).Split(">").ToList();

            var bugToModify = Commons.GetWorkItem(titleOfBug, "Bug") as Bug;

            bugToModify.StepsToReproduce = toBeSet;

            return $"Steps to reproduce have been added to bug {titleOfBug}.";
        }
    }
}
