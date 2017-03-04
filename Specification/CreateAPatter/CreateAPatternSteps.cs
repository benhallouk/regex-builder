using NUnit.Framework;
using Regex.Application.Patterns.Commands.CreatePattern;
using Regex.Application.Patterns.Commands.CreatePattern.Models;
using Regex.Specification.Common;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Regex.Specification.CreateAPatter
{
    [Binding]
    public class CreateAPatternSteps
    {
        private readonly AppContext _context;
        private CreatePatternModel _model;

        public CreateAPatternSteps(AppContext context)
        {
            _context = context;
        }

        [Given(@"The following data:")]
        public void GivenTheFollowingData(Table table)
        {
            var patternInfo = table.CreateInstance<CreateAPatternInfoModel>();
            _model = new CreatePatternModel
            {
                Title = patternInfo.Title,
                Description = patternInfo.Description,
                Template = patternInfo.Template
            };
        }
        
        [When(@"I create a pattern")]
        public void WhenICreateAPattern()
        {
            var command = _context.Container.GetInstance<CreatePatternCommand>();
            command.Execute(_model);
        }
        
        [Then(@"The following data must be recorded:")]
        public void ThenTheFollowingDataMustBeRecorded(Table table)
        {
            var patternRecord = table.CreateInstance<CreateAPatternRecordModel>();

            var database = _context.DatabaseService;
            var record = database.Patterns
                .FirstOrDefault(r=> r.Title == patternRecord.Title 
                && r.Description==patternRecord.Description 
                && r.Template == patternRecord.Template);

            Assert.IsNotNull(record);
        }
    }
}
