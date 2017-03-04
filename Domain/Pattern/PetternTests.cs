using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Regex.Domain.Pattern
{
    [TestFixture]
    public class PetternTests
    {
        private readonly Pattern _pattern;
        private const int Id = 1;
        private const string Title = "Test";

        public PetternTests()
        {
            _pattern = new Pattern();
        }

        [Test]
        public void Can_Set_Id()
        {
            _pattern.Id = Id;
            Assert.AreEqual(_pattern.Id, Id);
        }

        [Test]
        public void Can_Set_Title()
        {
            _pattern.Title = Title;
            Assert.AreEqual(_pattern.Title, Title);            
        }

        [Test]
        public void Test_IoC_COntainer()
        {
            var iocContainer = new IoCContainer();
            iocContainer.Register<IList<string>, List<string>>();


            var pattern = iocContainer.Resolve<IList<string>>();

            Assert.IsNotNull(pattern);
        }
    }

    public class IoCContainer
    {
        private Dictionary<Type, Type> dependancyMap = new Dictionary<Type, Type>();
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        internal void Register<TFrom, TTo>()
        {
            dependancyMap.Add(typeof(TFrom), typeof(TTo));
        }

        private object Resolve(Type type)
        {
            Type typeToResolve = null;

            try
            {
                typeToResolve = dependancyMap[type];
            }
            catch
            {
                throw new Exception("IoC container type error: Can not resolve the type "+type.FullName);
            }

            var firstConstructor = typeToResolve.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();

            if (constructorParameters.Count() == 0)
                return Activator.CreateInstance(typeToResolve);

            var parameters = new List<object>();
            foreach (var parameter in constructorParameters)
            {
                parameters.Add(Resolve(parameter.ParameterType));
            }

            return firstConstructor.Invoke(parameters.ToArray());
        }
    }
}
