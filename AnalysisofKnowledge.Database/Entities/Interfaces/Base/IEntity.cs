using System;

namespace AnalysisofKnowledge.Database.Entities.Interfaces.Base
{
    public interface IEntity<out TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; }
    }
}