using System.Collections.Generic;

namespace Pet.Model
{
    public class OwnerModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<PetModel> Pets { get; set; }
    }
}
