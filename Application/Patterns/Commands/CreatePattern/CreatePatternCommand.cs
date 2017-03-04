using Regex.Application.Patterns.Commands.CreatePattern.Models;
using Regex.Application.Interfaces;
using Regex.Domain.Pattern;
using Regex.Application.Patterns.Commands.CreatePattern.Factory;

namespace Regex.Application.Patterns.Commands.CreatePattern
{
    public class CreatePatternCommand : ICreatePatternCommand
    {
        private readonly IDatabaseService _database;
        private readonly IPatternFactory _factory;

        public CreatePatternCommand(IDatabaseService database, IPatternFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(CreatePatternModel model)
        {
            var pattern = _factory.Create(
               model.Title,
               model.Description,
               model.Template);

            _database.Patterns.Add(pattern);

            _database.Save();            
        }
    }
}
