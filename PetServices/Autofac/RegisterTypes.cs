using Autofac;
using Pet.Services.Interface;

namespace Pet.Services.Autofac
{
    public class RegisterTypes
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<PetInfoService>().As<IPetInfoService>().InstancePerLifetimeScope();
        }
    }
}
