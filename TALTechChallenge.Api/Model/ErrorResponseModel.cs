using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TALTechChallenge.Api.Model
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string code, string description)
        {
            Code = code;
            Description = description;
        }

        [JsonProperty(nameof(Code))]
        public string Code { get; set; }

        [JsonProperty(nameof(Description))]
        public string Description { get; set; }

        //[JsonProperty(nameof(Url))]
        //public string Url => Constants.ErrorMessage.SupportUrl;
    }
}
