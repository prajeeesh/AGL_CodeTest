using Autofac;
using Pet.Services;
using Pet.Services.Interface;

namespace Pet.ServicesTests
{
    public class PetServiceTestBase
    {
        protected ContainerBuilder builder ;
        public PetServiceTestBase()
        {
            builder = new ContainerBuilder();
            builder.RegisterType<PetInfoService>().As<IPetInfoService>().InstancePerLifetimeScope();
        }
    }
}
