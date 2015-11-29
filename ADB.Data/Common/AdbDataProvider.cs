using FluentNHibernate.Cfg;
using Levshits.Data;
using Levshits.Data.Common;
using NHibernate;
using NHibernate.Cfg;

namespace ADB.Data.Common
{
    public class AdbDataProvider: DataProvider
    {
        public AdbDataProvider(ISessionStorage storage) : base(storage)
        {
        }

        public override ISessionFactory InitFactory()
        {
            var cfg = new Configuration();
            cfg.Configure(); // read config default style
            var factory = Fluently.Configure(cfg)
                .Mappings(
                  m => m.FluentMappings.AddFromAssemblyOf<AdbDataProvider>())
                .BuildSessionFactory();
            return factory;
        }
    }
}