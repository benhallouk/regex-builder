using Regex.Domain.Pattern;
using System.Data.Entity;

namespace Regex.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Pattern> Patterns { get; set; }

        void Save();
    }
}
