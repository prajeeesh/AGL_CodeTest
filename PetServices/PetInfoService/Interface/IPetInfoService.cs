using System.Collections.Generic;
using System.Threading.Tasks;
using Pet.Model.Web;

namespace Pet.Services.Interface
{
    public interface IPetInfoService
    {
       Task<List<OwnerListViewModel>> GetPetListGroupByOwnerGender();
    }
}
