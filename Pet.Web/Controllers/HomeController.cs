using System.Threading.Tasks;
using System.Web.Mvc;
using Pet.Services.Interface;

namespace Pet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetInfoService petInfoService;
        public HomeController(IPetInfoService _petInfoService)
        {
            petInfoService = _petInfoService;
        }

       public async Task<ActionResult> Index()
        {
            var model = await petInfoService.GetPetListGroupByOwnerGender();
            return View("index",
                model
            );
        }
       
    }
}