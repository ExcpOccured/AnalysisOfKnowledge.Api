using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using DelegateDecompiler;
using Microsoft.AspNetCore.Identity;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }
        
        [NotMapped]
        [Computed]
        public string FullName =>
            string.Format((string.IsNullOrEmpty(LastName) ? string.Empty : LastName)
            + (string.IsNullOrEmpty(FirstName) ? string.Empty : $"\t{FirstName}")
            + (string.IsNullOrEmpty(Patronymic) ? string.Empty : $"\t{Patronymic}"), CultureInfo.InvariantCulture);
    }
}