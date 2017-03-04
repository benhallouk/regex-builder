using Moq;
using Regex.Application.Interfaces;
using Regex.Domain.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.Specification.Common
{
    public class DatabaseInitializer
    {
        private readonly Mock<IDatabaseService> _mockDatabase;

        public DatabaseInitializer(Mock<IDatabaseService> mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public void Seed()
        {
            var patterns = new InMemoryDbSet<Pattern>();

            var pattern = new Pattern
            {
                Id = 1,
                Title = "name",
                Description = "description",
                Template = "pattern"
            };

            patterns.Add(pattern);

            _mockDatabase.Setup(p => p.Patterns).Returns(patterns);
        }
    }
}
