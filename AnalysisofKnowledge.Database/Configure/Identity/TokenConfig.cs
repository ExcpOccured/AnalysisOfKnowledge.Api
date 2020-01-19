using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Identity
{
    public class TokenConfig : BaseEntityConfig<Token>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasOne(_ => _.User)
                .WithOne()
                .HasForeignKey<Token>(_ => _.UserId);

            builder.HasIndex(_ => _.UserId)
                .IsUnique(false);
            
            base.Configure(builder);
        }
    }
}