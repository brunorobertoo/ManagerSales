using Newtonsoft.Json;

namespace ManagerSalesApi.Client.Response
{
    public class TasMainResponse
    {
        [JsonProperty("descricao")]
        public string Description { get; set; }
    }
}
