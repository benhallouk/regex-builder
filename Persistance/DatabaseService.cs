using System;
using System.Data.Entity;
using Regex.Application.Interfaces;
using Regex.Domain.Pattern;
using Regex.Persistance.Patterns;

namespace Regex.Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<Pattern> Patterns { get; set; }

        public DatabaseService() : base("RegexDB")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PatternConfiguration());            
        }
    }
}
