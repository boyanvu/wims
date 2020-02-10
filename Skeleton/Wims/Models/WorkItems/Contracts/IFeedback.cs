using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Common;

namespace Wims.Models.Contracts
{
    public interface IFeedback
    {
        int Rating { get; }
        StatusFeedback Status { get; }
    }
}
