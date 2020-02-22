using AnalysisofKnowledge.Database.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Base
{
    /// <summary>
    /// Basic Fluent API configuration of an entity that implements IBaseTestResult
    /// </summary>
    /// <typeparam name="TTestResult">
    /// Entity that implements the IBaseTestResult interface
    /// </typeparam>
    public class BaseTestResultConfig<TTestResult> : BaseEntityConfig<TTestResult, long>
        where TTestResult : class, IBaseTestResult
    {
        public override void Configure(EntityTypeBuilder<TTestResult> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Score).IsRequired();
        }
    }
}