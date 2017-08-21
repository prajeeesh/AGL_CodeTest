using System.Collections.Generic;

namespace Pet.Model.Web
{
    public class OwnerListViewModel
    {
        public string Gender { get; set; }
        public List<PetModel> Pets { get; set; }
    }
}
