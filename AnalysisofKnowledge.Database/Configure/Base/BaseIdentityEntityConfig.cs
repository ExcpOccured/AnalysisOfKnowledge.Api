using AnalysisofKnowledge.Database.Entities.Interfaces;
using AnalysisofKnowledge.Database.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Base
{
    public class BaseIdentityEntityConfig<TIdentityEntity> : BaseEntityConfig<TIdentityEntity>
        where TIdentityEntity : class
    {
        // TODO: Localize 
        private const string ExceptionMessage = "The entity must implement the IApplicationUser interface";

        public override void Configure(EntityTypeBuilder<TIdentityEntity> builder)
        {
            base.Configure(builder);

            if (typeof(TIdentityEntity).IsAssignableFrom(typeof(IApplicationUser)))
            {
                builder.HasMany(_ => ((IApplicationUser) _).UserRoles)
                    .WithOne(_ => (TIdentityEntity) (object) _.User)
                    .HasForeignKey(_ => _.UserId);
            }
            else
            {
                throw new InvalidEntityTypeConfigureException(ExceptionMessage);
            }
        }
    }
}