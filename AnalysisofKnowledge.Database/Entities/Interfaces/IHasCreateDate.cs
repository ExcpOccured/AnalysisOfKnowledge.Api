using System;

namespace AnalysisofKnowledge.Database.Entities.Interfaces
{
    public interface IHasCreateDate
    {
        DateTimeOffset CreatedAt { get; }

        DateTimeOffset ExpiryAt { get; }
    }
}