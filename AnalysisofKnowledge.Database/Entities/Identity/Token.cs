using System;
using AnalysisofKnowledge.Database.Entities.Base;
using AnalysisofKnowledge.Database.Entities.Interfaces;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class Token : Entity, IHasCreateDate
    {
        public long UserId { get; set; }

        public string RefreshToken { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ExpiryAt { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}