using Regex.Domain.Pattern;

namespace Regex.Application.Patterns.Commands.CreatePattern.Factory
{
    public interface IPatternFactory
    {
        Pattern Create(string title, string description, string template);
    }
}
