using System.Threading.Tasks;
using System.Web.Mvc;
using Pet.Services.Interface;
using System;
using Common;

namespace Pet.Web.Controllers
{
    public class PetListController : Controller
    {
        private readonly IPetInfoService petInfoService;
        public PetListController(IPetInfoService _petInfoService)
        {
            petInfoService = _petInfoService;
        }

        public async Task<ActionResult> Cats()
        {
            try
            {
                var model = await petInfoService.GetPetListGroupByOwnerGender(PetTypes.Type.Cat);
                return View(model);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
       
    }
}