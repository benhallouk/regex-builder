using Regex.Application.Patterns.Commands.CreatePattern.Models;

namespace Regex.Application.Patterns.Commands.CreatePattern
{
    public interface ICreatePatternCommand
    {
        void Execute(CreatePatternModel model);
    }
}
