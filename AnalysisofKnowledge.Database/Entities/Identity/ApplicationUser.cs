using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using DelegateDecompiler;
using Microsoft.AspNetCore.Identity;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>, IApplicationUser, IIdentityEntity
    {
        public string Education { get; set; }

        public ushort? GroupId { get; set; }

        public long FacultyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public DateTimeOffset LastUpdateTime { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        [NotMapped] [Computed] public string FullName =>
            string.Format((string.IsNullOrEmpty(LastName) ? string.Empty : LastName)
                          + (string.IsNullOrEmpty(FirstName) ? string.Empty : $"\t{FirstName}")
                          + (string.IsNullOrEmpty(Patronymic) ? string.Empty : $"\t{Patronymic}"),
                CultureInfo.InvariantCulture);
    }
}