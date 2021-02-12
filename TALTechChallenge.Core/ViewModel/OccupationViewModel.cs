using Newtonsoft.Json;
using TALTechChallenge.Core.Common.Mappings;
using TALTechChallenge.Core.Models.Entities;
namespace TALTechChallenge.Core.ViewModel
{
    public class OccupationViewModel : IMapFrom<Occupations>
    {
        
        [JsonProperty("Occupation")]
        public string Occupation { get; set; }

        
    }
}
