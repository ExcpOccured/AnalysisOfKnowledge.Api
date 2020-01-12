using System;

namespace AnalysisofKnowledge.Database.Entities.Enum
{
    [Flags]
    public enum TestType
    {
        Activity = 1,
        
        Languages = 1 << 1,
        
        Reflexivity = 1 << 2,
        
        Selfgovernment  = 1 << 3,
        
        Socialization = 1 << 4
    }
}