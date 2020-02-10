using System;
using System.Collections.Generic;
using System.Text;
using Agency.Models.Common;

namespace Agency.Models.Contracts
{
    public interface IFeedback
    {
        int Rating { get; }
        StatusFeedback Status { get; }
    }
}
