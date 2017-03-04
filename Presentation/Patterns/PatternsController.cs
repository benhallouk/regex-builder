using Regex.Application.Interfaces;
using System.Web.Mvc;

namespace Regex.Presentation.Patterns
{
    public class PatternsController : Controller
    {
        private readonly IDatabaseService _database;

        public PatternsController(IDatabaseService database)
        {
            _database = database;
        }
        public ActionResult Index()
        {            
            return View();
        }
    }
}