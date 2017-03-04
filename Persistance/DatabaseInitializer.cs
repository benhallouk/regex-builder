using Regex.Domain.Pattern;
using System.Data.Entity;

namespace Regex.Persistance
{
    public class DatabaseInitializer: CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);
            CreatePatterns(database);
        }

        private void CreatePatterns(DatabaseService database)
        {
            database.Patterns.Add(new Pattern() { Title = "Any upper letter", Template = "[A-Z]" });

            database.SaveChanges();
        }
    }
}
