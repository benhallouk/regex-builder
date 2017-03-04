using AutoMoq;
using Regex.Application.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.Specification.Common
{
    public class AppContext
    {
        public AutoMoqer Mocker;
        public IContainer Container;
        public IDatabaseService DatabaseService;

        public AppContext()
        {
            Mocker = new AutoMoqer();

            var mockDatabase = Mocker.GetMock<IDatabaseService>();

            var intitializer = new DatabaseInitializer(mockDatabase);
            intitializer.Seed();
            DatabaseService = mockDatabase.Object;

            Container = IoC.Initialize(this);

        }
    }
}
