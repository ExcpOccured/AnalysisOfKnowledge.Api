using System;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Base
{
    public class BaseIdentityEntityConfig<TIdentityEntity, TKey> : BaseEntityConfig<TIdentityEntity, TKey>
        where TIdentityEntity : class, IIdentityEntity
        where TKey : struct, IEquatable<TKey>
    {
        public override void Configure(EntityTypeBuilder<TIdentityEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(identityEntity => identityEntity.UserRoles)
                .WithOne(userRole => (TIdentityEntity) (object) userRole.User)
                .HasForeignKey(userRole => userRole.UserId);
        }
    }
}