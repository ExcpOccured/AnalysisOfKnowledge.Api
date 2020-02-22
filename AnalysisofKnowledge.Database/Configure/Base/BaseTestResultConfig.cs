using System;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using AnalysisofKnowledge.Database.Exceptions;
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
        where TTestResult : class
    {
        // TODO: Localize 
        private const string ExceptionMessage = "The entity must implement the IBaseTestResult interface";

        public override void Configure(EntityTypeBuilder<TTestResult> builder)
        {
            base.Configure(builder);

            if (typeof(TTestResult).IsAssignableFrom(typeof(IBaseTestResult)))
            {
                builder.Property(_ => ((IBaseTestResult) _).Score).IsRequired();
            }
            else
            {
                throw new InvalidEntityTypeConfigureException(ExceptionMessage);
            }
        }
    }
}