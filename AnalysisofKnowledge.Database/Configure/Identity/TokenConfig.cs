using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Identity
{
    public class TokenConfig : BaseEntityConfig<Token, long>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasOne(applicationUser => applicationUser.User)
                .WithOne()
                .HasForeignKey<Token>(token => token.UserId);

            builder.HasIndex(token => token.UserId)
                .IsUnique(false);
            
            base.Configure(builder);
        }
    }
}