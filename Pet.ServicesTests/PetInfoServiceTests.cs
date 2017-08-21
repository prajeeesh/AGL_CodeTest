using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pet.Services.Interface;
using Pet.ServicesTests;

namespace PetServices.Tests
{
    [TestClass()]
    public class PetInfoServiceTests : PetServiceTestBase
    {
        [TestMethod()]
        public void GetPetListGroupByOwnerGenderTest()
        {
           int recordCount = 0;
            using (var container = builder.Build())
            {
                var petInfoService = container.Resolve<IPetInfoService>();
                var model = petInfoService.GetPetListGroupByOwnerGender();
                model.Wait();
                recordCount = model.Result.Count;
            }
            Assert.IsTrue(recordCount > 0);
        }
    }
}