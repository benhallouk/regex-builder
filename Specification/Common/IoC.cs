using StructureMap;

namespace Regex.Specification.Common
{
    public static class IoC
    {
        public static IContainer Initialize(AppContext appContext)
        {
            return new Container(c =>            
            {
                c.Scan(
                    scan => {
                        scan.AssembliesFromApplicationBaseDirectory(filter => filter.FullName.StartsWith("Regex"));

                        scan.WithDefaultConventions();
                });

                c.For<Application.Interfaces.IDatabaseService>().Use(appContext.DatabaseService);
            });
        }
    }    
}
