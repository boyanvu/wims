﻿using Wims.Models;
using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Core.Factories
{
    public class WimsFactory : IWimsFactory
    {
      
        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public Bug CreateBug(string title, string description, Priority priority, Severity severity)
        {
            return new Bug(title, description, priority, severity);
        }

        public Story CreateStory(string title, string description, Priority priority, Size size, StatusStory status)
        {
            return new Story(title, description, priority, size, status);
        }

        public Feedback CreateFeedback(string title, string description, int rating)
        {
            return new Feedback(title, description, rating);
        }

        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }

        public Comment CreateComment(string author, string message)
        {
            return new Comment(author, message);
        }
    }
}
