using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Model.Web
{
    public class OwnerListViewModel
    {
        public string Gender { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
