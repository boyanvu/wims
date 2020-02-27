using System;

namespace Wims.Models.WorkItems.Contracts
{
    public interface IComment
    {
        string Author { get; set; }

        string Message { get; set; }

        DateTime CreatedOn { get; }


    }
}
