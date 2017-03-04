using AutoMoq;
using Moq;
using NUnit.Framework;
using Regex.Application.Interfaces;
using Regex.Application.Patterns.Commands.CreatePattern.Factory;
using Regex.Application.Patterns.Commands.CreatePattern.Models;
using Regex.Common.Mocks;
using Regex.Domain.Pattern;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Regex.Application.Patterns.Commands.CreatePattern
{
    [TestFixture]
    public class CreatePatternCommandTests
    {
        private CreatePatternModel _model;
        private CreatePatternCommand _command;
        private Pattern _pattern;

        private AutoMoqer _mocker;

        [SetUp]
        public void Setup()
        {
            _model = new CreatePatternModel
            {
                Title = "title",
                Description = "description",
                Template = "template"
            };

            _pattern = new Pattern
            {
                Title = "title",
                Description = "description",
                Template = "template"
            };

            _mocker = new AutoMoqer();

            _mocker.GetMock<IDbSet<Pattern>>()
              .SetUpDbSet(new List<Pattern>());

            _mocker.GetMock<IDatabaseService>()
               .Setup(p=>p.Patterns)
               .Returns(_mocker.GetMock<IDbSet<Pattern>>().Object);

            _mocker.GetMock<IPatternFactory>()
            .Setup(p => p.Create(_model.Title, _model.Description, _model.Template))
            .Returns(_pattern);
            

            _command = _mocker.Create<CreatePatternCommand>();
        }

        [Test]
        public void Should_Add_To_Database_When_Execute()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDbSet<Pattern>>()
                    .Verify(p => p.Add(_pattern),Times.Once);
        }
    }
}
