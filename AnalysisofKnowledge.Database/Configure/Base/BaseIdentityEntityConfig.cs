using System;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using AnalysisofKnowledge.Database.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Base
{
    public class BaseIdentityEntityConfig<TIdentityEntity, TKey> : BaseEntityConfig<TIdentityEntity, TKey>
        where TIdentityEntity : class
        where TKey : struct, IEquatable<TKey>
    {
        // TODO: Localize 
        private const string ExceptionMessage = "The entity must implement the IIdentityEntity interface";

        public override void Configure(EntityTypeBuilder<TIdentityEntity> builder)
        {
            base.Configure(builder);

            if (!typeof(TIdentityEntity).IsAssignableFrom(typeof(IIdentityEntity)))
            {
                throw new InvalidEntityTypeConfigureException(ExceptionMessage);
            }

            builder.HasMany(_ => ((IIdentityEntity) _).UserRoles)
                .WithOne(_ => (TIdentityEntity) (object) _.User)
                .HasForeignKey(_ => _.UserId);
        }
    }
}