using System;

namespace AnalysisofKnowledge.Database.Exceptions
{
    public class InvalidEntityTypeConfigureException : Exception
    {
        // TODO: Localize
        private const string ExceptionMessage = "The entity must implement the IEntity interface";
        
        public InvalidEntityTypeConfigureException(string message = ExceptionMessage) : base(message) { }
    }
}