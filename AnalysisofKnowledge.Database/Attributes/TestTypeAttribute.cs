using System;
using AnalysisofKnowledge.Database.Entities.Enum;

namespace AnalysisofKnowledge.Database.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestTypeAttribute : Attribute
    {
        public TestTypeAttribute(TestType testType)
        {
            TestType = testType;
        }

        public TestType TestType { get; }
    }
}