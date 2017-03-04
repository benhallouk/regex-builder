using Regex.Domain.Pattern;
using System.Data.Entity.ModelConfiguration;

namespace Regex.Persistance.Patterns
{
    public class PatternConfiguration : EntityTypeConfiguration<Pattern>
    {
        public PatternConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Title).IsRequired();
            Property(p => p.Template).IsRequired();            
        }
    }
}
