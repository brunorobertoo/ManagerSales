using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ManagerSalesApi.Client.Response
{
    public class CnpjResponse
    {
        [JsonProperty("razao_social")]
        public string CorporateName { get; set; }

        [JsonProperty("estabelecimento")]
        public EstablishmentResponse Establishment { get; set; }
    }
}
