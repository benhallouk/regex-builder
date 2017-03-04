using System;
using Regex.Domain.Pattern;

namespace Regex.Application.Patterns.Commands.CreatePattern.Factory
{
    public class PatternFactory : IPatternFactory
    {

        public Pattern Create(string title, string description, string template)
        {
            return new Pattern
            {
                Title = title,
                Description = description,
                Template = template
            };
        }
    }
}
