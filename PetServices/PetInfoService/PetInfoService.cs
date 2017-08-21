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
       private string petListingService { get; set; }
       public PetInfoService()
        {
            petListingService = Constants.PetListingService;
        }
        /// <summary>
        /// Access the service endpoints and retrieves the list of pets based on the type passed as the parameter.
        /// </summary>
        /// <param name="petType">Pet Type Enum Refer Common.PetTypes.Type</param>
        /// <returns>List of pets grouped based on the owners gender</returns>
        public async Task<List<OwnerListViewModel>> GetPetListGroupByOwnerGender(Common.PetTypes.Type petType)
        {
            string uri = Common.ServicesManager.GetClientUri(petListingService);
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
                                               t.Type == petType.ToString()))
                                               .SelectMany(gr => gr.Pets)
                                               .ToList()
                                               .OrderBy(p => p.Name)
                                               .ToList()                                              
                                        }
                                        )                                       
                                       .ToList();
                    return petList;
                }
            }
            catch(Exception ex)
            {
                //Log Exception 
                Console.WriteLine(ex.Message);
                throw new Exception("Error occured while accessing the service API");
               
            }
        }
    }
}
