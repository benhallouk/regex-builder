using Regex.Domain.Common;

namespace Regex.Domain.Pattern
{
    public class Pattern : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
    }
}
