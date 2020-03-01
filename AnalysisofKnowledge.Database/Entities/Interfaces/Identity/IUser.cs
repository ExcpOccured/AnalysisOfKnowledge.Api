using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using DelegateDecompiler;

namespace AnalysisofKnowledge.Database.Entities.Interfaces.Identity
{
    public interface IUser
    {
        string FirstName { get; }

        string LastName { get; }

        string Patronymic { get; }

        [NotMapped]
        [Computed]
        string FullName =>
            string.Format((string.IsNullOrEmpty(LastName) ? string.Empty : LastName)
                          + (string.IsNullOrEmpty(FirstName) ? string.Empty : $"\t{FirstName}")
                          + (string.IsNullOrEmpty(Patronymic) ? string.Empty : $"\t{Patronymic}"),
                CultureInfo.InvariantCulture);
    }
}