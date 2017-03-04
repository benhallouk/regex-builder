using NUnit.Framework;

namespace Regex.Application.Patterns.Commands.CreatePattern.Factory
{
    [TestFixture]
    public class PatternFactoryTests
    {
        private readonly PatternFactory _factoryPattern;
        private const string Title = "Title";
        private const string Description = "Description";
        private const string Template = "Template";



        public PatternFactoryTests()
        {
            _factoryPattern = new PatternFactory();
        }

        [Test]
        public void Can_Create_Pattern()
        {
            Assert.IsNotNull(_factoryPattern.Create(Title, Description, Template));
        }

        [Test]
        public void Create_Pattern_With_The_Right_Parameters()
        {
            var pattern = _factoryPattern.Create(Title, Description, Template);
            Assert.AreEqual(pattern.Title,Title);
            Assert.AreEqual(pattern.Description, Description);            
            Assert.AreEqual(pattern.Template, Template);
        }
    }
}
