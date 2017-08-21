using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Pet.Model;
using Newtonsoft.Json;
using Pet.Model.Web;
using Pet.Services.Interface;
using Common;
using System;

namespace Pet.Services
{
    public class PetInfoService: IPetInfoService
    {
       private string PetListingService { get; set; }
       public PetInfoService()
        {
            PetListingService = Constants.PetListingService;
        }
       
        public async Task<List<OwnerListViewModel>> GetPetListGroupByOwnerGender()
        {
            string uri = Common.ServicesManager.GetClientUri(PetListingService);
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    var data = JsonConvert.DeserializeObject<List<OwnerModel>>(
                        await httpClient.GetStringAsync(uri)
                    );
                    var petList = data.Where(x => x.Pets != null)
                                        .GroupBy(x => x.Gender)
                                        .Select(termGroup =>
                                        new OwnerListViewModel
                                        {
                                            Gender = termGroup.Key,
                                            Pets = termGroup.Where(r => r.Pets.Any(t =>
                                               t.Type == PetTypes.Type.Cat.ToString()))
                                               .SelectMany(gr => gr.Pets).ToList()
                                        }
                                        ).ToList();
                    return petList;
                }
            }
            catch
            {
                throw new Exception("Error occured while accessing the service API"); 
            }
        }
    }
}
