using System;
using Wims.Models.Common;

namespace Wims.Core.Providers
{
    public static class ValidateEnums
    {
    /// <summary>
    /// Here user input for enums is converted from string to enum. If the string is not valid exception is thrown.
    /// </summary>
    /// <param name="priority">string that should be within one of the bellow enums</param>
    /// <returns></returns>
        public static Priority ValidatePriority(string priority)
        {
            switch (priority.ToLower())
            {
                case "high":
                    return Priority.High;
                case "medium":
                    return Priority.Medium;
                case "low":
                    return Priority.Low;
                default:
                    throw new InvalidOperationException("InvalidBugPriorityType! Bug priority must be high, medium or low!");
            }
        }

        public static Size ValidateStorySize(string size)
        {
            switch (size.ToLower())
            {
                case "large":
                    return Size.Large;
                case "medium":
                    return Size.Medium;
                case "small":
                    return Size.Small;
                default:
                    throw new InvalidOperationException("Invalid story size! Story size must be large, medium or small!");
            }
        }

        public static Severity ValidateSeverity(string severity)
        {
            switch (severity.ToLower())
            {
                case "critical":
                    return Severity.Critical;
                case "major":
                    return Severity.Major;
                case "minor":
                    return Severity.Minor;
                default:
                    throw new InvalidOperationException("InvalidBugSeverityType! Bug severity must be critical, major or minor!");
            }
        }

        public static StatusBug ValidateStatusBug(string status)
        {
            switch (status.ToLower())
            {
                case "active":
                    return StatusBug.Active;
                case "fixed":
                    return StatusBug.Fixed;
                default:
                    throw new InvalidOperationException("InvalidBugStatusType! Bug status must be active or fixed!");
            }
        }

        public static StatusStory ValidateStatusStory(string status)
        {
            switch (status.ToLower())
            {
                case "notdone":
                    return StatusStory.NotDone;
                case "inprogress":
                    return StatusStory.InProgress;
                case "done":
                    return StatusStory.Done;
                default:
                    throw new InvalidOperationException("InvalidStoryStatusType! Story status must be NotDone,InProgress or Done!");
            }
        }

        public static StatusFeedback ValidateStatusFeedback(string status)
        {
            switch (status.ToLower())
            {
                case "new":
                    return StatusFeedback.New;
                case "unscheduled":
                    return StatusFeedback.Unscheduled;
                case "scheduled":
                    return StatusFeedback.Scheduled;
                case "done":
                    return StatusFeedback.Done;
                default:
                    throw new InvalidOperationException("InvalidFeedbackStatusType! Feedback status must be New, Unscheduled, Scheduled or Done!");
            }
        }
    }
}
