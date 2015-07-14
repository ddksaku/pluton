using Mars.Common.UnitOfWork;
using Ninject.Modules;
using pluton.dal.Repository;
using pluton.dal.UnitOfWork;
using pluton.web.Data;

namespace pluton.web.Ioc
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>()
                               .InSingletonScope()
                               .WithConstructorArgument("context", x => new PlutonContext());

            Bind<IQueryTranslater>()
                .To<QueryTranslater>()
                .InSingletonScope();
        }
    }
}